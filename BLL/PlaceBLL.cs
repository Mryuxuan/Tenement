using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using Modal;

namespace BLL
{
    public class PlaceBLL
    {
        PlaceDAL dal = new PlaceDAL();
        public DataSet getPlace(string sql)
        {
            return dal.getPlace(sql);
        }
        public void AddPlace(Place p)
        {
            dal.AddPlace(p);
        }
    }
}