<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/mas.Master" CodeBehind="addplant.aspx.cs" Inherits="maplenursery.admin.addplant" Async="true" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblerror" runat="server" Text=""></asp:Label><br />

        <asp:Label ID="lblname" runat="server" Text="Plant Name"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbldesc" runat="server" Text="Plant Description"></asp:Label>
        <br />
        <asp:TextBox ID="Description" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblupload" runat="server" Text="Upload Image"></asp:Label>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="add plants" OnClick="Button1_Click" />
        <br />


    </div>
   
</asp:Content>
