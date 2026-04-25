using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Globalization;

public partial class invsterintrest_deletecheque : System.Web.UI.Page
{

    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            refreshdata();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);


        SqlCommand cmd = new SqlCommand("delete from chequedetails WHERE deletevalue='DEL' ", con);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        refreshdata(); 
    }
    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        int id = Convert.ToInt16(GridView3.DataKeys[e.RowIndex].Values["ID"].ToString());
        SqlCommand cmd = new SqlCommand("delete from chequedetails where ID=" + id + "", con);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        refreshdata(); 
    }
       public void refreshdata()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT ID,CUSTREGNO,NAME,ARAZI,PLOTNO,PLOTSIZE,CDATE,CHEQUENO,CAMOUNT,CHEQUETYPE,STATUS,deletevalue from chequedetails WHERE deletevalue='DEL' ORDER BY CDATE ASC", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
        con.Close();

    } 
}