using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Sentric_Api.Model
{
    public  class Message
    {
        //private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public Message()
        {
            currentTimeStamp = DateTime.UtcNow.ToString();
            encoded = new EncriptResponse
            {
                data = false
            };
        }
        [JsonProperty(Order = -2)]
        public string currentTimeStamp { get; set; }
        public EncriptResponse encoded { get; set; }
        public string  message { get; set; }
        public int status_code { get; set; }
        public bool status { get; set; }
    }
    public class EncriptResponse
    {
        [JsonProperty(Order = -2)]
        public bool data { get; set; }
    }
    public class EncriptRequest
    {
       public EncriptRequest()
        {
            encoded_data = "no";
        }
        public string encoded_data { get; set; }
    }
}
