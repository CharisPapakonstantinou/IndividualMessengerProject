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
    class WindowFormSendMessage : Form, IDisposable
    {
        static string connectionString =
         @"Server = LAPTOP-R3VR687R\SQLEXPRESS;Database = ApplicationDataBase; Trusted_Connection = True";

        //static string textBoxText = "";
        /*static*/ List<int> UserIdsFromComboBox = new List<int>();
        /*static*/ int numberOfSelectedItem;
        private User user;

        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private Button button3;
        private Label label2;
        private RichTextBox richTextBox2;
        private Label label1;

        public WindowFormSendMessage(User user)
        {
            this.user = user;
            InitializeComponent();
            
        }
        //~WindowFormSendMessage()
        //{
        //}

        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 126);
            this.richTextBox1.MaxLength = 250;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(362, 233);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User To Send Message by Username";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(411, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 38);
            this.button3.TabIndex = 5;
            this.button3.Text = "Clear text";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text limit is 250 characters";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox2.Location = new System.Drawing.Point(285, 44);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(258, 62);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // WindowFormSendMessage
            // 
            this.ClientSize = new System.Drawing.Size(573, 421);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "WindowFormSendMessage";
            this.Text = "Send Message";
            this.Load += new System.EventHandler(this.WindowFormSendMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void WindowFormSendMessage_Load(object sender, EventArgs e)
        {
            richTextBox2.Visible = false;

            FillComboboWithUSers();

            button2.Enabled = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string sDateTime = Convert.ToString(DateTime.Now);

            DataBaseCommunication dbWformTool = new DataBaseCommunication();

            string returnString = dbWformTool.SendMessage(richTextBox1.Text,comboBox1.SelectedItem.ToString(), UserIdsFromComboBox[numberOfSelectedItem], user.UserName, user.ID, sDateTime);

            MessageBox.Show(returnString);

            // this code will save the context of the richbox1.text
            var saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = string.Format("{0}Text files (*.txt)|*.txt|All files (*.*)|*.*", ""),
                RestoreDirectory = true,
                ShowHelp = true,
                CheckFileExists = false
            };

            while (saveFileDialog1.ShowDialog() != DialogResult.OK) // epeidi to minima prepei na apothikeuetai oti kai na ginei vasi requirments to parathiro de tha stamatisei na mexri na patithei to button OK
            {
                MessageBox.Show("You must save the message!");
            }
            File.WriteAllText(saveFileDialog1.FileName, "Sender UserName: " + user.UserName + "\r\nDateTime: " + sDateTime + "\r\nReceiver UserName: " + comboBox1.SelectedItem + "\r\n" + "\r\n" + richTextBox1.Text);

            MessageBox.Show("Message saved to a txt file!");

            richTextBox1.ResetText();
            richTextBox2.ResetText();
            UserIdsFromComboBox.Clear();
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            button2.Enabled = false;
            FillComboboWithUSers();

        }

        private void FillComboboWithUSers()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand($"SELECT* FROM USERS WHERE UserID != '{user.ID}'", sqlConnection); // gemizei to combobox me olous tous user ektos tou user pou xrisimopoiei thn efarmogi

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();

                    if (returnedDataFromDatabase == null)
                    {
                        comboBox1.Items.Add("No Users Exist");
                    }
                    else
                    {
                        SqlDataReader reader = cmdSelect.ExecuteReader();

                        while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                        {
                            //comboBox1.Items.Add(reader.GetString(4)  + "  " + reader.GetString(3) + " (Id: " + reader.GetInt32(0) + " / UserName: " + reader.GetString(2) + " / Licence: " + reader.GetString(5) + ")");
                            comboBox1.Items.Add(reader.GetString(1));
                            UserIdsFromComboBox.Add(reader.GetInt32(0));
                        }
                        reader.Close();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Visible = true;

            numberOfSelectedItem = comboBox1.SelectedIndex;
            button2.Enabled = true; // auto einai to send button

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand($"SELECT* FROM USERS WHERE UserID = '{UserIdsFromComboBox[numberOfSelectedItem]}'", sqlConnection);

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();

                    SqlDataReader reader = cmdSelect.ExecuteReader();

                    while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                    {
                        richTextBox2.Text = "UserID: " + reader.GetInt32(0) +"\r\nFirstname: " + reader.GetString(3) + "\r\nLastname: " + reader.GetString(4) + "\r\nLicence: " + reader.GetString(5);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

   
    }
}
