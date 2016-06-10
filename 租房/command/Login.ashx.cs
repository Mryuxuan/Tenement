using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Modal;
using System.Web.SessionState;

namespace 租房.command
{
    /// <summary>
    /// Logincheck 的摘要说明
    /// </summary>
    public class Logincheck : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Users u = new Users();
            string username = context.Request["name"].ToString().Trim();
            string password = context.Request["password"].ToString().Trim();
            UsersBLL bll = new UsersBLL();
            u = bll.getUserByName(username);
            if (u != null && u.Password == password)
            {
                if (u.Username == "yuxuan")
                {
                    context.Response.Write("admin");
                }
                else
                {
                    context.Session["users"] = u;
                    context.Response.Write("success");
                }
            }
            else
                context.Response.Write("failed");
        }
        //context.Response.Write("Hello World");

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}