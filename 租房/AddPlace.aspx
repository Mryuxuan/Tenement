<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddPlace.aspx.cs" Inherits="租房.AddPlace" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="images-text" style="text-align: center; height: auto; width: 100%;padding-bottom:150px;">
        <center>
        <table style="width:500px;height:auto;text-align:center;padding-top:20px;">
            <tr>
                <td style="text-align:right">
                    地址:
                </td>
                <td style="text-align:left">
                    <asp:TextBox ID="txtPlace" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">
                    图片:
                </td>
                <td style="text-align:left">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ForeColor="White" Font-Size="20px">提交</asp:LinkButton>
                </td>
            </tr>
        </table>
           </center>
    </div>
</asp:Content>
