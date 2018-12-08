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
    class WindowFormEditUser : Form, IDisposable
    {
        static string connectionString =
        @"Server = LAPTOP-R3VR687R\SQLEXPRESS;Database = ApplicationDataBase; Trusted_Connection = True";// to connectionString me sindeei me thn vasi dedomenwn

        List<int> UserIdsFromComboBox = new List<int>();
        int numberOfSelectedItem;
        private User user;

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private RichTextBox passWordTxt;
        private RichTextBox firstNameTxt;
        private RichTextBox lastNameTxt;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private Button btnCancel;
        private Label label2;
        private ComboBox comboBox1;

        public WindowFormEditUser (User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passWordTxt = new System.Windows.Forms.RichTextBox();
            this.firstNameTxt = new System.Windows.Forms.RichTextBox();
            this.lastNameTxt = new System.Windows.Forms.RichTextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select User by Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Licence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Firstname";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Lastname";
            // 
            // passWordTxt
            // 
            this.passWordTxt.Location = new System.Drawing.Point(231, 144);
            this.passWordTxt.MaxLength = 20;
            this.passWordTxt.Name = "passWordTxt";
            this.passWordTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.passWordTxt.Size = new System.Drawing.Size(163, 29);
            this.passWordTxt.TabIndex = 13;
            this.passWordTxt.Text = "";
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Location = new System.Drawing.Point(24, 143);
            this.firstNameTxt.MaxLength = 20;
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.firstNameTxt.Size = new System.Drawing.Size(167, 30);
            this.firstNameTxt.TabIndex = 15;
            this.firstNameTxt.Text = "";
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.Location = new System.Drawing.Point(24, 203);
            this.lastNameTxt.MaxLength = 20;
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.lastNameTxt.Size = new System.Drawing.Size(167, 31);
            this.lastNameTxt.TabIndex = 16;
            this.lastNameTxt.Text = "";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Super Administrator",
            "UserA",
            "UserB",
            "UserC",
            "Simple User"});
            this.comboBox2.Location = new System.Drawing.Point(231, 213);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(163, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 32);
            this.button1.TabIndex = 22;
            this.button1.Text = "Edit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 29);
            this.button2.TabIndex = 23;
            this.button2.Text = "Delete User";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(39, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 32);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "*Text limit is 20 characters";
            // 
            // WindowFormEditUser
            // 
            this.ClientSize = new System.Drawing.Size(430, 356);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lastNameTxt);
            this.Controls.Add(this.firstNameTxt);
            this.Controls.Add(this.passWordTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "WindowFormEditUser";
            this.Text = "Edit User";
            this.Load += new System.EventHandler(this.WindowFormEditUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void fillComboboxWithUsers()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();
                    string admin = "admin";
                    SqlCommand cmdSelect = new SqlCommand($"SELECT* FROM USERS WHERE Username != '{admin}'", sqlConnection); 

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();

                    SqlDataReader reader = cmdSelect.ExecuteReader();

                        while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                        {
                            //comboBox1.Items.Add(reader.GetString(4)  + "  " + reader.GetString(3) + " (Id: " + reader.GetInt32(0) + " / UserName: " + reader.GetString(2) + " / Licence: " + reader.GetString(5) + ")");
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
            comboBox1.Items.Clear();
           // comboBox2.Items.Clear();
            comboBox1.ResetText();
            passWordTxt.ResetText();
            firstNameTxt.ResetText();
            lastNameTxt.ResetText();
            comboBox2.ResetText();
            UserIdsFromComboBox.Clear();

            button1.Enabled = false; // to edit button
            button2.Enabled = false; // to delete button

        }


        private void WindowFormEditUser_Load(object sender, EventArgs e)
        {
            fillComboboxWithUsers();

            button1.Enabled = false; // to edit button
            button2.Enabled = false; // to delete button
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true; // to edit button
            button2.Enabled = true; // to delete button
            numberOfSelectedItem = comboBox1.SelectedIndex;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    SqlCommand cmdSelect = new SqlCommand($"SELECT* FROM USERS WHERE UserID = '{UserIdsFromComboBox[numberOfSelectedItem]}'", sqlConnection);
                    /*'UserID = '{UserIdsFromComboBox[numberOfSelectedItem]}'*/

                    var returnedDataFromDatabase = cmdSelect.ExecuteScalar();

                    SqlDataReader reader = cmdSelect.ExecuteReader();

                    while (reader.Read()) // o reader diavazei to apotelesma apo to erotima
                    {
                        passWordTxt.Text = reader.GetString(2);
                        comboBox2.Text = reader.GetString(5);
                        firstNameTxt.Text = reader.GetString(3);
                        lastNameTxt.Text = reader.GetString(4);
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            var dbTool = new DataBaseCommunication();
            string message = dbTool.UpdateUser(/*UserIdsFromComboBox[numberOfSelectedItem]*/Convert.ToString(comboBox1.SelectedItem), lastNameTxt.Text, firstNameTxt.Text,Convert.ToString(comboBox2.SelectedItem), passWordTxt.Text);
            MessageBox.Show(message);

            ResetFormTools();
            fillComboboxWithUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dbTool = new DataBaseCommunication();

            string message = dbTool.DeleteUser(Convert.ToString(comboBox1.SelectedItem));
            MessageBox.Show(message);

            ResetFormTools();
            fillComboboxWithUsers();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
