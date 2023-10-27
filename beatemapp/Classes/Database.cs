using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace BeatEmApp.Classes
{
    public static class Database
    {
        public static void InsertData(string player1Name, string Player1Email, string player2Name, string player2Email)
        {
            string Connectstring = Properties.Settings.Default.Database1ConnectionString;
            SqlConnection conn = new SqlConnection(Connectstring);
            SqlCommand sqlcmd;
            SqlCommand sqlcmd2;
            string sql = "INSERT INTO PlayerInfo(Naam, Email, Code) VAlUES('" + player1Name + "','" + Player1Email + "', NULL)";
            string sql2 = "INSERT INTO PlayerInfo(Naam, Email, Code) VAlUES('" + player2Name + "','" + player2Email + "', NULL)";
            try {
                conn.Open();
                sqlcmd = new SqlCommand(sql, conn);
                sqlcmd2 = new SqlCommand(sql2, conn);
                sqlcmd.ExecuteNonQuery();
                sqlcmd2.ExecuteNonQuery();
                sqlcmd.Dispose();
                sqlcmd2.Dispose();
                conn.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            return;
        }
    }
}
