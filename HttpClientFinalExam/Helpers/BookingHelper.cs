using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HttpClientFinalExam.DataModels;
using HttpClientFinalExam.TestData;
using Newtonsoft.Json;
using HttpClientFinalExam.Resource;

namespace HttpClientFinalExam.Helpers
{
    class BookingHelper
    {
        private HttpClient httpClient;


        private async Task<string> GetToken()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(GenerateToken.Logincredentials());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");


            var httpResponse = await httpClient.PostAsync(Endpoints.GetURL(Endpoints.AuthEndpoint), postRequest);

            var token = JsonConvert.DeserializeObject<TokenModel>(httpResponse.Content.ReadAsStringAsync().Result);

            return token.Token;
        }
        public async Task<HttpResponseMessage> CreateBooking()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var request = JsonConvert.SerializeObject(GenerateBookingData.bookingDetails());
            var postRequest = new StringContent(request, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(Endpoints.GetURL(Endpoints.UserEndpoint), postRequest);
        }

        public async Task<HttpResponseMessage> GetBooking(int bookingId)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return await httpClient.GetAsync(Endpoints.GetUri(Endpoints.UserEndpoint) + "/" + bookingId);
        }

        public async Task<HttpResponseMessage> DeleteBooking(int bookingId)
        {
            var token = await GetToken();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);
            return await httpClient.DeleteAsync(Endpoints.GetUri(Endpoints.UserEndpoint) + "/" + bookingId);
        }

        public async Task<HttpResponseMessage> UpdateBooking(BookingDetailModel booking, int bookingId)
        {
            var token = await GetToken();
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Cookie", "token=" + token);

            var request = JsonConvert.SerializeObject(booking);
            var putRequest = new StringContent(request, Encoding.UTF8, "application/json");
            return await httpClient.PutAsync(Endpoints.GetURL(Endpoints.UserEndpoint + "/" + bookingId), putRequest);
        }
    }
}
