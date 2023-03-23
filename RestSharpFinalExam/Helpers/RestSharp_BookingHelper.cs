using RestSharp;
using RestSharpFinalExam.Resource;
using RestSharpFinalExam.DataModels;
using RestSharpFinalExam.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace RestSharpFinalExam.Helpers
{
    public class RestSharp_BookingHelper
    {
        public static async Task<RestResponse<RestSharp_BookingIDModel>> CreateBooking(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoint.BaseBookingMethod).AddJsonBody(RestSharp_GenerateBookingData.bookingDetails());

            return await restClient.ExecutePostAsync<RestSharp_BookingIDModel>(postRequest);

        }

        public static async Task<RestResponse<RestSharp_BookingDetailModel>> GetBook(RestClient restClient, int bookingId)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var getRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId));

            return await restClient.ExecuteGetAsync<RestSharp_BookingDetailModel>(getRequest);
        }

        public static async Task<RestResponse> DeleteBooking(RestClient restClient, int bookingId)
        {
            var token = await GetToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var getRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId));

            return await restClient.DeleteAsync(getRequest);
        }

        public static async Task<RestResponse<RestSharp_BookingDetailModel>> UpdateBooking(RestClient restClient, RestSharp_BookingDetailModel booking, int bookingId)
        {
            var token = await GetToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var putRequest = new RestRequest(Endpoint.MethodByBookingById(bookingId)).AddJsonBody(booking);

            return await restClient.ExecutePutAsync<RestSharp_BookingDetailModel>(putRequest);
        }

        private static async Task<string> GetToken(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoint.GenerateToken).AddJsonBody(RestSharp_GenerateToken.credentials());

            var generateToken = await restClient.ExecutePostAsync<RestSharp_TokenModel>(postRequest);

            return generateToken.Data.Token;
        }
    }
}
