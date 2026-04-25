using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class kishanrecipt : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetch();
            
        }
    }
    public void fetch()
    {
        try
        {
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id,kname,arazi from newkishan where kid NOT IN (1)", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            
        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }
}