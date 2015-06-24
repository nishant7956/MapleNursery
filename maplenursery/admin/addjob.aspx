<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/mas.Master" CodeBehind="addjob.aspx.cs" Inherits="maplenursery.admin.addjob" Async="true" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    
</asp:Content>