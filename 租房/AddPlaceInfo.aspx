<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddPlaceInfo.aspx.cs" Inherits="租房.AddPlaceInfo" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="kindeditor-4.1.10/plugins/code/prettify.css" rel="stylesheet" />
    <script src="kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script src="kindeditor-4.1.10/plugins/code/code.js"></script>
    <link href="kindeditor-4.1.10/themes/default/default.css" rel="stylesheet" />
    <script src="kindeditor-4.1.10/kindeditor-all.js"></script>
    <script src="kindeditor-4.1.10/kindeditor-all-min.js"></script>
    <script type="text/javascript">
        $(function () {

        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('textarea[name="content"]', {
                resizeType: 1,
                type: 'text',
                dataType:'text',
                allowPreviewEmoticons: false,
                allowImageUpload: false,
                items: [
                    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
            });
        });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%;height:auto;padding-bottom:150px;line-height:inherit;" class="images-text">
        <table>
            <tr>
                <td width="150"></td>
                <td class="tdMiddle" width="200">城市：</td>
                <td class="tdRight">
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="False"></asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="城市编号不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="150"></td>
                <td class="tdMiddle" width="200">图片：</td>
                <td class="tdRight">
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
            </tr>
            <tr>
                <td width="150"></td>
                <td class="tdMiddle" width="200">标题：</td>
                <td class="tdRight">
                    <asp:TextBox ID="title" runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="title" ErrorMessage="标题不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="150"></td>
                <td class="tdMiddle" width="200">介绍：</td>
                <td class="tdRight">
                    <asp:TextBox ID="txtintroduction" runat="server" Width="98px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtintroduction" ErrorMessage="介绍不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="150"></td>
                <td class="tdMiddle" width="200">详细介绍：</td>
                <td class="tdRight">
                    <textarea id="introduce" name="introduce" style="width:700px;height:200px;"></textarea>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Editor" ErrorMessage="详细介绍不能为空！" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td width="150"></td>
                <td class="tdMiddle" width="200">&nbsp;</td>
                <td class="tdRight">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ForeColor="White" Font-Size="20px">提交</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
