using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace landLystHotelWebApp
{
    public class DbConnection
    {
        public static string Connection()
        {
            string con = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            return con;
        }
    }
}