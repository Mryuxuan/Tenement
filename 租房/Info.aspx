<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="租房.Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 16px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="outsideinfo" style="height:auto;">       
        <div>            
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" DataKeyField="PlaceInfoID" Height="200px" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <table class="width">
                        <tr style="width:300px;height:200px;" class="text">
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "images"+DataBinder.Eval(Container.DataItem,"image") %>' Height="400px" Width="600px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1" style="height:25px">
                                <asp:Label runat="server" Font-Size="20px" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem,"Introduction") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:300px;height:25px;">
                                <asp:Label ID="Label2" Font-Size="20px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Introduce") %>'></asp:Label>
                            </td>
                        </tr>                        
                    </table>
                </ItemTemplate>
            </asp:DataList>                
        </div>        
    </div>
</asp:Content>
