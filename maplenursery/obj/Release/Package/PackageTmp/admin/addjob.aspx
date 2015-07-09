<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/mas.Master" CodeBehind="addjob.aspx.cs" Inherits="maplenursery.admin.addjob" Async="true" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div>

        <br />
        <asp:Label ID="Lblerror" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Job Title"></asp:Label>
        <br />

        <asp:TextBox ID="JobTitle" runat="server" style="margin-left: 0px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Job Description"></asp:Label>
        <br />
        <asp:TextBox ID="JobDescription" runat="server"></asp:TextBox>
         <br />
         <br />
         <asp:Label ID="Label6" runat="server" Text="Job Location"></asp:Label>
         <br />
         <asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
         <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Assign User"></asp:Label>
        <br />
        <br />
        <br />
         <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <asp:DropDownList ID="LiEmployee" runat="server" > 
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Select Plant"></asp:Label>
        <br />
         <asp:ListView ID="selectedplant" runat="server" GroupItemCount="3" OnItemCommand="selectedplant_ItemCommand" GroupPlaceholderID="groupPlaceHolder" ItemPlaceholderID="itemPlaceHolder" >
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
                  <td>
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
                 <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument ="Delete">Delete</asp:LinkButton>
                          </td>  </ItemTemplate>
         </asp:ListView>
        <%-- <asp:DataList ID="DLselectedplant" RepeatColumns="3" runat="server" OnDeleteCommand="DLselectedplant_DeleteCommand">
             
             <ItemTemplate>
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
                 <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                            </ItemTemplate>
         </asp:DataList>--%>
        <br />
      
        <asp:Button ID="addplant" runat="server" Text="Add Plant" OnClick="addplant_Click" />
      
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"  /><br />
         <br />
    </div>
    
     
        <%-- <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="name" ReadOnly="true" />
            <asp:BoundField DataField="image" HeaderText="Blocked Y/N"/>
                </Columns>
        </asp:GridView>--%>
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
          
    
     <br />
     <br /> 
  <asp:ListView ID="ListView1" runat="server" OnItemCommand="ListView1_ItemCommand" GroupItemCount="3" GroupPlaceholderID="groupPlaceHolder" OnPagePropertiesChanged="ListView1_PagePropertiesChanged" ItemPlaceholderID="itemPlaceHolder" >
      
         <LayoutTemplate>
      <table>
         <tr>
             <th><asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>&nbsp
                <asp:Button ID="btnsearch" runat="server" Text="Search" CommandArgument="search" /></th></tr>
           <tr> <td>
               <table border="0" cellpadding="5">
                  <asp:PlaceHolder runat="server" ID="groupPlaceHolder"></asp:PlaceHolder>
               </table>
            </td></tr><tr>
             <td><asp:Button ID="selectplant" runat="server" Text="select " OnClick="selectplant_Click"  /></td>
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
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("name") %>'/>
                            
                        </div>
                    <asp:Label ID="lblprice1" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                   <asp:Textbox ID="lblquantity" runat="server" Text='<%# Eval("Quantity") %>' Visible="true" ></asp:Textbox>
                       </td>  
                </ItemTemplate>
           
              
           
  </asp:ListView>
</asp:Content>