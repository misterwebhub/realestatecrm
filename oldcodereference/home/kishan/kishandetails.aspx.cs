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
using System.Drawing;


public partial class kishandetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Double d1=0, d2=0, b=0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select k.arazino,k.kname,k.location,k.amount,c.PAID,(k.amount-c.PAID) AS 'BALANCE' from (select arazi,sum(amount) AS PAID  from chequetrans where status='PAID' group by arazi) AS c inner join chequekishan AS k on c.arazi=k.arazino", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(k.amount),sum(c.PAID) from (select arazi,sum(amount) AS PAID  from chequetrans where status='PAID' group by arazi) AS c inner join chequekishan AS k on c.arazi=k.arazino", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        d1 = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        d2 = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
        b = d1 - d2;
        Label1.Text = d1.ToString();
        Label2.Text = d2.ToString();
        Label3.Text = b.ToString();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbltmt = (Label)e.Row.FindControl("id4");
            Label lblpaid = (Label)e.Row.FindControl("id5");
            Label lblbal = (Label)e.Row.FindControl("id6");



           

                lbltmt.Style.Add("color", "green");

                lblbal.Style.Add("color", "Blue");

                lblpaid.Style.Add("color", "Red");

           
        }
    }
}