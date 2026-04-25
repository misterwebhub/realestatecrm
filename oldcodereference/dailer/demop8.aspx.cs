using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class arazi357_demp8 : System.Web.UI.Page
{
   static string entry1,entry2;
   string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
		id = "";
            if (Session["idr"] != null)
            {
                // id = "heedrealestate";
                id = Session["idr"].ToString();
                Label2.Text = id;
                entry1 = "";
                 entry2 = "";
            }
        entry1 = "";
         entry2 = "";
       // Label1.Text = entry1+"empty";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        entry1 = "";
         entry2 = "";
         id = Session["idr"].ToString();
         if (id == "heedrealestate")
         {
             entry1 = DateTime.Now.ToString("h:mm:ss tt");
         }
         if (id == "Ashok8396")
         {
             entry2 = DateTime.Now.ToString("h:mm:ss tt");
         }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
         id = Session["idr"].ToString();
        if (id == "heedrealestate")
        {
            Label1.Text = entry1;
        }
        if (id == "Ashok8396")
        {
            Label1.Text = entry2;
        }

    }
}