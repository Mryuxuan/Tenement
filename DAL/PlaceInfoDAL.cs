using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modal;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class PlaceInfoDAL
    {
        database db;
        public PlaceInfoDAL()
        {
            db = new database();
        }
        public DataSet getPlaceInfo(string sql)
        {
            DataSet ds = new DataSet();
            ds = db.GetDataSet(sql);
            return ds;
        }
        public void AddPlaceInfo(placeInfo p)
        {
            string sql = "select top 1 * from PlaceInfo";
            DataSet ds = db.GetDataSet(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr["PlaceID"] = p.PlaceID;
            dr["image"] = p.Image;
            dr["title"] = p.Title;
            dr["Introduction"] = p.Introduction;
            //dr["Price"] = p.Price;
            dr["Introduce"] = p.Introduce;
            //dr["Location"] = p.Location;
            //dr["Traffic"] = p.Traffic;
            //dr["Surrounding"] = p.Surrounding;
            //dr["Information"] = p.Information;
            //dr["Amenities"] = p.Amenities;
            //dr["Fee"] = p.Fee;
            //dr["Tip"] = p.Tip;
            ds.Tables[0].Rows.Add(dr);
            db.UpdateDataset(sql, ds);
        }
        public object GetPlaceID(string sql)
        {
            string result = db.ExecuteScalar(sql).ToString();
            return result;
        }
    }
}