using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventHubRESTAPICaller
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Starting Event Hub REST Client");

            string eventData = "Message sent via REST API";
            StringContent httpContent = new StringContent(eventData, Encoding.UTF8, "text/plain");
            string eventHubHostName = "[Event Hub Host].servicebus.windows.net";
            string eventHubName = "[Event Hub Name]";
            string SASKey = "[Shared Access Signature]";
            string eventHubURI = "https://" + eventHubHostName + "/" + eventHubName + "/messages";

            string result;

            try
            {

                Console.WriteLine("Posting data");
                result = await PostAsyncEventHubStringContentDataWithSharedAccessSignatureAuthentication(eventHubURI, SASKey, httpContent);

            }
            catch (Exception e)
            {
                result = e.Message;

            }

            Console.WriteLine("Response: {0}", result);
            Console.WriteLine("Stopping Event Hub REST Client");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        public static async Task<string> PostAsyncEventHubStringContentDataWithSharedAccessSignatureAuthentication(String EventHubURI, String EventHubSharedAccessSignature, StringContent EventData)
        {

            string result;

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(EventHubURI);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SharedAccessSignature", EventHubSharedAccessSignature);
                var response = await httpClient.PostAsync(new Uri(EventHubURI), EventData);
                response.EnsureSuccessStatusCode();
                result = response.StatusCode.ToString();
            }

            return result;
        }
    }
}
