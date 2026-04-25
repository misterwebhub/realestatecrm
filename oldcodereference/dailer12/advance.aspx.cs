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
using System.Globalization;
public partial class call_advance : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    
        DataTable ad = new DataTable();
        ad = (DataTable)Session["data"];
        DataTable bacad = new DataTable();
        bacad = (DataTable)Session["data1"];
        GridView2.DataSource = ad;
        GridView2.DataBind();
        GridView4.DataSource = bacad;
        GridView4.DataBind();

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int c = 0;
            string h = e.Row.Cells[8].Text;
            //  string h2 = e.Row.Cells[11].Text;
            if (h == "&nbsp;")
            {

            }
            else
            {
                string s4 = h;
                string dd = s4.Substring(0, 2);
                string mm = s4.Substring(3, 2);
                string yy = s4.Substring(6, 4);
              //  string s2 = TextBox2.Text;
              //  string s5 = TextBox3.Text;
              //  string dd1 = s2.Substring(0, 2);
               
                //string start = mm + "/" + dd + "/" + yy;
                //string end;

                DateTime d2 = new DateTime(Convert.ToInt32(yy), Convert.ToInt32(mm), Convert.ToInt32(dd));
                DateTime d3 = DateTime.Now;
               // DateTime d4 = new DateTime(Convert.ToInt32(yy2), Convert.ToInt32(mm2), Convert.ToInt32(dd2));
               
                int res = DateTime.Compare(d2, d3);
                // returns <0 since d1 is earlier than d2
             //   Label1111.Text = res.ToString();
                
                if (res == 0)
                {
                    e.Row.Cells[11].Text = "";
                    e.Row.Cells[8].Text = "";


                }

            }
            // Label6666.Text=c.ToString();
        }
            
       
    }
}