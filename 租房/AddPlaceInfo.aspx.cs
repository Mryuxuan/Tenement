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
    public partial class AddPlaceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            CategoryBLL bll=new CategoryBLL();
            DataSet ds = bll.getCategoryByParentId(1);
            DropDownList1.DataSource = ds.Tables[0].DefaultView;
            DropDownList1.DataTextField = "desn";
            DropDownList1.DataValueField = "categoryId";
            DropDownList1.DataBind();
            DropDownList1.SelectedIndex = 0;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string sql = "select top 1 * from Place where Places='" + DropDownList1.SelectedItem.Text.ToString().Trim()+"'";
            PlaceInfoBLL bll = new PlaceInfoBLL();
            int id = int.Parse(bll.GetPlaceID(sql).ToString().Trim());
            //string title = Context.Request["title"].ToString().Trim();
            //string txtintroduction = Context.Request["txtintroduction"].ToString().Trim();
            string Introduce =  Context.Request["introduce"].ToString().Trim();
            string dir = "";
            //try
            //{
                if (Directory.Exists(Server.MapPath("images/place/" + DropDownList1.SelectedItem.Text)) == false)
                {
                    //创建用户的文件夹
                    Directory.CreateDirectory(Server.MapPath("images/place/" + DropDownList1.SelectedItem.Text));

                }
                if (FileUpload2.HasFile)
                {
                    dir = Server.MapPath("/images/place/" + DropDownList1.SelectedItem.Text  + "/");
                    if (File.Exists(dir + FileUpload2.FileName))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('文件已存在!')", true);
                        return;
                    }
                    FileUpload2.SaveAs(dir + FileUpload2.FileName);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请选择要上传的文件!')", true);
                    return;
                }
                placeInfo p = new placeInfo();
                p.PlaceID = id;
                p.Image = "/place/" + DropDownList1.SelectedItem.Text +"/"+ FileUpload2.FileName;
                p.Title = title.Text;
                p.Introduction = txtintroduction.Text;
                p.Introduce = Introduce;
                bll.AddPlaceInfo(p);
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('数据提交成功!')", true);
                //title.Text = "";
                //txtintroduction.Text = "";
                //Editor.Text = "";
            //}
            //catch (Exception ee)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('数据提交失败!')", true);
            //}
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}