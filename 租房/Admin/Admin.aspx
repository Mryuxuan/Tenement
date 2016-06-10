<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="租房.Admin.AddUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JS/jquery-1.8.3.js"></script>
    <script type="text/javascript">
        var op;
        var UserId;
        var obj = {
            search: function () {
                $('#usersInfo').datagrid('load', {
                    username: $.trim($('#username').val())
                })
            },
            del: function () {
                var rows = $('#usersInfo').datagrid('getSelections');
                if (!rows || rows.length == 0) {
                    $.messager.alert('提示', '请选择要删除的用户!', 'info');
                    return;
                }
                $.messager.confirm('提示', '是否删除用户', function (r) {
                    if (!r) {
                        return;
                    }
                    var ids = "";
                    for (var i = 0; i < rows.length; i++) {
                        if (i == 0)
                            ids = rows[i].UserId;
                        else
                            ids = ids + ',' + rows[i].UserId;
                    }
                    $.ajax({
                        url: "../command/getUsers.ashx?type=del",
                        type: 'post',
                        data: {
                            id: ids
                        },
                        beforeSend: function () {
                            $('#usersInfo').datagrid('loading');
                        },
                        success: function (data) {
                            $('#usersInfo').datagrid('loaded');
                            $('#usersInfo').datagrid('load');
                            $('#usersInfo').datagrid('unselectAll');
                            $.messager.show({
                                title: '提示',
                                msg: data + "个用户被删除",
                                timeout: 5000,
                                showType: 'slide'
                            })
                        }
                    })
                });
            },
            add: function () {
                $('#dlg').dialog('open');
                //$('#fm').from('clear');               
                op = "add";
            },
            edit: function () {               
                var row = $('#usersInfo').datagrid('getSelected');
                if (row) {
                    $('#dlg').dialog('open').dialog('setTitle', '编辑');
                    UserId=row.UserId;
                    $('#name').val(row.Username);
                    $('#pwd').val(row.Password);
                    //if (row.RoleId == 1)
                    //    $('#role').combobox('setValue', "超级管理员");
                    //else
                    //    $('#role').combobox('setValue', "普通用户");
                    $('#sex').combobox('setValue', row.Sex);
                    $('#email').val(row.Email);
                    op = "edit";
                }
                else
                    $.messager.alert("提示", "请选择数据");
            },
            close: function () {
                $('#dlg').dialog('close');
            },
            save: function () {
                $.ajax({
                    url: '../command/getUsers.ashx?type=' + op,
                    type: 'post',
                    data: {
                        username: $('#name').val(),
                        pwd: $('#pwd').val(),
                        sex: $('#sex').combobox('getValue'),
                        role: $('#role').combobox('getValue'),
                        email: $('#email').val(),
                        userid: UserId
                    },
                    beforesend: function () {
                        $('#usersInfo').datagrid('loading');
                    },
                    success: function (data) {
                        $('#usersInfo').datagrid('loaded');
                        $('#usersInfo').datagrid('load');
                        $('#usersInfo').datagrid('unselectAll');
                        $.messager.show({
                            title: '提示',
                            msg: '一位用户被' + data,
                            timeout: 3000,
                            showtype: 'slide'
                        });
                        $('#dlg').dialog('close');
                    }
                })
            }
        };
        $(function () {
            $('#add').click(function () {
                obj.add();
            });
            $('#edit').click(function () {
                obj.edit();
            })
            $('#usersInfo').datagrid({
                title: '用户列表',
                heigth: 400,
                loadMsg: '正在加载,请稍候...',
                url: "../command/getUsers.ashx?type=show",
                striped: true,
                columns: [[
                    { field: 'ck', checkbox: true },
                    { field: 'UserId', title: '用户编号', hidden: true },
                    { field: 'Username', title: '用户名', width: 100 },
                    { field: 'Password', title: '密码', width: 100 },
                    { field: 'Sex', title: '性别', width: 50 },
                    { field: 'RoleId', title: '权限', width: 50 },
                    { field: 'Email', title: '邮箱', width: 150 }
                ]],
                singleSelect: true,
                rownumbers: true,
                pageSize: 5,
                pageList: [5, 10, 15, 30, 50],
                pagination: true,
                toolbar: '#tb',
                idField: 'UserId'
            });
            var p = $('#UsersInfo').datagrid('getPager');
            $(p).pagination({
                beforePgeText: '第',
                afterPageText: '页   共{pages}页',
                displayMsg: '当前显示{from}-{to}条记录  共{total}条记录'
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="usersInfo">
        <div id="tb">
            <div>
                <a href="#" class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" onclick="obj.add()">添加</a>
                <a href="#" class="easyui-linkbutton" iconcls="icon-edit" plain="true" id="edit" onclick="obj.edit()">编辑</a>
                <a href="#" class="easyui-linkbutton" iconcls="icon-remove" plain="true" id="del" onclick="obj.del()">删除</a>
            </div>
            <div style="padding: 0 0 0 10px">
                请输入用户名<input class="easyui-textbox" id="username" data-options="prompt:'请输入用户名...'" style="width: 200px; height: 25px">
                <a href="#" class="easyui-linkbutton" iconcls="icon-search" onclick="obj.search()" plain="true" id="search">查询</a>
            </div>
        </div>
    </table>
    <div class="easyui-dialog" id="dlg" closed="true" title="用户添加" style="width: 400px">
        <div style="padding: 10px 60px 20px 60px">
            <%--<form id="fm" class="esayui-form" method="post" runat="server" data-options="novalidata:true">--%>
                <table cellpadding="5">
                    <tr>
                        <td>用户名:</td>
                        <td>
                            <input class="easyui-validatebox textbox" type="text" id="name"  missingmessage="姓名不能为空!"
                                data-options="required:true"
                                />
                        </td>
                    </tr>
                    <tr>
                        <td>密码:</td>
                        <td>
                            <input class="easyui-validatebox textbox" type="text" id="pwd" missingmessage="密码不能为空!"
                                data-options="required:true" />
                        </td>
                    </tr>
                    <tr>
                        <td>性别:</td>
                        <td>
                            <select class="easyui-combobox" id="sex"  style="width: 100%" panelheight="auto">
                                <option value="男">男</option>
                                <option value="女">女</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>权限:</td>
                        <td>
                            <select class="easyui-combobox" id="role"  style="width: 100%" panelheight="auto">
                                <option value="1">超级管理员</option>
                                <option value="2">普通用户</option>
                            </select>
                        </td>
                    </tr>                    
                    <tr>
                        <td>邮箱:</td>
                        <td>
                            <input class="easyui-validatebox textbox" type="text" id="email"   missingmessage="邮箱不能为空!"
                                data-options="required:true" />
                        </td>
                    </tr>
                </table>
            <%--</form>--%>
            <div style="text-align: center; padding: 5px">
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-ok'" onclick="obj.save()">确定</a>
                <a href="javascript:void(0)" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'" onclick="obj.close()">关闭</a>
            </div>
        </div>
    </div>
</asp:Content>
