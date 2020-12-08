namespace landLystHotelWebApp
{
    public class RoomAndFeatures
    {
        public int RoomNumber { get; set; }

        public decimal RoomPrice { get; set; }

        public string FeatureDescription { get; set; }

        public decimal FeaturePrice { get; set; }

        public RoomAndFeatures(int roomNumber, decimal roomPrice, string featureDescription, decimal featurePrice)
        {
            this.RoomNumber = roomNumber;
            this.RoomPrice = roomPrice;
            this.FeatureDescription = featureDescription;
            this.FeaturePrice = featurePrice;
        }

    }
}