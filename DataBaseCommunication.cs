using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IndividualProjectSeptember
{
    public class DataBaseCommunication
    {
        static string connectionString =
         @"Server = LAPTOP-R3VR687R\SQLEXPRESS;Database = ApplicationDataBase; Trusted_Connection = True";// to connectionString me sindeei me thn vasi dedomenwn

        // auth h methodos elegxei an to username kai to password antistoixizetai se kapoia username kai password apo kapoion user ths database
        // ftiaxnei ena object tupou user kai to epistrefei
        // an o user uparxei de tha exei id = 0 
        public static User LogInByUserNameAndPassWord (string userName, string passWord) // login
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            User connectedUser = new User();

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdLogin = new SqlCommand
                            ($"SELECT* FROM USERS WHERE Username = '{userName}' AND Password = '{passWord}'", sqlConnection);

                    var returnedDataFromDatabase = cmdLogin.ExecuteScalar();

                    if (returnedDataFromDatabase == null)
                        Console.WriteLine("Wrong Username / Password !");
                    else
                    {
                        SqlDataReader reader = cmdLogin.ExecuteReader();
                        while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                        {
                            Console.WriteLine("Login completed!");
                            connectedUser.ID = reader.GetInt32(0);
                            connectedUser.UserName = reader.GetString(1);
                            connectedUser.PassWord = reader.GetString(2);
                            connectedUser.FirstName = reader.GetString(3);
                            connectedUser.LastName = reader.GetString(4);
                            connectedUser.Licence = reader.GetString(5);
                        }
                        reader.Close();
                    }


                    // readers must close to connection prepei pantana kleinei
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return connectedUser;

        } // end method
              
        //dhmiourgei kapoion user sthn dt=atabase
        public void CreateUserToDatabase(string userName, string passWord, string firstName, string lastName, string licence) 
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {

                try
                {
                    sqlConnection.Open();

                    // elegxei n to username iparxei // an oi times pou dothikan exoun to katallilo plithos xarakthrwn
                    if (CheckUsername(userName) == true || userName.Count()>20 || passWord.Count() > 20 || firstName.Count() > 20 || lastName.Count() > 20 || licence.Count() > 20)
                    {
                        if (CheckUsername(userName) == true)
                            Console.WriteLine("Username exists. Try another Username.");
                        else
                            Console.WriteLine("The input must be up to 20 characters. Try another input.");
                    }
                    else
                    {
                        SqlCommand cmdInsert = new SqlCommand($"INSERT INTO USERS(Username, PassWord, Firstname, Lastname, Licence) VALUES('{userName}', '{passWord}', '{firstName}', '{lastName}', '{licence}')", sqlConnection);
                        int rowsInserted = cmdInsert.ExecuteNonQuery();
                        if (rowsInserted > 0) // ean einai megalitero apo to mhden mpikan eggrafes
                        {
                            Console.WriteLine("New user created!");
                            Console.WriteLine($"{rowsInserted} user added sucessfully in the database");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();

                }
            }
        } // end of static method

        // epistrefei to profile kapoiou user
        public string SearchUserProfile(string querry) 
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string userProfile = "";

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand(querry, sqlConnection);

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();

                    if (returnedDataFromDatabase == null)
                    {
                        Console.WriteLine("User not found! Try another input...");
                    }

                    SqlDataReader reader = cmdSelect.ExecuteReader();

                    while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                    {
                        userProfile += "\r\n--UserID: " + reader.GetInt32(0)
                                    + "\r\n  Username: " + reader.GetString(1)
                                    + "\r\n  Lastname: " + reader.GetString(3)
                                    + "\r\n  Firstname: " + reader.GetString(4)
                                    + "\r\n  Licence: " + reader.GetString(5) + "\r\n";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return userProfile;
            }
        }

        // stelenei ena minima (kanei add mia eggrafi sto table me ta minimata)
        public string SendMessage (string messageIndex, string  receiverUserName, int receiverUserID, string senderUserName, int senderUserID, string messageDateTime)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string messageShow = "";

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    DateTime tempDateTime = new DateTime();
                    string sDateTime = tempDateTime.ToString();

                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO MESSAGES ( MessageIndex, MessageDateTime, MessageSenderUserName, MessageReceiverUserName) VALUES ( '{messageIndex}', '{messageDateTime}', '{senderUserName}', '{receiverUserName}')", sqlConnection);
                    // molis ginei to insert energopoieitai to trigger Tr_Message_Insert opou kanei duo eggrafes me to messageID sto table USERSMESSAGES

                    int rowsInserted = cmdInsert.ExecuteNonQuery();
                    if (rowsInserted > 0) // ean einai megalitero apo to mhden mpikan eggrafes
                    {
                        messageShow = $"Message Sended!\r\n{rowsInserted - 2} message added sucessfully in the database";
                    }
                    SqlCommand cmdUpdate1 = new SqlCommand($"UPDATE TOP(1) USERSMESSAGES SET  UserID = '{receiverUserID}' WHERE UserID IS NULL", sqlConnection);
                    int rowsEdited = cmdUpdate1.ExecuteNonQuery();
                    SqlCommand cmdUpdate2 = new SqlCommand($"UPDATE TOP(1) USERSMESSAGES SET  UserID = '{senderUserID}' WHERE UserID IS NULL", sqlConnection);
                    int rowsEdited2 = cmdUpdate2.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return messageShow;
            }
        }

        // emfanizei ta minimata tou user apo thn database
        public void ShowUserMessage(User tempUser)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect2 = new SqlCommand($"SELECT USERSMESSAGES.MessageID, MESSAGES.MessageIndex, MESSAGES.MessageDateTime, MESSAGES.MessageSenderUserName, MESSAGES.MessageReceiverUserName FROM USERSMESSAGES INNER JOIN MESSAGES ON USERSMESSAGES.MessageID = MESSAGES.MessageID WHERE USERSMESSAGES.UserID = '{tempUser.ID}'", sqlConnection);

                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE MESSAGES SET MessageIsReaded = '{1}' WHERE MessageReceiverUserName = '{tempUser.UserName}' AND MessageIsReaded = '{0}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();

                    var returnedDataFromDatabase = cmdSelect2.ExecuteScalar();

                    SqlDataReader reader2 = cmdSelect2.ExecuteReader();
                    if (returnedDataFromDatabase == null)
                    {
                        Console.WriteLine("You haven't messages");
                        reader2.Close();
                    }
                    else
                    {
                        string message = "";
                        int nMessage = 0;

                        while (reader2.Read())
                        {
                            message += (++nMessage) + "\r\nMessage ID: " + reader2.GetInt32(0) + "\r\n" 
                               + "From " + reader2.GetString(3) + " to " + reader2.GetString(4) + " at " + reader2.GetString(2) + "\r\n" + "Index: " + reader2.GetString(1) + "\r\n";
                        }
                        Console.WriteLine(message);
                        reader2.Close();

                        if (rowsUpdated > 0)  
                        {
                            // Console.WriteLine("User deleted!");
                            if (rowsUpdated == 1)
                                Console.WriteLine($"{rowsUpdated } new message just readed");
                            else
                                Console.WriteLine($"{rowsUpdated } new messages just readed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        // auth i methodos pairnei ws parametro ena query
        // exei to sugkekrimeno onoma giati provlepetai ta queries pou tha parei na einai COUNT queries
        public int HowManyExistsInDatabase(string querry)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                int returnValue = 0;
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand();
                    cmdSelect.CommandText = querry;
                    cmdSelect.Connection = sqlConnection;

                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }

                   returnValue = count ;

                }
                catch (Exception)
                {
                    returnValue = -20;
                }
                finally
                {
                    sqlConnection.Close();
                }
                return returnValue;
            }
        }

        // diagrafei ena minima apo thn database
        public string DeleteMessage(int tempUsersMessageID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                string returnedMessage = "";
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdDelete = new SqlCommand($"DELETE FROM USERSMESSAGES WHERE UsersMessageID = '{tempUsersMessageID}' ", sqlConnection);
                    int rowsInserted = cmdDelete.ExecuteNonQuery();
                    if (rowsInserted > 0) // ean einai megalitero apo to mhden mpikan eggrafes
                    {
                        returnedMessage += "Message deleted!\r\n";
                        returnedMessage += $"{rowsInserted - 1} message deleted sucessfully from the database";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return returnedMessage;
            }
        }

        // kanei update kapoion user apo thn database
        public string UpdateUser(string username, string newLastname , string newFirstname, string newLicence , string newPassword)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                string returnedMessage = "";
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE USERS SET Lastname = '{newLastname}', Firstname = '{newFirstname}', Licence = '{newLicence}', Password = '{newPassword}' WHERE Username =  '{username}'", sqlConnection);
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    if (rowsUpdated > 0) // ean einai megalitero apo to mhden mpikan eggrafes
                    {
                        returnedMessage += "User Updated!\r\n";
                        returnedMessage += $"{rowsUpdated} rows updated";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }

                return returnedMessage;
            }
        }

        // diagrafei enan user apo thn database
        public string DeleteUser (string userName)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                string message = "";
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdDelete = new SqlCommand($"DELETE USERS WHERE Username = '{userName}'", sqlConnection);
                    int rowsDeleted = cmdDelete.ExecuteNonQuery();

                    if (rowsDeleted > 0)
                    {
                        message = "User deleted"; 
                    }


                }catch(Exception)
                {
                    message = "something went wrong";
                }
                finally
                {
                    sqlConnection.Close();
                }
                return message;
            }

        }

        // elegxei ean to username iparxei sthn database
        public bool CheckUsername(String tempUsername)
        {
            bool passWordOrUsernameExist = false;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelectUsernamePassword = new SqlCommand();
                    cmdSelectUsernamePassword.CommandText = $"SELECT Username, Password FROM USERS WHERE Username = '{tempUsername}'";
                    cmdSelectUsernamePassword.Connection = sqlConnection;

                    var returnedData = cmdSelectUsernamePassword.ExecuteScalar();

                    if (returnedData != null)
                        passWordOrUsernameExist = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return passWordOrUsernameExist;
        }       
        public void NewMessageNotification(User tempUser)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmdSelect = new SqlCommand($"SELECT COUNT(MessageIsReaded) FROM MESSAGES WHERE MessageIsReaded = '{0}' AND MessageReceiverUserName = '{tempUser.UserName}'", sqlConnection);

                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    
                    int tempCount = 0;

                    while (reader.Read())
                    {
                        tempCount = reader.GetInt32(0);
                    }

                    if (tempCount == 1)
                    {
                        Console.Write("\r\nMessages: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(tempCount + " new message\r\n");
                        Console.ResetColor();
                    }
                    else if (tempCount != 0)
                    {
                        Console.Write("\r\nMessages: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(tempCount + " new messages\r\n");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine("\r\nMessages: 0 new messages\r\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string EditMessage(int tempMessageID, string tempMessageIndexUpdate, string tempMessageDateTimeUpdate, string tempMessageSenderUpdate)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string message = "";
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdUpdate = new SqlCommand($"UPDATE MESSAGES SET MessageIndex = '{tempMessageIndexUpdate}', MessageDateTime = '{tempMessageDateTimeUpdate}', MessageSenderUserName = '{tempMessageSenderUpdate}' WHERE MessageID = '{tempMessageID}'", sqlConnection);
                  
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();

                    if (rowsUpdated > 0) // ean einai megalitero apo to mhden mpikan update eggrafes
                    {
                        message = "New index updated";
                    }
                    else
                    {
                        message = "Index not updated";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return message;
        }


        public string EditMessage(int tempMessageID, string tempMessageIndexUpdate)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string message = "";
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdUpdate = new SqlCommand();

                    cmdUpdate.CommandText = $"UPDATE MESSAGES " +
                                            $"SET (MessageIndex = '{tempMessageIndexUpdate}')" +
                                            $"WHERE MessageID = '{tempMessageID}'";

                    cmdUpdate.Connection = sqlConnection;
                    int rowsUpdated = cmdUpdate.ExecuteNonQuery();

                    if (rowsUpdated > 0) // ean einai megalitero apo to mhden mpikan update eggrafes
                    {
                        message = "New index updated";
                    }
                    else
                    {
                        message = "Index not updated";
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return message;
        }
    }
}


