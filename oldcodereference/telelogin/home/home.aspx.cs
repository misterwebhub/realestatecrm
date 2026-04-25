using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class telelogin_home_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		String idmain="";
		if(Session["idr"] != null)
			{
			idmain= Session["idr"].ToString();
                    Session["idr"] = idmain;
				//idmain ="heedrealestate";*/
			   //Label13.Text = ";
			}
			else
				
			{
				Response.Redirect("~/telelogin/dist/telelogin.aspx");
			}
		
        Label1.Text = idmain.ToString();
	Session["idr"] = idmain;

    }
}