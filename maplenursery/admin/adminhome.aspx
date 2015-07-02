<%@ Page Language="C#" MasterPageFile="~/admin/mas.Master" AutoEventWireup="true" CodeBehind="adminhome.aspx.cs" Inherits="maplenursery.admin.adminhome" Async="true" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        <asp:Label ID="Label1" runat="server" Text="Welcome Admin!!" Font-Bold="True" Font-Size="X-Large" ></asp:Label><br />
            <br />
<cc1:GMap ID="GMap1" runat="server" enableDoubleClickZoom="true" enableRotation="true" enableGoogleBar="True" enableGTrafficOverlay="True" enableHookMouseWheelToZoom="True" enableTransitOverlay="True" Height="600px" mapType="Physical" Width="800px" />
            <br />
            <asp:Label ID="lblerror" runat="server"></asp:Label>
            <br />
    </div>
</asp:Content>