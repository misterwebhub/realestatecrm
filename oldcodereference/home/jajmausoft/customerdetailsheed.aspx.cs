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
        //String sr = Session["ID"].ToString();
        String sr = "heedrealestate";
         if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Label22.Visible = false;
            Label23.Visible = false;
        }

         
    }
    int total, total1;
    public void showbroker()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();

        SqlDataAdapter da = new SqlDataAdapter("select ID,CUSTREGNO,CHECKBY,DATE,TOTAL,PER,PAID,REASON from newbrokerpaid2 where CUSTREGNO='"+TextBox1.Text+"'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
        }
		 else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
    }
    public void reciptbind()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();

        SqlDataAdapter da = new SqlDataAdapter("select SUM(AMOUNT) from reciptreturn2 where CUSTREGNO='" + TextBox1.Text + "'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                Label22.Visible = true;
                Label22.Text = ds.Tables[0].Rows[0][0].ToString();
            Label23.Visible = true;
        
            }
            else
            {
             Label22.Visible = false;
            Label23.Visible = false;
        
            }
        }
        else
        {
            Label22.Visible = false;
            Label23.Visible = false;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Label8.Text = "";
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,r.AMOUNTWORD AS 'AMTWORD',r.userstatus AS 'STATUS',discount as 'RECTYPE',r.deldate from recipt3 r LEFT JOIN customerreg3 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + TextBox1.Text + "' ORDER BY r.DATE1 ASC", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
con1.Open();
SqlDataAdapter da1 = new SqlDataAdapter("select r.CUSTREGNO AS 'REGNO',u.NAMEDOBADDRESS AS 'ADDRESS',r.PLANTERM AS 'PLAN',u.CONSAMOUNT AS 'VALUE',r.RECIPT,r.DATE,r.INSTNO,r.AMOUNTR,r.NEXTDATE,CONCAT(u.mobile,' , ',u.mobile2) AS 'Mobile No',u.APPNO AS 'ARAZI NO',r.AMOUNTWORD AS 'AMT WORD',u.CHECKBY,u.plotno,u.PLOTSIZE from recipt3 r LEFT JOIN customerreg3 u ON r.CUSTREGNO=u.CUSTREGNO where r.CUSTREGNO='" + TextBox1.Text + "'", con1);
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
                Label14.Text = ds1.Tables[0].Rows[0][10].ToString()+" / "+ds1.Tables[0].Rows[0][13].ToString()+" / "+ds1.Tables[0].Rows[0][14].ToString();
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
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from recipt3 where CUSTREGNO='" + TextBox1.Text + "'", con1);


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
            showbroker();
            reciptbind();
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
            string f = e.Row.Cells[5].Text;

            foreach (TableCell cell in e.Row.Cells)
            {
                if (f == "Inactive")
                {
                   e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
                }
               


            }
        }
    }
     protected void TextBox5_TextChanged(object sender, EventArgs e)
     {
         Double t4=0, t5=0, t6=0;
         if (TextBox4.Text == "" || TextBox5.Text == "")
         {
             t4 = 0;
             t5 = 0;
         }
         else
         {
             t4 = Convert.ToDouble(TextBox4.Text);
             t5 = Convert.ToDouble(TextBox5.Text);
             t6 = t4 * t5 / 100;
             TextBox6.Text = t6.ToString();
         }
     }
     protected void TextBox4_TextChanged(object sender, EventArgs e)
     {
         Double t4 = 0, t5 = 0, t6 = 0;
         if (TextBox4.Text == "" || TextBox5.Text == "")
         {
             t4 = 0;
             t5 = 0;
         }
         else
         {
             t4 = Convert.ToDouble(TextBox4.Text);
             t5 = Convert.ToDouble(TextBox5.Text);
             t6 = t4 * t5 / 100;
             TextBox6.Text = t6.ToString();
         }
     }
     protected void Button2_Click(object sender, EventArgs e)
     {
         SqlConnection con1 = new SqlConnection(s);
         con1.Open();
         string s2 = TextBox3.Text;
         string dd = s2.Substring(0, 2);
         string mm = s2.Substring(3, 2);
         string yy = s2.Substring(6, 4);
         string ddd = mm + "/" + dd + "/" + yy;
         SqlCommand cmd = new SqlCommand("insert into newbrokerpaid2(CUSTREGNO,CHECKBY,DATE,TOTAL,PER,PAID,REASON)values('" + Label13.Text + "','" + Label12.Text + "','" + ddd + "'," + TextBox4.Text + "," + TextBox5.Text + "," + TextBox6.Text + ",'"+TextBox7.Text+"')", con1);
         int a = cmd.ExecuteNonQuery();
         con1.Close();
         if (a != 0)
         {
             Label19.Text = "Record Added";
             showbroker();
         }
         else
         {
             Label19.Text = "error";
         }
     }
	protected void LinkButton1_Click(object sender, EventArgs e)
     {
         Panel1.Visible = true;
         Panel2.Visible = false;
     }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlConnection con = new SqlConnection(s);

        int id = Convert.ToInt16(GridView2.DataKeys[e.RowIndex].Values["ID"].ToString());
        SqlCommand cmd = new SqlCommand("delete from newbrokerpaid2 where ID=" + id + "", con);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        showbroker(); 
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        showrecipt();
        reciptbind();
    }
    public void showrecipt()
    {
         SqlConnection con1 = new SqlConnection(s);
         con1.Open();
    

        SqlDataAdapter da = new SqlDataAdapter("select ID,DATE,AMOUNT,REASON from reciptreturn2 where CUSTREGNO='"+TextBox1.Text+"'", con1);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con1.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                GridView3.DataSource = ds;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }
		 else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
         SqlConnection con1 = new SqlConnection(s);
         con1.Open();
         string s2 = TextBox8.Text;
         string dd = s2.Substring(0, 2);
         string mm = s2.Substring(3, 2);
         string yy = s2.Substring(6, 4);
         string ddd = mm + "/" + dd + "/" + yy;
         SqlCommand cmd = new SqlCommand("insert into reciptreturn2 (DATE,AMOUNT,REASON,CUSTREGNO)values('"+ddd+"',"+TextBox11.Text+",'"+TextBox12.Text+"','"+TextBox1.Text+"')", con1);
         int a = cmd.ExecuteNonQuery();
         con1.Close();
         if (a != 0)
         {
             Label21.Text = "Record Added";
             showrecipt();
             reciptbind();
             TextBox11.Text = "";
             TextBox12.Text = "";
         }
         else
         {
             Label21.Text = "error";
         }
     }
    protected void  GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(s);

                  int id = Convert.ToInt16(GridView3.DataKeys[e.RowIndex].Values["ID"].ToString());
                      SqlCommand cmd = new SqlCommand("delete from reciptreturn2 where ID=" + id + "", con);

                     con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        showrecipt();
                        reciptbind();
                        Label21.Text = "";
        }

}