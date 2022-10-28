using LittleLibrary.Program_Operation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary
{
    class OptionsOfBooks
    {
        WelcomeUser wu = new WelcomeUser();
        CheckDatabase cd;
        string authorName, title;
        int id_book;
        SQLiteDataReader result;
        public OptionsOfBooks()
        {
            cd = new CheckDatabase();
        }
        public void createTable()
        {
            //SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            //cd.openConnection();
            //myCommand.CommandText = "Create TABLE if not exists TableOfBooks(id INT AUTO_INCREMENT PRIMARY KEY, authorName VARCHAR(30) NOT NULL, title VARCHAR(30))";
            //myCommand.ExecuteNonQuery();
            //cd.closeConnection();

            string taskQuerry = "Create TABLE if not exists TableOfBooks(id_book INT AUTO_INCREMENT PRIMARY KEY, authorName VARCHAR(30) NOT NULL, title VARCHAR(30))";
            SQLiteCommand myCommand = new SQLiteCommand(taskQuerry, cd.connectionWithSQL);
            cd.openConnection();
            var result = myCommand.ExecuteReader();
            cd.closeConnection();
        }
        public void insertTable()
        {

            Console.WriteLine("Insert id: ");
            try
            {
                id_book = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INSERT A NUMBER!!");
                Console.ResetColor();
                wu.welcomeUserAgain();
            }
            Console.WriteLine("Insert author name: ");
            authorName = Console.ReadLine();
            Console.WriteLine("Insert title: ");
            title = Console.ReadLine();
            string sentenceInsert = "INSERT OR REPLACE INTO TableOfBooks('id_book', 'authorName', 'title') VALUES (@id_book, @authorName, @title)";
            SQLiteCommand myCommand = new SQLiteCommand(sentenceInsert, cd.connectionWithSQL);
            cd.openConnection();
            myCommand.Parameters.AddWithValue("@id_book", $"{id_book}");
            myCommand.Parameters.AddWithValue($"@authorName", $"{authorName}");
            myCommand.Parameters.AddWithValue("@title", $"{title}");
            try
            {
                var result = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cd.closeConnection();
            // Console.WriteLine($"Rows added: {result}");
        }
        public void selectTable()
        {
            string taskQuery = "Select * FROM TableOfBooks";
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
            if(result == null)
            {
                wu.welcomeUserMethod();
            }
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine($"id_book: {result["id_book"]}author: {result["authorName"]}, title: {result["title"]} ");
                }
            }
            cd.closeConnection();
        }
        public void deleteTable()
        {
            SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            cd.openConnection();
            Console.WriteLine("Enter name by which You want to delete author.");
            string name = Console.ReadLine();
            myCommand.CommandText = $"Delete FROM TableOfBooks WHERE authorName LIKE '%{name}%' ";
            try
            {
            myCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cd.closeConnection();
        }
        public void dropTable()
        {
            SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            cd.openConnection();
            myCommand.CommandText = "DROP TABLE IF EXISTS TableOfBooks";
            myCommand.ExecuteNonQuery();
            cd.closeConnection();
        }
    }
}
