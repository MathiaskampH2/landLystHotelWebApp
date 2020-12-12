using System.Collections.Generic;
using System.Text;

namespace landLystHotelWebApp
{
    public class Room
    {
        public int RoomNum { get; set; }

        public decimal RoomPrice { get; set; }

        public List<Features> roomFeatures { get; set; }

    }
}