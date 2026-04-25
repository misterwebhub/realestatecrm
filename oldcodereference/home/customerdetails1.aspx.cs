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
        String reg=Session["reg"].ToString();
        TextBox1.Text = reg;
        amar(reg);
    }
    int total, total1;
    public void amar(String reg)
    {
        try
        {
            
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',r.ASSADDRESS AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DUDATE,r.DATE,r.INSTNO,r.AMOUNTR,CONCAT(r.mobile,' , ',u.mobile2) AS 'Mobile No',u.APPNO AS 'ARAZI NO',r.AMOUNTWORD AS 'AMT WORD',r.userstatus AS 'STATUS' from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + reg + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
con1.Open();
 SqlDataAdapter da1= new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',r.ASSADDRESS AS 'ADDRESS',r.PLANTERM AS 'PLAN',r.EXPLANDVALUE AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,r.NEXTDATE,r.mobile,u.APPNO AS 'ARAZI NO',r.AMOUNTWORD AS 'AMT WORD',u.CHECKBY from wjstar1.recipt1 r LEFT JOIN wjstar1.customerreg1 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + reg + "'", con1);
 DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con1.Close();
            Label12.Text=ds1.Tables[0].Rows[0][12].ToString();
                   
                    
           
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);


            SqlDataReader dr1 = cmd1.ExecuteReader();
            total1 = Convert.ToInt32(ds.Tables[0].Rows[0][3].ToString());
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
            Label8.Text = "Due to error";
        }
    }
}