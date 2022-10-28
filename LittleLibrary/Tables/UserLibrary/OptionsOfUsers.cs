using LittleLibrary.Program_Operation;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary.UserLibrary
{
    class OptionsOfUsers
    {
        CheckDatabase cd;
        SQLiteDataReader reader;
        WelcomeUser wu = new WelcomeUser();
        int id_customer;
        string nick;
        public OptionsOfUsers()
        {
            cd = new CheckDatabase();
        }
        public void createTable()
        {
            //SQLiteCommand myConnection = new SQLiteCommand(cd.connectionWithSQL);
            //cd.openConnection();
            //myConnection.CommandText = "CREATE TABLE ListOfUsers(id_customer INT AUTO_INCREMENT NOT NULL PRIMARY KEY, nick VARCHAR(30) NOT NULL)";
            //myConnection.ExecuteNonQuery();
            //cd.closeConnection();

            string taskQuerry = "CREATE TABLE if not exists ListOfUsers(id_customer INT AUTO_INCREMENT NOT NULL PRIMARY KEY, nick VARCHAR(30) NOT NULL)";
            cd.openConnection();
            SQLiteCommand myCommand = new SQLiteCommand(taskQuerry, cd.connectionWithSQL);
            SQLiteDataReader result = myCommand.ExecuteReader();
            // Console.WriteLine($"Table added: {result}"); ????
            cd.closeConnection();

        }
        public void insertTable()
        {
            Console.WriteLine("Insert customer id: ");
            try
            {
                id_customer = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INSERT A NUMBER!!");
                Console.ResetColor();
                wu.welcomeUserAgain();
            }
            Console.WriteLine("Insert nick: ");
            nick = Console.ReadLine();
            string taskQuery = "INSERT OR REPLACE INTO ListOfUsers(id_customer, nick) VALUES(@id_customer, @nick)";
            SQLiteCommand myCommand = new SQLiteCommand(taskQuery, cd.connectionWithSQL);
            cd.openConnection();
            myCommand.Parameters.AddWithValue("@id_customer", $"{id_customer}");
            myCommand.Parameters.AddWithValue("@nick", $"{nick}");
            try
            {
                var result = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            cd.closeConnection();
        }
        public void selectTable()
        {
            string taskQuery = "SELECT * FROM ListOfUsers";
            SQLiteCommand myCommand = new SQLiteCommand(taskQuery, cd.connectionWithSQL);
            cd.openConnection();
            try
            {
                reader = myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (reader == null)
            {
                wu.welcomeUserAgain();
            }
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id_customer: {reader["id_customer"]}, nick: {reader["nick"]}");
                }
            }
            cd.closeConnection();
        }
        public void deleteTable()
        {
            SQLiteCommand myCommand = new SQLiteCommand(cd.connectionWithSQL);
            cd.openConnection();
            Console.WriteLine("Enter name by which You want to delete author.");
            string nick = Console.ReadLine();
            myCommand.CommandText = $"Delete FROM ListOfUsers WHERE nick LIKE '%{nick}%' ";
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
            myCommand.CommandText = "DROP TABLE IF EXISTS ListOfUsers";
            myCommand.ExecuteNonQuery();
            cd.closeConnection();
        }
    }
}
