<%@ Page Language="C#" MasterPageFile="~/admin/mas.Master" AutoEventWireup="true" CodeBehind="adminhome.aspx.cs" Inherits="maplenursery.admin.adminhome" Async="true" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <asp:Label ID="Label1" runat="server" Text="Welcome Admin!!" Font-Bold="True" Font-Size="X-Large"></asp:Label><br />
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-3 col-lg-3 pull-left">
            <div class="panel panel-default height">
                <div class="panel-heading">
                    <asp:Label ID="lblidle" runat="server" Text="Idle Employees"></asp:Label></div>
                <div class="panel-body">
                    <strong>
                        <asp:Label ID="txtidle" runat="server"></asp:Label></strong>
                </div>
            </div>
        </div>

        <div class="col-xs-12 col-md-3 col-lg-3">
            <div class="panel panel-default height">
                <div class="panel-heading">
                    <asp:Label ID="lbloffwork" runat="server" Text="Off work"></asp:Label></div>
                <div class="panel-body">
                    <strong>
                        <asp:Label ID="txtoffwork" runat="server"></asp:Label></strong>
                </div>
            </div>
        </div>

        <div class="col-xs-12 col-md-3 col-lg-3">
            <div class="panel panel-default height">
                <div class="panel-heading">
                    <asp:Label ID="lblfinished" runat="server" Text="Finished"></asp:Label></div>
                <div class="panel-body">
                    <strong>
                        <asp:Label ID="txtfinished" runat="server"></asp:Label></strong>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-md-3 col-lg-3 pull-right">
            <div class="panel panel-default height">
                <div class="panel-heading">
                    <asp:Label ID="lblworking" runat="server" Text="Working"></asp:Label>
                </div>
                <div class="panel-body">
                    <strong>
                        <asp:Label ID="txtworking" runat="server"></asp:Label></strong>
                </div>
            </div>
        </div>
    </div>






    <div class="row">
        <div class="col-sm-6">




            <br />
            <cc1:GMap ID="GMap1" CssClass="embed-responsive embed-responsive-16by9" runat="server" enableDoubleClickZoom="true" enableRotation="true" enableGoogleBar="True" enableGTrafficOverlay="True" enableHookMouseWheelToZoom="True" enableTransitOverlay="True" Height="400px" mapType="Physical" Width="750px" />
        </div>
        <div class="col-sm-2" style="margin-top: 300px">
            <table>
                <tr>
                    <td>
                        <asp:Image ID="imggreen" runat="server" ImageUrl="~/Resources/idle.png" Width="17px" Height="25px" />Idle</td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/working.png" Width="25px" Height="25px" />Working</td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/offwork.png" Width="17px" Height="25px" />Off Work</td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Resources/finished.png" Width="16px" Height="25px" />Finished</td>
                </tr>
            </table>

        </div>
        <div class="col-sm-4">
            <asp:Panel ID="panel1" runat="server">
                Assign Jobs
                 <asp:GridView ID="listofusers" runat="server" AllowPaging="true" PageSize="10" OnPageIndexChanging="listofusers_PageIndexChanging" PagerSettings-Mode="NumericFirstLast" AutoGenerateColumns="False" OnSelectedIndexChanged="listofusers_SelectedIndexChanged" OnRowDataBound="listofusers_RowDataBound">
                     <EmptyDataRowStyle BackColor="LightBlue"
                         ForeColor="Red" />

                     <EmptyDataTemplate>
                         No Data Found.  
                <a href="addjob.aspx">Add New Job</a>
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

                                 <asp:DropDownList ID="idleuser" runat="server"></asp:DropDownList>
                                 <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                 <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                             </ItemTemplate>

                         </asp:TemplateField>
                         <asp:ButtonField Text="Update" CommandName="Select" ItemStyle-Width="150" />
                         <%-- <asp:CommandField HeaderText="Update" ShowHeader="True"  />--%>
                     </Columns>


                 </asp:GridView>
                <%--<asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" />--%><br /><br />Reassign Jobs
                <asp:GridView ID="rejectedjobs" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="rejectedjobs_SelectedIndexChanged" OnRowDataBound="rejectedjobs_RowDataBound" OnPageIndexChanging="rejectedjobs_PageIndexChanging" PagerSettings-Mode="NumericFirstLast" PageSize="10" AllowPaging="true">
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

                                <asp:DropDownList ID="idleuser" runat="server"></asp:DropDownList>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>' Visible="false"></asp:Label>
                            </ItemTemplate>

                        </asp:TemplateField>
                        <asp:ButtonField Text="Update" CommandName="Select" ItemStyle-Width="150" />
                        <%-- <asp:CommandField HeaderText="Update" ShowHeader="True"  />--%>
                    </Columns>

                </asp:GridView><br />
                <br />
                List showing the Employess assigned to different Jobs

                <asp:GridView ID="empjobrelation" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="empjobrelation_PageIndexChanging" AllowPaging="true" PagerSettings-Mode="NumericFirstLast" PageSize="10">
                    <Columns>
                        <asp:BoundField DataField="username" SortExpression="username" HeaderText="Employee Name" />
                        <asp:BoundField DataField="name" SortExpression="jobname" HeaderText="Assigned Jobs" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </div>
        <asp:Label ID="lblerror" runat="server"></asp:Label>
        <br />

        <br />



    </div>

</asp:Content>
