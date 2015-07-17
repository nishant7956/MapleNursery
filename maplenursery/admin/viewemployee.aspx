<%@ Page Title="" Language="C#" MasterPageFile="~/admin/mas.Master" Async="true" AutoEventWireup="true" CodeBehind="viewemployee.aspx.cs" Inherits="maplenursery.admin.viewemployee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="content-wrapper">
        
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            <asp:Label ID="Label1" runat="server" Text="Employee List">
                 <asp:Label ID="Label2" runat="server"></asp:Label>
            </asp:Label>
            
          </h1>
            </section>
<!-- Main content -->
        <section class="content">

            <style>
               .Grid  { width:100%; font-size:1.3em; background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}.Grid td {padding: 2px;border: solid 1px #c1c1c1; }.Grid th  {padding : 4px 2px;color: #fff;background: #363670 url(Images/grid-header.png) repeat-x top;border-left: solid 1px #525252;font-size: 0.9em; }.Grid .alt {background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }.Grid .pgr {background: #363670 url(Images/grid-pgr.png) repeat-x top; }.Grid .pgr table { margin: 3px 0; }.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold; color: #fff; line-height: 12px; }.Grid .pgr a { color: Gray; text-decoration: none; }.Grid .pgr a:hover { color: #000; text-decoration: none; }
                        </style>




    <asp:Label ID="lblerror" runat="server"></asp:Label>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:GridView ID="userstatus"  CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
           runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="userstatus_SelectedIndexChanged" >
         <Columns>
             <asp:TemplateField HeaderText="Select Employee">
	<ItemTemplate>
        <asp:Label ID="Label1" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
		<asp:LinkButton ID="lnkEdit" Text="Show Jobs" CommandName="select"  runat="server"></asp:LinkButton>
	</ItemTemplate>
	</asp:TemplateField>
             <asp:BoundField DataField="username" SortExpression="username"  HeaderText="Employee Name" />
                  <asp:BoundField DataField="userstatus" SortExpression="userstatus"  HeaderText="User status" />
             <asp:BoundField DataField="address" SortExpression="address"  HeaderText="        Address      " />
             <asp:BoundField DataField="email" SortExpression="email"  HeaderText="Email Id" />
             <asp:BoundField DataField="telephone" SortExpression="telephone"  HeaderText="Phone Number" />
         </Columns>
     </asp:GridView>
    <asp:Button ID="modelPopup" runat="server" style="display:none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="modelPopup" PopupControlID="updatePanel"
CancelControlID="btnCancel" BackgroundCssClass="tableBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="updatePanel" runat="server" BackColor="White" Height="230px" Width="300px" style="display:none">
    <asp:GridView ID="empjobrelation" runat="server" AutoGenerateColumns="false" OnSorting="empjobrelation_Sorting" AllowSorting="true" OnPageIndexChanging="empjobrelation_PageIndexChanging" AllowPaging="true" PagerSettings-Mode="NumericFirstLast" PageSize="10">
         <EmptyDataRowStyle BackColor="LightBlue"
                        ForeColor="Red" />

                    <EmptyDataTemplate>
                        No Jobs Assigned to this employee.  
                
                    </EmptyDataTemplate>           
         <Columns>
                       
                        
                          <asp:BoundField DataField="name" SortExpression="Assigned Jobs" HeaderText="Job Name" />
                        <asp:BoundField DataField="Status" SortExpression="jobstatus" HeaderText="Job Status" />
                    
                       
                    </Columns>
        
                </asp:GridView>
    <asp:Button ID="btnCancel" runat="server" Text="Close" />
    </asp:Panel>
             
        </section>
    </div>

</asp:Content>
