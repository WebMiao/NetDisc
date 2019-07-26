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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from users where username=@UN and password=@PW", conn);
            cmd.Parameters.Add("@UN", SqlDbType.VarChar).Value = tbUsername.Text;
            cmd.Parameters.Add("@PW", SqlDbType.VarChar).Value = tbPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);

            if (res.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Mainpage main_form = new Mainpage();
                main_form.UID = res.Tables[0].Rows[0][0].ToString();
                main_form.Show();
            }
            else
            {
                MessageBox.Show("OOPs! Invalid username or password! ", "Login wrong!");
            }
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
