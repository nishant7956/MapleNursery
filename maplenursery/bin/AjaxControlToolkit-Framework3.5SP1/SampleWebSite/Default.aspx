<%@ Page Language="C#" MasterPageFile="~/DefaultMaster.master" AutoEventWireup="true"
    Inherits="CommonPage" Title="ASP.NET AJAX Control Toolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <p>
        Welcome to the ASP.NET AJAX Control Toolkit sample website. Please choose from any
        of the samples on the left.
    </p>
    <br />
    <p>
        <strong><u>Installation Files</u></strong></p>
    <br />
    <p>
        Please visit the
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.codeplex.com/Wiki/View.aspx?ProjectName=AtlasControlToolkit">AJAX Control Toolkit Project Page</asp:HyperLink>
        on CodePlex</p>
    <br />
    <p>
        <strong><u>Release Notes</u></strong></p>
    <br />
    <strong><u>New control</u></strong>
    <ul class="releaseList">
        <li><strong><a href="MultiHandleSlider/MultiHandleSlider.aspx">MultiHandleSlider</a></strong>
            <p>The MultiHandleSlider extender provides a feature-rich extension to a regular asp:Textbox control. It allows
            you to choose a single value, or multiple values in a range, through a graphical slider interface. It supports
            one handle, dual handles, or any number of handles bound to the values of asp:TextBox or asp:Label controls.</p>
            
            <p>It also provides options for read-only access, custom graphic styling, hover and drag handle styles, as well
            as mouse and keyboard support for accessibility.</p>
            
            <p>This control is backwards-compatible and can be used as a drop-in replacement of 
                <a href="Slider/Slider.aspx">the Slider control</a>.</p>
            
            <p>Many thanks to Daniel Crenna for building this.</p></li>
    </ul>
    <br />
    <strong><u>Community effort</u></strong>
    <p>
        This release includes many <a href="http://www.codeplex.com/AtlasControlToolkit/Wiki/View.aspx?title=PatchUtility">
            patch fixes</a> provided by members of the Toolkit community. We would like
        to specially thank all the patch contributors for their effort which helped make
        this release possible. We recognize their names on the <a href="http://www.codeplex.com/AtlasControlToolkit/Wiki/View.aspx?title=PatchHallOfFame">
            Toolkit Patch Hall of Fame</a>.
    </p>
    <br />
    <strong><u>Setting up the environment to use the Toolkit</u></strong>: This Toolkit
    release targets the .NET Framework 3.5 SP1 (3.5.30729.1) and Visual Studio 2008 SP1.<br />
    <br />
    <p>
        <strong><u>Note: </u></strong><strong>Toolkit version 3.5.20820</strong> is <em>only</em>
        for users who are building on top of .NET Framework 3.5 SP1 using Visual Studio 2008 SP1.
        If you are using .NET Framework 2.0 and Visual Studio 2005 then you should use <strong>
            Toolkit version 1.0.20229</strong>.</p>
    <br />
    Link to Toolkit Release <a href="ArchivedReleases.aspx">archive</a>.</asp:Content>
