using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace landLystHotelWebApp
{
    public partial class _Default : Page
    {
        // This method is called when the page gets loaded.
        // It resets my customer fields and fills in the feature prices from the database
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fNameBox.Text = null;
                lNameBox.Text = null;
                emailBox.Text = null;
                phoneNumberBox.Text = null;
                zipcodeBox.Text = null;
                addressBox.Text = null;
                this.LoadFeaturePrices();
                ListOfRooms.Visible = false;


            }
        }

        // this method resets the webpage
        protected void ResetWebPage()
        {
            Thread.Sleep(2000);
            Response.Redirect("Default.aspx");
        }

        // this method gets feature prices from Database
        protected void LoadFeaturePrices()
        {
            List<Features> features = HotelManager.GetFeaturePrice();

            foreach (Features feature in features)
            {
                if (feature.featureDescription == "balcony")
                {
                    balconyPriceLabel.Text = feature.FeaturePrice.ToString();
                }

                if (feature.featureDescription == "double bed")
                {
                    doubleBedPriceLabel.Text = feature.FeaturePrice.ToString();
                }

                if (feature.featureDescription == "bathtub")
                {
                    bathtopPriceLabel.Text = feature.FeaturePrice.ToString();
                }

                if (feature.featureDescription == "jacuzzi")
                {
                    jacuzziPriceLabel.Text = feature.FeaturePrice.ToString();
                }

                if (feature.featureDescription == "kitchen")
                {
                    kitchenPriceLabel.Text = feature.FeaturePrice.ToString();
                }

                if (feature.featureDescription == "single bed")
                {
                    oneSingleBedsLabel.Text = feature.FeaturePrice.ToString();
                }

                if (feature.featureDescription == "2 single beds")
                {
                    twoSingleBedsLabel.Text = feature.FeaturePrice.ToString();
                }
            }
        }

        // this method creates a customer based on the information from website
        protected void ConfirmCustomerButton_Click(object sender, EventArgs e)
        {
            string custFName = fNameBox.Text;
            string custLName = lNameBox.Text;
            int custZipcode = int.Parse(zipcodeBox.Text);
            string custAddress = addressBox.Text;
            string custPhoneNum = phoneNumberBox.Text;
            string custEmail = emailBox.Text;

            HotelManager.CreateCustomer(custFName, custLName, custZipcode, custAddress, custPhoneNum, custEmail);
        }


        // this methods is used to select the feature checkboxes and returns a number
        protected int SelectFeatures()
        {
            int featureNumber = 0;

            if (bathtubCheckbox.Checked && doubleBedCheckbox.Checked)
            {
                featureNumber = 1;
            }

            else if (doubleBedCheckbox.Checked)
            {
                featureNumber = 2;
            }

            else if (doubleBedCheckbox.Checked && balconyCheckbox.Checked && jacuzziCheckbox.Checked)
            {
                featureNumber = 3;
            }

            else if (doubleBedCheckbox.Checked && balconyCheckbox.Checked && jacuzziCheckbox.Checked &&
                     kitchenCheckbox.Checked)
            {
                featureNumber = 4;
            }

            else if (doubleBedCheckbox.Checked && bathtubCheckbox.Checked && jacuzziCheckbox.Checked)
            {
                featureNumber = 5;
            }

            else if (twoSingleBedsCheckbox.Checked && bathtubCheckbox.Checked)
            {
                featureNumber = 6;
            }

            else if (oneSingleBedsCheckbox.Checked && bathtubCheckbox.Checked && balconyCheckbox.Checked)
            {
                featureNumber = 7;
            }

            else if (oneSingleBedsCheckbox.Checked && bathtubCheckbox.Checked)
            {
                featureNumber = 8;
            }

            else if (oneSingleBedsCheckbox.Checked && balconyCheckbox.Checked)
            {
                featureNumber = 9;
            }

            else if (oneSingleBedsCheckbox.Checked)
            {
                featureNumber = 10;
            }

            else if (doubleBedCheckbox.Checked && balconyCheckbox.Checked)
            {
                featureNumber = 11;
            }

            return featureNumber;
        }

        // this method is used to search for a room based on feature number and check in and out date
        protected void searchRoom_Click(object sender, EventArgs e)
        {


            DateTime checkInDate = DateTime.Parse(checkInBox.Text);
            DateTime checkOutDate = DateTime.Parse(checkOutBox.Text);
            int featureNumber = SelectFeatures();

            List<Room> rooms = HotelManager.GetRoomsAvailableBasedOnFeatures(checkInDate, checkOutDate, featureNumber);

            ListOfRooms.DataSource = rooms;
            ListOfRooms.DataTextField = "roomNum";
            DataBind();
            ListOfRooms.Visible = true;



        }
        // thjis method is used to create the reservation
        protected void confirmReservationButton_Click(object sender, EventArgs e)
        {
            string phoneNum = phoneNumberBox.Text;
            int roomNumber = int.Parse(this.ChooseRoomNumber.Text);
            DateTime checkInDate = DateTime.Parse(checkInBox.Text);
            DateTime checkOutDate = DateTime.Parse(checkOutBox.Text);

            HotelManager.CreateReservation(phoneNum, roomNumber, checkInDate, checkOutDate);

            ResetWebPage();


        }

        // this method is used to get get the total room price when a customer types in a room number in the ChooseRoomNumber textbox
        protected void ChooseRoomNumber_TextChanged(object sender, EventArgs e)
        {
            DateTime checkInDate = DateTime.Parse(checkInBox.Text);
            DateTime checkOutDate = DateTime.Parse(checkOutBox.Text);
            int roomNumber = int.Parse(this.ChooseRoomNumber.Text);
            decimal totalPrice = HotelManager.CalculatePriceWithTenPercentageDiscount(roomNumber, checkInDate, checkOutDate);
            TotalRoomPrice.Text = totalPrice.ToString();
        }
    }

}