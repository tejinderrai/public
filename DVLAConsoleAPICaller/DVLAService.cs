using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DVLAConsoleAPICaller
{
    public class DVLAService
    {

        public static string CreateRequestBody(string RegistrationNumber)
        {
            DVLARequestBody request = new DVLARequestBody { registrationNumber = RegistrationNumber };
            string RequestBodyValue = JsonConvert.SerializeObject(request);
            return RequestBodyValue;
        }
    }
}
