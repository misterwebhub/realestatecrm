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
using System.Globalization;
public partial class RECIPTUPFATE : System.Web.UI.Page
{
    string s1 = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {         
if(Session["ID"] != null)
			{
				Label4.Text = Session["ID"].ToString();
			   //Label13.Text = "heedrealestate";
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            Panel5.Visible = false;
            Panel6.Visible = false;

        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = false;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Panel5.Visible = false;
        Panel7.Visible = false;
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = true;
        Panel5.Visible = false;
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel5.Visible = true;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        try
        {
           // st = "";
            st1 = "";
            SqlConnection con = new SqlConnection(s1);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select status from kishanrecipt where  reciptid='" + TextBox23.Text + "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0][0].ToString() == "PAID")
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select kid,arazi,name,date,paymode,cheqdate,cheqno,refno,status,amount,reason,broker,bpaid,breason from kishanrecipt where  reciptid='" + TextBox23.Text + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label2.Text = ds.Tables[0].Rows[0][0].ToString();
                        Label3.Text = ds.Tables[0].Rows[0][1].ToString();
                        Label4.Text = ds.Tables[0].Rows[0][2].ToString();
                        //date Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                        string s3 = ds.Tables[0].Rows[0][3].ToString();
                        DateTime r = Convert.ToDateTime(s3);
                        int s = Convert.ToInt32(r.Day.ToString());
                        int m = Convert.ToInt32(r.Month.ToString());
                        if (m == 1 || m == 2 || m == 3 || m == 4 || m == 5 || m == 6 || m == 7 || m == 8 || m == 9)
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 1);
                                string yy = s2.Substring(4, 4);
                                string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 2);
                                string yy = s2.Substring(5, 4);
                                string date1 = dd + "/" + "0" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();
                            }

                        }
                        else
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 1);
                                string yy = s2.Substring(5, 4);
                                string date1 = "0" + dd + "/" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 2);
                                string yy = s2.Substring(6, 4);
                                string date1 = dd + "/" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();
                            }
                        }
                        TextBox5.Text = ds.Tables[0].Rows[0][13].ToString();
                        TextBox1.Text = ds.Tables[0].Rows[0][9].ToString();
                        TextBox2.Text = ds.Tables[0].Rows[0][10].ToString();
                        Label10.Text = ds.Tables[0].Rows[0][11].ToString();
                        TextBox4.Text = ds.Tables[0].Rows[0][12].ToString();
                        st1 = ds.Tables[0].Rows[0][8].ToString();

                        if (ds.Tables[0].Rows[0][4].ToString() != "CASH")
                        {
                            Panel1.Visible = true;
                            RadioButton2.Checked = true;
                            RadioButton1.Checked = false;
                            // TextBox8.Text = ds.Tables[0].Rows[0][5].ToString();
                            TextBox6.Text = ds.Tables[0].Rows[0][6].ToString();
                            TextBox7.Text = ds.Tables[0].Rows[0][7].ToString();
                            DropDownList1.Text = ds.Tables[0].Rows[0][8].ToString();
                            string s4 = ds.Tables[0].Rows[0][5].ToString();
                            DateTime r1 = Convert.ToDateTime(s4);
                            int s8 = Convert.ToInt32(r1.Day.ToString());
                            int m2 = Convert.ToInt32(r1.Month.ToString());
                            if (m2 == 1 || m2 == 2 || m2 == 3 || m2 == 4 || m2 == 5 || m2 == 6 || m2 == 7 || m2 == 8 || m2 == 9)
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 1);
                                    string yy = s2.Substring(4, 4);
                                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 2);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();
                                }

                            }
                            else
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 1);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 2);
                                    string yy = s2.Substring(6, 4);
                                    string date1 = dd + "/" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();
                                }
                            }



                        }
                        else
                        {
                            Panel1.Visible = false;
                            RadioButton1.Checked = true;
                            RadioButton2.Checked = false;
                        }
                    }
                    else
                    {
                        Label9.Text = "Recipt No. Not Found";
                    }
                }

                if (ds1.Tables[0].Rows[0][0].ToString() == "UNPAID")
                {

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select kid,arazi,name,date,paymode,cheqdate,cheqno,refno,status,unpaidamt,reason,broker,bpaid,breason from kishanrecipt where  reciptid='" + TextBox23.Text + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label2.Text = ds.Tables[0].Rows[0][0].ToString();
                        Label3.Text = ds.Tables[0].Rows[0][1].ToString();
                        Label4.Text = ds.Tables[0].Rows[0][2].ToString();
                        //date Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                        string s3 = ds.Tables[0].Rows[0][3].ToString();
                        DateTime r = Convert.ToDateTime(s3);
                        int s = Convert.ToInt32(r.Day.ToString());
                        int m = Convert.ToInt32(r.Month.ToString());
                        if (m == 1 || m == 2 || m == 3 || m == 4 || m == 5 || m == 6 || m == 7 || m == 8 || m == 9)
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 1);
                                string yy = s2.Substring(4, 4);
                                string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 2);
                                string yy = s2.Substring(5, 4);
                                string date1 = dd + "/" + "0" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();
                            }

                        }
                        else
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 1);
                                string yy = s2.Substring(5, 4);
                                string date1 = "0" + dd + "/" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 2);
                                string yy = s2.Substring(6, 4);
                                string date1 = dd + "/" + mm + "/" + yy;
                                TextBox3.Text = date1.ToString();
                            }
                        }
                        TextBox5.Text = ds.Tables[0].Rows[0][13].ToString();
                        TextBox1.Text = ds.Tables[0].Rows[0][9].ToString();
                        TextBox2.Text = ds.Tables[0].Rows[0][10].ToString();
                        Label10.Text = ds.Tables[0].Rows[0][11].ToString();
                        TextBox4.Text = ds.Tables[0].Rows[0][12].ToString();
                        st1 = ds.Tables[0].Rows[0][8].ToString();

                        if (ds.Tables[0].Rows[0][4].ToString() != "CASH")
                        {
                            Panel1.Visible = true;
                            RadioButton2.Checked = true;
                            RadioButton1.Checked = false;
                            // TextBox8.Text = ds.Tables[0].Rows[0][5].ToString();
                            TextBox6.Text = ds.Tables[0].Rows[0][6].ToString();
                            TextBox7.Text = ds.Tables[0].Rows[0][7].ToString();
                            DropDownList1.Text = ds.Tables[0].Rows[0][8].ToString();
                            string s4 = ds.Tables[0].Rows[0][5].ToString();
                            DateTime r1 = Convert.ToDateTime(s4);
                            int s8 = Convert.ToInt32(r1.Day.ToString());
                            int m2 = Convert.ToInt32(r1.Month.ToString());
                            if (m2 == 1 || m2 == 2 || m2 == 3 || m2 == 4 || m2 == 5 || m2 == 6 || m2 == 7 || m2 == 8 || m2 == 9)
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 1);
                                    string yy = s2.Substring(4, 4);
                                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 2);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();
                                }

                            }
                            else
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 1);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 2);
                                    string yy = s2.Substring(6, 4);
                                    string date1 = dd + "/" + mm + "/" + yy;
                                    TextBox8.Text = date1.ToString();
                                }
                            }



                        }
                        else
                        {
                            Panel1.Visible = false;
                            RadioButton1.Checked = true;
                            RadioButton2.Checked = false;
                        }
                    }
                    else
                    {
                        Label9.Text = "Recipt No. Not Found";
                    }
                }

            } 
            

        }
        catch (Exception t)
        {
            Label9.Text = "Due to error";
        }
    }
    public static string st1;
    protected void Button1_Click(object sender, EventArgs e)
    {
        String mode = "";
        String chkdate, chknn, refno, status;
        string dateString = TextBox3.Text;
        SqlConnection con = new SqlConnection(s1);
       
        if (RadioButton1.Checked)
        {
            mode = "CASH";
            string s7 = TextBox3.Text;
            string dd = s7.Substring(0, 2);
            string mm = s7.Substring(3, 2);
            string yy = s7.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            chkdate = null;
            chknn = null;
            refno = null;
            status = "PAID";
            SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + status + "',amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='"+TextBox5.Text+"' where  reciptid='" + TextBox23.Text + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                Label9.Text = "Record Updated Sucessfully";
              
            }

            else
            {
                Label9.Text = "error";
            }

            con.Close();
        }
        if(RadioButton2.Checked)
        {
            mode = "CHEQUE";
            string s7 = TextBox3.Text;
            string dd = s7.Substring(0, 2);
            string mm = s7.Substring(3, 2);
            string yy = s7.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox8.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ck = mm1 + "/" + dd1 + "/" + yy1;
            chkdate = ck;
            chknn = TextBox6.Text;
            refno = TextBox7.Text;
            if (DropDownList1.Text == st1)
            {
                if (DropDownList1.Text == "PAID")
                {
                    SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "'  where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label9.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label9.Text = "error";
                    }

                    con.Close();
                }
                if (DropDownList1.Text == "UNPAID")
                {
                    SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',unpaidamt=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "',amount=0  where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label9.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label9.Text = "error";
                    }

                    con.Close();
                }
            }
            else
            {
                if (DropDownList1.Text == "PAID")
                {
                    SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + chkdate + "',paymode='" + mode + "', cheqdate='" + date1 + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',unpaidamt=0,amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "' where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label9.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label9.Text = "error";
                    }

                    con.Close();
                }
                if (DropDownList1.Text == "UNPAID")
                {
                    SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',unpaidamt=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "',amount=0  where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label9.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label9.Text = "error";
                    }

                    con.Close();
                }
            }

            
        }


    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s1);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from  kishanrecipt where  reciptid='" + TextBox23.Text + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label9.Text = "Record Deleted";
        }
        else
        {
            Label9.Text = "Error";
        }
    }
    public static string st;
    protected void Button10_Click(object sender, EventArgs e)
    {
        try
        {
            st1 = "";
            SqlConnection con = new SqlConnection(s1);
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select status from  investerrecipt where  invrecipt='" + TextBox24.Text + "'", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0][0].ToString() == "PAID")
                {
                 
                   
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("select invid,name,date,amount,type,paymode,chekdate, chkno,refby,status,reason,bname,bpaid,breason from investerrecipt where  invrecipt='" + TextBox24.Text + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label20.Text = ds.Tables[0].Rows[0][0].ToString();
                        Label22.Text = ds.Tables[0].Rows[0][1].ToString();
                        TextBox16.Text = ds.Tables[0].Rows[0][3].ToString();
                        DropDownList4.Text = ds.Tables[0].Rows[0][4].ToString();
                        //date Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                        string s3 = ds.Tables[0].Rows[0][2].ToString();
                        DateTime r = Convert.ToDateTime(s3);
                        int s = Convert.ToInt32(r.Day.ToString());
                        int m = Convert.ToInt32(r.Month.ToString());
                        if (m == 1 || m == 2 || m == 3 || m == 4 || m == 5 || m == 6 || m == 7 || m == 8 || m == 9)
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 1);
                                string yy = s2.Substring(4, 4);
                                string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 2);
                                string yy = s2.Substring(5, 4);
                                string date1 = dd + "/" + "0" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();
                            }

                        }
                        else
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 1);
                                string yy = s2.Substring(5, 4);
                                string date1 = "0" + dd + "/" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 2);
                                string yy = s2.Substring(6, 4);
                                string date1 = dd + "/" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();
                            }
                        }
                        TextBox20.Text = ds.Tables[0].Rows[0][10].ToString();
                        TextBox21.Text = ds.Tables[0].Rows[0][12].ToString();
                        TextBox22.Text = ds.Tables[0].Rows[0][13].ToString();
                        Label27.Text = ds.Tables[0].Rows[0][11].ToString();
                        st = ds.Tables[0].Rows[0][9].ToString();
                        if (ds.Tables[0].Rows[0][5].ToString() != "CASH")
                        {
                            Panel7.Visible = true;
                            RadioButton6.Checked = true;
                            RadioButton5.Checked = false;
                            // TextBox8.Text = ds.Tables[0].Rows[0][5].ToString();
                            TextBox18.Text = ds.Tables[0].Rows[0][7].ToString();
                            TextBox19.Text = ds.Tables[0].Rows[0][8].ToString();
                            DropDownList3.Text = ds.Tables[0].Rows[0][9].ToString();

                            string s4 = ds.Tables[0].Rows[0][6].ToString();
                            DateTime r1 = Convert.ToDateTime(s4);
                            int s8 = Convert.ToInt32(r1.Day.ToString());
                            int m2 = Convert.ToInt32(r1.Month.ToString());
                            if (m2 == 1 || m2 == 2 || m2 == 3 || m2 == 4 || m2 == 5 || m2 == 6 || m2 == 7 || m2 == 8 || m2 == 9)
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 1);
                                    string yy = s2.Substring(4, 4);
                                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 2);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();
                                }

                            }
                            else
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 1);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 2);
                                    string yy = s2.Substring(6, 4);
                                    string date1 = dd + "/" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();
                                }
                            }



                        }
                        else
                        {
                            Panel7.Visible = false;
                            RadioButton5.Checked = true;
                            RadioButton6.Checked = false;
                        }
                    }
                    else
                    {
                        Label36.Text = "Recipt No. Not Found";
                    }
                }

                if (ds1.Tables[0].Rows[0][0].ToString() == "UNPAID")
                {
                    
                    
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("select invid,name,date,unpamt,type,paymode,chekdate, chkno,refby,status,reason,bname,bpaid,breason from investerrecipt where  invrecipt='" + TextBox24.Text + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Label20.Text = ds.Tables[0].Rows[0][0].ToString();
                        Label22.Text = ds.Tables[0].Rows[0][1].ToString();
                        TextBox16.Text = ds.Tables[0].Rows[0][3].ToString();
                        DropDownList4.Text = ds.Tables[0].Rows[0][4].ToString();
                        //date Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                        string s3 = ds.Tables[0].Rows[0][2].ToString();
                        DateTime r = Convert.ToDateTime(s3);
                        int s = Convert.ToInt32(r.Day.ToString());
                        int m = Convert.ToInt32(r.Month.ToString());
                        if (m == 1 || m == 2 || m == 3 || m == 4 || m == 5 || m == 6 || m == 7 || m == 8 || m == 9)
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 1);
                                string yy = s2.Substring(4, 4);
                                string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 1);
                                string dd = s2.Substring(2, 2);
                                string yy = s2.Substring(5, 4);
                                string date1 = dd + "/" + "0" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();
                            }

                        }
                        else
                        {
                            if (s == 1 || s == 2 || s == 3 || s == 4 || s == 5 || s == 6 || s == 7 || s == 8 || s == 9)
                            {
                                string s2 = r.ToString("M/d/yyyy ");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 1);
                                string yy = s2.Substring(5, 4);
                                string date1 = "0" + dd + "/" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();

                            }
                            else
                            {
                                string s2 = r.ToString("M/d/yyyy");
                                string mm = s2.Substring(0, 2);
                                string dd = s2.Substring(3, 2);
                                string yy = s2.Substring(6, 4);
                                string date1 = dd + "/" + mm + "/" + yy;
                                TextBox15.Text = date1.ToString();
                            }
                        }
                        TextBox20.Text = ds.Tables[0].Rows[0][10].ToString();
                        TextBox21.Text = ds.Tables[0].Rows[0][12].ToString();
                        TextBox22.Text = ds.Tables[0].Rows[0][13].ToString();
                        Label27.Text = ds.Tables[0].Rows[0][11].ToString();
                        st = ds.Tables[0].Rows[0][9].ToString();
                        if (ds.Tables[0].Rows[0][5].ToString() != "CASH")
                        {
                            Panel7.Visible = true;
                            RadioButton6.Checked = true;
                            RadioButton5.Checked = false;
                            // TextBox8.Text = ds.Tables[0].Rows[0][5].ToString();
                            TextBox18.Text = ds.Tables[0].Rows[0][7].ToString();
                            TextBox19.Text = ds.Tables[0].Rows[0][8].ToString();
                            DropDownList3.Text = ds.Tables[0].Rows[0][9].ToString();

                            string s4 = ds.Tables[0].Rows[0][6].ToString();
                            DateTime r1 = Convert.ToDateTime(s4);
                            int s8 = Convert.ToInt32(r1.Day.ToString());
                            int m2 = Convert.ToInt32(r1.Month.ToString());
                            if (m2 == 1 || m2 == 2 || m2 == 3 || m2 == 4 || m2 == 5 || m2 == 6 || m2 == 7 || m2 == 8 || m2 == 9)
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 1);
                                    string yy = s2.Substring(4, 4);
                                    string date1 = "0" + dd + "/" + "0" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 1);
                                    string dd = s2.Substring(2, 2);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = dd + "/" + "0" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();
                                }

                            }
                            else
                            {
                                if (s8 == 1 || s8 == 2 || s8 == 3 || s8 == 4 || s8 == 5 || s8 == 6 || s8 == 7 || s8 == 8 || s8 == 9)
                                {
                                    string s2 = r1.ToString("M/d/yyyy ");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 1);
                                    string yy = s2.Substring(5, 4);
                                    string date1 = "0" + dd + "/" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();

                                }
                                else
                                {
                                    string s2 = r1.ToString("M/d/yyyy");
                                    string mm = s2.Substring(0, 2);
                                    string dd = s2.Substring(3, 2);
                                    string yy = s2.Substring(6, 4);
                                    string date1 = dd + "/" + mm + "/" + yy;
                                    TextBox17.Text = date1.ToString();
                                }
                            }



                        }
                        else
                        {
                            Panel7.Visible = false;
                            RadioButton5.Checked = true;
                            RadioButton6.Checked = false;
                        }
                    }
                    else
                    {
                        Label36.Text = "Recipt No. Not Found";
                    }
                }

            } 

        }
        catch (Exception t)
        {
            Label36.Text = "Due to error";
        }
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        Panel7.Visible =false;
    }
    protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
    {
        Panel7.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        String mode = "";
        String chkdate, chknn, refno, status;
        string dateString = TextBox15.Text;
        SqlConnection con = new SqlConnection(s1);

        if (RadioButton5.Checked)
        {
            mode = "CASH";
            string s7 = TextBox15.Text;
            string dd = s7.Substring(0, 2);
            string mm = s7.Substring(3, 2);
            string yy = s7.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            chkdate = null;
            chknn = null;
            refno = null;
            status = "PAID";
            SqlCommand cmd = new SqlCommand("update  investerrecipt set name='" + Label22.Text + "',date='" + date1 + "',amount=" + TextBox16.Text + ",type='" + DropDownList4.Text + "',paymode='" + mode + "',chekdate='" + chkdate + "', chkno='" + chknn + "',refby='" + refno + "',status='" + status + "',reason='" + TextBox20.Text + "',bname='" + Label27.Text + "',bpaid=" + TextBox21.Text + ",breason='" + TextBox22.Text + "' where  invrecipt='" + TextBox24.Text + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                Label36.Text = "Record Updated Sucessfully";

            }

            else
            {
                Label36.Text = "error";
            }

            con.Close();
        }
        if (RadioButton6.Checked)
        {
            mode = "CHEQUE";
            string s7 = TextBox15.Text;
            string dd = s7.Substring(0, 2);
            string mm = s7.Substring(3, 2);
            string yy = s7.Substring(6, 4);
            string date1 = mm + "/" + dd + "/" + yy;
            string s3 = TextBox17.Text;
            string dd1 = s3.Substring(0, 2);
            string mm1 = s3.Substring(3, 2);
            string yy1 = s3.Substring(6, 4);
            string ck = mm1 + "/" + dd1 + "/" + yy1;
            chkdate = ck;
            chknn = TextBox18.Text;
            refno = TextBox19.Text;
            if (DropDownList3.Text == st)
            {
                if (DropDownList3.Text == "PAID")
                {
                    SqlCommand cmd = new SqlCommand("update  investerrecipt set name='" + Label22.Text + "',date='" + date1 + "',amount=" + TextBox16.Text + ",type='" + DropDownList4.Text + "',paymode='" + mode + "',chekdate='" + chkdate + "', chkno='" + chknn + "',refby='" + refno + "',status='" + DropDownList3.Text + "',reason='" + TextBox20.Text + "',bname='" + Label27.Text + "',bpaid=" + TextBox21.Text + ",breason='" + TextBox22.Text + "' where  invrecipt='" + TextBox24.Text + "'", con);
                    // SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "'  where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label36.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label36.Text = "error";
                    }

                    con.Close();
                }
                if (DropDownList3.Text == "UNPAID")
                {
                    SqlCommand cmd = new SqlCommand("update  investerrecipt set name='" + Label22.Text + "',date='" + date1 + "',unpamt=" + TextBox16.Text + ",type='" + DropDownList4.Text + "',paymode='" + mode + "',chekdate='" + chkdate + "', chkno='" + chknn + "',refby='" + refno + "',status='" + DropDownList3.Text + "',reason='" + TextBox20.Text + "',bname='" + Label27.Text + "',bpaid=" + TextBox21.Text + ",breason='" + TextBox22.Text + "' where  invrecipt='" + TextBox24.Text + "'", con);
                    // SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "'  where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label36.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label36.Text = "error";
                    }

                    con.Close();
                }
            }
            else
            {

                if (DropDownList3.Text == "PAID")
                {
                    SqlCommand cmd = new SqlCommand("update  investerrecipt set name='" + Label22.Text + "',date='" + chkdate + "',amount=" + TextBox16.Text + ",unpamt=0,type='" + DropDownList4.Text + "',paymode='" + mode + "',chekdate='" + date1 + "', chkno='" + chknn + "',refby='" + refno + "',status='" + DropDownList3.Text + "',reason='" + TextBox20.Text + "',bname='" + Label27.Text + "',bpaid=" + TextBox21.Text + ",breason='" + TextBox22.Text + "' where  invrecipt='" + TextBox24.Text + "'", con);
                    // SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + chkdate + "',paymode='" + mode + "', cheqdate='" + date1 + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "' where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label36.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label36.Text = "error";
                    }

                    con.Close();
                }
                if (DropDownList3.Text == "UNPAID")
                {
                    SqlCommand cmd = new SqlCommand("update  investerrecipt set name='" + Label22.Text + "',date='" + date1 + "',amount=0,unpamt=" + TextBox16.Text + ",type='" + DropDownList4.Text + "',paymode='" + mode + "',chekdate='" + chkdate + "', chkno='" + chknn + "',refby='" + refno + "',status='" + DropDownList3.Text + "',reason='" + TextBox20.Text + "',bname='" + Label27.Text + "',bpaid=" + TextBox21.Text + ",breason='" + TextBox22.Text + "' where  invrecipt='" + TextBox24.Text + "'", con);
                    // SqlCommand cmd = new SqlCommand("update kishanrecipt set date='" + date1 + "',paymode='" + mode + "', cheqdate='" + chkdate + "',cheqno='" + chknn + "',refno='" + refno + "',status='" + DropDownList1.Text + "',amount=" + TextBox1.Text + ",reason='" + TextBox2.Text + "',bpaid=" + TextBox4.Text + ",breason='" + TextBox5.Text + "'  where  reciptid='" + TextBox23.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        Label36.Text = "Record Updated Sucessfully";

                    }

                    else
                    {
                        Label36.Text = "error";
                    }

                    con.Close();
                }
            }

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s1);
        con.Open();
        SqlCommand cmd = new SqlCommand("delete from  investerrecipt where  invrecipt='" + TextBox24.Text + "'", con);
        int i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            Label36.Text = "Record Deleted";
        }
        else
        {
            Label36.Text = "Error";
        }
    }
}