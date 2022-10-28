using LittleLibrary.Program_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleLibrary.Tables
{
    class listOfPossibleChoose
    {
        WelcomeUser wu = new WelcomeUser();
        public int choose { get; set; }
        Dictionary<int, string> myList = new Dictionary<int, string>();
        public void choseOption()
        {
            listOfOptions();
            showOptions();
        }
        public void listOfOptions()
        {
            myList.Add(1, "Create");
            myList.Add(2, "Insert");
            myList.Add(3, "Select");
            myList.Add(4, "Delete");
            myList.Add(5, "Drop");
            myList.Add(6, "Back to choose tables");
            myList.Add(7, "Close Program");
        }
        public void showOptions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in myList)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.ResetColor();
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
                wu.welcomeUserMethod();
            }
        }
        public void comfirmChoose()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Type your decision: ");
            Console.ResetColor();
        }
    }
}
