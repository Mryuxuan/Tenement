using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modal;
using System.Data.OleDb;
using System.Data;

namespace DAL
{    
    public class UsersDAL
    {
        database db;
        public UsersDAL()
        {
            db = new database();
        }
        //根据用户名得到用户
        public Users getUserByName(string username)
        {
            Users u = new Users();
            string sql = "select * from Users where Username='" + username + "'";
            OleDbDataReader dr = db.GetDataReader(sql);
            if (dr.Read())
            {
                u.UserId = int.Parse(dr["UserId"].ToString());
                u.Username = dr["Username"].ToString();
                u.Password = dr["Password"].ToString();
                //u.Sex = dr["Sex"].ToString();
                //u.RoleId = int.Parse(dr["RoleId"].ToString());
                u.Email = dr["Email"].ToString();
                return u;
            }
            else
                return null;
        }
        //注册用户
        public void Register(Users u)
        {
            string sql = "select top 1 * from Users";
            DataSet ds = db.GetDataSet(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr["Username"] = u.Username;
            dr["Password"] = u.Password;
            dr["Sex"] = u.Sex;
            dr["RoleId"] = u.RoleId;

            dr["Email"] = u.Email;
            ds.Tables[0].Rows.Add(dr);
            db.UpdateDataset(sql, ds);
        }
        //更新用户
        public int updataUsers(Users u)
        {
            string sql = "update users set UserName ='" + u.Username + "',Password ='" + u.Password + "',Sex='" + u.Sex + "',RoleID='" + u.RoleId + "',Email='" + u.Email + "' where UserId=" + u.UserId;
            int x = db.ExecSql(sql);
            return x;
        }
        //删除用户
        public int deleteUsers(string[] ids)
        {
            string sql = "";
            for (int i = 0; i < ids.Length; i++)
            {
                if(i==0)
                    sql = "delete Users where UserId=" + ids[i];
                else
                    sql = sql + " or UserId=" + ids[i];
            }
            int count = db.ExecSql(sql);
            return count;
        }
        //根据分页得到用户
        public DataSet getUsersByPage(int pageNo, int pageSize, string name)
        {
            string sql = "select top " + pageSize + "  * from Users where UserId not in(select top  " + (pageNo - 1) * pageSize + " UserID from Users where Username like '%" + name + "%') and Username like '%" + name + "%' ";
            DataSet ds = db.GetDataSet(sql);
            return ds;
        }
        //得到用户总数
        public int getUsersCount(string name)
        {
            string sql = "select * from Users where Username like '%" + name + "%'";
            DataSet ds = db.GetDataSet(sql);
            return ds.Tables[0].Rows.Count;
        }
        public DataSet getAllUser()
        {
            string sql = "select * from Users";
            DataSet ds = db.GetDataSet(sql);
            return ds;
        }

    }
}