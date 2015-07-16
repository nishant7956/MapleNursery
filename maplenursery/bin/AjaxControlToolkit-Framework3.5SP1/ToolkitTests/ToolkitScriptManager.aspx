<%@ Page Language="C#" MasterPageFile="~/Default.master" Title="ToolkitScriptManagerAndScriptManagerProxy.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="ToolkitScriptManager.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    Result: <span id="result">FAIL</span>

   <script type="text/javascript">
        // (c) Copyright Microsoft Corporation.
        // This source is subject to the Microsoft Permissive License.
        // See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
        // All other rights reserved.

        var typeDependencies = ["ToolkitScriptManagerJsType"];

        // Register the AlwaysVisibleControl test cases
        function registerTests(harness) {
            testHarness = harness;

            // Test the initialization
            var test = testHarness.addTest('ScriptManagerProxy');
            test.addStep(function() {
                testHarness.assertEqual($get("result").innerHTML, "Pass", "ScriptManagerProxy did not include the ScriptReference");
            });
        }
   </script>
</asp:Content>
