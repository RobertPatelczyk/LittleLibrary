using LittleLibrary.OrdersLibrary;
using LittleLibrary.Program_Operation;
using LittleLibrary.Tables.JoinData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary.Tables.OrdersLibrary
{
    class ShowActionsOfOrders
    {
        public int choose { get; set; }
        OptionsOfOrders ood = new OptionsOfOrders();
        listOfPossibleChoose lopc = new listOfPossibleChoose();
        WelcomeUser wu = new WelcomeUser();
        JoinQuerry jq = new JoinQuerry();
        public void useOption()
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
                    ood.createTable();
                    wu.welcomeUserAgain();
                    break;
                case 2:
                    ood.insertTable();
                    wu.welcomeUserAgain();
                    break;
                case 3:
                    ood.selectTable();
                    wu.welcomeUserAgain();
                    break;
                case 4:
                    ood.deleteTable();
                    wu.welcomeUserAgain();
                    break;
                case 5:
                    ood.dropTable();
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
                logicOfSwitch();
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

