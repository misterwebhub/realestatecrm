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

public partial class Registartion_details : System.Web.UI.Page
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
           SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlCommand cmd = new SqlCommand("select CUSTREGNO,DATEOFCOM as 'DATE',PLANANDTERM,CONSAMOUNT as 'AMOUNT',INSTSUBPAY as 'INSTALLMENT',NAMEDOBADDRESS,APPNO as 'ARAZI NO',PLOTSIZE,plotno,RECIPTNO,mobile,CHECKBY  ,regstatus,usertype from wjstar1.customerreg1", con1);
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            con1.Close();
        }
        catch (Exception t)
        {
            Label1.Text = "due to error";
        }
        

    }
}
    
