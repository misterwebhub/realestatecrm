using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class credential: System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int c = 0;
            SqlConnection con = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("select username,password  from logininfo where utype='"+DropDownList2.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (TextBox1.Text == ds.Tables[0].Rows[i][0].ToString() && TextBox2.Text == ds.Tables[0].Rows[i][1].ToString())
                    {
                        c = c + 1;
                        break;
                    }
                }
                if (c != 0)
                {
                    if (DropDownList2.Text == "ADMIN")
                    {
                     Session["ID"] = TextBox1.Text;
						  //  Response.Cookies.Add(new HttpCookie("ID",TextBox1.Text));
                        Response.Redirect("~/home/admin.aspx");
                    }
                    if (DropDownList2.Text == "USER")
                    {
                      Session["ID"] = TextBox1.Text;
						  // Response.Cookies.Add(new HttpCookie("ID",TextBox1.Text));
                       Response.Redirect("~/user/userhome.aspx");
                    }
                }
                else
                {
                    Label1.Text = "Internal Error";
                }
            }
        }
        catch (Exception t)
        {
            Label1.Text = "Server Error"+t;
        }
       
    }
}