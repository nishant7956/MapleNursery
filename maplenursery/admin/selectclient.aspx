<%@ Page Title="" Language="C#" MasterPageFile="~/admin/mas.Master" EnableEventValidation="false" Async="true" AutoEventWireup="true" CodeBehind="selectclient.aspx.cs" Inherits="maplenursery.admin.selectclient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Lblerror" runat="server"></asp:Label>
     <div class="container">
    <div class="row">
        <form role="form">
            <div class="col-lg-6">
                <div class="well well-sm"><strong><span class="glyphicon glyphicon-asterisk"></span>Required Field</strong></div>
                <div class="form-group" id="radio">
                    <div class="radio">
                        
                        <asp:RadioButton  ID="radioexist" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton_CheckedChanged"  GroupName="client" Text="Select if the Client Already Exists" />
                    </div>
                    <div class="radio">
                        <asp:RadioButton  ID="radionew" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton_CheckedChanged" GroupName="client" Text="Select to add new Client" />
                    </div>
                    </div>
                <div class="form-group" id="search" runat="server">
                    <asp:Label ID="lblsearch" runat="server" Text="Search Client"></asp:Label>
                     <div class="input-group">
        <asp:TextBox ID="txtsearchclient" CssClass="form-control" runat="server" required="true" TextMode="Search"></asp:TextBox>
        <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>

                         </div>
                    
                    
                <asp:Button ID="searchclient" runat="server" CssClass="btn btn-default btn-flat" Text="Search" OnClick="searchclient_Click"></asp:Button>
                    </div>
                
      
        <div class="form-group" id="clientcontrols" runat="server">
            Name
            <div class="input-group">
                <asp:TextBox CssClass="form-control" ID="clientname" runat="server" required="true"></asp:TextBox>
                 <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            Address
             <div class="input-group">
                <asp:TextBox CssClass="form-control" ID="clientaddress" runat="server" required="true"></asp:TextBox>
                 <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            Contact Number
             <div class="input-group">
                <asp:TextBox CssClass="form-control" ID="clientcontact" runat="server" required="true" TextMode="Phone"></asp:TextBox>
                 <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            Email
            <div class="input-group">
                <asp:TextBox CssClass="form-control" ID="clientemail" runat="server" required="true" TextMode="Email"></asp:TextBox>
                 <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            <asp:Button ID="next" CssClass="btn btn-default btn-flat" runat="server" Text="Next" OnClick="next_Click" />
            </div>
                 </div>
             </form>
        </div>
         </div>
    
</asp:Content>
