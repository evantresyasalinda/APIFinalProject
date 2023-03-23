using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpClientFinalExam.DataModels;

namespace HttpClientFinalExam.TestData
{
    class GenerateBookingData
    {
        public static BookingDetailModel bookingDetails()
        {
            DateTime dt = DateTime.UtcNow.Date;

            Bookingdates bookingDates = new Bookingdates();
            bookingDates.Checkin = dt;
            bookingDates.Checkout = dt.AddDays(1);

            return new BookingDetailModel
            {
                FirstName = "Evan Tresya",
                LastName = "Manuel",
                TotalPrice = 1031,
                DepositPaid = true,
                BookingDates = bookingDates,
                AdditionalNeeds = "Breakfast"
            };
        }
    }
}
