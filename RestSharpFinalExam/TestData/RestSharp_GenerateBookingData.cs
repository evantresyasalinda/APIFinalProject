using RestSharpFinalExam.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpFinalExam.TestData{ 
     class RestSharp_GenerateBookingData
    {
        public static RestSharp_BookingDetailModel bookingDetails()
        {
            DateTime dt = DateTime.UtcNow.Date;

            Bookingdates bookingDates = new Bookingdates();
            bookingDates.Checkin = dt;
            bookingDates.Checkout = dt.AddDays(2);

            return new RestSharp_BookingDetailModel
            {
                Firstname = "SampleFName",
                Lastname = "SampleLName",
                Totalprice = 500,
                Depositpaid = true,
                Bookingdates = bookingDates,
                Additionalneeds = "Nothing"
            };
        }
    }
}
