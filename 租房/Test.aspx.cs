using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.IO;
using Modal;

namespace 租房
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select top 1 * from Place where Places='北京'";
            PlaceInfoBLL bll = new PlaceInfoBLL();
            int id = Convert.ToInt32(bll.GetPlaceID(sql));            
            //Label1.Text = id.ToString();
        }
    }
}