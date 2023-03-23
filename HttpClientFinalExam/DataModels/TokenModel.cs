using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientFinalExam.DataModels
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
