using LittleLibrary.OrdersLibrary;
using LittleLibrary.Program_Operation;
using LittleLibrary.Tables.JoinData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary.Tables.LibraryTable
{
    class ShowActionsOfBooks
    {
        //public int choose { get; set; }
        listOfPossibleChoose lopc = new listOfPossibleChoose();
        OptionsOfBooks oob = new OptionsOfBooks();
        WelcomeUser wu = new WelcomeUser();
        JoinQuerry jq = new JoinQuerry();
        public void listOfBooks()
        {
            lopc.choseOption();
            lopc.comfirmChoose();
            lopc.tryCatchChoose();
            ifWithChoose();
        }
        public void logicOfSwitch()
        {
            switch (lopc.choose)
            {
                case 1:
                    oob.createTable();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Table has been created.");
                    Console.ResetColor();
                    wu.welcomeUserAgain();
                    break;
                case 2:
                    oob.insertTable();
                    wu.welcomeUserAgain();
                    break;
                case 3:
                    oob.selectTable();
                    wu.welcomeUserAgain();
                    break;
                case 4:
                    oob.deleteTable();
                    wu.welcomeUserAgain();
                    break;
                case 5:
                    oob.dropTable();
                    wu.welcomeUserAgain();
                    break;
                case 6:
                    wu.welcomeUserMethod();
                    break;
                case 7:
                    Console.WriteLine("See You soon:)");
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
        public void ifWithChoose()
        {
            if (lopc.choose >= 1 && lopc.choose <= 6)
            {
                logicOfSwitch();  // inject dependency would cut code a lot
            }
            else if (lopc.choose == 7)
            {
                Console.WriteLine("See You soon:).");
            }
            else
            {
                Console.WriteLine("Sorry, We can't understand Your choice. Please try Your path again.");
                wu.welcomeUserMethod();
            }
        }

    }
}
