<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="landLystHotelWebApp._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/Reservation.css"/>
<div class="CustomerInformation">
    <h1>Customer information</h1>
    <div>
        <table>
            <tr>
                <th>First name</th>

                <th>Last name</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="fNameBox" runat="server"></asp:TextBox>
                </td>

                <td>
                    <asp:TextBox ID="lNameBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <th>Zipcode</th>
                <th>Address</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="zipcodeBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="addressBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <th>Email</th>
                <th>Phone number</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="phoneNumberBox" onkeypress="return integersOnly(this)" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <br/>
    <table>
        <tr>
            <td>
                <asp:Button ID="ConfirmCustomerButton" runat="server" Text="Create customer" OnClick="ConfirmCustomerButton_Click"/>
            </td>
        </tr>
    </table>
</div>
<div class="ReservationInformation">
    <h1>Reservation information</h1>
    <h3>Room features</h3>
    <p>
        The default price of a room is 695.- per night.<br/>
        Below you see some room features that you can select.<br/>
        the selected room features price will be added to the default price of the room.<br/>
    </p>
</div>
<div class="RoomFeatures">
    <table>
        <tr>
            <th>Room feature</th>
            <th></th>
            <th>Price</th>
        </tr>
        <tr>
            <td>Balcony</td>
            <td>
                <asp:CheckBox ID="balconyCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="balconyPriceLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Double Bed</td>
            <td>
                <asp:CheckBox ID="doubleBedCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="doubleBedPriceLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Bathtub</td>
            <td>
                <asp:CheckBox ID="bathtubCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="bathtopPriceLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Jacuzzi</td>
            <td>
                <asp:CheckBox ID="jacuzziCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="jacuzziPriceLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Kitchen</td>
            <td>
                <asp:CheckBox ID="kitchenCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="kitchenPriceLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Two single beds</td>
            <td>
                <asp:CheckBox ID="twoSingleBedsCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="twoSingleBedsLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>One single bed</td>
            <td>
                <asp:CheckBox ID="oneSingleBedsCheckbox" runat="server"/>
            </td>
            <td>
                <asp:Label ID="oneSingleBedsLabel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</div>
<br/>
<div class="checkInDate">
    <table>
        <tr>
            <th>Check in date</th>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="checkInBox" runat="server"></asp:TextBox>
                <asp:ImageButton ID="checkInButtom" ImageUrl="images/calendar.png" ImageAlign="Bottom"
                                 runat="server"/>
                <ajaxToolkit:CalendarExtender ID="checkInCalender" PopupButtonID="checkInButtom" runat="server" TargetControlID="checkInBox"
                                              Format="yyyy-MM-dd">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
    </table>
</div>
<div class="CheckOutDate">
    <table>
        <th>Check out date</th>
        <tr>
            <td>
                <asp:TextBox ID="checkOutBox" runat="server"></asp:TextBox>
                <asp:ImageButton ID="checkOutButtom" ImageUrl="images/calendar.png" ImageAlign="Bottom"
                                 runat="server"/>
                <ajaxToolkit:CalendarExtender ID="checkOutCalender" PopupButtonID="checkOutButtom" runat="server" TargetControlID="checkOutBox"
                                              Format="yyyy-MM-dd">
                </ajaxToolkit:CalendarExtender>
            </td>
        </tr>
    </table>
</div>
<div class="SearchRoom">
    <table>
        <tr>
            <th>search for room</th>
            <th></th>
        </tr>
        <tr>
            <td>
                <br/><asp:Button ID="searchRoom" runat="server" Text="search" OnClick="searchRoom_Click"/>
            </td>
            <td>
                <asp:ListBox ID="ListOfRooms" runat="server"></asp:ListBox>
            </td>

        </tr>

    </table>
    <table>
        <tr>
            <th>choose room</th>
            <th>total price</th>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="ChooseRoomNumber" runat="server" OnTextChanged="ChooseRoomNumber_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="TotalRoomPrice" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>
<div class="ReservationConfirmation">
    <table>
        <tr>
            <td>
                <asp:Button ID="confirmReservationButton" runat="server" Text="Confirm reservation" OnClick="confirmReservationButton_Click"/>
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript">
    function integersOnly(obj) {
        obj.value = obj.value.replace(/[^0-9-.]/g, '');
    }
</script>
</asp:Content>

