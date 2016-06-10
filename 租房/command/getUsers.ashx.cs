using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Newtonsoft.Json;
using System.Data;
using Modal;

namespace 租房.command
{
    /// <summary>
    /// getUsers 的摘要说明
    /// </summary>
    public class getUsers : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UsersBLL bll = new UsersBLL();
            if (context.Request["type"].ToString() == "show")
            {
                int pageNo = int.Parse(context.Request["page"].ToString());
                int pageSize = int.Parse(context.Request["rows"].ToString());
                string name = "";
                if (context.Request["username"] != null)
                    name = context.Request["username"].ToString();                
                int count = bll.getUsersCount(name);
                DataSet ds = bll.getUsersByPage(pageNo, pageSize, name);
                string json;
                json = Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0], new Newtonsoft.Json.Converters.DataTableConverter());
                json = "{\"total\":" + count.ToString() + ",\"rows\":" + json + "}";
                context.Response.Write(json);
            }
            else if (context.Request["type"] == "del")
            {
                string ids = context.Request["id"].ToString();
                string [] id=ids.Split(',');
                int count = bll.deleteUsers(id);
                context.Response.Write(count);
            }
            else if (context.Request["type"] == "add")
            {
                Users u = new Users();
                u.Username = context.Request["username"].ToString().Trim();
                u.Password = context.Request["pwd"].ToString();
                u.Sex = context.Request["sex"].ToString().Trim();
                u.RoleId = int.Parse(context.Request["role"].ToString().Trim());
                u.Email = context.Request["email"].ToString();
                bll.Register(u);
                context.Response.Write("添加");
            }
            else if (context.Request["type"] == "edit")
            {
                Users u = new Users();
                u.Username = context.Request["username"].ToString();
                u.Password = context.Request["pwd"].ToString();
                u.Sex = context.Request["sex"].ToString();
                u.RoleId = int.Parse(context.Request["role"].ToString());
                u.Email = context.Request["email"].ToString();
                u.UserId = int.Parse(context.Request["userid"].ToString().Trim());
                bll.updataUsers(u);
                context.Response.Write("更新");
            }
            //context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}