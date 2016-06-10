using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DAL
{
    public class CategoryDAL
    {
        database db = new database();
        //定义一个方法，根据父类别id得到其所有的子类别
        public DataSet getCategoryByParentId(int parentid)
        {
            string sql = "select * from category where parentid=" + parentid;
            DataSet ds = db.GetDataSet(sql);
            return ds;


        }
    }
}