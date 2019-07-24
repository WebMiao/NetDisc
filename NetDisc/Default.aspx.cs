using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetDisc
{
    public partial class Default : System.Web.UI.Page
    {
        string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["coursename"];
            lbTitle.Text= name + " Course Chat Room";

            
        }
    }
}