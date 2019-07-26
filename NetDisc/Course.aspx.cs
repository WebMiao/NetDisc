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
    public partial class Course : System.Web.UI.Page
    {
        string name = "";
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["coursename"];
            lbNewsTitle.Text = name;
            //Show();

            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from courses where coursename=@CN", conn);
            cmd.Parameters.Add("@CN", SqlDbType.VarChar).Value = name;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);

            lbDescription.Text = res.Tables[0].Rows[0][3].ToString();

        }

        protected void btnChat_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx?coursename=" + name);
        }

        protected void btnFile_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from courses where coursename=@CN", conn);
            cmd.Parameters.Add("@CN", SqlDbType.VarChar).Value = name;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet res = new DataSet();
            adapter.Fill(res);
            id = res.Tables[0].Rows[0][0].ToString();

            Response.Redirect("Disk.aspx?coursename=" + name+"&courseid="+id);
        }
    }
}