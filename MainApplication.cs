using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IndividualProjectSeptember
{
    public class MainApplication
    {
        public User user;
        public DataBaseCommunication DbTool { get; set; }

        public static bool DatabaseConnected { get; set; }

        public MainApplication(User connectedUser)
        {
            user = connectedUser;
            DbTool = new DataBaseCommunication();
        }

        public static void InformationAboutThisApplication()
        {
            Console.WriteLine("This is an application that users can interact by sending messages." +
                "\r\nThere are five type of Users: " +
                "\r\n - Super Administrator or Administrator who controls all the system. He is application's owner / creator." +
                "\r\n - Simple User who can only send messages to other users." +
                "\r\n - UserA who can send messages to other users and can see other users messages."+
                "\r\n - UserB who can send messages to other users and can see / edit other users messages."+
                "\r\n - UserC who can send messages to other users and can see / edit / delete other users messages." +
                "\r\n\r\n\r\nAll type of users can see / edit / delete their messages." +
                "\r\n\r\nEverybody can register but only as a simple user. Only Adminnistrator can update a user." +
                "\r\nAll users have a unique username." +
                "\r\nUsername can't change.");
        }

        public static string LoginUsernameInput()
        {
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("USERNAME: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string LoginPasswordInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("PASSWORD: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string CommandLine()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\r\n--Command_Line: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string AskUserNameFromUserAndTakeUserName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Give UserName: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string AskPassWordFromUserAndTakePassword()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Give Password: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string AskFirstNameFromUserAndTakeFirstName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Give Firstname: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static string AskLastNameFromUserAndTakeLastName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Give Lastname: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        private void AdministratorRunEnviroment(string uCommand)
        {
           switch(uCommand)
           {
                case "create user":
                    var createdUser = User.createUserByInput();
                    DbTool.CreateUserToDatabase(createdUser.UserName, createdUser.PassWord, createdUser.FirstName, createdUser.LastName, createdUser.Licence);
                    Console.ReadKey(); Console.Clear(); Console.Clear();
                    break;
                case "send message":
                    Application.EnableVisualStyles();
                    Application.Run(new WindowFormSendMessage(user)); Console.Clear();
                    break;
                case "end":
                    Console.WriteLine("\r\nYou logged out!\r\nAplication ended");
                    Environment.Exit(0); Console.Clear();
                    break;
                case "edit user":
                    Application.EnableVisualStyles();
                    Application.Run(new WindowFormEditUser(user)); Console.Clear();
                    break;
                case "help":
                    user.ShowWhatAUserCanDoInTheProgram();
                    Console.ReadKey(); Console.Clear();
                    break;
                case "search user":
                    string searchOption = Menu.SearchUserMethod(), querry = "";
                    string firstName, lastName, userName, licence;
                    switch (searchOption)
                    {
                        case "Firstname and Lastname":
                            firstName = AskFirstNameFromUserAndTakeFirstName(); lastName = AskLastNameFromUserAndTakeLastName();
                            querry = $"SELECT* FROM USERS WHERE Firstname = '{firstName}' AND Lastname = '{lastName}'";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                        case "Username":
                            userName = AskUserNameFromUserAndTakeUserName();
                            querry = $"SELECT* FROM USERS WHERE Username = '{userName}'";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                        case "Licence":
                            Console.Write("Give licence: ");
                            licence = Console.ReadLine();
                            querry = $"SELECT* FROM USERS WHERE Licence = '{licence}'";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                        default:
                            querry = $"SELECT* FROM USERS";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                    }
                    break;

                case "statistics":
                    Application.EnableVisualStyles();
                    Application.Run(new WindowFormStatistics());
                    Console.Clear();
                    break;
                case "my messages":
                    DbTool.ShowUserMessage(user);
                    Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                    break;
                case "edit message":
                    Application.EnableVisualStyles();
                    Application.Run(new WindowFormEditMessage(user));
                    Console.Clear();
                    break;
             } // end first switch
        } // end AdministratorRunEnviroment void

        private void OtherUsersRunEnviroment(string uCommand)
        {
            switch (uCommand)
            {
                case "edit message":
                    Application.EnableVisualStyles();
                    Application.Run(new WindowFormEditMessage(user));
                    Console.Clear();
                    break;
                case "send message":
                    Application.EnableVisualStyles();
                    Application.Run(new WindowFormSendMessage(user));
                    Console.Clear();
                    break;
                case "search user":
                    string searchOption = Menu.SearchUserMethod(), querry = "";
                    string firstName, lastName, userName, licence;
                    switch (searchOption)
                    {
                        case "Firstname and Lastname":
                            firstName = AskFirstNameFromUserAndTakeFirstName(); lastName = AskLastNameFromUserAndTakeLastName();
                            querry = $"SELECT* FROM USERS WHERE Firstname = '{firstName}' AND Lastname = '{lastName}'";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                        case "Username":
                            userName = AskUserNameFromUserAndTakeUserName();
                            querry = $"SELECT* FROM USERS WHERE Username = '{userName}'";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();                           
                            break;
                        case "Licence":
                            Console.Write("Give licence: ");
                            licence = Console.ReadLine();
                            querry = $"SELECT* FROM USERS WHERE Licence = '{licence}'";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                        default:
                            querry = $"SELECT* FROM USERS";
                            Console.WriteLine(DbTool.SearchUserProfile(querry));
                            Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                            break;
                    }
                    break;
                case "help":
                    user.ShowWhatAUserCanDoInTheProgram();
                    Console.ReadKey(); Console.Clear();
                    break;
                case "my messages":
                    DbTool.ShowUserMessage(user);
                    Console.WriteLine("\r\n Press any key..."); Console.ReadKey(); Console.Clear();
                    break;
                case "end":
                    Console.WriteLine("\r\nyou logged out! Aplication ended");
                    Environment.Exit(0); Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }

        public void Run()
        {
            do
            {
                Console.CursorVisible = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\r\n-------  {user.FirstName} {user.LastName} profile  -------");  Console.ResetColor();
                DbTool.NewMessageNotification(user);
                Console.WriteLine(user + "\r\n");
                Console.WriteLine("write 'help' for instructions");

                string uCommand = MainApplication.CommandLine();
                Console.WriteLine();

                if (user.Licence == "Super Administrator")
                    AdministratorRunEnviroment(uCommand);
                else if (user.Licence != "Super Administrator")
                    OtherUsersRunEnviroment(uCommand);
                else
                    Console.WriteLine("something went wrong");

                Console.Clear();
            } while (true);
        }

    }
}
