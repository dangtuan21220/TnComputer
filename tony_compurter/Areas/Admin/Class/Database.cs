using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace tony_compurter.Areas.Admin.Class
{
    public class Database
    {
        //ham tra ve nhieu ban ghi
        public static DataTable ListDataTable(string sql, List<Parameter> parameters)
        {
            //lay chuoi ket noi tu file web.config
            string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //neu co tham so thi hien thi o day
                foreach (Parameter item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.name, item.value);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //do du lieu vao table
                da.Fill(dt);
                return dt;
            }
        }
        //ham tra ve 1 ban ghi
        public static DataRow FirstDataRow(string sql, List<Parameter> parameters)
        {
            //lay chuoi ket noi tu file web.config
            string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //neu co tham so thi hien thi o day
                foreach (Parameter item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.name, item.value);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //do du lieu vao table
                da.Fill(dt);
                //tra ve 1 ban ghi
                return dt.Rows[0];
            }
        }
        //ham thuc thi cau lenh sql
        public static void Execute(string sql, List<Parameter> parameters)
        {
            //lay chuoi ket noi tu file web.config
            string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //neu co tham so thi hien thi o day
                foreach (Parameter item in parameters)
                {
                    cmd.Parameters.AddWithValue(item.name, item.value);
                }
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static DataTable ListDataTable(string sql)
        {
            //lay chuoi ket noi tu file web.config
            string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //do du lieu vao table
                da.Fill(dt);
                return dt;
            }
        }
        public static DataRow FirstDataRow(string sql)
        {
            //lay chuoi ket noi tu file web.config
            string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //do du lieu vao table
                da.Fill(dt);
                //tra ve 1 ban ghi
                return dt.Rows[0];
            }
        }
        public static void Execute(string sql)
        {
            //lay chuoi ket noi tu file web.config
            string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}