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

public partial class regcertificate : System.Web.UI.Page
{
    static List<int> dblock = new List<int>();
	static List<int> Eblock = new List<int>();
	static List<int> Fblock = new List<int>();
    static List<int> bblock = new List<int>();
    static List<int> cblock = new List<int>();
    static List<int> ablock = new List<int>();
   string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Panel1.Visible = false;
            Panel2.Visible = false;
            DateTime r = DateTime.Now;
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
               TextBox1.Text = date1.ToString();

            }
            else
            {
                string s2 = r.ToString("M/d/yyyy");
                string mm = s2.Substring(0, 1);
                string dd = s2.Substring(2, 2);
                string yy = s2.Substring(5, 4);
                string date1 = dd + "/" + "0" + mm + "/" + yy;
              TextBox1.Text = date1.ToString();
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
                 TextBox1.Text = date1.ToString();

            }
            else
            {
                string s2 = r.ToString("M/d/yyyy");
                string mm = s2.Substring(0, 2);
                string dd = s2.Substring(3, 2);
                string yy = s2.Substring(6, 4);
                string date1 = dd + "/" + mm + "/" + yy;
                TextBox1.Text = date1.ToString();
            }
        }
			if(Session["ID"] != null)
			{
				Label4.Text = Session["ID"].ToString();
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}
			
            
     // Label4.Text = "heedrealestate";
            bindl();
          
          
        }
    }
    public void bindl()
    {
        DropDownList3.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
		con.Open();
        SqlDataAdapter da7 = new SqlDataAdapter("select DISTINCT loc from softploted1", con);
        DataSet ds7 = new DataSet();
        da7.Fill(ds7);
        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from softploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
		
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT name from brokarpage", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
			DropDownList4.Items.Add("----SELECT----");
		DropDownList3.Items.Add("----SELECT----");
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
           // DropDownList2.Items.Add(ds7.Tables[0].Rows[i][0].ToString());
        }
		for (int i = 0; i < ds7.Tables[0].Rows.Count; i++)
        {
           // DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList2.Items.Add(ds7.Tables[0].Rows[i][0].ToString());
        }
        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
		
            DropDownList4.Items.Add(ds1.Tables[0].Rows[i][0].ToString());
           
        }
        con.Close();
    }

         public void fetch()
    {
        SqlConnection con1 = new SqlConnection(s);
        con1.Open();
        int rcid=0;
        SqlCommand cmd = new SqlCommand("select max(ID) from customerreg3", con1);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows == true)
        {
            while (dr.Read())
            {
               rcid =Convert.ToInt32(dr.GetValue(0));
            }
            rcid = rcid + 1;
            Label1.Text = "REG00"+rcid.ToString();
            con1.Close();
        }

    
    }
         public void recipt()
         {
             try
             {
                 SqlConnection con1 = new SqlConnection(s);
                 con1.Open();
                 int rcid = 0;
                 SqlCommand cmd = new SqlCommand("select max(RCID) from recipt3", con1);
                 SqlDataReader dr = cmd.ExecuteReader();
                 if (dr.HasRows == true)
                 {
                     while (dr.Read())
                     {
                         rcid = Convert.ToInt32(dr.GetValue(0));
                     }
                     rcid = rcid + 1;
                     TextBox16.Text = rcid.ToString();
                     con1.Close();
                 }
             }
             catch (Exception t)
             {
                 Label1.Text = "Due to error"+t;
             }
         }
         
         public void printreg()
         {
             Session["creg"] = Label1.Text;
             Session["dateofcom"] = TextBox1.Text;
             Session["plan"] = DropDownList2.Text;
             Session["mod"] = DropDownList1.Text;
             Session["consamt"] = TextBox4.Text;
             Session["instpay"] = TextBox5.Text;
             Session["subduedate"] = TextBox6.Text;
             Session["exppay"] = TextBox7.Text;
             Session["dateoflast"] = TextBox8.Text;
             Session["expirydate"] = TextBox9.Text;
             Session["agency"] = TextBox10.Text;
             Session["namedbad"] = TextBox11.Text;
             Session["appno"] = DropDownList3.Text;
             Session["plotsize"] =plotno+"/"+TextBox13.Text;
             Session["nominee"] = TextBox14.Text;
             Session["reciptno"] = TextBox16.Text;
             Session["amountword"] = TextBox17.Text;
             Session["name2nominee"] = TextBox18.Text;
             Session["espr"] = TextBox15.Text;
             Session["idcard"] = TextBox2.Text;
            // Session["mobile2"] = TextBox21.Text;

         }
         public string plotbind1()
         {
             string plot = "";
             for (int i = 0; i < ablock.Count; i++)
             {
                 plot = plot + ablock[i].ToString() + ",";
             }
             
             return plot;
         }
         public string plotbind()
         {
             string plot = "";
             for (int i = 0; i < ablock.Count; i++)
             {
                 plot =plot+ablock[i].ToString()+"A,";
             }
             for (int i = 0; i < bblock.Count; i++)
             {
                 plot = plot + bblock[i].ToString() + "B,";
             }
             for (int i = 0; i < cblock.Count; i++)
             {
                 plot = plot + cblock[i].ToString() + "C,";
             }
             for (int i = 0; i < dblock.Count; i++)
             {
                 plot = plot + dblock[i].ToString() + "D,";
             }
			 for (int i = 0; i < Eblock.Count; i++)
             {
                 plot = plot + Eblock[i].ToString() + "E,";
             }
			  for (int i = 0; i < Fblock.Count; i++)
             {
                 plot = plot + Fblock[i].ToString() + "F,";
             }
             return plot;
         }
         string plotno = "";
         public Double dppay()
         {
             Double dppayamt=0;
             String arazi = DropDownList3.Text;
             if ( arazi=="37 JAJMAU")
             {
                 if (TextBox4.Text != "")
                 {
                     dppayamt = Convert.ToDouble(TextBox4.Text)*0.50;
                 }
                 else
                 {
                     dppayamt = 0;
                 }
             }
             else
             {
                 if (arazi == "375KA" || arazi == "30" || arazi == "174MI" || arazi == "372KA" || arazi == "385KA")
                 {
                     if (TextBox4.Text != "")
                     {
                         dppayamt = Convert.ToDouble(TextBox4.Text) * 0.35;
                     }
                     else
                     {
                         dppayamt = 0;
                     }
                 }
                 else
                 {
                     if (TextBox4.Text != "")
                     {
                         dppayamt = Convert.ToDouble(TextBox4.Text) * 0.25;
                     }
                     else
                     {
                         dppayamt = 0;
                     }
                 }
             }
             return dppayamt;

         }
         protected void Button1_Click(object sender, EventArgs e)
         {
             try
             {
                 if ( DropDownList3.Text == "37 JAJMAU")
                 {
                     plotno = plotbind1();
                 }
                 if (DropDownList3.Text == "152")
                 {
                     plotno = plotbind();
                 }
                 else
                 {
                     plotno = TextBox20.Text;
                 }

                 fetch();
                // bindl();
                 recipt();
                 string s1 = TextBox20.Text;
                 string ddd = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
				 string s22 =TextBox8.Text ;
                string dd = s22.Substring(0, 2);
                string mm = s22.Substring(3, 2);
                string yy = s22.Substring(6, 4);
                string date12 = mm + "/" + dd + "/" + yy;
                Double totaldppay = dppay();
                 SqlConnection con1 = new SqlConnection(s);
                 con1.Open();
                 SqlCommand cmd = new SqlCommand("insert into customerreg3(CUSTREGNO,DATEOFCOM,PLANANDTERM,MODOFPAY,CONSAMOUNT,INSTSUBPAY,SUBDUEDATE,EXPPAY,DATEOFLAST,EXPIRYDATE,AGENCYID,NAMEDOBADDRESS,APPNO,PLOTSIZE,NOMINEESNAME,RECIPTNO,AMOUNTWORD,ESPR,CHECKBY,plotno,mobile,idcard,date3,mobile2,usertype,ragistry,ragistryamt,lastdate,downpay,lockreg,mobile3)values('" + Label1.Text + "','" + TextBox1.Text + "','" + DropDownList2.Text + "','" + DropDownList1.Text + "'," + TextBox4.Text + "," + TextBox5.Text + ",'" + TextBox6.Text + "'," + TextBox7.Text + ",'" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + DropDownList3.Text + "'," + TextBox13.Text + ",'" + TextBox14.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "'," + TextBox15.Text + ",'" + DropDownList4.Text + "','" + plotno + "','" + TextBox3.Text + "','" + TextBox2.Text + "','" + ddd + "','" + TextBox21.Text + "','" + Label4.Text + "',NULL,0,'" + date12 + "'," + totaldppay + ",'UNLOCK','" + TextBox45.Text + "')", con1);
                 int i = cmd.ExecuteNonQuery();
                 con1.Close();
              /*   con1.Open();
                 SqlCommand cmd1 = new SqlCommand("insert into customerreg2(CUSTREGNO,DATEOFCOM,PLANANDTERM,MODOFPAY,CONSAMOUNT,INSTSUBPAY,SUBDUEDATE,EXPPAY,DATEOFLAST,EXPIRYDATE,AGENCYID,NAMEDOBADDRESS,APPNO,PLOTSIZE,NOMINEESNAME,RECIPTNO,AMOUNTWORD,ESPR,CHECKBY,plotno,mobile,idcard,date3,mobile2,usertype,ragistry,ragistryamt,lastdate,downpay)values('" + Label1.Text + "','" + TextBox1.Text + "','" + DropDownList2.Text + "','" + DropDownList1.Text + "'," + TextBox4.Text + "," + TextBox5.Text + ",'" + TextBox6.Text + "'," + TextBox7.Text + ",'" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox10.Text + "','" + TextBox11.Text + "','" + DropDownList3.Text + "'," + TextBox13.Text + ",'" + TextBox14.Text + "','" + TextBox16.Text + "','" + TextBox17.Text + "'," + TextBox15.Text + ",'" + DropDownList4.Text + "','" + plotno + "','" + TextBox3.Text + "','" + TextBox2.Text + "','" + ddd + "','" + TextBox21.Text + "','" + Label4.Text + "',NULL,0,'" + date12 + "'," + totaldppay + ")", con1);
                i = cmd1.ExecuteNonQuery();
                 con1.Close();*/
                 //con1.Open();
                // SqlCommand cmd1 = new SqlCommand("update plot set book='unavailable' where plotno=" + s1 + "", con1);
                // i = cmd1.ExecuteNonQuery();

                 if (i == 1)
                 {
                     Label2.Text = "Thank You for Paid Installment";
                     printreg();
                     plotbook();
       Response.Redirect("~/home/printreg.aspx");
                 }
                 else
                 {
                     Label2.Text = "Due to internal error";
                 }

             }
             catch (Exception t)
             {
                 Label2.Text = "internal problem";
             }
         }
         protected void TextBox4_TextChanged(object sender, EventArgs e)
         {
            // TextBox7.Text = TextBox4.Text;
             TextBox15.Text = TextBox4.Text;
         }
         protected void TextBox11_TextChanged(object sender, EventArgs e)
         {
             TextBox18.Text = TextBox11.Text;
         }

         protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (DropDownList3.Text == "------select-------")
             {
                 //Label5.Text = "Please select any arazi";
             }
             
             if (DropDownList3.Text == "152")
             {
                 Panel1.Visible = true;
                 TextBox20.ReadOnly=true;
             }
             else
             {
                 if ( DropDownList3.Text == "37 JAJMAU")
                 {
                     Panel1.Visible = true;
                     TextBox20.ReadOnly = true;
                     Label7.Visible = false;
                     DropDownList5.Visible = false;
                 }
                 else
                 {
                     Panel1.Visible = false;
                     TextBox20.ReadOnly = false;
                 }
             }
         }
         public void plotbook()
         {
             SqlConnection con = new SqlConnection(s);
             
             if (DropDownList3.Text == "152")
             {
                 con.Open();
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     int pl = Convert.ToInt32(ablock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book',CUSTREGNO='" + Label1.Text + "' where block='A' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
                 for (int i = 0; i < bblock.Count; i++)
                 {
                     int pl = Convert.ToInt32(bblock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book',CUSTREGNO='" + Label1.Text + "' where block='B' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
                 for (int i = 0; i < cblock.Count; i++)
                 {
                     int pl = Convert.ToInt32(cblock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book',CUSTREGNO='" + Label1.Text + "' where block='C' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
                 for (int i = 0; i < dblock.Count; i++)
                 {
                     int pl = Convert.ToInt32(dblock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book',CUSTREGNO='" + Label1.Text + "' where block='D' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
				 for (int i = 0; i < Eblock.Count; i++)
                 {
                     int pl = Convert.ToInt32(Eblock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book',CUSTREGNO='" + Label1.Text + "' where block='E' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
				 for (int i = 0; i < Fblock.Count; i++)
                 {
                     int pl = Convert.ToInt32(Fblock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book',CUSTREGNO='" + Label1.Text + "' where block='F' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
                 con.Close();
             }
             if (DropDownList3.Text == "37 JAJMAU")
             {
                 con.Open();
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     int pl = Convert.ToInt32(ablock[i].ToString());
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book',CUSTREGNO='" + Label1.Text + "' where arazi='" + DropDownList3.Text + "' AND plotno=" + pl + "", con);
                     int j = cmd.ExecuteNonQuery();
                 }
             }
            
             ablock.Clear();
             bblock.Clear();
             cblock.Clear();
             dblock.Clear();
			 Eblock.Clear();
             
         }
       
         protected void Button2_Click(object sender, EventArgs e)
         {
             try
             {
                 Panel2.Visible = false;
                 SqlConnection con = new SqlConnection(s);
                 
                 if (TextBox22.Text != "")
                 {
                     if (DropDownList3.Text == "152")
                     {
                         con.Open();
                         SqlDataAdapter da = new SqlDataAdapter("select status from arazi30beegha where block='" + DropDownList5.Text + "' AND plotno=" + TextBox22.Text + "", con);
                         DataSet ds = new DataSet();
                         da.Fill(ds);
                         con.Close();
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                             if (ds.Tables[0].Rows[0][0].ToString() == "book")
                             {
                                 Label6.Text = "plot aleady booked";
                             }
                             else
                             {
                                 if (ds.Tables[0].Rows[0][0].ToString() == "empty")
                                 {
                                     Label6.Text = "";
                                     string st = TextBox20.Text;
									 if(st!="")
									 {
                                     st = st + "," + TextBox22.Text + DropDownList5.Text;
									 }
									 else
									 {
										 st = st + " " + TextBox22.Text + DropDownList5.Text;
									 }
                                     TextBox20.Text = st;
									 
                                     // plotbook();
                                     if (DropDownList5.Text == "A")
                                         ablock.Add(Convert.ToInt32(TextBox22.Text));
                                     if (DropDownList5.Text == "B")
                                         bblock.Add(Convert.ToInt32(TextBox22.Text));
                                     if (DropDownList5.Text == "C")
                                         cblock.Add(Convert.ToInt32(TextBox22.Text));
                                     if (DropDownList5.Text == "D")
                                         dblock.Add(Convert.ToInt32(TextBox22.Text));
									  if (DropDownList5.Text == "E")
                                         Eblock.Add(Convert.ToInt32(TextBox22.Text));
									  if (DropDownList5.Text == "F")
                                         Fblock.Add(Convert.ToInt32(TextBox22.Text));
                                     Label6.Text = "plot booked";


                                 }
                             }
                         }
                     }
                     if ( DropDownList3.Text == "37 JAJMAU")
                     {
                         con.Open();
                         SqlDataAdapter da = new SqlDataAdapter("select status from arazimap where arazi='" + DropDownList3.Text + "' AND plotno=" + TextBox22.Text + "", con);
                         DataSet ds = new DataSet();
                         da.Fill(ds);
                         con.Close();
                         if (ds.Tables[0].Rows.Count > 0)
                         {
                             if (ds.Tables[0].Rows[0][0].ToString() == "book")
                             {
                                 Label6.Text = "plot aleady booked";
                             }
                             else
                             {
                                 if (ds.Tables[0].Rows[0][0].ToString() == "empty")
                                 {
                                     Label6.Text = "";
                                     string st = TextBox20.Text;
									 if(st!="")
									 {
                                     st = st + "," + TextBox22.Text;
									 }
									 else
									 {
										 st = st + " " + TextBox22.Text;
									 }
                                     TextBox20.Text = st;
                                     // plotbook();
                                    
                                         ablock.Add(Convert.ToInt32(TextBox22.Text));
                                    
                                     Label6.Text = "plot booked";


                                 }
                             }
                         }
                     }
                     
                     
                 }
                 else
                 {
                     Label6.Text = "please fill plotno.";
                 }
             }
             catch(Exception tr)
             {
                 Label6.Text ="server error"+tr;
             }
             
         }
         protected void Button3_Click(object sender, EventArgs e)
         {
             Panel2.Visible = true;
             

         }
         protected void Button4_Click(object sender, EventArgs e)
         {
             if (DropDownList3.Text == "152")
             {
                 if (DropDownList5.Text == "A")
                 {
                     for (int i = 0; i < ablock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(ablock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                         {

                             ablock[i] = plot;
                             break;
                         }

                     }
                 }
                 if (DropDownList5.Text == "B")
                 {
                     for (int i = 0; i < ablock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(bblock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                         {

                             bblock[i] = plot;
                             break;
                         }

                     }
                 }
                 if (DropDownList5.Text == "C")
                 {
                     for (int i = 0; i < ablock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(cblock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                         {
                             cblock[i] = plot;
                             break;
                         }

                     }
                 }
                 if (DropDownList5.Text == "D")
                 {
                     for (int i = 0; i < dblock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(dblock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                         {
                             dblock[i] = plot;
                             break;
                         }

                     }
                 }
				 if (DropDownList5.Text == "E")
                 {
                     for (int i = 0; i < Eblock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(Eblock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                         {
                             Eblock[i] = plot;
                             break;
                         }

                     }
                 }
				 if (DropDownList5.Text == "F")
                 {
                     for (int i = 0; i < Fblock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(Fblock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                         {
                             Fblock[i] = plot;
                             break;
                         }

                     }
                 }

             }
            if (DropDownList3.Text == "37 JAJMAU")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     int plot = Convert.ToInt32(TextBox23.Text);
                     if (Convert.ToInt32(ablock[i].ToString()) == Convert.ToInt32(TextBox22.Text))
                     {

                         ablock[i] = plot;
                         break;
                     }

                 }
             }
             Label6.Text = "plot updated";
         }
         protected void TextBox5_TextChanged(object sender, EventArgs e)
         {

             DateTime ddd = DateTime.Now;
             int m1 = Convert.ToInt32(TextBox5.Text);
             DateTime r = ddd.AddMonths(m1);
            // TextBox8.Text = modifiedDatetime.ToShortDateString();
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
                     TextBox8.Text = date1.ToString();
					    TextBox9.Text = date1.ToString();

                 }
                 else
                 {
                     string s2 = r.ToString("M/d/yyyy");
                     string mm = s2.Substring(0, 1);
                     string dd = s2.Substring(2, 2);
                     string yy = s2.Substring(5, 4);
                     string date1 = dd + "/" + "0" + mm + "/" + yy;
                     TextBox8.Text = date1.ToString();
					    TextBox9.Text = date1.ToString();
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
                     TextBox8.Text = date1.ToString();
					    TextBox9.Text = date1.ToString();

                 }
                 else
                 {
                     string s2 = r.ToString("M/d/yyyy");
                     string mm = s2.Substring(0, 2);
                     string dd = s2.Substring(3, 2);
                     string yy = s2.Substring(6, 4);
                     string date1 = dd + "/" + mm + "/" + yy;
                     TextBox8.Text = date1.ToString();
					    TextBox9.Text = date1.ToString();
                 }
             }
         }
         public static string convertnumtoword(int number)
         {
             if (number == 0)
                 return "Zero";
             if (number < 0)
                 return "MINUS" + convertnumtoword(Math.Abs(number));
             string word = "";
             if ((number / 1000000) > 0 || (number / 100000) > 0)
             {
                 if ((number / 1000000) > 0)
                 {
                     word += convertnumtoword(number / 1000000) + " Lakh ";
                     number %= 1000000;
                 }
                 if ((number / 100000) > 0)
                 {
                     word += convertnumtoword(number / 100000) + " Lakh ";
                     number %= 100000;
                 }
             }
             if ((number / 1000) > 0)
             {
                 word += convertnumtoword(number / 1000) + " Thousand ";
                 number %= 1000;
             }
             if ((number / 100) > 0)
             {
                 word += convertnumtoword(number / 100) + " Hundred ";
                 number %= 100;
             }
             if (number > 0)
             {
                 if (word != " ")
                     word += "";
                 var unitmap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                 var tenmap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
                 if (number < 20)
                 {
                     word += unitmap[number];
                 }
                 else
                 {
                     word += tenmap[number / 10];
                     if ((number % 10) > 0)
                     {
                         word += " " + unitmap[number % 10];
                     }
                 }
             }
             return word;

         }
         protected void TextBox7_TextChanged(object sender, EventArgs e)
         {
             string word = convertnumtoword(Convert.ToInt32(TextBox7.Text)) + " Rupees Only";
             TextBox17.Text = word;
         }
}
