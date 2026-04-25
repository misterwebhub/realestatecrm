using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Userhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//Label1.Text =Request.QueryString["val2"].ToString();
			//Label1.Text=Server.HtmlEncode(Request.Cookies["ID"].Value);
		//Label1.Text =Request.QueryString["val1"].ToString();
		//Response.Cookies.Add(new HttpCookie("ID",Label1.Text));
        Label1.Text = Session["ID"].ToString(); 
		ViewState["ID"] = Label1.Text;
    }
}