using HttpClientFinalExam.DataModels;
using System.Net;
using HttpClientFinalExam.Helpers;
using Newtonsoft.Json;
using HttpClientFinalExam.TestData;

namespace HttpClientFinalExam
{
    [TestClass]
    public class HttpClientFinalTest
    {
        private BookingHelper bookingHelper;

        [TestMethod]
        public async Task CreateBooking()
        {
            bookingHelper = new BookingHelper();

            //Create Data
            var addBooking = await bookingHelper.CreateBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingIdModel>(addBooking.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);


            //Retrieve and Deserialize data
            var getBooking = await bookingHelper.GetBooking(getResponse.BookingId);
            var getBookingResponse = JsonConvert.DeserializeObject<BookingDetailModel>(getBooking.Content.ReadAsStringAsync().Result);


            //Assertion
            var expectedBookingDetails = GenerateBookingData.bookingDetails();
            Assert.AreEqual(expectedBookingDetails.FirstName, getBookingResponse.FirstName, "First=name doesn't match.");
            Assert.AreEqual(expectedBookingDetails.LastName, getBookingResponse.LastName, "Lastname doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.TotalPrice, getBookingResponse.TotalPrice, "Totalorice doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.DepositPaid, getBookingResponse.DepositPaid, "Depositpaid doesn't match.");
            Assert.AreEqual(expectedBookingDetails.BookingDates.Checkin, getBookingResponse.BookingDates.Checkin, "Checkin dates doesn't match.");
            Assert.AreEqual(expectedBookingDetails.BookingDates.Checkout, getBookingResponse.BookingDates.Checkout, "Checkout dates doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.AdditionalNeeds, getBookingResponse.AdditionalNeeds, "Additional needs doesn't  match.");



        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            bookingHelper = new BookingHelper();

            //Create Data 
            var addBooking = await bookingHelper.CreateBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingIdModel>(addBooking.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);

            //Retrieve and Deserialize data
            var getBooking = await bookingHelper.GetBooking(getResponse.BookingId);
            var getBookingResponse = JsonConvert.DeserializeObject<BookingDetailModel>(getBooking.Content.ReadAsStringAsync().Result);


            //Update Data 
            var updateBookingDetails = new BookingDetailModel()
            {
                FirstName = "Evan Tresya",
                LastName = "Manuel_Updated",
                TotalPrice = getBookingResponse.TotalPrice,
                DepositPaid = getBookingResponse.DepositPaid,
                BookingDates = getBookingResponse.BookingDates,
                AdditionalNeeds = getBookingResponse.AdditionalNeeds
            };
            var updateBooking = await bookingHelper.UpdateBooking(updateBookingDetails, getResponse.BookingId);
            var getUpdatedResponse = JsonConvert.DeserializeObject<BookingDetailModel>(updateBooking.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(updateBooking.StatusCode, HttpStatusCode.OK);


            //Retrieve updated and Deserialize data
            var getUpdatedBooking = await bookingHelper.GetBooking(getResponse.BookingId);
            var getUpdatedBookingResponse = JsonConvert.DeserializeObject<BookingDetailModel>(getUpdatedBooking.Content.ReadAsStringAsync().Result);


            // Assertion
            Assert.AreEqual(updateBookingDetails.FirstName, getUpdatedBookingResponse.FirstName, "First name did not match.");
            Assert.AreEqual(updateBookingDetails.LastName, getUpdatedBookingResponse.LastName, "Last name did not match.");
            Assert.AreEqual(updateBookingDetails.TotalPrice, getUpdatedBookingResponse.TotalPrice, "Total price did not match.");
            Assert.AreEqual(updateBookingDetails.DepositPaid, getUpdatedBookingResponse.DepositPaid, "Deposit paid did not match.");
            Assert.AreEqual(updateBookingDetails.BookingDates.Checkin, getUpdatedBookingResponse.BookingDates.Checkin, "Checkin dates did not match.");
            Assert.AreEqual(updateBookingDetails.BookingDates.Checkout, getUpdatedBookingResponse.BookingDates.Checkout, "Checkout dates did not match.");
            Assert.AreEqual(updateBookingDetails.AdditionalNeeds, getUpdatedBookingResponse.AdditionalNeeds, "Additional needs did not match.");




        }

        [TestMethod]
        public async Task DeleteBooking()
        {
            bookingHelper = new BookingHelper();

            //Create Data
            var addBooking = await bookingHelper.CreateBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingIdModel>(addBooking.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);


            //Retrieve and Deserialize data
            var getBooking = await bookingHelper.GetBooking(getResponse.BookingId);
            var getBookingResponse = JsonConvert.DeserializeObject<BookingDetailModel>(getBooking.Content.ReadAsStringAsync().Result);


            //Delete Data 
            var deleteBooking = await bookingHelper.DeleteBooking(getResponse.BookingId);


            //Assertion
            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created);

        }

        [TestMethod]
        public async Task ValidateBookingId()
        {
            bookingHelper = new BookingHelper();

            //Get Data
            var getCreatedBooking = await bookingHelper.GetBooking(123456789);


            //ASsertion
            Assert.AreEqual(getCreatedBooking.StatusCode, HttpStatusCode.NotFound);

        }
    }
}