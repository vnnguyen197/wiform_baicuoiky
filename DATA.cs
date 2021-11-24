//Nguyễn Văn Nguyện CS414H
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMATHANG
{
    class DATA
    {
        String chuoikn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\QLMATHANG\QLMATHANG\QLMATHANG.mdf;Integrated Security=True";
        SqlConnection conn;
        public DATA()
        {
            conn = new SqlConnection(chuoikn);
        }

        public int ThemXoaSua(string sql)
        {
            int kq;
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq;
        }

        public DataTable loadData(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
