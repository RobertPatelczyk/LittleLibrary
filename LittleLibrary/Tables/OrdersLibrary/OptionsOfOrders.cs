using LittleLibrary.Program_Operation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary.OrdersLibrary
{
    class OptionsOfOrders
    {
        CheckDatabase cd;
        WelcomeUser wu = new WelcomeUser();
        SQLiteDataReader result;
        string authorName, title;
        int id, id_order, book_number, user_id;
        public OptionsOfOrders()
        {
            cd = new CheckDatabase();
        }
        public void createTable()
        {
            SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            cd.openConnection();
            myCommand.CommandText =
               "CREATE TABLE if not exists Orders" +
               "(id INT AUTO_INCREMENT PRIMARY KEY, id_order INT NOT NULL, book_number INT NOT NULL, user_id INT NOT NULL," +
               " FOREIGN KEY(user_id) REFERENCES ListOfUsers(id_customer), FOREIGN KEY(book_number) REFERENCES TableOfBooks(id_book))";
            myCommand.ExecuteNonQuery();
            cd.closeConnection();
        }
        public void insertTable()
        {
            id = cutTheCodeMethod("id");
            id_order = cutTheCodeMethod("id_order");
            book_number = cutTheCodeMethod("book_number");
            user_id = cutTheCodeMethod("user_id");
            string taskQuery = "INSERT OR REPLACE INTO Orders('id', 'id_order', 'book_number', 'user_id') VALUES(@id, @id_order, @book_number, @user_id)";
            SQLiteCommand myCommand = new SQLiteCommand(taskQuery, cd.connectionWithSQL);
            cd.openConnection();
            myCommand.Parameters.AddWithValue("@id", $"{id}");
            myCommand.Parameters.AddWithValue("@id_order", $"{id_order}");
            myCommand.Parameters.AddWithValue("@book_number", $"{book_number}");
            myCommand.Parameters.AddWithValue("@user_id", $"{user_id}");
            var result = myCommand.ExecuteNonQuery();
            try
            {
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cd.closeConnection();

        }
        // try catch method to cut the code
        public int cutTheCodeMethod(string value)
        {
            Console.WriteLine($"Insert {value} : ");
            try
            {
                int name = int.Parse(Console.ReadLine());
                return name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INSERT A NUMBER!!");
                Console.ResetColor();
                wu.welcomeUserAgain();
                return 0;
            }
        }
        public void selectTable()
        {
            //SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            //cd.openConnection();
            //myCommand.CommandText = "SELECT * FROM Orders";
            //myCommand.ExecuteNonQuery();
            //cd.closeConnection();

            string taskQuery = "SELECT * FROM Orders";
            SQLiteCommand myCommand = new SQLiteCommand(taskQuery, cd.connectionWithSQL);
            cd.openConnection();
            try
            {
            result = myCommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if(result==null)
            {
                wu.welcomeUserMethod();
            }
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine($"id_order: {result["id_order"]}, book number: {result["book_number"]},  User id: {result["user_id"]}");
                }
            }
            cd.closeConnection();
        }
        public void deleteTable()
        {
            SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            cd.openConnection();
            Console.WriteLine("Enter name by which You want to delete author.");
            int id = int.Parse(Console.ReadLine());
            myCommand.CommandText = $"Delete FROM Orders WHERE id LIKE '%{id}%' ";
            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cd.closeConnection();
        }
        public void dropTable()
        {
            SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            cd.openConnection();
            myCommand.CommandText = "DROP TABLE IF EXISTS Orders";
            myCommand.ExecuteNonQuery();
            cd.closeConnection();
        }
    }
}
