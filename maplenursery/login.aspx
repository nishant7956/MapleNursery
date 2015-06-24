<%@ Page Language="C#" MasterPageFile="~/userMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs"  Inherits="maplenursery.login" Async="true" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Height="183px" Width="242px" style="margin-left: 11px"></asp:Login>
       
 </asp:Content>