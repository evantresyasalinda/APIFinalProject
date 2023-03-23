using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpFinalExam.DataModels;

namespace RestSharpFinalExam.TestData
{
    public class RestSharp_GenerateToken
    {
        public static RestSharp_TokenDetailModel credentials()
        {
            return new RestSharp_TokenDetailModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
