using System.Net;
using RestSharpFinalExam.DataModels;
using RestSharpFinalExam.Helpers;
using RestSharpFinalExam.TestData;

namespace RestSharpFinalExam.TestData
{
    [TestClass]
    public class RestSharpTests : APIBaseTest
    {
        [TestInitialize]
        public async Task TestInitialize()
        {
            //Create Data
            var restResponse = await RestSharp_BookingHelper.CreateBooking(RestClient);
            BookingDetails = restResponse.Data;


            //Assertion
            Assert.AreEqual(restResponse.StatusCode, HttpStatusCode.OK);

        }

        [TestMethod]
        public async Task CreateBooking()
        {
            //Create Data
            var getBookingResponse = await RestSharp_BookingHelper.GetBook(RestClient, BookingDetails.BookingId);


            //ASsertion
            var expectedBookingDetails = RestSharpFinalExam.TestData.RestSharp_GenerateBookingData.bookingDetails();
            Assert.AreEqual(expectedBookingDetails.Firstname, getBookingResponse.Data.Firstname, "Firstname doesn't Match .");
            Assert.AreEqual(expectedBookingDetails.Lastname, getBookingResponse.Data.Lastname, "Lastname doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Totalprice, getBookingResponse.Data.Totalprice, "Totalprice doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Depositpaid, getBookingResponse.Data.Depositpaid, "Deposi tpaid doesn't match.");
            Assert.AreEqual(expectedBookingDetails.Bookingdates.Checkin, getBookingResponse.Data.Bookingdates.Checkin, "Checkin dates doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Bookingdates.Checkout, getBookingResponse.Data.Bookingdates.Checkout, "Checkout dates doesn't  match.");
            Assert.AreEqual(expectedBookingDetails.Additionalneeds, getBookingResponse.Data.Additionalneeds, "Additional needs doesn't  match.");


            //Clean Up
            await RestSharp_BookingHelper.DeleteBooking(RestClient, BookingDetails.BookingId);

        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            //Create Data
            var getBookingResponse = await RestSharp_BookingHelper.GetBook(RestClient, BookingDetails.BookingId);


            //Update Data 
            var updateBookingDetails = new RestSharp_BookingDetailModel()
            {
                Firstname = "SampleFNameUpdated",
                Lastname = "SampleLNameUpdated",
                Totalprice = getBookingResponse.Data.Totalprice,
                Depositpaid = getBookingResponse.Data.Depositpaid,
                Bookingdates = getBookingResponse.Data.Bookingdates,
                Additionalneeds = getBookingResponse.Data.Additionalneeds
            };
            var updateBooking = await RestSharp_BookingHelper.UpdateBooking(RestClient, updateBookingDetails, BookingDetails.BookingId);

            //Assertion
            Assert.AreEqual(updateBooking.StatusCode, HttpStatusCode.OK);


            //Get Updated Data 
            var getUpdatedBookingResponse = await RestSharp_BookingHelper.GetBook(RestClient, BookingDetails.BookingId);


            //Assertion
            Assert.AreEqual(updateBookingDetails.Firstname, getUpdatedBookingResponse.Data.Firstname, "Firstname doesn't  match.");
            Assert.AreEqual(updateBookingDetails.Lastname, getUpdatedBookingResponse.Data.Lastname, "Lastname doesn't  match.");
            Assert.AreEqual(updateBookingDetails.Totalprice, getUpdatedBookingResponse.Data.Totalprice, "Totalprice doesn't match.");
            Assert.AreEqual(updateBookingDetails.Depositpaid, getUpdatedBookingResponse.Data.Depositpaid, "Depositpaid doesn't match.");
            Assert.AreEqual(updateBookingDetails.Bookingdates.Checkin, getUpdatedBookingResponse.Data.Bookingdates.Checkin, "Checkin dates doesn't  match.");
            Assert.AreEqual(updateBookingDetails.Bookingdates.Checkout, getUpdatedBookingResponse.Data.Bookingdates.Checkout, "Checkout dates doesn't t match.");
            Assert.AreEqual(updateBookingDetails.Additionalneeds, getUpdatedBookingResponse.Data.Additionalneeds, "Additional needs doesn't  match.");

            //Clean Up
            await RestSharp_BookingHelper.DeleteBooking(RestClient, BookingDetails.BookingId);

        }

        [TestMethod]
        public async Task DeleteBooking()
        {
            //Delete Data
            var deleteBooking = await RestSharp_BookingHelper.DeleteBooking(RestClient, BookingDetails.BookingId);


            //Assertion
            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created);

        }

        [TestMethod]
        public async Task ValidateInvalidBooking()
        {
            //Create Data
            var getCreatedBooking = await RestSharp_BookingHelper.GetBook(RestClient, 123456789);


            //Assertion
            Assert.AreEqual(getCreatedBooking.StatusCode, HttpStatusCode.NotFound);


            //Clean up
            await RestSharp_BookingHelper.DeleteBooking(RestClient, BookingDetails.BookingId);

        }
    }
}