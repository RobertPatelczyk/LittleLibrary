using LittleLibrary.OrdersLibrary;
using LittleLibrary.Tables.JoinData;
using LittleLibrary.Tables.LibraryTable;
using LittleLibrary.Tables.OrdersLibrary;
using LittleLibrary.Tables.UserLibrary;
using LittleLibrary.UserLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary.Program_Operation
{
    class WelcomeUser
    {
        Dictionary<int, string> myList = new Dictionary<int, string>();
        public int choose { get; set; }
        public void welcomeUserMethod()
        {
            Console.WriteLine("Choose on which table you want to take action");
            listOfTypes();
            showTables();
            colorDecision();
            ifChoose();
        }
        public void welcomeUserAgain()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your type has been done. Chose Your action again.");
            Console.ResetColor();
            welcomeUserMethod();
        }
        public void listOfTypes()
        {
            myList.Add(0, "Close Program");
            myList.Add(1, "Table of books");
            myList.Add(2, "Table of orders");
            myList.Add(3, "Table of users");
            myList.Add(4, "Show necessary data");
        }
        public void showTables()
        {
            foreach (var item in myList)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
        public void switchOptions()
        {

            switch (choose)
            {
                case 0:
                    break;
                case 1:
                    ShowActionsOfBooks saob = new ShowActionsOfBooks();
                    saob.listOfBooks();
                    break;
                case 2:
                    ShowActionsOfOrders saod = new ShowActionsOfOrders();
                    saod.useOption();
                    break;
                case 3:
                    ShowActionsOfUsers saou = new ShowActionsOfUsers();
                    saou.useOption();
                    break;
                case 4:
                    JoinQuerry jq = new JoinQuerry();
                    WelcomeUser wu = new WelcomeUser();
                    jq.joinQuerry();
                    wu.welcomeUserAgain();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
        public void ifChoose()
        {
            tryCatchChoose();
            if (choose >= 1 && choose <= 4)
            {
                switchOptions();
            }
            else if (choose == 0)
            {
                Console.WriteLine("See You soon :).");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, We can't understand Your choice. Please try Your path again.");
                Console.ResetColor();
                showTables();
                ifChoose();
                switchOptions();
            }
        }

        public void tryCatchChoose()
        {
            try
            {
              choose = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                showTables();
                colorDecision();
                ifChoose();
            }
        }
        public void colorDecision()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Type your decision: ");
            Console.ResetColor();
        }
    }
}
