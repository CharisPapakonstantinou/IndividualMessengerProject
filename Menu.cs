using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IndividualProjectSeptember
{
    public class Menu
    {
        static int index = 0;

        static List<string> indexMenu = new List<string>()
            {
                "Log in",
                "Register",
                "Information about the application",
                "Exit"
            };


        static List<string> licenceMenu = new List<string>()
            {
              //  "Super Administrator",
                "UserA",
                "UserB",
                "UserC",
                "Simple User"
            };

        static List<string> searchUserMenu = new List<string>()
        {
            "Username",
            "Firstname and Lastname",
            "Licence",
            "Show all Users"
        };

        //static List<string> yesNoMenu = new List<string>()
        //{
        //    "Yes",
        //    "No"
        //};


        public static string SelectMenu(List<string> menuItems, int bufferWidthNumber)
        {
            while (true)
            {
                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine(menuItems[i]);
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }

                    Console.ResetColor();
                }

                ConsoleKeyInfo cKey = Console.ReadKey();


                if (cKey.Key == ConsoleKey.DownArrow)
                {
                    if (index == menuItems.Count - 1)
                        index = 0;
                    else
                        index++;
                }
                else if (cKey.Key == ConsoleKey.UpArrow)
                {
                    if (index <= 0)
                        index = menuItems.Count - 1;
                    else
                        index--;
                }
                else if (cKey.Key == ConsoleKey.Enter)
                {
                    return menuItems[index];
                }
                else
                {
                    // return "";
                }

                ClearSpecificAreaOfTheConsole(bufferWidthNumber);

                return "";
            }
        }

        public static string SelectLicenceMethod()
        {
            while (true)
            {
                Console.CursorVisible = false;
                string selectedItem = Menu.SelectMenu(licenceMenu, 5);

                if (selectedItem == "UserA")
                    return selectedItem;
                else if (selectedItem == "UserB")                
                  return selectedItem;
                else if (selectedItem == "UserC")
                    return selectedItem;
                else if (selectedItem == "Simple User")
                    return selectedItem;
                else
                { }
            }
        }

        //public static string YesNoMethod()
        //{
        //    while (true)
        //    {
        //        Console.CursorVisible = false;
        //        string selectedItem = Menu.SelectMenu(yesNoMenu, 3);

        //        if (selectedItem == "Yes")
        //            return selectedItem;
        //        else if (selectedItem == "No")
        //            return selectedItem;
        //        else
        //        { }
        //    }
        //}

        public static void Index()
        {
            while (true)
            {
                Console.CursorVisible = false;

                Console.WriteLine("CHAT APPLICATION");
                string selectedFirstMenuItem =SelectMenu(indexMenu, 6);

                if (selectedFirstMenuItem == "Log in")
                    break;
                else if (selectedFirstMenuItem == "Register")
                {
                    Console.Clear();
                    Console.WriteLine("You will register as a Simple User.\r\nAfter the registration chat with administrator to update you\r\n\r\n");

                    string registerUserName = MainApplication.AskUserNameFromUserAndTakeUserName();
                    string registerPassWord = MainApplication.AskPassWordFromUserAndTakePassword();
                    string registerFirstName = MainApplication.AskFirstNameFromUserAndTakeFirstName();
                    string registerLastName = MainApplication.AskLastNameFromUserAndTakeLastName();

                    DataBaseCommunication dbTool = new DataBaseCommunication();
                    dbTool.CreateUserToDatabase(registerUserName, registerPassWord, registerFirstName, registerLastName, "Simple User");
                    Console.WriteLine("\r\nPress any key to log in...");
                    Console.ReadKey();
                   // break;
                    Console.Clear();
                }
                else if (selectedFirstMenuItem == "Information about the application")
                {
                    Console.Clear();
                    MainApplication.InformationAboutThisApplication();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedFirstMenuItem == "Exit")
                    Environment.Exit(0);
                else
                { }
            }
        }

        public static string SearchUserMethod()
        {
            while (true)
            {
                Console.WriteLine("Search by: ");
                Console.CursorVisible = false;
                string selectedItem = Menu.SelectMenu(searchUserMenu, 6);

                if (selectedItem == "Username")
                    return selectedItem;
                else if (selectedItem == "Firstname and Lastname")
                    return selectedItem;
                else if (selectedItem == "Licence")
                    return selectedItem;
                else if (selectedItem == "Show all Users")
                    return selectedItem;
                else
                { }
            }
        }

        public static void ClearSpecificAreaOfTheConsole(int numberBufferWidth)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? numberBufferWidth : 0));
        }

    }
}
