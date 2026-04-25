using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;

public partial class arazi217_backadd : System.Web.UI.Page
{
    static string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DateTime date11 = DateTime.Now;
            DateTime date2 = date11;
            int dd = date11.Day;
            int mm = date11.Month;
            int yy = date11.Year;
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select c.CUSTREGNO,r.userid  from wjstar1.customerreg1 c LEFT join calldemo r on r.CUSTREGNO=c.CUSTREGNO left join (select CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date BETWEEN '" + date11 + "' AND '" + date2 + "' group By CUSTREGNO ) as  r1  on r1.CUSTREGNO=c.CUSTREGNO where r.CUSTREGNO NOT IN(select c5.CUSTREGNO   from wjstar1.customerreg1 c5 left join (select CUSTREGNO,date,reason,	feeddate	,entrytime	,entrytime1 from callerfeedback where ID in(select MAX(ID) from callerfeedback where date='" + date11 + "'  group By CUSTREGNO)) as r5 on r5.CUSTREGNO=c5.CUSTREGNO left join (select DISTINCT CUSTREGNO,count(ID) AS pmt1 from callerfeedback where date='" + date11 + "' group By CUSTREGNO) as  r6  on r6.CUSTREGNO=c5.CUSTREGNO where DAY(c5.date3)='" + dd + "' AND c5.CUSTREGNO in(select DISTINCT CUSTREGNO from wjstar1.recipt1 where  CUSTREGNO NOT IN (Select DISTINCT CUSTREGNO from wjstar1.recipt1 where month(DATE1)='" + mm + "' AND year(DATE1)='" + yy + "')) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel')      ) AND r.feeddate BETWEEN '" + date11 + "' AND '" + date2 + "'  AND r.CUSTREGNO in(select DISTINCT CUSTREGNO from calldemo) AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.customerreg1 where regstatus='completed'  OR regstatus='Cancel') AND c.CUSTREGNO NOT IN(Select DISTINCT CUSTREGNO from wjstar1.recipt1 where MONTH(DATE1)=" + mm + " AND YEAR(DATE1)=" + yy + " )", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                string reg="", userid = "";
                con.Open();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    reg = "";
                    userid = "";
                    reg = ds.Tables[0].Rows[i][0].ToString();
                    userid = ds.Tables[0].Rows[i][1].ToString();
                     SqlCommand cmd = new SqlCommand("insert into backcall (date,CUSTREGNO,userid)values('"+date11+"','"+reg+"','"+userid+"')", con);

        /* string time = DateTime.Now.ToString("h:mm:ss tt");
         Label1.Text = time;*/
        
        cmd.ExecuteNonQuery();
        
                }
                con.Close();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            Label1.Text = date11.ToString();
        }
        catch (Exception r)
        {
            Label1.Text = r.ToString();
        }
    }
}