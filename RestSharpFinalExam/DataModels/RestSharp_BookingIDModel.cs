using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestSharpFinalExam.DataModels
{
    public class RestSharp_BookingIDModel
    {
        [JsonProperty("bookingid")]
        public int BookingId { get; set; }

        [JsonProperty("booking")]
        public RestSharp_BookingDetailModel Booking { get; set; }
    }
}
