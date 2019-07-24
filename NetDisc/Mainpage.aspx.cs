using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                //if (!IsPostBack)
                //{
                //    DataBindGridView();
                //}
                UserType = Session["UserType"].ToString();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (UserType == "teacher")
            {
                Response.Redirect("FileExplorer.html");
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
    }
}