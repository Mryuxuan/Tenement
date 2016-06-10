<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="租房._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="CSS/default.css" rel="stylesheet" />
    <link href="CSS/picture.css" rel="stylesheet" />
    <link href="easyui/themes/default/easyui.css" rel="stylesheet" />
    <link href="easyui/themes/icon.css" rel="stylesheet" />
    <link href="easyui/demo.css" rel="stylesheet" />
    <script src="easyui/jquery.min.js"></script>
    <script src="easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#dlglogin').dialog('close');
            $('#dlgregister').dialog('close');
            $('#logincon').click(function () {
                $.post("command/Login.ashx",
                {
                    name: $('#txtusername').val(),
                    password: $('#txtpassword').val()
                },
                function (data) {
                    if (data == "admin") {
                        window.open("Admin/Admin.aspx");
                        $('#alogin').html($('#txtusername').val());
                        $('#dlglogin').dialog('close');
                    }
                    else {
                        if (data == "success") {
                            $('#alogin').html($('#txtusername').val());
                            $('#dlglogin').dialog('close');
                            alert('登录成功!');
                        }
                        else
                            alert('登录失败');
                    }
                })
            });
            $('#registercon').click(function () {
                $.post("command/Register.ashx", {
                    name: $('#usernamereg').val(),
                    passwordreg: $('#passwordreg').val(),
                    passwordcon: $('#passwordcon').val(),
                    email: $('#email').val()
                },
                function (data) {
                    if (data == "success") {
                        alert('注册成功!');
                        $('#dlgregister').dialog('close')
                    }
                    else
                        alert('注册失败!');
                })
            })
        }
        )
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: auto; top: 0px; right: 0px; background-color: #DCDDDB;">
            <div style="width: 100%; height: 100%; top: 0px; right: 0px;" id="bgp" class="images-wrapper">
                <img src="images/bgpicture/bg6.jpg" style="width: 100%; height: 600px;" />
            </div>
            <div class="images-text">
                <span style="font-size: 70px; font-family: 华文新魏;">短租</span>
            </div>
            <div class="images-button">
                <a href="#" onclick="$('#dlglogin').dialog('open')" runat="server" style="text-decoration: none; font-size: 20px; color: white" id="alogin">登录</a>
                <a href="#" onclick="$('#dlgregister').dialog('open')" runat="server" style="text-decoration: none; font-size: 20px; color: white" id="aregister">注册</a>
            </div>

            <div class="easyui-dialog" id="dlglogin" title="登录" data-options="iconCls:'icon-save'">

                <div id="Div1" class="easyui-panel" style="width: 400px; padding: 30px 70px 20px 70px">
                    <div style="margin-bottom: 10px;">
                        <div>用户名:</div>
                        <input class="easyui-textbox" id="txtusername" name="username" style="width: 100%; height: 40px; padding: 12px" data-options="prompt:'请输入用户名:',iconCls:'icon-man',iconWidth:38" />
                    </div>
                    <div style="margin-bottom: 20px;">
                        <div>密码:</div>
                        <input class="easyui-textbox" id="txtpassword" name="password" type="password" style="width: 100%; height: 40px; padding: 12px" data-options="iconCls:'icon-lock',iconWidth:38" />
                    </div>
                    <div style="margin-bottom: 20px;">
                        <input type="checkbox" checked="checked" />
                        <span>记住我</span>
                    </div>
                    <div style="display: inline-block">
                        <a href="#" class="easyui-linkbutton" id="logincon" iconcls="icon-ok" style="width: 120px; height: 32px;">登录</a>
                        <a href="#" class="easyui-linkbutton" onclick="$('#dlgregister').dialog('open'),$('#dlglogin').dialog('close')" iconcls="icon-ok" style="width: 120px; height: 32px;">注册</a>
                    </div>
                </div>
            </div>
            <div class="easyui-dialog" id="dlgregister" title="注册" data-options="iconCls:'icon-save'">
                <div id="Div2" class="easyui-panel" style="width: 400px; padding: 30px 60px" runat="server">
                    <div style="margin-bottom: 20px;">
                        <div>用户名:</div>
                        <input class="easyui-textbox" id="usernamereg" data-options="prompt:'请输入用户名'" style="width: 100%; height: 32px" />
                    </div>
                    <div style="margin-bottom: 20px;">
                        <div>密码:</div>
                        <input class="easyui-textbox" id="passwordreg" type="password" style="width: 100%; height: 32px" />
                    </div>
                    <div style="margin-bottom: 20px;">
                        <div>确认密码:</div>
                        <input class="easyui-textbox" id="passwordcon" type="password" style="width: 100%; height: 32px" />
                    </div>
                    <div style="margin-bottom: 20px;">
                        <div>邮箱:</div>
                        <input class="easyui-textbox" id="email" data-options="prompt:'请输入邮箱',validType:'email'" style="width: 100%; height: 32px" />
                    </div>
                    <div style="display: inline-block">
                        <a href="#" class="easyui-linkbutton" onclick="$('#dlglogin').dialog('open'),$('#dlgregister').dialog('close')" iconcls="icon-ok" style="width: 120px; height: 32px;">登录</a>
                        <a href="#" class="easyui-linkbutton" id="registercon" iconcls="icon-ok" style="width: 120px; height: 32px;">注册</a>
                    </div>
                </div>
            </div>
            <div class="images-content">
                <span style="font-size: 70px; font-family: 华文琥珀;">欢迎回家</span><br />
                <span style="font-size: larger; font-family: 方正喵呜体;">向超过191个国家的当地人租住独一无二的家。</span>
            </div>
            <div style="background-color: #DCDDDB; height: 900px; text-align: center; padding-top: 0px; margin-top: 0px;">
                <div style="padding-top: 60px">
                    <span style="font-size: 35px; text-align: center; line-height: 50px;">探索城市旅游指南</span><br />
                    <span style="font-size: 20px; text-align: center; font-family: 幼圆;">发现离家不远、启发灵感的新房源</span>
                </div>
                <br />
                <br />
                <div style="text-align: center">
                    <center>
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="PlaceID" RepeatColumns="3" OnItemCommand="DataList1_ItemCommand">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" Width="420px" Height="300px" runat="server" CssClass="images-wrapper" ImageUrl='<%# "images"+DataBinder.Eval(Container.DataItem,"image") %>' />
                            <br />
                            <div style="text-align:center;">
                            <asp:LinkButton ID="LinkButton1" Font-Size="20px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Places") %>' Height="28px" Width="104px"></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    </center>
                </div>
                <div style="text-align: center; background-color: #DCDDDB; padding-top: 30px;">
                    <h3>关注我们</h3>
                    <br />
                    <a href="javascript：void(0)" onmouseover="show()" id="weixin" onmouseout="hide()" class="weixin">
                        <img src="images/foot/微信.png" class="foot" style="width: 40px; height: 40px" /></a>&nbsp;&nbsp;&nbsp;&nbsp;
                <a href="javascript：void(0)">
                    <img src="images/foot/微博.png" class="foot" style="width: 40px; height: 40px" /></a>
                    <p style="padding: 20px 0px 0px 0px">@版权所有</p>
                    <br />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
