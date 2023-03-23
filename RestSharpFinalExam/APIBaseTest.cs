using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharpFinalExam.DataModels;

namespace RestSharpFinalExam.TestData
{
    public class APIBaseTest
    {
        public RestClient RestClient { get; set; }

        public RestSharp_BookingIDModel BookingDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }
    }
}
