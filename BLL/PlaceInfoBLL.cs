using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using Modal;
using System.Data.OleDb;

namespace BLL
{
    public class PlaceInfoBLL
    {
        PlaceInfoDAL dal = new PlaceInfoDAL();
        public DataSet getPlaceInfo(string sql)
        {
            return dal.getPlaceInfo(sql);
        }
        public void AddPlaceInfo(placeInfo p)
        {
            dal.AddPlaceInfo(p);
        }
        //public DataSet GetPlaceID(string sql)
        //{
        //    return dal.GetPlaceID(sql);
        //}
        public object GetPlaceID(string sql)
        {
            return dal.GetPlaceID(sql);
        }


    }
}