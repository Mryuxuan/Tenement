using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;

namespace BLL
{
    public class CategoryBLL
    {
        database db = new database();
        CategoryDAL dal = new CategoryDAL();
        //定义一个方法，根据父类别id得到其所有的子类别
        public DataSet getCategoryByParentId(int parentid)
        {
            return dal.getCategoryByParentId(parentid);
        }
    }
}