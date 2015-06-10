<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addjob.aspx.cs" Inherits="maplenursery.admin.addjob" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <br />
        <asp:Label ID="Lblerror" runat="server"></asp:Label>
        <br />
        <br />

        <asp:TextBox ID="JobTitle" runat="server" style="margin-left: 0px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="JobDescription" runat="server"></asp:TextBox>
        <br />
        <br />

    <asp:DropDownList ID="LiEmployee" runat="server" > 
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"  />
    </div>
    </form>
</body>
</html>
