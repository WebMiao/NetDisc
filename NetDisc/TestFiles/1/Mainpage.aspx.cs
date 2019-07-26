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
        protected List<String> courselist;
        protected void Page_Load(object sender, EventArgs e)
        {
            RequiredFieldValidator1.Enabled = false;
            if (Session["UID"] == null)
            {
                Response.Redirect("Login.aspx?Backpage=Mainpage.aspx");
            }
            else
            {
                Addtable.Visible = false;
                btnConfirm.Visible = false;
                UserType = Session["UserType"].ToString();
                if(UserType == "teacher"){
                    btnAdd.Visible = true;
                    btnEnroll.Visible = false;
                }
                else{
                    btnAdd.Visible = false;
                    btnEnroll.Visible = true;
                }
                BulletedListDataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
                Addtable.Visible = true;
                btnConfirm.Visible = true;
                RequiredFieldValidator1.Enabled = true;
        }

        protected void bulletedlistitem_Click(object sender, BulletedListEventArgs e)
        {
            //lbMessage.Text = courselist[e.Index];

            Response.Redirect("Course.aspx?coursename=" + courselist[e.Index]);          
        }

        protected void BulletedListDataBind()
        {
            SqlConnection conn = new SqlConnection("server=DESKTOP-BBBBQTA\\SQLEXPRESS;UID=123;Password=123;Database=WebDisk");
            conn.Open();

            DataSet res = new DataSet();

            if (UserType == "teacher")
            {
                SqlCommand cmd = new SqlCommand("select coursename from courses where userid=@UID", conn);
                cmd.Parameters.Add("@UID", SqlDbType.Int).Value = Session["UID"];

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                adapter.Fill(res);

                bulletedlist1.DataSource = res;
                bulletedlist1.DataBind();
            }else if(UserType == "student")
            {
                SqlCommand cmd = new SqlCommand("select coursename from courses, enroll where enroll.courseid = courses.courseid AND enroll.userid = @UID",conn);
                cmd.Parameters.Add("@UID", SqlDbType.Int).Value = Session["UID"];

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(res);

                bulletedlist1.DataSource = res;
                bulletedlist1.DataBind();
            }

            courselist = new List<string>();
            for(int i = 0; i < res.Tables[0].Rows.Count; ++i)
            {
                courselist.Add(res.Tables[0].Rows[i][0].ToString());
            }
            
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (detecct_duplicate())
            {
                lbMessage.Text = "Error: Course Already Exists! Please change the course name.";
                return;
            }
            
            SqlConnection conn = new SqlConnection("server=DESKTOP-BBBBQTA\\SQLEXPRESS;UID=123;Password=123;Database=WebDisk");
            conn.Open();

            //insert the course information into the database
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

            //create the folder in the server path
            string newpath = "~//TestFiles//" + res.Tables[0].Rows[0][0].ToString();

            if (!Directory.Exists(newpath))
            {
                Directory.CreateDirectory(Server.MapPath(newpath));
            }

            lbMessage.Text = "Insert Successfully!";
        }

        protected bool detecct_duplicate()
        {
            SqlConnection conn = new SqlConnection("server=DESKTOP-BBBBQTA\\SQLEXPRESS;UID=123;Password=123;Database=WebDisk");
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

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Enroll.aspx");
        }
    }
}