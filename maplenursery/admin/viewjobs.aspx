<%@ Page Title="" Language="C#" MasterPageFile="~/admin/mas.Master" Async="true" AutoEventWireup="true" CodeBehind="viewjobs.aspx.cs" Inherits="maplenursery.admin.viewjobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblerror" runat="server"></asp:Label>
     <asp:GridView ID="rejectedjobs" AutoGenerateColumns="false" runat="server"
          OnSelectedIndexChanged="rejectedjobs_SelectedIndexChanged"
          OnRowDataBound="rejectedjobs_RowDataBound" OnPageIndexChanging="rejectedjobs_PageIndexChanging" 
         PagerSettings-Mode="NumericFirstLast" PageSize="10" AllowPaging="true">
                    <EmptyDataRowStyle BackColor="LightBlue"
                        ForeColor="Red" />

                    <EmptyDataTemplate>
                        No Jobs to Reassign.  
                
                    </EmptyDataTemplate>
                    <Columns>

                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="name" SortExpression="name" HeaderText="Name" />
                        <asp:TemplateField HeaderText="Available Users"
                            SortExpression="user">

                            <ItemTemplate>

                                <asp:DropDownList ID="idleuser"  AutoPostBack="false" runat="server"></asp:DropDownList>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:ButtonField Text="Update" CommandName="Select" ItemStyle-Width="150" />
                        <%-- <asp:CommandField HeaderText="Update" ShowHeader="True"  />--%>
                    </Columns>

                </asp:GridView>
</asp:Content>
