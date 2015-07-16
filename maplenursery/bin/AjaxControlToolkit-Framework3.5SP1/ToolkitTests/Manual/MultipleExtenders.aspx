<%@ Page
    Language="C#"
    MasterPageFile="~/Default.master"
    AutoEventWireup="true"
    Title="Multiple Extenders Tests" %>

<script runat="server">
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static string[] GetCompletionList(string prefixText, int count)
    {
        return "One-Two-Three-Four-Five".Split('-');
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>This page contains a TextBox with an AutoCompleteExtender and a TextBoxWatermarkExtender hooked up to it.</p>

    <asp:TextBox ID="TextBox1" runat="server" />
    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="TextBox1" ServiceMethod="GetCompletionList"/>
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TextBox1" WatermarkText="[watermark]" WatermarkCssClass="watermarked" />

</asp:Content>
