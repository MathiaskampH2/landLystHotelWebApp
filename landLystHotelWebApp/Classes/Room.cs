using System.Collections.Generic;
using System.Text;

namespace landLystHotelWebApp
{
    /// <summary>
    /// Class Room
    /// is used to create an object of Room 
    /// </summary>
    public class Room
    {
        public int RoomNum { get; set; }

        public decimal RoomPrice { get; set; }

        public List<Features> roomFeatures { get; set; }

    }
}