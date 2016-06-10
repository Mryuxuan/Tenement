using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Modal;
using System.IO;

namespace 租房
{
    public partial class AddPlace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string dir = "";
            try
            {
            if (FileUpload1.HasFile)
            {
                dir = Server.MapPath("/images/indexpicture/");
                if (File.Exists(dir + FileUpload1.FileName))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('文件已存在!')", true);
                    return;
                }
                FileUpload1.SaveAs(dir + FileUpload1.FileName);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请选择要上传的文件!')", true);
                return;
            }
            Place p = new Place();
            p.Places = txtPlace.Text;
            p.Image = "/indexpicture/"+ FileUpload1.FileName;
            PlaceBLL bll = new PlaceBLL();
            bll.AddPlace(p);
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('数据提交成功!')", true);
            txtPlace.Text = "";
            }
            catch (Exception ee)
            {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('数据提交失败!')", true);
            }
        }
    }
}