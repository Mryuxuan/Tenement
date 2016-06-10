using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modal;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class PlaceDAL
    {
        database db;
        public PlaceDAL()
        {
            db = new database();
        }
        public DataSet getPlace(string sql)
        {
            DataSet ds;
            ds = db.GetDataSet(sql);
            return ds;
        }
        public void AddPlace(Place p)
        {
            string sql = "select top 1 * from place";
            DataSet ds = db.GetDataSet(sql);
            DataRow dr = ds.Tables[0].NewRow();
            dr["PlaceID"] = p.PlaceID;
            dr["Places"] = p.Places;
            dr["Image"] = p.Image;
            ds.Tables[0].Rows.Add(dr);
            db.UpdateDataset(sql, ds);
        }
    }
}