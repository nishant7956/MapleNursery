<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" MasterPageFile="~/admin/mas.Master" CodeBehind="addplant.aspx.cs" Inherits="maplenursery.admin.addplant" Async="true" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label><br />
    <div class="container">
    <div class="row">
        <form role="form">
            <div class="col-lg-6">
                <div class="well well-sm"><strong><span class="glyphicon glyphicon-asterisk"></span>Required Field</strong></div>
                <div class="form-group">
                     <asp:Label ID="lblname" runat="server" Text="Plant Name"></asp:Label>
                    <div class="input-group">
        <asp:TextBox ID="Name" CssClass="form-control" runat="server" required="true"></asp:TextBox>

       
        <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                    </div>
                </div>
                <div class="form-group">
        <asp:Label ID="lbldesc" runat="server" Text="Plant Description"></asp:Label>
        <div class="input-group">
        <asp:TextBox ID="Description" CssClass="form-control" runat="server" required="true"></asp:TextBox>
        <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                    </div>
                </div>
                <div class="form-group">
                    
        <asp:Label ID="lblupload" runat="server" Text="Upload Image"  ></asp:Label>
        <div class="input-group">
        <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" required="true" /><br />
            <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                    </div>
                </div>
                  <div class="form-group">
        <asp:Label ID="lblprice" runat="server" Text="Enter Price"></asp:Label>
        <div class="input-group">
        <asp:TextBox ID="txtprice" CssClass="form-control" runat="server" required="true"></asp:TextBox>
        <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                    </div>
                </div>
        
        <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" CssClass="btn btn-info pull-right" /></div>
                </form>
        <div class="col-lg-5 col-md-push-1">
            <div class="col-md-12">
                <div class="alert alert-success">
                    <strong><span class="glyphicon glyphicon-ok"></span> Success! Message sent.</strong>
                </div>
                <div class="alert alert-danger">
                    <span class="glyphicon glyphicon-remove"></span><strong> Error! Please check all page inputs.</strong>
                </div>
            </div>
        </div>
    </div></div>


   
</asp:Content>
