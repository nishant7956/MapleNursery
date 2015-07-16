<%@ Page Title="" Language="C#" MasterPageFile="~/admin/mas.Master" Async="true" AutoEventWireup="true" CodeBehind="viewemployee.aspx.cs" Inherits="maplenursery.admin.viewemployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblerror" runat="server"></asp:Label>
     <asp:GridView ID="empjobrelation" runat="server" AutoGenerateColumns="false" OnSorting="empjobrelation_Sorting" AllowSorting="true" OnPageIndexChanging="empjobrelation_PageIndexChanging" AllowPaging="true" PagerSettings-Mode="NumericFirstLast" PageSize="10">
                    <Columns>
                        <asp:BoundField DataField="username" SortExpression="username"  HeaderText="Employee Name" />
                        
                         <asp:BoundField DataField="name" SortExpression="name" HeaderText="Job Name" />
                        <asp:BoundField DataField="jobstatus" SortExpression="jobstatus" HeaderText="Job Status" />
                        <asp:BoundField DataField="userstatus" SortExpression="userstatus"  HeaderText="User status" />
                    </Columns>
                </asp:GridView>
</asp:Content>
