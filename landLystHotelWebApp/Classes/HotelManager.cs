using System;
using System.Collections.Generic;

namespace landLystHotelWebApp
{
    public class HotelManager
    {
        
        public static List<Customer> CreateCustomer(string fName, string lName, int zipCode, string address, string phoneNumber, string email)
        {
            return ServerManager.CreateCustomer(fName, lName, zipCode, address, phoneNumber, email);
        }

        public static List<Reservation> CreateReservation(string custPhoneNumber, int roomNumber, DateTime checkInDate, DateTime CheckOutDate)
        {
            return ServerManager.CreateReservation(custPhoneNumber, roomNumber, checkInDate, CheckOutDate);
        }

        public static List<Room> GetRoomsAvailableBasedOnFeatures(DateTime checkInDate, DateTime checkOutDate, int featureNumber)
        {
            return ServerManager.GetRoomsAvailableBasedOnFeatures(checkInDate, checkOutDate, featureNumber);
        }

        public static List<Features> GetFeaturePrice()
        {
            return ServerManager.GetFeaturePrice();
        }

        public static decimal CalculatePriceWithTenPercentageDiscount(int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            return ServerManager.CalculatePriceWithTenPercentageDiscount(roomNumber, checkInDate, checkOutDate);
        }
    }
}