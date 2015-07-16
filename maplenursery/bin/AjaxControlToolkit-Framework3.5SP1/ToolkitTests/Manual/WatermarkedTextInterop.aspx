<%@ Page
    Language="C#"
    MasterPageFile="~/Default.master"
    AutoEventWireup="true"
    Title="Watermarked Text Interop" %>

<script runat="server">
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <asp:TextBox ID="TextBox1" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TextBox1" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <asp:Label ID="Label1" runat="server" Text="::" />
    <br />
    <input type="button" value="Change Value" onclick="ChangeValue();" />

    <hr />

    <asp:TextBox ID="TextBox2" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="TextBox2" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2" />
    <asp:Label ID="Label2" runat="server" Text="::" />

    <hr />

    <asp:TextBox ID="TextBox3" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="TextBox3" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <ajaxToolkit:PasswordStrength ID="PasswordStrength3" runat="server" TargetControlID="TextBox3" MinimumNumericCharacters="1" HelpStatusLabelID="PasswordStrengthLabel3" />
    <asp:Label ID="Label3" runat="server" Text="::" />
    <br />
    <asp:Label ID="PasswordStrengthLabel3" runat="server" />

    <hr />

    <asp:TextBox ID="TextBox4" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="TextBox4" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="TextBox4" Mask="99/99/9999" MaskType="Date" />
    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlToValidate="TextBox4" ControlExtender="MaskedEditExtender4" IsValidEmpty="False" InvalidValueMessage="INVALID"/>
    <asp:Label ID="Label4" runat="server" Text="::" />

    <hr />

    <asp:TextBox ID="TextBox5" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server" TargetControlID="TextBox5" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="TextBox5" Mask="999,999.99" MaskType="Number" />
    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator5" runat="server" ControlToValidate="TextBox5" ControlExtender="MaskedEditExtender5" IsValidEmpty="False" InvalidValueMessage="INVALID"/>
    <asp:Label ID="Label5" runat="server" Text="::" />

    <hr />

    <asp:TextBox ID="TextBox6" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server" TargetControlID="TextBox6" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="TextBox6" Mask="99:99:99" MaskType="Time" />
    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator6" runat="server" ControlToValidate="TextBox6" ControlExtender="MaskedEditExtender6" IsValidEmpty="False" InvalidValueMessage="INVALID"/>
    <asp:Label ID="Label6" runat="server" Text="::" />

    <hr />

    <asp:TextBox ID="TextBox7" runat="server" />
    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server" TargetControlID="TextBox7" WatermarkText="watermark" WatermarkCssClass="watermarked" />
    <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="TextBox7" Mask="?{10}" />
    <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator7" runat="server" ControlToValidate="TextBox7" ControlExtender="MaskedEditExtender7" IsValidEmpty="False" InvalidValueMessage="INVALID"/>
    <asp:Label ID="Label7" runat="server" Text="::" />

    <hr />

    <script type="text/javascript">
    function ChangeValue() {
        AjaxControlToolkit.TextBoxWrapper.get_Wrapper($get('ctl00_ContentPlaceHolder1_TextBox1')).set_Value("value");
        return false;
    }
    function UpdateLabels() {
        for (var i = 1 ; i <= 7 ; i++) {
            $get("ctl00_ContentPlaceHolder1_Label"+i).innerHTML = ":" + AjaxControlToolkit.TextBoxWrapper.get_Wrapper($get("ctl00_ContentPlaceHolder1_TextBox"+i)).get_Value() + ":";
        }
        return false;
    }
    </script>

    <input type="button" value="Update All Labels" onclick="UpdateLabels();" />

</asp:Content>
