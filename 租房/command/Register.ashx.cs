using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modal;
using BLL;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 租房.command
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Users u = new Users();
            string name = context.Request["name"].ToString();
            string passwordreg = context.Request["passwordreg"].ToString();
            string passwordcon = context.Request["passwordcon"].ToString();
            string email=context.Request["email"].ToString();
            UsersBLL bll = new UsersBLL();
            u = bll.getUserByName(name);
            if (u != null||passwordreg!=passwordcon)
            {
                context.Response.Write("failed");
            }
            else
            {
                Users s = new Users();
                s.Username = name;
                s.Password = passwordreg;
                s.Email = email;
                s.RoleId = 2;
                bll.Register(s);
                context.Response.Write("success");
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