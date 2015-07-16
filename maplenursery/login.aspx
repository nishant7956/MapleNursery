<%@ Page Language="C#" MasterPageFile="~/log.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs"  Inherits="maplenursery.login" Async="true" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">
                        <form role="form">
                            <fieldset>
                                <div class="form-group">

        
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
            <LayoutTemplate>
                
                                  
                                    
                                        <asp:TextBox Cssclass="form-control" ID="UserName" runat="server"></asp:TextBox>
                                   </div>
                                <div class="form-group">
                                    
                                        <asp:TextBox Cssclass="form-control"  ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                   </div>
                                <div class="checkbox">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                  </div>
                                    
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                   
                                        <asp:Button ID="LoginButton" runat="server" Cssclass="btn btn-lg btn-success btn-block" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                             
                
            </LayoutTemplate>
                                    </asp:Login>
                                    </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

       <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>

    </div>
</asp:Content>