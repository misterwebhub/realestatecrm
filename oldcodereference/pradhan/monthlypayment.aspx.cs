using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

public partial class _161GHA_extrapaymentrecipt : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    static DataTable ft;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }


    public void bind()
    {
        Double sum = 0;
        ft = new DataTable();
       
        ft.Columns.Add("DATE", typeof(String));
      
       

        ft.Columns.Add("DES", typeof(String));
        ft.Columns.Add("VALUE", typeof(String));
        ft.Columns.Add("BACK", typeof(String));
        ft.Columns.Add("TOTAL AMT", typeof(String));
        ft.Columns.Add("PAID AMT", typeof(String));
        ft.Columns.Add("BALANCE AMT", typeof(String));
        ft.Columns.Add("MODE", typeof(String));
        ft.Columns.Add("NUMBER", typeof(String));
       
            DateTime basedate = new DateTime(2024, 11, 1, 12, 0, 0);
        string s1 = TextBox7.Text;
        string dd1 = s1.Substring(0, 2);
        int d = Convert.ToInt32(dd1);
        string mm1 = s1.Substring(3, 2);
        int m = Convert.ToInt32(mm1);
        string yy1 = s1.Substring(6, 4);
        int y = Convert.ToInt32(yy1);
        DateTime dt1 = new DateTime(y, m, d, 12, 0, 0);
        string date1 = mm1 + "/" + dd1 + "/" + yy1;
        string s2 = TextBox8.Text;
        string dd = s2.Substring(0, 2);
        int d2 = Convert.ToInt32(dd);
        string mm = s2.Substring(3, 2);
        int m2 = Convert.ToInt32(mm);
        string yy = s2.Substring(6, 4);
        int y2 = Convert.ToInt32(yy);
        string date2 = mm + "/" + dd + "/" + yy;
        DateTime dt2 = new DateTime(y2, m2, d2, 12, 0, 0);
        int value = DateTime.Compare(dt1, basedate);
        if (value >= 0)
        {
            int value1 = DateTime.Compare(dt2, basedate);
            if (value1 >= 0)
            {
                dt1 = dt1;
                dt2 = dt2;
            }
            else
            {
                dt2 = new DateTime(2024, 11, 30, 12, 0, 0);
            }
        }
        else
        {
            dt1 = new DateTime(2024, 11, 01, 12, 0, 0);
             int value1 = DateTime.Compare(dt2, basedate);
             if (value1 >= 0)
             {
                 dt1 = dt1;
                 dt2 = dt2;
             }
             else
             {
                 dt2 = new DateTime(2024, 11, 30, 12, 0, 0);
             }
        }

        int compair1 = DateTime.Compare(dt2, dt1);

        if (compair1 > 0)
        {
            DateTime ty = dt1.AddDays(-1);
            SqlConnection con = new SqlConnection(s);
            con.Close();
            SqlDataAdapter da1 = new SqlDataAdapter("select sum(amount) from  investerrecipt where invid='I0022' AND TYPE='RETURN' AND date between '11/01/2024' and '" + ty + "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            DataRow dr2 = ft.NewRow();
            Double total=0,back = 0,r=0;
            DateTime tu=new DateTime(2024, 11, 01, 12, 0, 0);
            int compair3 = DateTime.Compare(tu, ty);
            if (compair3 < 0)
            {
                int monthsApart = 12 * (2024 - ty.Year) + 12 - ty.Month;
                r = 1 + Math.Abs(monthsApart);
            }
            else
            {
                r = 0;
            }
           if (ds1.Tables[0].Rows.Count > 0)
           {
               if (ds1.Tables[0].Rows[0][0].ToString() != "")
               {
                   back = back+Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
               }
               else
               {
                   back = back+0;
               }
           }
           else
           {
               back = back+0;
           }
           total = 1500000 *r - back;
            dr2[0] =null;
            dr2[1] = "BACK";
            dr2[2] = 0;
            dr2[3] = 0;
            dr2[4] = 1500000*r;
            dr2[5] =back;
            sum = sum + back;
            dr2[6] = total;
            dr2[7] = null;
            dr2[8] = null;
            ft.Rows.Add(dr2);

            int month = 12 * (dt1.Year - dt2.Year) + dt1.Month - dt2.Month;
            int y1 = 1 + Math.Abs(month);
            for (int u = 1; u <= y1; u++)
            {
                DataRow dr1 = ft.NewRow();
                DateTime dt3 = dt1.AddMonths(1).AddDays(-1);

                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select date,amount,paymode	,chkno from  investerrecipt where invid='I0022' AND TYPE='RETURN' AND date between '" + dt1 + "' and '" + dt3 + "' order by date ASC", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Double paid = 0;
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        for (int w = 0; w < ds.Tables[0].Rows.Count; w++)
                        {
                            string h = ds.Tables[0].Rows[w][0].ToString();
                            dr1[0] = h.Substring(0, 10);
                            dr1[1] = null;
                            dr1[2] = null;
                            dr1[3] = null;
                            dr1[4] = null;
                            paid = paid + Convert.ToDouble(ds.Tables[0].Rows[w][1].ToString());
                            dr1[5] = Convert.ToDouble(ds.Tables[0].Rows[w][1].ToString()) ;
                            dr1[6] = null;
                            dr1[7] = ds.Tables[0].Rows[w][2].ToString();
                            dr1[8] = ds.Tables[0].Rows[w][3].ToString();
                            ft.Rows.Add(dr1);
                            dr1 = ft.NewRow();
                        }
                        DataRow dr22 = ft.NewRow();
                        dr22[0] = null;
                        dr22[1] = null;
                        dr22[2] = null;
                        dr22[3] = null;
                        dr22[4] = null;

                        dr22[5] = null;
                       // total = total + 1500000;
                        dr22[6] = null;
                        dr22[7] = null;
                        dr22[8] = null;
                        ft.Rows.Add(dr22);
                        dr22 = ft.NewRow();
                        dr22[0] = null;
                        dr22[1] = "BACK";
                        dr22[2] = 1500000 ;
                        dr22[3] = total.ToString();
                        dr22[4] = 1500000 + total;

                        dr22[5] = paid;
                        total = total + 1500000;
                        sum = sum + paid;
                        dr22[6] = total-paid;
                        dr22[7] = null;
                        dr22[8] = null;
                        ft.Rows.Add(dr22);
                        dr22 = ft.NewRow();
                        dr22[0] = null;
                        dr22[1] = null;
                        dr22[2] = null;
                        dr22[3] = null;
                        dr22[4] = null;

                        dr22[5] = null;
                        // total = total + 1500000;
                        dr22[6] = null;
                        dr22[7] = null;
                        dr22[8] = null;
                        ft.Rows.Add(dr22);
                        total = total - paid;
                    }
                    else
                    {
                        back = back + 1500000;
                        dr1[0] = null;
                        dr1[1] = "BACK" + dt2.Month + "/" + dt2.Year;
                        dr1[2] = back;
                        dr1[3] = back;
                        dr1[4] = back;
                        dr1[5] = null;
                        dr1[6] = null;
                    }

                }
                else
                {
                    back = back + 1500000;
                    dr1[0] = null;
                    dr1[1] = "BACK" + dt2.Month + "/" + dt2.Year;
                    dr1[2] = back;
                    dr1[3] = back;
                    dr1[4] = back;
                    dr1[5] = null;
                    dr1[6] = null;
                }
                dt1 =new DateTime(dt3.Year,dt3.Month,1,12,0,0).AddMonths(1);
            }
            GridView1.DataSource = ft;
            GridView1.DataBind();
        }
        else
        {
            string message = "Please Select end date is greater than start date";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
        Label2.Text = "48918233";

        Label3.Text = sum.ToString();
        Double b = 48918233 - sum;
        Label4.Text = b.ToString();

       

        
    }
   
    protected void Button4_Click(object sender, EventArgs e)
    {
        bind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String quantity = e.Row.Cells[1].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (quantity == "BACK")
                {
                    cell.BackColor = Color.Black;
                    cell.ForeColor = Color.White;
                }
            }
        }
    }
}