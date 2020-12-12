using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Dapper;
using Microsoft.Ajax.Utilities;

namespace landLystHotelWebApp
{
    /// <summary>
    /// Class ServerManager
    /// handles all methods and connections to the database
    /// </summary>
    public class ServerManager
    {
        // private variable of Con that all my methods can use
        private static readonly string Con = DbConnection.Connection();

        // private variable of sqlDataReader that all my methods can use
        private static SqlDataReader rdr = null;

        // method Features returns a list of all features with their description and price
        public static List<Features> GetFeaturePrice()
        {
            List<Features> features = new List<Features>();

            using (SqlConnection connection = new SqlConnection(Con))
            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("select * from features", connection);

                    rdr = sql.ExecuteReader();

                    while (rdr.Read())
                    {
                        string featureDescription = (string)rdr["description"];
                        decimal featurePrice = (decimal)rdr["price"];

                        Features feature = new Features() { featureDescription = featureDescription, FeaturePrice = featurePrice };

                        features.Add(feature);
                    }

                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }

                return features;
            }
        }

        /// <summary>
        /// CreateCustomer
        /// Calls a stored procedure called sp_insertCustomer that inserts the customer into customer table
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="zipCode"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <returns>customers</returns>
        public static List<Customer> CreateCustomer(string fName, string lName, int zipCode, string address,
            string phoneNumber, string email)
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_insertCustomer", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@fName", fName));
                    sql.Parameters.Add(new SqlParameter("@lName", lName));
                    sql.Parameters.Add(new SqlParameter("@zipcode", zipCode));
                    sql.Parameters.Add(new SqlParameter("@address", address));
                    sql.Parameters.Add(new SqlParameter("@phoneNumber", phoneNumber));
                    sql.Parameters.Add(new SqlParameter("@email", email));

                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        string custFName = (string) rdr["fName"];
                        string custLName = (string) rdr["lName"];
                        int custZipcode = (int) rdr["zipCode"];
                        string custAddress = (string) rdr["address"];
                        string custPhoneNumber = (string) rdr["PhoneNumber"];
                        string custEmail = (string) rdr["email"];

                        Customer customer = new Customer(){FName = custFName, LName = custLName, ZipCode = custZipcode, Address = custAddress, PhoneNumber = custPhoneNumber, Email = custEmail};
                        customers.Add(customer);
                    }
                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return customers;
        }
        /// <summary>
        /// ConvertTotalPriceToDecimal
        /// takes the totalPrice from a list and converts it to a decimal value
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns>price</returns>
        public static decimal ConvertTotalPriceToDecimal(int roomNumber)
        {
            List<TotalPrices> prices = TotalPrice(roomNumber);

            decimal price = Convert.ToDecimal(prices[0].TotalPrice.ToString());
            return price;
        }

        /// <summary>
        /// CalculatePriceWithTenPercentageDiscount
        /// takes its parameters and checks if the difference between CheckInDate and CheckOutDate is >=7
        /// then it will subtract 10% of the total cost price
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <returns>roomPrice</returns>
        public static decimal CalculatePriceWithTenPercentageDiscount(int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            int daysToStay = (checkOutDate - checkInDate).Days;
            decimal totalRoomPrice = ConvertTotalPriceToDecimal(roomNumber) * daysToStay;

            decimal roomPrice = 0;

            if (daysToStay >= 7)
            {
                
                decimal price = (totalRoomPrice / 100) * 10;
                roomPrice = totalRoomPrice - price;
            }

            else
            {
                roomPrice = totalRoomPrice;
            }

            return roomPrice;
        }

        /// <summary>
        /// CreateReservation
        /// Calls a stored procedure called sp_insertReservation that inserts the Reservation into Reservation table
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="roomNumber"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkoutDate"></param>
        /// <returns>reservations</returns>
        public static List<Reservation> CreateReservation(string phoneNumber, int roomNumber, DateTime checkInDate, DateTime checkoutDate)
        {
            List<Reservation> reservations = new List<Reservation>();

            int daysToStay = (checkoutDate - checkInDate).Days;

            decimal totalPrice = CalculatePriceWithTenPercentageDiscount(roomNumber, checkInDate, checkoutDate);

            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_insertReservation", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@custPhoneNumber", phoneNumber));
                    sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
                    sql.Parameters.Add(new SqlParameter("@checkInDate", checkInDate.Date));
                    sql.Parameters.Add(new SqlParameter("@checkOutDate", checkoutDate.Date));
                    sql.Parameters.Add(new SqlParameter("@daysToStay", daysToStay));
                    sql.Parameters.Add(new SqlParameter("@totalPrice", totalPrice));
                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        string resPhoneNumber = (string) rdr["custPhoneNumber"];
                        int resRoomNumber = (int) rdr["roomNumber"];
                        DateTime resCheckInDate = (DateTime) rdr["checkInDate"];
                        DateTime resCheckOutDate = (DateTime) rdr["CheckOutDate"];

                        Reservation reservation = new Reservation()
                        {
                            CustPhoneNumber = resPhoneNumber, RoomNumber = resRoomNumber, CheckInDate = resCheckInDate,
                            CheckOutDate = resCheckOutDate, DaysToStay = daysToStay, TotalPrice = totalPrice
                        };
                        reservations.Add(reservation);
                    }
                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return reservations;
        }

        /// <summary>
        /// TotalPrice
        /// calls a method called sp_GetRoomPrice that gets the total roomPrice per night based on features and room price of that room.
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <returns>prices</returns>
        public static List<TotalPrices> TotalPrice(int roomNumber)
        {
            List<TotalPrices> prices = new List<TotalPrices>();

            using (SqlConnection connection = new SqlConnection(Con))

            {
                try
                {
                    connection.Open();

                    SqlCommand sql = new SqlCommand("sp_GetRoomPrice", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
                    rdr = sql.ExecuteReader();
                    while (rdr.Read())
                    {
                        decimal totalPrice = (decimal) rdr["totalPrice"];
                        TotalPrices totalPrices = new TotalPrices(){TotalPrice = totalPrice};

                        prices.Add(totalPrices);
                    }
                }
                finally
                {
                    connection?.Close();

                    rdr?.Close();
                }
            }

            return prices;
        }

        /// <summary>
        /// SearchRoomWithFeature
        /// is used by method GetRoomsAvailableBasedOnFeatures
        /// this gives the method a string of room numbers based on what featureNumber the user choose on the website
        /// </summary>
        /// <param name="feaNumber"></param>
        /// <returns></returns>
        public static string SearchRoomWithFeature(int feaNumber)
        {
            string featureSql = null;

            if (feaNumber == 1)
            {
                featureSql = " roomNumber in (100, 102, 103, 104, 105, 106, 107, 108, 110, 201, 202, 203, 204, 206, 207, 208, 302, 303, 306, 307, 308, 402, 403, 502, 503, 507, 508, 509, 510)";
            }

            else if (feaNumber == 2)
            {
                featureSql = " roomNumber in (101, 109)";
            }

            else if (feaNumber == 3)
            {
                featureSql = " roomNumber in (200, 300, 400, 500)";
            }

            else if (feaNumber == 4)
            {
                featureSql = " roomNumber in (205, 305, 405)";
            }
            else if (feaNumber == 5)
            {
                featureSql = " roomNumber in (209, 309, 409)";
            }

            else if (feaNumber == 6)
            {
                featureSql = " roomNumber in (301, 304, 501)";
            }

            else if (feaNumber == 7)
            {
                featureSql = " roomNumber in (401)";
            }

            else if (feaNumber == 8)
            {
                featureSql = " roomNumber in (404, 504)";
            }

            else if (feaNumber == 9)
            {
                featureSql = " roomNumber in (406, 407)";
            }

            else if (feaNumber == 10)
            {
                featureSql = " roomNumber in (408)";
            }

            else if (feaNumber == 11)
            {
                featureSql = " roomNumber in (506)";
            }

            return featureSql;
        }



        /// <summary>
        /// GetRoomsAvailableBasedOnFeatures
        /// i've used dapper in this method to map two global tables together.
        /// but i couldn't get it to work properly. So i created SearchRoomWithFeature instead.
        /// </summary>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <param name="featureNumber"></param>
        /// <returns>list of rooms</returns>
        public static List<Room> GetRoomsAvailableBasedOnFeatures(DateTime checkInDate,
             DateTime checkOutDate, int featureNumber)
        {
            string dateIn = checkInDate.ToString("yyyy-MM-dd");
            string dateOut = checkOutDate.ToString("yyyy-MM-dd");

            using (SqlConnection connection = new SqlConnection(Con))

            {
                connection.Open();

                string sql = $@"DECLARE @RoomFeatureRS TABLE (roomNum int)
                                DECLARE @roomNumberRs TABLE (roomNumber int,roomPrice decimal(19,4),featureDescription varchar(50),featurePrice decimal(19,4))
                                insert into @roomNumberRs
                                SELECT room.roomNumber,Room.price as roomPrice, fe.description, fe.price as featurePrice FROM Room
                                INNER JOIN roomFeatures rf  ON rf.roomNumber = Room.roomNumber
                                INNER JOIN Features fe  ON rf.featureNumber = fe.featureNumber
                                WHERE Room.roomNumber NOT IN(SELECT reservation.roomNumber FROM reservation WHERE checkInDate <= '{dateIn}' AND checkOutDate >= '{dateOut}')
                                insert into @roomFeatureRs SELECT roomNumber  FROM @roomNumberRs where {SearchRoomWithFeature(featureNumber)}
                                SELECT roomNum, r.price as RoomPrice ,fe.description as FeatureDescription,fe.price AS featurePrice FROM @RoomFeatureRS
                                INNER JOIN Room r ON r.roomNumber = roomNum
                                INNER JOIN roomFeatures rf ON rf.roomNumber = roomNum
                                INNER JOIN Features fe ON fe.featureNumber = rf.featureNumber";

                var roomFeatureDictionary = new Dictionary<int, Room>();
                var list = connection.Query<Room, Features, Room>(
                        sql,
                        (room, features) =>
                        {
                            Room roomEntry;

                            if (!roomFeatureDictionary.TryGetValue(room.RoomNum, out roomEntry))
                            {
                                roomEntry = room;
                                roomEntry.roomFeatures = new List<Features>();
                                roomFeatureDictionary.Add(roomEntry.RoomNum, roomEntry);
                            }

                            roomEntry.roomFeatures.Add(features);
                            return roomEntry;
                        },
                        splitOn: "FeatureDescription")
                    .Distinct()
                    .ToList();
                return list;
            }
        }
    }
}