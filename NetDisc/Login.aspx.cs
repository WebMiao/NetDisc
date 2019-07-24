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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
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
                Session["Username"] = res.Tables[0].Rows[0][1];
                Session["UID"] = res.Tables[0].Rows[0][0];
                Session["UserType"] = res.Tables[0].Rows[0][3];
                //Message.Text = "Hi"+Session["Username"].ToString();
                if (Request["Backpage"] != null)
                    Response.Redirect(Request["Backpage"] + ".aspx");
                else
                    Response.Redirect("Mainpage.aspx");
            }
            else
            {
                Message.Text="OOPs! Invalid username or password! ";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbPassword.Text = null;
            tbUsername.Text = null;
        }
    }
}