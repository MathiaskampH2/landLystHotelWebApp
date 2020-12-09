using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Dapper;

namespace landLystHotelWebApp
{
    public class ServerManager
    {
        private static readonly string Con = DbConnection.Connection();

        private static SqlDataReader rdr = null;

        //public static List<Features> GetRoomFeatures(int roomNumber)
        //{
        //    List<Features> features = new List<Features>();

        //    using (SqlConnection connection = new SqlConnection(Con))

        //    {
        //        try
        //        {
        //            connection.Open();

        //            SqlCommand sql = new SqlCommand("sp_GetRoomFeatures", connection)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };

        //            sql.Parameters.Add(new SqlParameter("@roomNumber", roomNumber));
        //            rdr = sql.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                string description = (string) rdr["description"];

        //                Features feature = new Features(description);
        //                features.Add(feature);
        //            }
        //        }
        //        finally
        //        {
        //            connection?.Close();

        //            rdr?.Close();
        //        }
        //    }

        //    return features;
        //}


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

                        Customer customer = new Customer(custFName, custLName, custZipcode, custAddress,
                            custPhoneNumber, custEmail);
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

        public static List<Reservation> CreateReservation(string phoneNumber, int roomNumber, DateTime checkInDate,
            DateTime checkoutDate)
        {
            List<Reservation> reservations = new List<Reservation>();

            int daysToStay = (checkoutDate - checkInDate).Days;

            decimal totalPrice = ConvertTotalPRiceToDecimal(roomNumber) * daysToStay;

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

                        Reservation reservation = new Reservation(resPhoneNumber, resRoomNumber, resCheckInDate,
                            resCheckOutDate, daysToStay, totalPrice);
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
                        TotalPrices totalPrices = new TotalPrices(totalPrice);

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

        public static decimal ConvertTotalPRiceToDecimal(int roomNumber)
        {
            List<TotalPrices> prices = TotalPrice(roomNumber);

            decimal price = Convert.ToDecimal(prices[0].TotalPrice.ToString());
            return price;
        }


        public static List<Room> GetRoomsAvailableBasedOnFeatures(DateTime checkInDate,
             DateTime checkOutDate)
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
                                insert into @roomFeatureRs SELECT roomNumber  FROM @roomNumberRs WHERE featureDescription = 'double bed'
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