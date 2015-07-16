<%@ Page Title="" Language="C#" Async="true" EnableEventValidation="false" MasterPageFile="~/admin/mas.Master" AutoEventWireup="true" CodeBehind="selectplant.aspx.cs" Inherits="maplenursery.admin.selectplant" %>
<asp:Content ID="content2" ContentPlaceHolderID="head" runat="server">
   
</asp:Content> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript"> 
         window.onunload = function (e) {
             opener.document.getElementById('ContentPlaceHolder1_btnHidden').click();
             opener.document.getElementById('btnHidden').click();
         };

</script>
    <asp:Label ID="Lblerror" runat="server"></asp:Label>
      <div class="container">
    <div class="row">
        <form role="form">
            <div class="col-lg-6">
                <asp:ListView ID="ListView1" EnableViewState="true" runat="server" OnItemCommand="ListView1_ItemCommand" GroupItemCount="3" 
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
             <td><input type="button" value="Select" onclick="SetName();" />
                 <asp:Button ID="selectplant" runat="server" Text="select" OnClick="selectplant_Click"  /></td>
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
                             <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Quantity") %>' ></asp:TextBox>
                           
                  <%-- <asp:Textbox ID="lblquantity" runat="server" Text='<%# Eval("Quantity") %>' Visible="true" ></asp:Textbox>--%>
                    </div>   </td>  
                </ItemTemplate>
           
              
           
  </asp:ListView>
                </div>
            </form>
        </div>
          </div>
</asp:Content>
