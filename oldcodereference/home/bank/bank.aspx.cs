﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.Web.Services;
using System.Configuration;
using System.Web.Configuration;
using System.Globalization;
public partial class bank : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
           // Panel3.Visible = false;
            Label6.Visible = false;
            Label7.Visible =false;
            TextBox14.Visible = false;
            TextBox15.Visible = false;
            Button6.Visible = false;

        }
    }
    public void account()
    {
        Double total = 0, dr = 0, cr = 0, bal = 0,tem=0;
        try
        {
            if (DropDownList1.Text != "----------SELECT------------")
            {
               
                SqlConnection con = new SqlConnection(s);
                con.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("select amount from bankacount where acnumber='" + DropDownList1.Text + "' ", con);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                con.Close();
                con.Open();

                SqlDataAdapter cmd1 = new SqlDataAdapter("select sum(DEBIT),sum(CREDIT) from bank where ACNUMBER='" + DropDownList1.Text + "' ", con);
                DataSet ds1 = new DataSet();
                cmd1.Fill(ds1);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    total = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    total = 0;
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][0].ToString() != "")
                    {
                        dr = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
                    }
                    else
                    {
                        dr = 0;
                    }
                }
                else
                {
                    dr = 0;
                }
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    if (ds1.Tables[0].Rows[0][1].ToString() != "")
                    {
                        cr = Convert.ToDouble(ds1.Tables[0].Rows[0][1].ToString());
                    }
                    else
                    {
                        cr = 0;
                    }
                    
                }
                else
                {
                    cr = 0;
                }
            }
            else
            {
                total = 0;
            }

           tem = total+ cr;
           bal = tem-dr;
           Label5.Text = Convert.ToInt32(bal).ToString();
        }
        catch (Exception t)
        {
            Label4.Text = "error" + t;
        }
    }
   public void bind1()
    {
        try
        {
            if (DropDownList1.Text != "----------SELECT------------")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("select TOP(10) ID,DATE,NAME,chequetype,paymod,REFNO,STATUS,DEBIT,CREDIT,REASON  from bank where ACNUMBER='" + DropDownList1.Text + "' ORDER BY DATE DESC ", con);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    account();
                }
                else
                {
                    Label4.Text = "Record Not Found";
                }
            }
            else
            {
                Label1.Text = "Please select Acount Number";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

            
        }
        catch (Exception t)
        {
            Label4.Text = "error"+t;
        }
    }
   public void bind2()
   {
       try
       {
           string s2 = TextBox14.Text;
           string dd = s2.Substring(0, 2);
           string mm = s2.Substring(3, 2);
           string yy = s2.Substring(6, 4);
           string date1 = mm + "/" + dd + "/" + yy;
           string s22 = TextBox15.Text;
           string dd22 = s22.Substring(0, 2);
           string mm22 = s22.Substring(3, 2);
           string yy22 = s22.Substring(6, 4);
           string date2 = mm22 + "/" + dd22 + "/" + yy22;
           if (DropDownList1.Text != "----------SELECT------------")
           {
               SqlConnection con = new SqlConnection(s);
               con.Open();

               SqlDataAdapter cmd = new SqlDataAdapter("select ID,DATE,NAME,chequetype,paymod,REFNO,STATUS,DEBIT,CREDIT,REASON from bank where ACNUMBER='" + DropDownList1.Text + "' AND DATE BETWEEN '" + date1 + "' AND '"+date2+"' ORDER BY DATE ASC ", con);
               DataSet ds = new DataSet();
               cmd.Fill(ds);
               con.Close();
               if (ds.Tables[0].Rows.Count > 0)
               {
                   GridView1.DataSource = ds;
                   GridView1.DataBind();
                   account();
               }
               else
               {
                   Label4.Text = "Record Not Found";
               }
           }
           else
           {
               Label1.Text = "Please select Acount Number";
               GridView1.DataSource = null;
               GridView1.DataBind();
           }


       }
       catch (Exception t)
       {
           Label4.Text = "error" + t;
       }
   }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible =false;
       // Panel3.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        TextBox14.Visible = false;
        TextBox15.Visible = false;
        Button6.Visible = false;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel1.Visible =false;
        Panel2.Visible = true;
       // Panel3.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        TextBox14.Visible = false;
        TextBox15.Visible = false;
        Button6.Visible = false;
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
       
        Panel3.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
        TextBox14.Visible = true;
        TextBox15.Visible = true;
        Button6.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Label1.Text == "")
            {
                if (DropDownList1.Text != "----------SELECT------------")
                {
                    SqlConnection con = new SqlConnection(s);

                    string s2 = TextBox5.Text;
                    string dd = s2.Substring(0, 2);
                    string mm = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = mm + "/" + dd + "/" + yy;
                    if (DropDownList2.Text == "DEBIT ( - )")
                    {
                        int am = 0;
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into bank(ACNUMBER,NAME,DEBIT,CREDIT,DATE,REFNO,REASON,STATUS,paymod,chequetype)values('" + DropDownList1.Text + "','" + TextBox1.Text + "'," + TextBox2.Text + "," + am + ",'" + date1 + "','" + TextBox6.Text + "','" + TextBox7.Text + "','Dr','" + DropDownList4.Text + "','"+DropDownList6.Text+"')", con);
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i != 0)
                        {
                            Label1.Text = "Record Added Successfully";
                            bind1();
                        }
                        else
                        {
                            Label1.Text = "error";
                        }
                    }
                    else
                    {
                        if (DropDownList2.Text == "CREDIT ( + )")
                        {
                            int am1 = 0;
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into bank(ACNUMBER,NAME,DEBIT,CREDIT,DATE,REFNO,REASON,STATUS,paymod,chequetype)values('" + DropDownList1.Text + "','" + TextBox1.Text + "'," + am1 + "," + TextBox2.Text + ",'" + date1 + "','" + TextBox6.Text + "','" + TextBox7.Text + "','Cr','" + DropDownList4.Text + "','"+DropDownList6.Text+"')", con);
                            int i = cmd.ExecuteNonQuery();
                            con.Close();
                            if (i != 0)
                            {
                                Label1.Text = "Record Added Successfully";
                                bind1();
                            }
                            else
                            {
                                Label1.Text = "error";
                            }
                        }
                        else
                        {
                            Label1.Text = "Please select status debit/credit";
                        }
                    }

                }
                else
                {
                    Label1.Text = "Please select Acount Number";
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            else {
                Label1.Text = "Please click on new";
            }
        }
        catch (Exception t)
        {
            Label1.Text = "error"+t;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        Label1.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.Text != "----------SELECT------------")
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();

                SqlDataAdapter cmd = new SqlDataAdapter("select NAME,DEBIT,CREDIT,DATE,REFNO,REASON,STATUS,paymod,chequetype from bank where ID=" + TextBox13.Text + " ", con);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string s2 = ds.Tables[0].Rows[0][3].ToString();
                    string mm = s2.Substring(0, 2);
                    string dd = s2.Substring(3, 2);
                    string yy = s2.Substring(6, 4);
                    string date1 = dd + "/" + mm + "/" + yy;
                    TextBox8.Text = ds.Tables[0].Rows[0][0].ToString();
                   
                    TextBox10.Text = date1;
                    TextBox11.Text = ds.Tables[0].Rows[0][4].ToString();
                    TextBox12.Text = ds.Tables[0].Rows[0][5].ToString();
                    DropDownList5.Text = ds.Tables[0].Rows[0][7].ToString();
                    DropDownList7.Text = ds.Tables[0].Rows[0][8].ToString();
                    string st = ds.Tables[0].Rows[0][6].ToString();
                    if(st=="Dr")
                    {
                        TextBox9.Text = ds.Tables[0].Rows[0][1].ToString();
                        DropDownList3.Text = "DEBIT ( - )";
                    }
                    if (st == "Cr")
                    {
                        TextBox9.Text = ds.Tables[0].Rows[0][2].ToString();
                        DropDownList3.Text = "CREDIT ( + )";
                    }

                }
                else
                {
                    Label3.Text = "Record Not Found";
                }

            }
            else
            {
                Label3.Text = "Please select Acount Number";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception t)
        {
            Label3.Text = "error";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.Text != "----------SELECT------------")
            {
                SqlConnection con = new SqlConnection(s);
               
                string s2 = TextBox10.Text;
                string dd = s2.Substring(0, 2);
                string mm = s2.Substring(3, 2);
                string yy = s2.Substring(6, 4);
                string date1 = mm + "/" + dd + "/" + yy;
                int yu = 0;
                if (DropDownList3.Text == "DEBIT ( - )")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update  bank set NAME='" + TextBox8.Text + "',DEBIT=" + TextBox9.Text + ",CREDIT=" + yu + ",DATE='" + date1 + "',REFNO='" + TextBox11.Text + "',REASON='" + TextBox12.Text + "',STATUS='Dr',paymod='" + DropDownList5.Text + "',chequetype='"+DropDownList7.Text+"' where ID=" + TextBox13.Text + "", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        Label2.Text = "Record Updated Successfully";
                        bind1();
                    }
                    else
                    {
                        Label2.Text = "error";
                    }
                }
                if (DropDownList3.Text == "CREDIT ( + )")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update  bank set NAME='" + TextBox8.Text + "',DEBIT=" + yu + ",CREDIT=" + TextBox9.Text + ",DATE='" + date1 + "',REFNO='" + TextBox11.Text + "',REASON='" + TextBox12.Text + "',STATUS='Cr' ,paymod='" + DropDownList5.Text + "',chequetype='" + DropDownList7.Text + "' where ID=" + TextBox13.Text + "", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        Label2.Text = "Record Updated Successfully";
                        bind1();
                    }
                    else
                    {
                        Label2.Text = "error";
                    }
                }

            }
            else
            {
                Label2.Text = "Please select Acount Number";
              
         
                GridView1.DataSource = null;
                GridView1.DataBind();
           
            }
        }
        catch (Exception t)
        {
            Label2.Text = "error";
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblid = (Label)e.Row.FindControl("id1");
            Label lbldate = (Label)e.Row.FindControl("date1");
            Label lblname = (Label)e.Row.FindControl("name1");
            Label lblpay = (Label)e.Row.FindControl("pay1");
            Label lblcheq = (Label)e.Row.FindControl("cheq1");
            Label lblref = (Label)e.Row.FindControl("ref1");
            Label lblstatus = (Label)e.Row.FindControl("status1");
            Label lbldebit = (Label)e.Row.FindControl("debit1");
            Label lblcredit = (Label)e.Row.FindControl("credit1");
            Label lblreason = (Label)e.Row.FindControl("reason1");

            if (lblstatus.Text == "Dr")
            {

                lblid.Style.Add("color", "red");
                lbldate.Style.Add("color", "red");
                lblpay.Style.Add("color", "red");
                lblcheq.Style.Add("color", "red");
                lblname.Style.Add("color", "red");
                lblref.Style.Add("color", "red");
                lblstatus.Style.Add("color", "red");
                lbldebit.Style.Add("color", "red");
                lblcredit.Style.Add("color", "red");
                lblreason.Style.Add("color", "red");

            }
            if (lblstatus.Text == "Cr")
            {

                lblid.Style.Add("color", "green");
                lbldate.Style.Add("color", "green");
                lblname.Style.Add("color", "green");
                lblpay.Style.Add("color", "green");
                lblcheq.Style.Add("color", "green");
                lblref.Style.Add("color", "green");
                lblstatus.Style.Add("color", "green");
                lbldebit.Style.Add("color", "green");
                lblcredit.Style.Add("color", "green");
                lblreason.Style.Add("color", "green");

            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from  bank where ID=" + TextBox13.Text + "", con);
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i != 0)
        {
            Label3.Text = "Record deleted Successfully";
            bind1();
        }
        else
        {
            Label3.Text = "error";
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text != "----------SELECT------------")
        {
            account();
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        bind2();
    }
}