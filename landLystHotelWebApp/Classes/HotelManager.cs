using System;
using System.Collections.Generic;

namespace landLystHotelWebApp
{
    /// <summary>
    /// hotel manager class.
    /// is used to get create connection between website and backend server
    /// </summary>
    public class HotelManager
    {
        // create customer
        public static List<Customer> CreateCustomer(string fName, string lName, int zipCode, string address, string phoneNumber, string email)
        {
            return ServerManager.CreateCustomer(fName, lName, zipCode, address, phoneNumber, email);
        }

        // create reservation
        public static List<Reservation> CreateReservation(string custPhoneNumber, int roomNumber, DateTime checkInDate, DateTime CheckOutDate)
        {
            return ServerManager.CreateReservation(custPhoneNumber, roomNumber, checkInDate, CheckOutDate);
        }

        // returns a list of rooms Available based on features chosen, check in date and check out date
        public static List<Room> GetRoomsAvailableBasedOnFeatures(DateTime checkInDate, DateTime checkOutDate, int featureNumber)
        {
            return ServerManager.GetRoomsAvailableBasedOnFeatures(checkInDate, checkOutDate, featureNumber);
        }

        // returns a list of features and their prices
        public static List<Features> GetFeaturePrice()
        {
            return ServerManager.GetFeaturePrice();
        }

        // returns the total stay cost if the stay is > 7 days it will subtract 10%
        public static decimal CalculatePriceWithTenPercentageDiscount(int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            return ServerManager.CalculatePriceWithTenPercentageDiscount(roomNumber, checkInDate, checkOutDate);
        }
    }
}