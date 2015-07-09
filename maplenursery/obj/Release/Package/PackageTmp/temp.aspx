<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="temp.aspx.cs" Inherits="maplenursery.temp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblerror" runat="server"></asp:Label>
          <asp:TextBox ID="streetname" runat="server"></asp:TextBox>
        <%--<asp:TextBox ID="streetnumber" runat="server"></asp:TextBox>
      
        <asp:TextBox ID="city" runat="server"></asp:TextBox>
        <asp:TextBox ID="pin" runat="server"></asp:TextBox>--%>
        <asp:Button ID="convert" runat="server" Text="convert" OnClick="convert_Click" />
    </div>
    </form>
</body>
</html>
