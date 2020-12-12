using System;

namespace landLystHotelWebApp
{
    /// <summary>
    /// class Reservation
    /// Is used to create an object of Reservation
    /// </summary>
    public class Reservation
    {
        public string CustPhoneNumber { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int DaysToStay { get; set; }

        public decimal TotalPrice { get; set; }

    }
}