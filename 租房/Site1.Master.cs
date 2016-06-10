using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modal;

namespace 租房
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Users"] != null)
            {
                Users u=new Users();
                u=(Users)Session["Users"];
                alogin.InnerHtml = u.Username;
            }
        }
    }
}