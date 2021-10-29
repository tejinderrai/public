
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DVLAConsoleAPICaller
{
    class Program
    {

        public static string APIKey = "[Your API Key]";
        public static string APIEndpoint = "https://driver-vehicle-licensing.api.gov.uk/vehicle-enquiry/v1/vehicles";

        static void Main(string[] args)
        {
            DVLAVehicle vehicleDetails = CallDVLAVehicleAPI("TE57VRN");

            Console.WriteLine("Vehicle Result:");
            Console.WriteLine("Colour: " + vehicleDetails.colour?.ToString());
            Console.WriteLine("Registration Number: " + vehicleDetails.registrationNumber?.ToString());
            Console.WriteLine("CO2 Emmisions: " + vehicleDetails.co2Emissions);
            Console.WriteLine("Date of last V5 Issued: " + CheckValue(vehicleDetails.dateOfLastV5CIssued));
            Console.WriteLine("Engine Capacity: " + vehicleDetails.engineCapacity.ToString());
            Console.WriteLine("Euro Status: " + vehicleDetails.euroStatus?.ToString());
            Console.WriteLine("Fuel Type: " + vehicleDetails.fuelType?.ToString());
            Console.WriteLine("Make: " + vehicleDetails.make?.ToString());
            Console.WriteLine("Year of Manufacture: " + CheckValue(vehicleDetails.yearOfManufacture.ToString()));
            Console.WriteLine("Tax due date: " + CheckValue(vehicleDetails.taxDueDate));
            Console.WriteLine("Tax Status: " + CheckValue(vehicleDetails.taxStatus));
            Console.WriteLine("Revenue Weight: " + vehicleDetails.revenueWeight.ToString());
            Console.WriteLine("MOT Status: " + CheckValue(vehicleDetails.motStatus));
            Console.WriteLine("Year-Month of first registration: " + CheckValue(vehicleDetails.monthOfFirstRegistration));
            Console.WriteLine("Marked for export: " + CheckValue(vehicleDetails.markedForExport.ToString()));
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static string CheckValue(string Value)
        {
            string value = "NULL";

            if (Value != null) {

                value = Value;
            }

            return value;
        }

        public static DVLAVehicle CallDVLAVehicleAPI(string RegistrationNumber)
        {

            DVLAVehicle result = new DVLAVehicle();

            if (RegistrationNumber.Length > 0)
            {

                using (HttpClient client = new HttpClient())
                {

                    string requestBody = DVLAService.CreateRequestBody(RegistrationNumber);

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("x-api-key", APIKey);
                    StringContent content = new StringContent(requestBody, System.Text.Encoding.UTF8);
                    var APIRequest = client.PostAsync(APIEndpoint, content).Result;
                    string DVLAResponse = APIRequest.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<DVLAVehicle>(DVLAResponse);

                }
             }

            return result;
        }
    }
}
