using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Windows;

namespace CamundaBotForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == DialogResult.OK)
                FilePathLbl.Text = (fbd.SelectedPath);
        }

        private void DefinitionIDTxtBox_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefinitionIDTxtBox.Text))
            {
                DefinitionIDTxtBox.SelectionStart = 0;
                DefinitionIDTxtBox.SelectionLength = DefinitionIDTxtBox.Text.Length;
            }
        }

        private void DefinitionIDTxtBox_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefinitionIDTxtBox.Text))
            {
                DefinitionIDTxtBox.SelectionStart = 0;
                DefinitionIDTxtBox.SelectionLength = DefinitionIDTxtBox.Text.Length;
            }

        }

        private void DefinitionKeyTxtBox_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefinitionKeyTxtBox.Text))
            {
                DefinitionKeyTxtBox.SelectionStart = 0;
                DefinitionKeyTxtBox.SelectionLength = DefinitionKeyTxtBox.Text.Length;
            }
        }

        private void DefinitionKeyTxtBox_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefinitionKeyTxtBox.Text))
            {
                DefinitionKeyTxtBox.SelectionStart = 0;
                DefinitionKeyTxtBox.SelectionLength = DefinitionKeyTxtBox.Text.Length;
            }

        }

        private void TimesTxtBox_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TimesTxtBox.Text))
            {
                TimesTxtBox.Select(0, 100);
            }
        }

        private void TimesTxtBox_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TimesTxtBox.Text))
            {
                TimesTxtBox.Select(0, 100);
            }
        }

        private void DelayInterval_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DelayInterval.Text))
            {
                DelayInterval.Select(0, 100);
            }
        }

        private void DelayInterval_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DelayInterval.Text))
            {
                DelayInterval.Select(0, 100);
            }
        }


        [STAThread]
        private async void RunProgramBtn_Click(object sender, EventArgs e)
        {
            // * The definition key and ID are required for the CamundaBot to know which process to work with. *

            // The definition key of the process.
            string definitionKey = DefinitionKeyTxtBox.Text;

            // The definition ID for your deployment of the process in Camunda.
            string definitionID = DefinitionIDTxtBox.Text;

            // The JSON object containing the required variables (Leave blank if none are required)
            string json = JSONTxtBox.Text;

            // Do you want to start the process again? (true/false)
            bool startProcess = StartProcessCheckBox.Checked;
            // if so, how many times?
            int timesStarted = Convert.ToInt32(Math.Round(TimesTxtBox.Value, 0));
            int delayMs;
            try
            {
                int inputNumber = Convert.ToInt32(Math.Round(DelayInterval.Value, 0));
                if (inputNumber < 0)
                {
                    string message = "Delay interval must be a valid number (in milliseconds).";
                    string caption = "Error While Starting Process";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    delayMs = inputNumber;
                }
            }
            catch (FormatException)
            {
                string message = "Delay interval must be a valid number (in milliseconds).";
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // * Setting the file name and file path for the purpose of saving the returned activities into a csv file *

            // Where do you want to save the file?
            string fileName = FileNameTxtBox.Text;  // the name of the file to be saved.

            string filePath = FilePathLbl.Text; // This is where the file will be saved.

            filePath = filePath + @"\" + fileName + ".csv"; // Joining them together for use.
            

            // ******* These parameters need to be configured correctly before running the bot *******

            // Building the CamundaBot using the parameters above.
            CamundaBot sequenceBot = new CamundaBot(definitionKey, definitionID, json);
            List<string> responseList = new List<string>();

            // Starting the process the required amount of times
            try
            {
                if (startProcess)
                {
                    ProgressLbl.Visible = true;
                    for (int i = 0; i < timesStarted; i++)
                    {
                        ProgressLbl.Text = "Starting Process: " + (i + 1);
                        ProgressLbl.Refresh();
                        await sequenceBot.StartProcess();
                        Thread.Sleep(delayMs);
                    }
                }
            }
            catch (HttpRequestException) // There was a problem connecting with the host.
            {
                string message = "No connection to the host could be made. Check the URL is correct, or the host is running.";
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressLbl.Text = "Test Failed...";
                ProgressLbl.Refresh();
                return;
            }
            catch (NullReferenceException) // There was no response from the host after connection was made.
            {
                string message = "No connection to the host could be made. Check the URL is correct, or the host is running.";
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressLbl.Text = "Test Failed...";
                ProgressLbl.Refresh();
                return;
            }
            catch(RestException)
            {
                string message = "No matching Process Definition matching key: " + definitionKey;
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressLbl.Text = "Test Failed...";
                ProgressLbl.Refresh();
                return;
            }



            // Create a list of the Activities from Camunda using the GetActivities function
            List<Activity> activities = null;
            try
            {
                ProgressLbl.Text = "Retrieving Activity Data";
                ProgressLbl.Refresh();
                activities = await sequenceBot.GetActivities();
            }
            catch (HttpRequestException) // There was a problem connecting with the host.
            {
                string message = "No connection to the host could be made. Check the URL is correct, or the host is running.";
                string caption = "Error While Retrieving Activity Data";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressLbl.Text = "Test Failed...";
                ProgressLbl.Refresh();
                return;
            }
            catch (NullReferenceException) // There was no response from the host after connection was made.
            {
                string message = "No data was received from the host. Check the Definition ID and Key are correct, or that the process has been started.";
                string caption = "Error While Retrieving Activity Data";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressLbl.Text = "Test Failed...";
                ProgressLbl.Refresh();
                return;
            }


            // Store the list of activities as a csv file.
            StreamWriter writer;
            CsvWriter csv;
            try
            {
                using (writer = new StreamWriter(filePath))

                    try
                    {
                        using (csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            try
                            {
                                ProgressLbl.Text = "Saving Activity Data";
                                csv.WriteRecords(activities);
                            }
                            catch (CsvHelper.WriterException)
                            {
                                string message = "No data was received from the host";
                                string caption = "Error Saving Data";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ProgressLbl.Text = "Test Failed...";
                                ProgressLbl.Refresh();
                                return;
                            }

                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        string message = "There was an issue while creating the file.";
                        string caption = "Error Saving Data";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProgressLbl.Text = "Test Failed...";
                        ProgressLbl.Refresh();
                        return;
                    }
            }
            catch (IOException)
            {
                string message = "The file path is incorrect or the file is still in use.";
                string caption = "Error Saving Data";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgressLbl.Text = "Test Failed...";
                ProgressLbl.Refresh();
                return;
            }

            // Hides progress label and displays success label
            ProgressLbl.Visible = false;
            SuccessLbl.Visible = true;
        }

        private void TimesTxtBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void JSONCbox_CheckedChanged(object sender, EventArgs e)
        {
            if (JSONLbl.Enabled == false)
            {
                JSONLbl.Enabled = true;
                JSONTxtBox.Enabled = true;
            }
            else
            {
                JSONLbl.Enabled = false;
                JSONTxtBox.Enabled = false;
            }
        }

        private void DefinitionIDTxtBox_GotMouseCapture(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DefinitionIDTxtBox.Text))
            {
                DefinitionIDTxtBox.SelectionStart = 0;
                DefinitionIDTxtBox.SelectionLength = DefinitionIDTxtBox.Text.Length;
            }
        }


    }
}
