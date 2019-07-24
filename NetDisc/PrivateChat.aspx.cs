using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetDisc
{
    public partial class PrivateChat : System.Web.UI.Page
    {
        protected string UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UID"] == null)
            {
                Response.Redirect("Login.aspx?Backpage=PrivateChat");
            }
            else
            {
                UserType = Session["UserType"].ToString();
            }
        }
    }
}