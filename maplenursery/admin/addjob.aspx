<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" MasterPageFile="~/admin/mas.Master" CodeBehind="addjob.aspx.cs" Inherits="maplenursery.admin.addjob" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>





<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           
     <asp:Label ID="Lblerror" runat="server"></asp:Label>
     <div class="container">
    <div class="row">
      <%--  <form role="form">
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
        <asp:TextBox ID="txtsearchclient" CssClass="form-control" runat="server" required="true"></asp:TextBox>
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
                <asp:TextBox CssClass="form-control" ID="clientcontact" runat="server" required="true"></asp:TextBox>
                 <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            Email
            <div class="input-group">
                <asp:TextBox CssClass="form-control" ID="clientemail" runat="server" required="true"></asp:TextBox>
                 <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            <asp:Button ID="next" CssClass="btn btn-default btn-flat" runat="server" Text="Next" OnClick="next_Click" />
            </div>
                 </div>
             </form>
        </div>--%>
                    
               
        <form role="form">
            <div class="col-lg-6">
               
                <div class="form-group" id="addjobs" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Job Title"></asp:Label>
        <div class="input-group">
        <asp:TextBox ID="JobTitle" CssClass="form-control" runat="server" style="margin-left: 0px"></asp:TextBox>
       <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
        <asp:Label ID="Label2" runat="server" Text="Job Description"></asp:Label>
        <div class="input-group">
        <asp:TextBox ID="JobDescription" Rows="5"  CssClass="form-control" runat="server"></asp:TextBox>
         <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
         <asp:Label ID="Label6" runat="server" Text="Job Location"></asp:Label>
         <div class="input-group">
         <asp:TextBox ID="txtlocation"  CssClass="form-control" runat="server"></asp:TextBox>
         <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
        <asp:Label ID="Label3" runat="server" Text="Assign User"></asp:Label>
        <br />
                    <div class="input-group">
    <asp:DropDownList Cssclass="form-control input-lg" ID="LiEmployee" runat="server" > 
        </asp:DropDownList>
        <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
         <asp:Label ID="lbldate" runat="server" Text="Start Date"></asp:Label>
        
         <asp:Calendar ID="Calendar1"  runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <br/>
                    
                    <asp:Button ID="addplant" runat="server" CausesValidation="false"    CssClass="btn btn-default btn-flat" Text="Add Content" OnClick="addplant_Click" />
          
<asp:Button ID="btnHidden" runat="Server" 
     style="display:none" OnClick="btnHidden_Click" />
                    <br />
                    <br />
                <asp:ListView ID="selectedplant"  runat="server" GroupItemCount="3" OnItemCommand="selectedplant_ItemCommand" GroupPlaceholderID="groupPlaceHolder" ItemPlaceholderID="itemPlaceHolder" >
             <LayoutTemplate>
      <table>
         
           <tr> <td>
               <table border="0" cellpadding="5">
                  <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
               </table>
            </td></tr>
         
      </table>
             <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="6" >
        <Fields>
              <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
   </LayoutTemplate>
             <GroupTemplate>
      <tr>
         <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
      </tr>
   </GroupTemplate>
              <ItemTemplate>
                  <td runat="server">
                   <img  height="130" width="150" src='<%# Eval("image") %>'>
                               
                            </img>
                 <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("image") %>' Visible="false" />
                 <asp:Label ID="Label5" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                <br /> <asp:Label ID="lblname" runat="server" Text='<%# Eval("name") %>' ></asp:Label>
              <br />Quantity  <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                <br />
                price <asp:Label ID="lblprice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                    <br />
                Total <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("Total") %>'></asp:Label><br />
                      <asp:Button ID="Button2" runat="server" Text="Button" CommandArgument ="Delete" />
                 <asp:LinkButton ID="LinkButton1" runat="server"  CommandArgument ="Delete"  >Delete</asp:LinkButton>
                          </td>  </ItemTemplate>
         </asp:ListView>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server"  CssClass="btn btn-default btn-flat" Text="Save" OnClick="Button1_Click"  />    
                </div>
         
         <%-- <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="name" ReadOnly="true" />
            <asp:BoundField DataField="image" HeaderText="Blocked Y/N"/>
                </Columns>
        </asp:GridView>--%>
      
    </div>
    
     
        <%--    <asp:DataList ID="DataList1" runat="server"  RepeatColumns="3"
     OnItemCommand="DataList1_ItemCommand">
            <HeaderTemplate>
                  <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>&nbsp
                <asp:Button ID="btnsearch" runat="server" Text="Search" CommandArgument="search" />
              </HeaderTemplate>
                <ItemTemplate>
                     
                        <asp:Label ID="LblID" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Visible="false" />
                    <img  height="130" width="150" src='<%# Eval("image") %>'/>
                        <asp:Label ID="description" runat="server" Text ='<%# Eval("description")%>' Visible="false"></asp:Label>
                            
                        
                        <div style="width: 190px; min-height: 30px;">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("name") %>'/>
                            
                        </div>
                    <asp:Label ID="lblprice1" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                   <asp:Textbox ID="lblquantity" runat="server" Text='<%# Eval("Quantity") %>' Visible="true" ></asp:Textbox>
                </ItemTemplate>
            
              
            <FooterTemplate>
                <asp:Button ID="selectplant" runat="server" Text="select " OnClick="selectplant_Click"  />
  
            </FooterTemplate>
            </asp:DataList>--%>
    <%--    <asp:DataList ID="DataList1" runat="server"  RepeatColumns="3"
     OnItemCommand="DataList1_ItemCommand">
            <HeaderTemplate>
                  <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>&nbsp
                <asp:Button ID="btnsearch" runat="server" Text="Search" CommandArgument="search" />
              </HeaderTemplate>
                <ItemTemplate>
                     
                        <asp:Label ID="LblID" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Visible="false" />
                    <img  height="130" width="150" src='<%# Eval("image") %>'/>
                        <asp:Label ID="description" runat="server" Text ='<%# Eval("description")%>' Visible="false"></asp:Label>
                            
                        
                        <div style="width: 190px; min-height: 30px;">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("name") %>'/>
                            
                        </div>
                    <asp:Label ID="lblprice1" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                   <asp:Textbox ID="lblquantity" runat="server" Text='<%# Eval("Quantity") %>' Visible="true" ></asp:Textbox>
                </ItemTemplate>
            
              
            <FooterTemplate>
                <asp:Button ID="selectplant" runat="server" Text="select " OnClick="selectplant_Click"  />
  
            </FooterTemplate>
            </asp:DataList>--%>
    
   <%--  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
         
         <%--<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="popup" TargetControlID="addplant"
    CancelControlID="btnClose" Enabled="true"  BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>--%>
       

 <%-- <asp:ListView ID="ListView1" EnableViewState="true" runat="server" OnItemCommand="ListView1_ItemCommand" GroupItemCount="3" 
      GroupPlaceholderID="groupPlaceHolder" OnPagePropertiesChanged="ListView1_PagePropertiesChanged" ItemPlaceholderID="itemPlaceHolder" >
      
         <LayoutTemplate>
      <table>
         <tr>
             <th><asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>&nbsp
                <asp:Button ID="btnsearch" runat="server"  Text="Search" CommandArgument="search" /></th></tr>
           <tr> <td>
               <table border="0" cellpadding="5">
                  <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
               </table>
            </td></tr><tr>
             <td><asp:Button ID="selectplant" runat="server" Text="select" OnClick="selectplant_Click"  /></td>
         </tr>
         
      </table>
             <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="6" >
            <Fields>
              <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
                NextPageText=" &gt; " PreviousPageText=" &lt; " />
            </Fields>
          </asp:DataPager>
   </LayoutTemplate>

   <GroupTemplate>
      <tr>
         <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
      </tr>
   </GroupTemplate>
                <ItemTemplate>
                  
                         <td>
                        <asp:Label ID="LblID" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Visible="false" />
                    <img  height="130" width="150" src='<%# Eval("image") %>'/>
                        <asp:Label ID="description" runat="server" Text ='<%# Eval("description")%>' Visible="false"></asp:Label>
                            
                        
                        <div style="width: 190px; min-height: 30px;">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("name") %>' AutoPostBack="true"/>
                           
                        
                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("Quantity") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lblprice1" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Quantity") %>' AutoPostBack="true" ></asp:TextBox>
                           
                  <%-- <asp:Textbox ID="lblquantity" runat="server" Text='<%# Eval("Quantity") %>' Visible="true" ></asp:Textbox>
                    </div>   </td>  
                </ItemTemplate>
           
              
           
  </asp:ListView>
       --%>
  
     

         
            </form>
                   </div>
     <asp:Calendar ID="Calendar2"  runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
</div>
</asp:Content>