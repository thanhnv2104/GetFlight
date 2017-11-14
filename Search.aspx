<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Search.aspx.vb" Inherits="GetFlight.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Result limit: <asp:TextBox ID="txt_Limit" runat="server" Text="40" Width="50px"></asp:TextBox>
           ADT: <asp:TextBox ID="txt_ADT" runat="server" Text="1" Width="100px"></asp:TextBox>
            <asp:TextBox ID="txt_Origin" runat="server" Text="SGN" PlaceHolder="Origin" Width="100px"></asp:TextBox>
            <asp:TextBox ID="txt_Destination" runat="server" Text="HAN" PlaceHolder="Destination" Width="100px"></asp:TextBox>
            <asp:TextBox ID="txt_FlightDate" runat="server" PlaceHolder="yyyy-MM-dd" Width="200px"></asp:TextBox>

            <asp:Button ID="Btn_GetFlight" runat="server" Text="Search"></asp:Button>
        </div>
    </form>
</body>
</html>
