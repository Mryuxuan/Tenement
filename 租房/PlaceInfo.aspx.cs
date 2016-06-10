using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using BLL;
using Modal;

namespace 租房
{
    public partial class PlaceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {                
                PlaceInfoBLL bll=new PlaceInfoBLL();
                int id = int.Parse(Context.Request["id"].ToString());
                string sql = "select top 6 * from PlaceInfo where PlaceID="+id;
                DataSet ds = bll.getPlaceInfo(sql);
                DataList1.DataSource = ds.Tables[0];
                DataList1.DataBind();                
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Response.Redirect("Info.aspx?id=" + DataList1.DataKeys[e.Item.ItemIndex].ToString());
        }
    }
}