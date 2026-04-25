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

public partial class customer_details : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    int total, total1;
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Label8.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select r.RECIPT,r.DUDATE,r.DATE,r.INSTNO,r.AMOUNTR,r.AMOUNTWORD AS 'AMT WORD',r.userstatus AS 'STATUS' from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + TextBox1.Text + "' ORDER BY r.DATE1 ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
con1.Open();
SqlDataAdapter da1 = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',u.NAMEDOBADDRESS AS 'ADDRESS',r.PLANTERM AS 'PLAN',u.CONSAMOUNT AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,r.NEXTDATE,CONCAT(u.mobile,' , ',u.mobile2,',',u.mobile3) AS 'Mobile No',u.APPNO AS 'ARAZI NO',r.AMOUNTWORD AS 'AMT WORD',u.CHECKBY from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + TextBox1.Text + "'", con1);
 DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            Label12.Text=ds1.Tables[0].Rows[0][12].ToString();
            if(ds1.Tables[0].Rows[0][0].ToString()!="")
            {  
             Label13.Text = ds1.Tables[0].Rows[0][0].ToString();
            }
            if (ds1.Tables[0].Rows[0][10].ToString() != "")
            {
                Label14.Text = ds1.Tables[0].Rows[0][10].ToString();
            }
            if (ds1.Tables[0].Rows[0][2].ToString() != "")
            {
                Label15.Text = ds1.Tables[0].Rows[0][2].ToString();
            }
            if (ds1.Tables[0].Rows[0][9].ToString() != "")
            {
                Label16.Text = ds1.Tables[0].Rows[0][9].ToString();
            }
            if (ds1.Tables[0].Rows[0][1].ToString() != "")
            {
                Label17.Text = ds1.Tables[0].Rows[0][1].ToString();
            }
            if (ds1.Tables[0].Rows[0][3].ToString() != "")
            {
                Label18.Text = ds1.Tables[0].Rows[0][3].ToString();
            }


                   
                    
           
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + TextBox1.Text + "'", con1);


            SqlDataReader dr1 = cmd1.ExecuteReader();
            total1 = Convert.ToInt32(ds1.Tables[0].Rows[0][3].ToString());
            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    // total1 = Convert.ToInt32(dr.GetValue(1));
                    total = Convert.ToInt32(dr1.GetValue(0));
                }
                int balance = total1 - total;
                Label5.Text = total1.ToString();
                Label4.Text = total.ToString();
                Label7.Text = balance.ToString();
            }

            con1.Close();
        }
        catch (Exception t)
        {
            Label8.Text = "Due to error"+t;
        }
    }
	 protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            /* e.Row.Cells[2].ForeColor = System.Drawing.Color.Blue;
             e.Row.Cells[4].ForeColor = System.Drawing.Color.Blue;
             e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;*/
            string f = e.Row.Cells[6].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Inactive")
                {
                   e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
                }
               


            }
        }
    }
}