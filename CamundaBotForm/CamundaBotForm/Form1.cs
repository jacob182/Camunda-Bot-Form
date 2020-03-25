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
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using CsvHelper;
using System.Globalization;

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


            // * Setting the file name and file path for the purpose of saving the returned activities into a csv file *

            // Where do you want to save the file?
            string fileName = FileNameTxtBox.Text;  // the name of the file to be saved.

            string filePath = FilePathLbl.Text; // This is where the file will be saved.

            filePath = filePath + @"\" + fileName + ".csv"; // Joining them together for use.
            

            // ******* These parameters need to be configured correctly before running the bot *******

            // Building the CamundaBot using the parameters above.
            CamundaBot sequenceBot = new CamundaBot(definitionKey, definitionID, json);
            

            // Starting the process the required amount of times
            try
            {
                if (startProcess)
                {
                    for (int i = 0; i < timesStarted; i++)
                    {
                        await sequenceBot.StartProcess();
                    }
                }
            }
            catch (HttpRequestException) // There was a problem connecting with the host.
            {
                string message = "No connection to the host could be made. Check the URL is correct, or the host is running.";
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (NullReferenceException) // There was no response from the host after connection was made.
            {
                string message = "No connection to the host could be made. Check the URL is correct, or the host is running.";
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch(RestException)
            {
                string message = "No matching Process Definition matching key: " + definitionKey;
                string caption = "Error While Starting Process";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // Create a list of the Activities from Camunda using the GetActivities function
            List<Activity> activities = null;
            try
            {
                activities = await sequenceBot.GetActivities();
            }
            catch (HttpRequestException) // There was a problem connecting with the host.
            {
                string message = "No connection to the host could be made. Check the URL is correct, or the host is running.";
                string caption = "Error While Retrieving Activity Data";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (NullReferenceException) // There was no response from the host after connection was made.
            {
                string message = "No data was received from the host. Check the Definition ID and Key are correct, or that the process has been started.";
                string caption = "Error While Retrieving Activity Data";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                csv.WriteRecords(activities);
                            }
                            catch (CsvHelper.WriterException)
                            {
                                string message = "No data was received from the host";
                                string caption = "Error Saving Data";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }
                    catch (ObjectDisposedException)
                    {
                        string message = "There was an issue while creating the file.";
                        string caption = "Error Saving Data";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
            }
            catch (IOException)
            {
                string message = "The file path is incorrect or the file is still in use.";
                string caption = "Error Saving Data";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Displays success label
            SuccessLbl.Visible = true;
        }

        private void TimesTxtBox_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
