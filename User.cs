using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectSeptember
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Licence { get; set; }
       // public DataBaseConnection UserAndDatabase { get; set; }


        public User()
        {
        }

        public User(int id, string userName, string passWord, string firstName, string lastName, string licence)
        {
            ID = id;
            UserName = userName;
            PassWord = passWord;
            FirstName = firstName;
            LastName = lastName;
            Licence = licence;
        }

        public static User createUserByInput()
        {
            User createdUser = new User();

            Console.WriteLine("Creation proccess");

            Console.Write("Give Username: ");
            createdUser.UserName = Console.ReadLine();

            Console.Write("Give Password: ");
            createdUser.PassWord = Console.ReadLine();

            Console.Write("Give Firstname: ");
            createdUser.FirstName = Console.ReadLine();

            Console.Write("Give Lastname: ");
            createdUser.LastName = Console.ReadLine();

            Console.WriteLine("Select Licence: ");
            createdUser.Licence = Menu.SelectLicenceMethod();

            
            return createdUser;
        } // end of method

        public void ShowWhatAUserCanDoInTheProgram() // this instance method shows what user can do in the programm
        {
            if (Licence == "Super Administrator")
                SuperAdministratorCommandText();
            else
                OtherUserCommandText();

        } // end of instance method

        private void SuperAdministratorCommandText()
        {
            Console.WriteLine("You logged as SuperAdministrator\r\n" +
                "\r\nCOMMANDS" +
                "\r\n\r\n'create user' to create a user" +
                "\r\n'my messages' to see your messages" +
                "\r\n'search user' to search a user profile" +
                "\r\n'edit user' to edit a user profile" +
                "\r\n'edit message' to edit message" +
                "\r\n'send message' to send a message " +
                "\r\n'statistics' to see system statistics" +
                "\r\n'end' to logout and end the application");
        }

        private void OtherUserCommandText()
        {
            string s = "";
            if (Licence == "UserA")
                s = "You logged as UserA";
            else if (Licence == "UserB")
                s = "You logged as UserB";
            else if (Licence == "UserC")
                s = "You logged as UserC";
            else
                s = "You logged as Simple User";

            Console.WriteLine( s+
                "\r\n\r\nCOMMANDS\r\n" +
                "\r\n'my messages' to see your messages" +
                "\r\n'search user' to search a user profile" +
                "\r\n'edit message' to edit message" +
                "\r\n'send message' to send a message " +
                "\r\n'end' to logout and end the application");
        }

        public override string ToString()
        {

            return "ID: " + ID + 
                "\r\n" + "FirstName: " + FirstName +
                "\r\n" + "Lastname: " + LastName + 
                "\r\n" + "Username: " + UserName +
                "\r\n" + "Password: " + PassWord + 
                "\r\n" + "Licence: " + Licence;
        }


    }
}
