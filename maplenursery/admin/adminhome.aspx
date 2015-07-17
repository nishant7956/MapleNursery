<%@ Page Language="C#" MasterPageFile="~/admin/mas.Master" AutoEventWireup="true" CodeBehind="adminhome.aspx.cs" Inherits="maplenursery.admin.adminhome" Async="true" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="content-wrapper">
        
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            <asp:Label ID="Label1" runat="server" Text="Welcome Admin!!">
                 <asp:Label ID="lblerror" runat="server"></asp:Label>
            </asp:Label>
            
          </h1>
            </section>
<!-- Main content -->
        <section class="content">
          <!-- Small boxes (Stat box) -->
          <div class="row">
            <div class="col-lg-3 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua" style="height:150px;">
                <div class="inner">
                  <h3 style="margin-left:20px; font-size:5em;"><asp:Label ID="txtidle" runat="server"></asp:Label></h3>
                  <p  style="margin-left:20px; margin-top:-10px; font-size:1.4em;"><asp:Label ID="lblidle" runat="server" Text="Idle"></asp:Label></p>
                </div>
                <div class="icon">
                  <i class="ion ion-bag"></i>
                </div>
                <a href="viewemployee.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div>
          <div class="col-lg-3 col-xs-6"  style="height:150px;">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner" >
                  <h3 style="margin-left:20px; font-size:5em;"><asp:Label ID="txtoffwork" runat="server"></asp:Label></h3>
                  <p style="margin-left:20px; margin-top:-10px; font-size:1.4em;"><asp:Label ID="lbloffwork" runat="server" Text="Off work"></asp:Label></p>
                </div>
                <div class="icon">
                  <i class="ion ion-stats-bars"></i>
                </div>
                <a href="viewemployee.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
              <div class="col-lg-3 col-xs-6" style="height:150px;">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3 style="margin-left:20px; font-size:5em;"><asp:Label ID="txtfinished" runat="server"></asp:Label></h3>
                  <p style="margin-left:20px; margin-top:-10px; font-size:1.4em;"><asp:Label ID="lblfinished" runat="server" Text="Finished"></asp:Label></p>
                </div>
                <div class="icon">
                  <i class="ion ion-person-add"></i>
                </div>
                <a href="viewemployee.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div>
               <div class="col-lg-3 col-xs-6" style="height:150px;">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3 style="margin-left:20px; font-size:5em;"><asp:Label ID="txtworking" runat="server"></asp:Label></h3>
                  <p style="margin-left:20px; margin-top:-10px; font-size:1.4em;"><asp:Label ID="lblworking" runat="server" Text="Working"></asp:Label></p>
                </div>
                <div class="icon">
                  <i class="ion ion-pie-graph"></i>
                </div>
                <a href="viewemployee.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div>
    </div>
    <div class="row">
            <!-- Left col -->
            <section class="col-lg-7 connectedSortable" >
              <!-- Custom tabs (Charts with tabs)-->
              <div class="nav-tabs-custom" style="height:220px; max-width:500px">
                <!-- Tabs within a box -->
                <ul class="nav nav-tabs pull-right">
                    
                  <li class="active">Employee Legend</li>
                  <li class="pull-left header" >
                      
                    
                        <asp:Image ID="imggreen" runat="server" ImageUrl="~/Resources/idle.png" Width="12px" Height="20px" />&nbsp;idle &nbsp
                     
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/working.png" Width="20px" Height="22px" />&nbsp;working&nbsp

                       <asp:Image ID="Image2" runat="server" ImageUrl="~/Resources/offwork.png" Width="12px" Height="20px" />&nbsp;off Work&nbsp
                 

                  </li>
                </ul>
                <div class="tab-content no-padding" style="height:205px;">
                  <!-- Morris chart - Sales -->
                             <cc1:GMap ID="GMap1" CssClass="embed-responsive embed-responsive-16by9"
                                  style=" height: 200px; vertical-align:central;  text-align:center;" Height="200" runat="server"
                                  enableDoubleClickZoom="true" enableRotation="true" enableGoogleBar="false"
                                  enableGTrafficOverlay="false" 
                                  enableHookMouseWheelToZoom="True" enableTransitOverlay="True"  mapType="Physical" />
                    
                  <div class="chart tab-pane active" id="revenue-chart" >

                  </div>

                </div>
              </div><!-- /.nav-tabs-custom -->
             
       </section>
         <section class="col-lg-5 connectedSortable" style="height:125px;">

              <!-- Map box --> 
                      <div class="small-box bg-aqua" >
                        <div class="inner" style="height:80px; ">
                  
                          <p> <span style="font-size:4em;"><asp:Label ID="lblusers" runat="server"></asp:Label></span>&nbsp;
                              &nbsp;
                              &nbsp;<span style="margin-left:20px; margin-top:-20px; font-size:1.4em;"><asp:Label ID="Label3" runat="server" Text="Jobs to Assign"></asp:Label></span></p>
                        </div>
                        <div class="icon">
                          <i class="ion ion-bag"></i>
                        </div>
                <a href="viewjobs.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>

             <div class="small-box bg-aqua" >
                        <div class="inner" style="height:150px; ">
                  
                          <p> <span style="margin-left:20px; margin-top:-20px; font-size:1.4em;"><asp:Label ID="Label4" runat="server" Text="Jobs to Assign"></asp:Label></span></p>
                       <span style="">List of news</span>&nbsp;
                              &nbsp;
                              &nbsp;
                             </div>
                        <div class="icon">
                          <i class="ion ion-bag"></i>
                        </div>
                <a href="viewjobs.aspx" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
              
             </section>
        </div>
        
        </section>
    </div>


       
       
       
</asp:Content>
