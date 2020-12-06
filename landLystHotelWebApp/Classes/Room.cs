namespace landLystHotelWebApp
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int HotelNumber { get; set; }
        public int FloorLevel { get; set; }
        public decimal Price { get; set; }
        public int Reserved { get; set; }
        public string Condition { get; set; }


        public Room(int roomNumber)
        {
            this.RoomNumber = roomNumber;
        }
        public Room(int roomNumber, int hotelNumber, int floorLevel, decimal price, int reserved, string condition)
            : this(roomNumber)
        {
            this.HotelNumber = hotelNumber;
            this.FloorLevel = floorLevel;
            this.Price = price;
            this.Reserved = reserved;
            this.Condition = condition;
        }

        public Room(int roomNumber, int hotelNumber)
            : this(roomNumber)
        {
            this.HotelNumber = hotelNumber;
        }


        public Room(int roomNumber, int hotelNumber, int floorLevel)
            : this(roomNumber, hotelNumber)
        {
            this.FloorLevel = floorLevel;
        }

        public Room()
        {
        }
    }
}