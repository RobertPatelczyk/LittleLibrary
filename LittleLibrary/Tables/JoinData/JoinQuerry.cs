using LittleLibrary.Program_Operation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LittleLibrary.Tables.JoinData
{
    class JoinQuerry
    {
        CheckDatabase cd;

        public JoinQuerry()
        {
            cd = new CheckDatabase();
        }
        SQLiteDataReader result;
        WelcomeUser wu = new WelcomeUser();
        public void joinQuerry()
        {
            string querry = "SELECT book_number, nick, authorName, title FROM Orders JOIN ListOfUsers ON user_id = id_customer  JOIN  TableOfBooks ON book_number = id_book";
            cd.openConnection();
             var connectionJoinQuerry = new SQLiteConnection(cd.connectionWithSQL);
            SQLiteCommand myComand = new SQLiteCommand(querry, connectionJoinQuerry);
           result = myComand.ExecuteReader();
            while (result.Read())
            {
                Console.WriteLine($"{result.GetInt32(0)}, {result.GetString(1)}, {result.GetString(2)}, {result.GetString(3)}");
            }
            cd.closeConnection();
        }
    }
}
