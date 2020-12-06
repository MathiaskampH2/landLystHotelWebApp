using System;

namespace landLystHotelWebApp
{
    public class Reservation
    {
        public string CustPhoneNumber { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int DaysToStay { get; set; }

        public decimal TotalPrice { get; set; }

        public Reservation(string custPhoneNumber, int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            this.CustPhoneNumber = custPhoneNumber;
            this.RoomNumber = roomNumber;
            this.CheckInDate = checkInDate;
            this.CheckOutDate = checkOutDate;
        }

        public Reservation(string custPhoneNumber, int roomNumber, DateTime checkInDate, DateTime checkOutDate, int daysToStay, decimal totalPrice)
            : this(custPhoneNumber, roomNumber, checkInDate, checkOutDate)
        {
            this.DaysToStay = daysToStay;
            this.TotalPrice = totalPrice;
        }
    }
}