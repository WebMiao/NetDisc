using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetDisc
{
    public partial class Mainpage : System.Web.UI.Page
    {
        protected string UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] == null)
            {
                Response.Redirect("Login.aspx?Backpage=MainPage");
            }
            else
            {
                btnConfirm.Visible = false;
                Addtable.Visible = false;
                UserType = Session["UserType"].ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (UserType == "teacher")
            {
                Addtable.Visible = true;
                btnConfirm.Visible = true;
            }
            else
            {
                lbMessage.Text = "Sorry, only Authors can add new psots!";
            }
        }

        protected void Unnamed1_Click(object sender, BulletedListEventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from courses where userid=@UN", conn);
            cmd.Parameters.Add("@UN", SqlDbType.Int).Value = Session["UID"];

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);

            Response.Redirect("Course.aspx?coursename=" + res.Tables[0].Rows[e.Index][1].ToString());
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (detecct_duplicate())
            {
                lbMessage.Text = "Error: Course Already Exists!";
                return;
            }
            
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into courses (coursename,userid) values (@CN,@UID)", conn);
            cmd.Parameters.Add("@CN", SqlDbType.VarChar).Value = tbname.Text;
            cmd.Parameters.Add("@UID", SqlDbType.Int).Value = Session["UID"];

            cmd.ExecuteNonQuery();
            cmd.Dispose();

            SqlCommand cmd1 = new SqlCommand("select courseid from courses where coursename=@CN", conn);
            cmd1.Parameters.Add("@CN", SqlDbType.VarChar).Value = tbname.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
            DataSet res = new DataSet();
            adapter.Fill(res);

            string newpath = "D://NetDisc//NetDisc//TestFiles//" + res.Tables[0].Rows[0][0].ToString();

            if (!Directory.Exists(newpath))
            {
                Directory.CreateDirectory(newpath);
            }

            lbMessage.Text = "Insert Successfully!";
        }

        protected bool detecct_duplicate()
        {
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select coursename from courses where coursename=@CN", conn);
            cmd.Parameters.Add("@CN", SqlDbType.VarChar).Value = tbname.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);
            if (res.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}