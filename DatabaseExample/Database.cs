using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseExample
{
    internal class Database
    {
        //for read
        DataTable dTable;
        SqlDataAdapter sqlDA;


        SqlCommand sqlCmd;
        SqlConnection sqlCon;
        string conStr;

        public Database()
        {
            conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Cemalettin\\Desktop\\Csharp Projects\\DatabaseExample\\DatabaseExample\\dbinfo.mdf;Integrated Security=True";
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
        }

        public int cudCMD(string sql)
        {
            sqlCmd = new SqlCommand(sql,sqlCon);
            return sqlCmd.ExecuteNonQuery();
        }

        public DataTable selectCmd(string sql)
        {
            dTable = new DataTable();
            sqlDA = new SqlDataAdapter(sql, conStr);
            sqlDA.Fill(dTable);
            sqlDA.Dispose();
            return dTable;
        }
    }
}
