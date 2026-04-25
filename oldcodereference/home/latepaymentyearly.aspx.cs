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
using System.Drawing;


public partial class dialer_latepaymentyearly : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
     }
    public void bind()
    {
        try
        {

            SqlConnection con1 = new SqlConnection(s);
            con1.Open();


            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT username FROM logininfo", con1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();

            DropDownList3.Items.Add("--SELECT--");
            DropDownList3.Items.Add("ALL USER");
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {

                DropDownList3.Items.Add(ds1.Tables[0].Rows[j][0].ToString());
            }




        }
        catch (Exception t)
        {
            Label1.Text = "internal problem" + t;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(DropDownList3.Text== "--SELECT--")
        {
            Label1.Text = "Please Select Any One User";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        else
        {
            string s2 = TextBox2.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox3.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string date2 = mm1 + "/" + dd1 + "/" + yy1;
            Label1.Text = " ";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select CONCAT(LEFT(DATENAME(mm, date),3),'-',year(date)) AS 'month',startpmt,totallateemi,totallateemi-startpmt AS 'BALEMI',	lateemimonth,	totalpaidemi,	totalbalemi from lateemipay where date between '" + date1 + "' AND '" + date2 + "' AND user1='" + DropDownList3.Text + "' order by date ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            if(Convert.ToDouble(lblStatus.Text)<=0)
            {
                    lblStatus.ForeColor = Color.Green;
            }
            else
            {
               
                    lblStatus.ForeColor = Color.Red;
            }
                    
            
        }
    }
}