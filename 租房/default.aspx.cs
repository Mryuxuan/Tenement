using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace 租房
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                PlaceBLL bll = new PlaceBLL();
                string sql = "select top 6 * from Place order by PlaceID";
                DataSet ds = bll.getPlace(sql);
                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();
            }            
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Response.Redirect("PlaceInfo.aspx?id=" + DataList1.DataKeys[e.Item.ItemIndex].ToString());
        }
    }
}