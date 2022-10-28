using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary
{
   public class CheckDatabase
    {
        public SQLiteConnection connectionWithSQL;
        public CheckDatabase()
        {
            connectionWithSQL = new SQLiteConnection("Data Source = Library.sqlite3");
            if (!File.Exists("./Library.sqlite3"))
            {
                SQLiteConnection.CreateFile("Library.sqlite3");
                Console.WriteLine("File has been created.");
            }
        }
        public void openConnection()
        {
            if (connectionWithSQL.State != System.Data.ConnectionState.Open)
            {
                connectionWithSQL.Open();
            }
        }
        public void closeConnection()
        {
            if (connectionWithSQL.State != System.Data.ConnectionState.Closed)
            {
                connectionWithSQL.Close();
            }
        }
    }
}
