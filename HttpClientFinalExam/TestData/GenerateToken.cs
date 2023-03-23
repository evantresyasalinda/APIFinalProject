using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpClientFinalExam.DataModels;

namespace HttpClientFinalExam.TestData
{
    class GenerateToken
    {
        public static TokenDetailModel Logincredentials()
        {
            return new TokenDetailModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
