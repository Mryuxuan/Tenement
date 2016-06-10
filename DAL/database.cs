using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;//可以所有类型数据库
using System.Data.SqlClient;//只能访问sql server
namespace DAL
{
  public   class database
    {
        private string Constr = "Provider=SQLOLEDB;Data Source=.;Persist Security Info=True;User ID=sa;Initial Catalog=Tenement;pwd=";
        private OleDbConnection conn;
        public database()//构造函数
        {
            conn = new OleDbConnection(Constr);
            conn.Open();
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
      // 执行sql命令，返回为dataReader
        public OleDbDataReader GetDataReader(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            OleDbDataReader dr = cmd.ExecuteReader();
            return dr;


        }
        //执行无返回结果的Sql命令
        public int ExecSql(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            int i = 0;
            i = cmd.ExecuteNonQuery();//受影响的行数
            return i;

        }
        //执行SQL命令，返回数据集
        public DataSet GetDataSet(string sql)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        //执行sql命令返回ExecuteScalar
        public object ExecuteScalar(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            string result = cmd.ExecuteScalar().ToString();
            return result;
        }
        //定义一个函数，用数据集来更新物理数据库
        public void UpdateDataset(string sql, DataSet ds)
        {
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            OleDbCommandBuilder CmdBuilder = new OleDbCommandBuilder(da);//用来自动产生sql语句
            da.UpdateCommand = CmdBuilder.GetUpdateCommand();
            da.InsertCommand = CmdBuilder.GetInsertCommand();
            da.DeleteCommand = CmdBuilder.GetDeleteCommand();
            da.Update(ds);

        }
        public void close()
        {
            conn.Close();

        }
    }
}
