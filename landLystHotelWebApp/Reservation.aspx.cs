using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landLystHotelWebApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateCustomerButID_Click(object sender, EventArgs e)
        {
            string custFName = fNameBox.Text;
            string custLName = lNameBox.Text;
            int custZipcode = int.Parse(zipcodeBox.Text);
            string custAddress = addressBox.Text;
            string custPhoneNum = phoneNumberBox.Text;
            string custEmail = emailBox.Text;

            HotelManager.CreateCustomer(custFName, custLName, custZipcode, custAddress, custPhoneNum, custEmail);
        }

     

        protected void ConfirmReservationButton_Click(object sender, EventArgs e)
        {
            string phoneNum = phoneNumberBox.Text;
            //int roomNumber = int.Parse(roomNum);
            int roomNumber = 100;
            DateTime checkInDate = DateTime.Parse(CheckInDateChosenBox.Text);
            DateTime checkOutDate = DateTime.Parse(CheckOutDateChosenBox.Text);


            HotelManager.CreateReservation(phoneNum, roomNumber, checkInDate, checkOutDate);
        }

        protected void CalenderCheckInDate_SelectionChanged(object sender, EventArgs e)
        {
            CheckInDateChosenBox.Text = CalenderCheckInDate.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void CalenderCheckOutDate_SelectionChanged(object sender, EventArgs e)
        {
            CheckOutDateChosenBox.Text = CalenderCheckOutDate.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void searchRoom_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = DateTime.Parse(CheckInDateChosenBox.Text);
            DateTime checkOutDate = DateTime.Parse(CheckOutDateChosenBox.Text);

            List<Room> rooms = HotelManager.GetRoomsAvailableBasedOnFeatures(checkInDate, checkOutDate);

            GridWithRooms.DataSource = rooms;
            GridWithRooms.DataBind();
        }
    }
}