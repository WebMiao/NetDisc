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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected List<int> fullcourselist;
        protected List<int> enrolledcourselist;
        protected List<int> notenrolledList;
        protected List<String> notenrolledName;
        protected void Page_Load(object sender, EventArgs e)
        {
            BulletedListDataBind();
        }

        protected void BulletedListDataBind()
        {
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select courseid from courses", conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet res = new DataSet();
            adapter.Fill(res);

            fullcourselist = new List<int>();
            for (int i = 0; i < res.Tables[0].Rows.Count; ++i)
            {
                fullcourselist.Add(Convert.ToInt32(res.Tables[0].Rows[i][0].ToString()));
            }

            SqlCommand cmd1 = new SqlCommand("select courseid from enroll where userid = @UID", conn);
            cmd1.Parameters.Add("@UID", SqlDbType.Int).Value = Session["UID"];
            adapter = new SqlDataAdapter(cmd1);
            DataSet res1 = new DataSet();
            adapter.Fill(res1);

            enrolledcourselist = new List<int>();
            notenrolledList = new List<int>();
            for (int i = 0; i < res1.Tables[0].Rows.Count; ++i)
            {
                enrolledcourselist.Add(Convert.ToInt32(res1.Tables[0].Rows[i][0].ToString()));
            }

            for (int i = 0; i < fullcourselist.Count; ++i)
            {
                if (!enrolledcourselist.Contains(fullcourselist[i]))
                {
                    notenrolledList.Add(fullcourselist[i]);
                }
            }

            notenrolledName = new List<string>();
            SqlCommand cmd2 = new SqlCommand("select coursename from courses where courseid = @CID", conn);
            for (int i = 0; i < notenrolledList.Count; ++i)
            {
                cmd2.Parameters.Add("@CID", SqlDbType.Int).Value = notenrolledList[i];

                adapter = new SqlDataAdapter(cmd2);
                DataSet res2 = new DataSet();
                adapter.Fill(res2);

                notenrolledName.Add(res2.Tables[0].Rows[0][0].ToString());
                cmd2.Parameters.Clear();
            }

            BulletedList1.DataSource = notenrolledName;
            BulletedList1.DataBind();
        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=LAPTOP-MSQV6S42\\SQLEXPRESS;UID=sa;Password=123;Database=WebDisk");
            conn.Open();

            SqlCommand insert_cmd = new SqlCommand("insert into enroll (userid, courseid) values (@UID,@CID)", conn);
            insert_cmd.Parameters.Add("@UID", SqlDbType.VarChar, 10).Value = Session["UID"];
            insert_cmd.Parameters.Add("@CID", SqlDbType.VarChar, 10).Value = notenrolledList[e.Index];

            insert_cmd.ExecuteNonQuery();
            insert_cmd.Dispose();

            BulletedListDataBind();

            lbMessage.Text = "Course already enrolled.";
        }
    }
}