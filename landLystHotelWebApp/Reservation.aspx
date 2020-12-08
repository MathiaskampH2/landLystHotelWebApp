<%@ Page Title="Reservation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="landLystHotelWebApp.About" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="fonts/Reservation.css"/>
 <div id="CustomerInformation" style="position: relative; left: 0px;">
        <h1 id="customerHeadline">Customer information</h1>
        <div id="firstNameLastName" style="position: relative; left: 0px;">
            <table style="width: 350px;">
                <tr>
                    <th id="fNameID" style="width: 150px">First name</th>
                    <th id="lNameID" style="width: 150px">Last name</th>
                </tr>
                <tr>
                    <td id="fNameBoxID" style="width: 150px;">
                        <asp:TextBox ID="fNameBox" runat="server"></asp:TextBox>
                    </td>
                    <td id="lNameBoxID" style="width: 150px">
                        <asp:TextBox ID="lNameBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="zipcodeAddress" style="position: relative; left: 0px;">
            <table style="width: 350px;">
                <tr>
                    <th id="zipcodeID" style="width: 150px">Zipcode</th>
                    <th id="addressID" style="width: 150px">Address</th>
                </tr>
                <tr>
                    <td id="zipcodeBoxID" style="width: 150px;">
                        <asp:TextBox ID="zipcodeBox" runat="server"></asp:TextBox>
                    </td>
                    <td id="addressBoxID" style="width: 150px">
                        <asp:TextBox ID="addressBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="emailPhoneNumber" style="position: relative; left: 0px;">
            <table style="width: 350px;">
                <tr>
                    <th id="emailID" style="width: 150px">Email</th>
                    <th id="phoneNumberID" style="width: 150px">Phone number</th>
                </tr>
                <tr>
                    <td id="emailBoxID" style="width: 150px;">
                        <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                    </td>
                    <td id="phoneNumberBoxID" style="width: 150px">
                        <asp:TextBox ID="phoneNumberBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <br/>
        <table style="width: 350px">
            <tr>
                <td id="createCustomer" style="width: 150px;">
                    <asp:Button ID="CreateCustomerButID" runat="server" Text="create customer" OnClick="CreateCustomerButID_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="reservationInformation" style="position: relative; left: 0px;">
        <h1 id="reservationHeadline">Reservation information</h1><br/>
        <h3 id="roomFeaturesHeadline">Room features</h3>
        <p id="breadTextRoomServation">
            The default price of a room is 695.- per night.<br/>
            Below you see some room features that you can select<br/>
            the selected room features price will be added to the default price of the room.<br/>
        </p><br/>
        <div id="roomFeaturesID" style="position: relative; left: 0px;">
            <table id="roomFeaturesTableID" style="width: 350px;">
                <tr>
                    <th id="roomFeatureColumnID" style="width: 100px">Room feature</th>
                    <th id="roomFeatureChekboxID" style="width: 50px"></th>
                    <th id="rroomFeaturePriceID" style="width: 100px">Price</th>
                </tr>
                <tr id="balconyRow">
                    <td id="balconyLabelID" style="width: 100px;">Balcony</td>
                    <td id="balconyCheckboxID" style="width: 50px">
                        <asp:CheckBox ID="balconyCheckbox" runat="server"/>
                    </td>
                    <td id="balconyPriceID" style="width: 100px">
                        <asp:Label ID="balconyPriceLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="doubleBedRow">
                    <td id="doubleBedLabelID" style="width: 100px;">Double Bed</td>
                    <td id="doubleBedCheckBoxID" style="width: 50px;">
                        <asp:CheckBox ID="doubleBedCheckbox" runat="server"/>
                    </td>
                    <td id="doublebedPriceID" style="width: 100px">
                        <asp:Label ID="doubleBedPriceLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="bathtopRow">
                    <td id="bathtopLabelID" style="width: 100px;">Bathtop</td>
                    <td id="bathtopCheckBoxID" style="width: 50px;">
                        <asp:CheckBox ID="bathtopCheckbox" runat="server"/>
                    </td>
                    <td id="BathtopPriceID" style="width: 100px">
                        <asp:Label ID="bathtopPriceLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="jacuzziRow">
                    <td id="jacuzziLabelID" style="width: 100px;">Jacuzzi</td>
                    <td id="jacuzziCheckBoxID" style="width: 50px;">
                        <asp:CheckBox ID="jacuzziCheckbox" runat="server"/>
                    </td>
                    <td id="jacuzziPriceID" style="width: 100px">
                        <asp:Label ID="jacuzziPriceLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="kitchenRow">
                    <td id="kitchenLabelID" style="width: 100px;">Kitchen</td>
                    <td id="kitchenCheckBoxID" style="width: 50px;">
                        <asp:CheckBox ID="kitchenCheckbox" runat="server"/>
                    </td>
                    <td id="kitchenPriceID" style="width: 100px">
                        <asp:Label ID="kitchenPriceLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="twoSingleBedsnRow">
                    <td id="twoSingleBedsLabelID" style="width: 100px;">Kitchen</td>
                    <td id="twoSIngleBedsCheckBoxID" style="width: 50px;">
                        <asp:CheckBox ID="twoSingleBedsCheckbox" runat="server"/>
                    </td>
                    <td id="twoSingleBedsPriceID" style="width: 100px">
                        <asp:Label ID="twoSingleBedsLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="oneSingleBedsnRow">
                    <td id="oneSingleBedsLabelID" style="width: 100px;">Kitchen</td>
                    <td id="oneSIngleBedsCheckBoxID" style="width: 50px;">
                        <asp:CheckBox ID="oneSingleBedsCheckbox" runat="server"/>
                    </td>
                    <td id="oneSingleBedsPriceID" style="width: 100px">
                        <asp:Label ID="oneSingleBedsLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div><br/>
        <div id="calenderCheckInCheckOut" style="position: relative; left: 5px; top: 12px;">
            <table id="calenderTableID">
                <tr id="CalenderTableColumns">
                <th id="calenderCheckIn" style="width: 300px">check in date</th>
                <th id="calenderCheckOut" style="width: 300px">check out date</th>
                </tr>
                <tr id="calenders">
                    <td id="calenderTableCheckInDate">
                        <asp:Calendar ID="CalenderCheckInDate" runat="server" OnSelectionChanged="CalenderCheckInDate_SelectionChanged"></asp:Calendar><br/>
                    </td>
                    <td id="calenderTableCheckOutDate">
                        <asp:Calendar ID="CalenderCheckOutDate" runat="server" OnSelectionChanged="CalenderCheckOutDate_SelectionChanged"></asp:Calendar><br/>
                    </td>
                </tr>
                <tr id="datesChosen">
                    <td id="checkInDateChosenBoxID">
                        <asp:TextBox ID="CheckInDateChosenBox" runat="server"></asp:TextBox>
                    </td>
                    <td id="checkOutDateChosenBoxID">
                        <asp:TextBox ID="CheckOutDateChosenBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr id="ConfirmReservation">
                    <td id="ConfirmReservationButtonID">
                        <br/><asp:Button ID="ConfirmReservationButton" runat="server" Text="confirm reservation" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>