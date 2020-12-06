namespace landLystHotelWebApp
{
    public class Customer
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer(string fName, string lName, int zipCode, string address, string phoneNumber, string email)
        {
            this.FName = fName;
            this.LName = lName;
            this.ZipCode = zipCode;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public override string ToString()
        {
            return
                "First Name :" + FName + "\n" +
                "Last Name  :" + LName + "\n" +
                "zipcode    :" + ZipCode + "\n" +
                "address    :" + Address + "\n" +
                "phone number :" + PhoneNumber + "\n" +
                "email :" + Email + "\n";
        }
    }
}