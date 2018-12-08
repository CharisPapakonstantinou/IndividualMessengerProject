using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;


namespace IndividualProjectSeptember
{
    class WindowFormEditMessage : Form
    {

        static string connectionString =
       @"Server = LAPTOP-R3VR687R\SQLEXPRESS;Database = ApplicationDataBase; Trusted_Connection = True";

        //List<User> allUsers= new List<User>();
        List<int> UserIdsFromComboBox = new List<int>(); // i lista pou krataei ta UserID twn users
        List<int> MessageIdsFromComboBox = new List<int>(); // i lista pou krataei ta MessageID twn messages
        int numberOfSelectedItem2; // o integer pou me deixnei thn thesi tou katallhlou MessageID sth lista MessageIdsFromComboBox
        int numberOfSelectedItem; // o integer pou me deixnei thn thesi tou katallhlou  UserID sth lista UserIdsFromComboBox
        private User user;
        string querry = "";

        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label3;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private Label label4;
        private Label label5;
        private Button btnDelete;
        private Label label6;
        private RichTextBox richTextBox4;
        private TextBox textBox1;
        private Label label7;
        private Button btnEdit;
        private Label label8;
        private Label label9;
        private Label label1;

        public WindowFormEditMessage(User user)
        {
            this.user = user;
            InitializeComponent();
        }


        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1 
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(65, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search User by userName";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(478, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(155, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search message by messageID";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(27, 218);
            this.richTextBox1.MaxLength = 250;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(606, 174);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datetime";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(96, 147);
            this.richTextBox2.MaxLength = 20;
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(173, 24);
            this.richTextBox2.TabIndex = 8;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(478, 107);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(155, 23);
            this.richTextBox3.TabIndex = 9;
            this.richTextBox3.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Message Index";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(496, 418);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 34);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete Message";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Receiver";
            // 
            // richTextBox4
            // 
            this.richTextBox4.Location = new System.Drawing.Point(478, 153);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(155, 22);
            this.richTextBox4.TabIndex = 15;
            this.richTextBox4.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(96, 112);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 21);
            this.textBox1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "UM ID";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(337, 418);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 34);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "*Text limit is 250 characters";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "*Text limit is 20 characters";
            // 
            // WindowFormEditMessage
            // 
            this.ClientSize = new System.Drawing.Size(662, 481);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "WindowFormEditMessage";
            this.Text = "Edit Message";
            this.Load += new System.EventHandler(this.WindowFormEditMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MessageIdsFromComboBox.Clear();
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            richTextBox1.Clear();
            richTextBox2.Clear();

            numberOfSelectedItem = comboBox1.SelectedIndex;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand($"SELECT MESSAGES.MessageID FROM USERSMESSAGES INNER JOIN USERS ON USERS.UserID = USERSMESSAGES.UserID INNER JOIN MESSAGES ON USERSMESSAGES.MessageID = MESSAGES.MessageID WHERE USERS.Username = '{comboBox1.SelectedItem.ToString()}'", sqlConnection);

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();
                    SqlDataReader reader = cmdSelect.ExecuteReader();

                    while (reader.Read()) 
                    {
                        MessageIdsFromComboBox.Add(reader.GetInt32(0));
                        comboBox2.Items.Add(reader.GetInt32(0));
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
            }


            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null )
                btnEdit.Enabled = false;
            else
                btnEdit.Enabled = true;

            btnEdit.Enabled = comboBox1.Text == "" ? false : true; // button2 einai to edit button
            btnEdit.Enabled = comboBox2.Text == "" ? false : true; // button2 einai to edit button

        }

        private void fillComboboxWithUsers(string querry)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand(querry, sqlConnection);

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();

                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    while (reader.Read()) 
                    {
                        User comboBoxUser = new User();

                        comboBoxUser.ID = reader.GetInt32(0);
                        comboBoxUser.UserName = reader.GetString(1);
                        comboBoxUser.PassWord = reader.GetString(2);
                        comboBoxUser.Licence = reader.GetString(3);

                        comboBox1.Items.Add(reader.GetString(1));
                        UserIdsFromComboBox.Add(reader.GetInt32(0));
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
            }
        }

        private void ResetFormTools()
        {
            richTextBox1.ResetText();
            richTextBox2.ResetText();
            richTextBox3.ResetText();
            richTextBox4.ResetText();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            comboBox1.ResetText();
            btnEdit.Enabled = false; // to edit button
            btnDelete.Enabled = false;
            textBox1.ResetText();

            UserIdsFromComboBox.Clear();
            MessageIdsFromComboBox.Clear();

        }

        private void WindowFormEditMessage_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false; // to edit button
            btnDelete.Enabled = false;

            richTextBox3.Enabled = false; // sender richTextBox
            richTextBox4.Enabled = false; // receiver richTextBox

            switch (user.Licence)
            {
                case "Simple User":
                    MessageBox.Show("You have Simple User Licence\r\nYou can read - edit - delete your messages");
                    break;
                case "UserA":
                    MessageBox.Show("You have UserA Licence\r\nYou can read - edit - delete your messages\r\nYou can see other users messages");
                    break;
                case "UserB":
                    MessageBox.Show("You have UserB Licence\r\nYou can read - edit - delete your messages\r\nYou can read - edit other users messages ");
                    break;
                case "UserC":
                    MessageBox.Show("You have UserC Licence\r\nYou can read - edit - delete your messages\r\nYou can read - edit - delete other users messages ");
                    break;
                case "Super Administrator":
                    MessageBox.Show("You have Super Administrator Licence\r\nYou can read - edit - delete your messages\r\nYou can read - edit - delete other users messages ");
                    break;
                default:
                    break;
            }

            // ean to Licence to user den einai Simple user ekxwrei to prwto querry alliws to deutero
            querry = user.Licence != "Simple User" ? $"SELECT* FROM USERS" : $"SELECT* FROM USERS WHERE UserID = '{user.ID}'";

            fillComboboxWithUsers(querry);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            numberOfSelectedItem2 = int.Parse(comboBox2.SelectedIndex.ToString());

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();


                    SqlCommand cmdSelect = new SqlCommand($"SELECT MESSAGES.MessageIndex, MESSAGES.MessageDateTime, MESSAGES.MessageReceiverUserName, MESSAGES.MessageSenderUserName, USERSMESSAGES.UsersMessageID FROM USERSMESSAGES INNER JOIN USERS ON USERS.UserID = USERSMESSAGES.UserID INNER JOIN MESSAGES ON USERSMESSAGES.MessageID = MESSAGES.MessageID WHERE USERS.Username = '{comboBox1.SelectedItem.ToString()}' AND USERSMESSAGES.MessageID = '{MessageIdsFromComboBox[numberOfSelectedItem2]}'", sqlConnection);

                    SqlDataReader reader = cmdSelect.ExecuteReader();
                    while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                    {
                        richTextBox1.Text = reader.GetString(0);
                        richTextBox2.Text = reader.GetString(1);
                        richTextBox3.Text = reader.GetString(3);
                        richTextBox4.Text = reader.GetString(2);
                        textBox1.Text = Convert.ToString(reader.GetInt32(4));
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

            }

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (user.Licence == "UserA")
            {
                if (comboBox1.SelectedItem.ToString() == user.UserName)
                {
                    DataBaseCommunication dbTool = new DataBaseCommunication();
                    string returnedMessage = dbTool.DeleteMessage(int.Parse(textBox1.Text));
                    MessageBox.Show(returnedMessage);
                }
                else
                    MessageBox.Show("Delete canceled\r\nYou are a UserA\r\nYou can edit and delete only your messages");
            }
            else if (user.Licence == "Simple User") // ston Simple User den xreiazetai na kanw kapoion elegxo giati einai o monos xrhsths sto combobox me ta usernames
            {                                       // kata to form load den prostithetai to username kapoiou allou xrhsth sto combobox me ta usernames

                DataBaseCommunication dbTool = new DataBaseCommunication();
                string returnedMessage = dbTool.DeleteMessage(int.Parse(textBox1.Text));
                MessageBox.Show(returnedMessage);
            }
            else if (user.Licence == "UserB")
            {
                if (comboBox1.SelectedItem.ToString() == user.UserName)
                {
                    DataBaseCommunication dbTool = new DataBaseCommunication();
                    string returnedMessage = dbTool.DeleteMessage(int.Parse(textBox1.Text));
                    MessageBox.Show(returnedMessage);

                }
                else
                    MessageBox.Show("Delete canceled\r\nYou are a UserB\r\nYou can edit other users messages but you can delete only your messages ");
            }
            else if (user.Licence == "UserC")
            {
                if (comboBox1.SelectedItem.ToString() != "admin")
                {
                    DataBaseCommunication dbTool = new DataBaseCommunication();
                    string returnedMessage = dbTool.DeleteMessage(int.Parse(textBox1.Text));
                    MessageBox.Show(returnedMessage);
                }
                else
                    MessageBox.Show("Delete canceled\r\nYou can not delete this message because it belongs to Administrator");
              
            }
            else
            {
                DataBaseCommunication dbTool = new DataBaseCommunication();
                string returnedMessage = dbTool.DeleteMessage(int.Parse(textBox1.Text));
                MessageBox.Show(returnedMessage);
            }

            ResetFormTools();
            fillComboboxWithUsers(querry);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            //var saveFileDialog1 = new SaveFileDialog
            //{
            //    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            //    Filter = string.Format("{0}Text files (*.txt)|*.txt|All files (*.*)|*.*", ""),
            //    RestoreDirectory = true,
            //    ShowHelp = true,
            //    CheckFileExists = false
            //};

            if (user.Licence == "UserA")
            {
                if (comboBox1.SelectedItem.ToString() == user.UserName)
                {
                    DataBaseCommunication dbTool = new DataBaseCommunication();
                    string message = dbTool.EditMessage(MessageIdsFromComboBox[numberOfSelectedItem2], richTextBox1.Text, richTextBox2.Text, richTextBox3.Text);
                    MessageBox.Show(message);

                    //while (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    //{
                    //    MessageBox.Show("You must save the message");
                    //}
                    //File.WriteAllText(saveFileDialog1.FileName, "Sender UserName: " + richTextBox3.Text + "\r\nDatetime: " + richTextBox2.Text + "\r\nReceiver UserName: " + richTextBox4.Text + "\r\n" + "\r\n" + richTextBox1.Text);
                    //MessageBox.Show("Message saved to a txt file!");
                }
                else
                    MessageBox.Show("Update canceled\r\nYou are a UserA\r\nYou can edit and delete only your messages");
            }
            else if (user.Licence == "Simple User") // ston Simple User den xreiazetai na kanw kapoion elegxo giati einai o monos xrhsths sto combobox me ta usernames
            {                                       // kata to form load den prosthetai to username kapoiou allou xrhsth sto combobox me ta usernames

                DataBaseCommunication dbTool = new DataBaseCommunication();
                string message = dbTool.EditMessage(MessageIdsFromComboBox[numberOfSelectedItem2], richTextBox1.Text, richTextBox2.Text, richTextBox3.Text);
                MessageBox.Show(message);

                //while (saveFileDialog1.ShowDialog() != DialogResult.OK)
                //{
                //    MessageBox.Show("You must save the message");
                //}
                //File.WriteAllText(saveFileDialog1.FileName, "Sender UserName: " + richTextBox3.Text + "\r\nDatetime: " + richTextBox2.Text + "\r\nReceiver UserName: " + richTextBox4.Text + "\r\n" + "\r\n" + richTextBox1.Text);
                //MessageBox.Show("Message saved to a txt file!");
            }

            else if (user.Licence == "UserC" || user.Licence == "UserB")
            {
                if (comboBox1.SelectedItem.ToString() != "admin")
                {
                    DataBaseCommunication dbWformTool = new DataBaseCommunication();
                    string message = dbWformTool.EditMessage(MessageIdsFromComboBox[numberOfSelectedItem2], richTextBox1.Text, richTextBox2.Text, richTextBox3.Text);
                    MessageBox.Show(message);

                    //while (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    //{
                    //    MessageBox.Show("You must save the message");
                    //}
                    //File.WriteAllText(saveFileDialog1.FileName, "Sender UserName: " + richTextBox3.Text + "\r\nDatetime: " + richTextBox2.Text + "\r\nReceiver UserName: " + richTextBox4.Text + "\r\n" + "\r\n" + richTextBox1.Text);
                    //MessageBox.Show("Message saved to a txt file!");
                }
                else
                    MessageBox.Show("You can not edit this message. It belongs to Administrator");
            }
            else
            {
                DataBaseCommunication dbWformTool = new DataBaseCommunication();
                string message = dbWformTool.EditMessage(MessageIdsFromComboBox[numberOfSelectedItem2], richTextBox1.Text, richTextBox2.Text, richTextBox3.Text);
                MessageBox.Show(message);

                //while (saveFileDialog1.ShowDialog() != DialogResult.OK)
                //{
                //    MessageBox.Show("You must save the message");
                //}
                //File.WriteAllText(saveFileDialog1.FileName, "Sender UserName: " + richTextBox3.Text + "\r\nDatetime: " + richTextBox2.Text + "\r\nReceiver UserName: " + richTextBox4.Text + "\r\n" + "\r\n" + richTextBox1.Text);
                //MessageBox.Show("Message saved to txt file!");
            }


            ResetFormTools();
            fillComboboxWithUsers(querry);
        }
    }
}
