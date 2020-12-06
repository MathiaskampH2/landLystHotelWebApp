<%@ Page Title="Reservation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservation.aspx.cs" Inherits="landLystHotelWebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

         <link rel="stylesheet" href="fonts/Reservation.css"/>
        <div style="height: 187px">
            <h1>
            Customer information
            </h1>
        <br/>
        <asp:Label ID="fNameLabel" runat="server" Text="First name:"></asp:Label>
        <asp:TextBox runat="server" ID="fName"></asp:TextBox>
        <asp:Label ID="lNameLabel" runat="server" Text="Last name:"></asp:Label>
        <asp:TextBox runat="server" ID="lName"></asp:TextBox>
        <br/>
        <br/>
        <asp:Label ID="phoneNumberLabel" runat="server" Text="Phone number:"></asp:Label>
        <asp:TextBox runat="server" ID="phoneNumber"></asp:TextBox>
        <asp:Label ID="emailLabel" runat="server" Text="Email"></asp:Label>
        <asp:TextBox runat="server" ID="email" Height="24px" Width="133px"></asp:TextBox>
        <br/>
        </div>
        <div style="height: 623px">
            <h1>Reservation information</h1>
            <h3>Room features</h3>
            <p>
                The default price of a room is 695.- per night.<br/>
                Below you see some room features that you can select<br/>
                the selected room features price will be added to the default price of the room.<br/>
            </p>
            <br/>
            <asp:Label ID="balconyLabel" runat="server" Text="Balcony"></asp:Label>
            <asp:CheckBox ID="balcony" runat="server" />
            <asp:Label ID="balconyPrice" runat="server" Text="150.- kr"></asp:Label>
            <br />
            <asp:Label ID="doubleBedLabel" runat="server" Text="Double bed"></asp:Label>
            <asp:CheckBox ID="doubleBed" runat="server" />
            <asp:Label ID="doubleBedPrice" runat="server" Text="200.- Kr"></asp:Label>
            <br />
            <asp:Label ID="bathtopLabel" runat="server" Text="Bathtop"></asp:Label>
            <asp:CheckBox ID="bathtop" runat="server" />
            <asp:Label ID="bathtopPrice" runat="server" Text="50.- Kr"></asp:Label>
            <br />
            <asp:Label ID="jacuzziLabel" runat="server" Text="Jacuzzi"></asp:Label>
            <asp:CheckBox ID="jacuzzi" runat="server" />
            <asp:Label ID="jacuzziPrice" runat="server" Text="175.- Kr"></asp:Label>
            <br />
            <asp:Label ID="kitchenLabel" runat="server" Text="Kitchen"></asp:Label>
            <asp:CheckBox ID="kitchen" runat="server" />
            <asp:Label ID="KitchenPrice" runat="server" Text="350.- Kr"></asp:Label>
            <br />
            <asp:Label ID="twoSingleBedsLabel" runat="server" Text="2 single beds"></asp:Label>
            <asp:CheckBox ID="twoSingleBeds" runat="server" />
            <asp:Label ID="twoSingleBedsPrice" runat="server" Text="200.- Kr"></asp:Label>
            <br />
            <asp:Label ID="oneSingleBedLabel" runat="server" Text="1 single bed"></asp:Label>
            <asp:CheckBox ID="oneSingleBed" runat="server" />
            <asp:Label ID="oneSingleBedPrice" runat="server" Text="0.- Kr"></asp:Label>
            <br />
            <br/>
            <asp:Label ID="roomNumberLabel" runat="server" Text="Room number:"></asp:Label>
            <asp:TextBox runat="server" ID="roomNumber"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="checkInDateLabel" runat="server" Text="Check in date"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="checkOutdateLabel" runat="server" Text="Check out date"></asp:Label>
            <br />
            <div style="position: relative; top: 2px; left: 0px; height: 189px;">
            <div style="position: absolute; left: 0px; ">
                <asp:calendar id="checkInDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="checkInDate_SelectionChanged">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:calendar>
            </div>
            <div style="position: absolute; left: 250px; ">
                <asp:calendar id="CheckOutDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="CheckOutDate_SelectionChanged" >
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:calendar>
            </div>
        </div>
        <div style="position: relative; top: 0px; left: 0px; height: 62px;">
            <div style="position: absolute; left: 0px;">
                <asp:TextBox ID="checkInDateChecked" runat="server"> </asp:TextBox>
            </div>
        <div style="position: absolute; left: 248px;">
            <asp:TextBox ID="checkOutDateChecked" runat="server"></asp:TextBox>
        </div>
        </div>
            <div style="position: relative; left: 0px; top: -31px; height: 30px;">
            <div style="position: absolute; left: 0px;">
            <asp:Button ID="confirmReservation" runat="server" Text="confirm" OnClick="confirmReservation_Click1" />
            </div>
        </div>
        </div>
</asp:Content>
