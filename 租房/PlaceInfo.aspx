<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PlaceInfo.aspx.cs" Inherits="租房.PlaceInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outside">
        <center>
        <div>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" DataKeyField="PlaceInfoID" Height="200px" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <table class="width">
                        <tr style="width:300px;height:200px;">
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "images"+DataBinder.Eval(Container.DataItem,"image") %>' Height="230px" Width="380px" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="height:20px">
                                <asp:Label Font-Size="20px" ForeColor="#808080" runat="server" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem,"price") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top:0px;height:20px">
                                <asp:HyperLink ID="HyperLink1" Font-Size="15px" runat="server" NavigateUrl='<%# "Info.aspx?id="+DataBinder.Eval(Container.DataItem,"PlaceInfoID") %>' Text='<%# DataBinder.Eval(Container.DataItem,"title") %>'></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
            </center>
    </div>
</asp:Content>
