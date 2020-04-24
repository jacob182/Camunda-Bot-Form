using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace CamundaBotForm
{
        class Activity
        {
            public string id { get; set; }
            public string parentActivityInstanceId { get; set; }
            public string activityId { get; set; }
            public string activityName { get; set; }
            public string activityType { get; set; }
            public string processDefinitionKey { get; set; }
            public string processDefinitionId { get; set; }
            public string processInstanceId { get; set; }
            public string executionId { get; set; }
            public string taskId { get; set; }
            public string calledProcessInstanceId { get; set; }
            public string calledCaseInstanceId { get; set; }
            public string assignee { get; set; }
            public string canceled { get; set; }
            public string completeScope { get; set; }
            public string tenantId { get; set; }
            public string removalTime { get; set; }
            public string rootProcessInstanceId { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
            public int durationInMillis { get; set; }
        }

        public class RestException : Exception
    {
        public RestException()
        {

        }
        public RestException(string message) : base(message)
        {

        }
        public RestException(string message, Exception inner) : base(message, inner)
        {

        }
    }




        class CamundaBot
        {
            // The CamundaBot uses the definition key and ID to tell Camunda which process we are working with.  Each CamundaBot has a HttpClient that it uses to interact with the REST API of Camunda.
            // The defnition key is used to start the process, and the definition ID is used to return the activity data that Camunda stores after starting a process.
            private string definitionKey, definitionID, json;
            private HttpClient client;


            public CamundaBot(string definitionKey, string definitionID, string json)
            {
                this.definitionID = definitionID;
                this.definitionKey = definitionKey;
                this.json = json;
                this.client = new HttpClient();
                this.client.Timeout = TimeSpan.FromMinutes(30);
            }



            public async Task<string> StartProcess()
            // This current version of start process assumes you have Camunda running on the local machine, as it uses the localhost address to cammunicate with the REST API.
            // Start the process of the CamundaBot using the stored definitionId and json
            {
                string url = "http://localhost:8080/engine-rest/process-definition/key/" + this.definitionKey + "/start";

                var data = new StringContent(json, Encoding.UTF8, "application/json");

                

                // Declaring the variables to be used in starting the process
                HttpResponseMessage response = new HttpResponseMessage();
                string result = null;

                // Send the POST message to Camunda to start the process
                try
                {
                    response = await this.client.PostAsync(url, data);
                }
                catch (HttpRequestException ex)
                {
                    //Console.WriteLine("Error while starting process: No connection to the host could be made. Check the URL is correct, or the host is running.\n");
                    throw ex;
                }

                // Retrieve the HTTP response message from Camunda to determine if the process started correctly.
                try
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                catch (NullReferenceException ex)
                {
                    //Console.WriteLine("Error while reading response from Camunda: No response has been received from the host.\n");
                    throw ex;
                }
                Regex regex = new Regex("RestException");
                Match match = regex.Match(result);
                if (match.Success)
                {
                    throw new RestException("No matching Process Definition matching the given key.");
                }
            

                return result;
            }




            public async Task<List<Activity>> GetActivities()
            {
                string url = "http://localhost:8080/engine-rest/history/activity-instance?processDefinitionId=" + this.definitionID;

                

                HttpResponseMessage response = null;

                // Retrieve the activity data from Camunda using a http GET request
                try
                {
                    response = await this.client.GetAsync(url);
                }
                catch (HttpRequestException ex)
                {
                    //Console.WriteLine("Error while retrieving activity data: No connection to the host could be made. Check the URL is correct, or the host is running.\n");
                    throw ex;
                }

                string[] activities = null;
                try
                {
                    activities = Regex.Matches(response.Content.ReadAsStringAsync().Result, @"{[^{}]*}")
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToArray();
                }
                catch (NullReferenceException ex)
                {
                    //Console.WriteLine("Error while retrieving activity data: No data was received from the host.");
                    throw ex;
                }

                

                    List<Activity> activityList = new List<Activity>();

                try
                {
                    foreach (string activity in activities)
                    {
                        activityList.Add(JsonConvert.DeserializeObject<Activity>(activity));
                    }
                }
                catch (NullReferenceException ex) // No activities were retrieved. Create an exception to be handled.
                {
                    //Console.WriteLine("Error while retrieving activity data: No data was received from the host.");
                    throw ex;
                }
                if (activityList.Count() == 0)
                {
                    throw new NullReferenceException();
                }
                
                    return activityList;
                }




        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        class Program
        { 
        [STAThread]
        static void Main(string[] args)
            {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            }
        }
}
