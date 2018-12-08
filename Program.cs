using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;


namespace IndividualProjectSeptember
{
    class Program 
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(Console.BufferWidth, 32766);

            do
            {
                Menu.Index();

                string userName = MainApplication.LoginUsernameInput();
                string passWord = MainApplication.LoginPasswordInput();
           
                User user = DataBaseCommunication.LogInByUserNameAndPassWord(userName, passWord);
                
                //  ean o user den iparxei sthn database tote to id tha einai 0 (default integer value)
                // opws einai domimeno to table users sthn database den ginetai na iparxei user me id = 0
                if (user.ID != 0) // trexei to kurios programma
                {
                    Console.Write("\r\npress any key to continue the app");
                    Console.ReadKey();
                    Console.Clear();
                    MainApplication mainApp = new MainApplication(user);
                    mainApp.Run();
                }

                Console.ReadKey();
                Console.Clear();

            } while (true);
            

        }
    }
}
