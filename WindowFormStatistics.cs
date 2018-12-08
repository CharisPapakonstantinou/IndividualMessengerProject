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
    class WindowFormStatistics : Form, IDisposable
    {
        private RichTextBox richTextBox1;
        private Button btnClose;

        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 308);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(288, 250);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // WindowFormStatistics
            // 
            this.ClientSize = new System.Drawing.Size(340, 353);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnClose);
            this.Name = "WindowFormStatistics";
            this.Text = "System Statistics";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.ResumeLayout(false);

        }

        public WindowFormStatistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            DataBaseCommunication dbTool = new DataBaseCommunication();
            string querry1 = "SELECT COUNT(UserID) FROM USERS";
            string querry2 = "SELECT COUNT(UserID) FROM DELETEDUSERS";
            string querry3 = "SELECT COUNT(MessageID) FROM MESSAGES";
            string querry4 = "SELECT COUNT(DISTINCT MessageID) FROM USERSMESSAGES";


            richTextBox1.Text += "MESSAGES AND USERS STATISTICS\r\n\r\n\r\n\r\n\r\n*EXISTNG USERS: " + dbTool.HowManyExistsInDatabase(querry1) + "\r\n\r\n";
            richTextBox1.Text += "*DELETED USERS : "  + dbTool.HowManyExistsInDatabase(querry2)  + "\r\n\r\n";
            richTextBox1.Text += "*TOTAL NUMBER OF SENDED MESSAGES  : " + dbTool.HowManyExistsInDatabase(querry3) + "\r\n\r\n";
            richTextBox1.Text += "*ACTIVE MESSAGES : " + dbTool.HowManyExistsInDatabase(querry4) + "\r\n\r\n*message deactivated when deleted\r\n from sender and from receiver" + "\r\n\r\n";



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
