using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Modal;
using System.Data;

namespace BLL
{
    public class UsersBLL
    {
        UsersDAL dal = new UsersDAL();
        //根据用户名得到用户
        public Users getUserByName(string username)
        {
            return dal.getUserByName(username);
        }
        //注册用户
        public void Register(Users u)
        {
            dal.Register(u);
        }
        //更新用户
        public int updataUsers(Users u)
        {
            return dal.updataUsers(u);
        }
        //删除用户
        public int deleteUsers(string[] ids)
        {
            return dal.deleteUsers(ids);
        }
        //得到用户总数
        public int getUsersCount(string name)
        {
            return dal.getUsersCount(name);
        }
        //根据分页得到用户
        public DataSet getUsersByPage(int pageNo, int pageSize, string name)
        {
            return dal.getUsersByPage(pageNo, pageSize, name);
        }
        //得到所有用户
        public DataSet getAllUsers()
        {
            return dal.getAllUser();
        }
    }
}