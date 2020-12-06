using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landLystHotelWebApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void checkInDate_SelectionChanged(object sender, EventArgs e)
        {
            checkInDateChecked.Text = checkInDate.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void CheckOutDate_SelectionChanged(object sender, EventArgs e)
        {
            checkOutDateChecked.Text = CheckOutDate.SelectedDate.Date.ToString("yyyy-MM-dd");
        }

        protected void confirmReservation_Click1(object sender, EventArgs e)
        {
            string phoneNum = phoneNumber.Text;
            int roomNumber = int.Parse(this.roomNumber.Text);
            DateTime checkInDate = DateTime.Parse(checkInDateChecked.Text);
            DateTime checkOutDate = DateTime.Parse(checkOutDateChecked.Text);


            HotelManager.CreateReservation(phoneNum, roomNumber, checkInDate, checkOutDate);
        }
    }
}