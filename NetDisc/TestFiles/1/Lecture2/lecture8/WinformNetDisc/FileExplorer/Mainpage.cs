using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Mainpage : Form
    {
        public string UID = "";
        public string CN = "";
        public Mainpage()
        {
            InitializeComponent();
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {

        }

        private void Btn_course_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;


            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from courses where userid=@UN", conn);
            cmd.Parameters.Add("@UN", SqlDbType.Int).Value =UID;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);

            if (res.Tables[0].Rows.Count != 0)
            {
                    for (int i = 0; i < res.Tables[0].Rows.Count; ++i)
                    {
                        Button newButton = new Button();
                        newButton.Left = 40;
                        newButton.Top = 20+ 120*i;
                        newButton.Width = 120;
                        newButton.Height = 100;
                        newButton.FlatStyle = FlatStyle.Flat;
                        newButton.FlatAppearance.BorderSize = 0;
                        newButton.BackColor = SystemColors.HotTrack;
                        newButton.ForeColor = Color.White;
                        newButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        newButton.Text = res.Tables[0].Rows[i][1].ToString();

                        newButton.Click += new EventHandler(this.button_click);

                        panel3.Controls.Add(newButton);
                    }
            }
            else
            {
                lbMessage.Text = "Sorry You don't have any courses now!";
            }
        }

        private void button_click(object sender,EventArgs e)
        {
            Button dynamicButton = (sender as Button);
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select courseid from courses where coursename=@CN", conn);
            cmd.Parameters.Add("@CN", SqlDbType.VarChar).Value = dynamicButton.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);

            Form1 file = new Form1();
            file.courseid = res.Tables[0].Rows[0][0].ToString();
            file.Show();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        //最小化
        private void Btn_Mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //窗口移动
        Point mouseoff;
        bool leftFlag;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseoff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseoff.X, mouseoff.Y);
                Location = mouseSet;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }
    }
}
