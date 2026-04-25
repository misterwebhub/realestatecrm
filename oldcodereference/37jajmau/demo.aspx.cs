using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _37jajmau_demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string script = "window.onload = function() { fetch1(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "fetch1", script, true);
    }
}