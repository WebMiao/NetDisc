using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetDisc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=DESKTOP-BBBBQTA\\SQLEXPRESS;UID=123;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from users where username=@UN", conn);
            cmd.Parameters.Add("@UN", SqlDbType.VarChar, 10).Value = tbUsername.Text;
            IDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Message.Text = "Username Already used. Please select another.";
            }
            else
            {
                SqlCommand count_cmd = new SqlCommand("select * from Users", conn);
                IDataAdapter count_adapter = new SqlDataAdapter(count_cmd);
                DataSet countset = new DataSet();
                count_adapter.Fill(countset);

                SqlCommand insert_cmd = new SqlCommand("insert into Users (username, password, type) values (@UN,@PW,@UT)", conn);
                //insert_cmd.Parameters.Add("@UID", SqlDbType.Int, 10).Value = countset.Tables[0].Rows.Count + 1;
                insert_cmd.Parameters.Add("@UN", SqlDbType.VarChar, 10).Value = tbUsername.Text;
                insert_cmd.Parameters.Add("@PW", SqlDbType.VarChar, 10).Value = tbPassword.Text;

                if (rbTeacher.Checked == true)
                    insert_cmd.Parameters.Add("@UT", SqlDbType.VarChar, 10).Value = "teacher";
                else
                    insert_cmd.Parameters.Add("@UT", SqlDbType.VarChar, 10).Value = "student";
                insert_cmd.ExecuteNonQuery();
                insert_cmd.Dispose();

                //Message.Text = "Successful Registration! Enjoy Reading!";

                Message.Text = "Successful Regodtration! Now redirecting in 3 second...";
                Message.ForeColor = ColorTranslator.FromHtml("#037203");

                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS",
                "setTimeout(function() { window.location.replace('Login.aspx') }, 3000);", true);
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbUsername.Text = null;
            tbPassword.Text = null;
            rbTeacher.Checked = false;
            rbStudent.Checked = false;
        }
    }
}