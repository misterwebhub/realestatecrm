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
	 static List<int> fblock = new List<int>();
    static List<int> fblock1 = new List<int>();
	 static List<int> eblock = new List<int>();
    static List<int> eblock1 = new List<int>();
    static List<int> dblock = new List<int>();
    static List<int> dblock1 = new List<int>();
    static List<int> bblock = new List<int>();
    static List<int> cblock = new List<int>();
    static List<int> ablock = new List<int>();
    static List<int> bblock1 = new List<int>();
    static List<int> cblock1 = new List<int>();
    static List<int> ablock1 = new List<int>();
     string plotno = "";
     static string arazi="",ragistrystatus="";
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {
            //Label13.Text = Session["ID"].ToString();
           // Session["ID"] = "dc";
		   if(Session["ID"] != null)
			{
				Label13.Text = Session["ID"].ToString();
			  // Label13.Text = "heedrealestate";
			}
			else
				
			{
				Response.Redirect("~/home/usercredential/credential.aspx");
			}
            
            bindl();
           Panel1.Visible=false;
           Panel2.Visible=false;
           Panel3.Visible = false;
        }
    }

    public void bindl()
    {
         DropDownList3.Items.Clear();
         DropDownList2.Items.Clear();
         DropDownList4.Items.Clear();
            SqlConnection con = new SqlConnection(s);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino,loc from softploted1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
               // DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
               // DropDownList2.Items.Add(ds.Tables[0].Rows[i][1].ToString());
            }
            con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select DISTINCT name from brokarpage", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
			
            con.Close();
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {

                DropDownList4.Items.Add(ds1.Tables[0].Rows[i][0].ToString());

            }
    }
        


    
 public void printreg()
         {
             Session["creg"] = TextBox21.Text;
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

             Session["plotsize"] =TextBox20.Text+"/"+TextBox13.Text;
             Session["nominee"] = TextBox14.Text;
             Session["reciptno"] = TextBox16.Text;
             Session["amountword"] = TextBox17.Text;
             Session["name2nominee"] = TextBox18.Text;
             Session["espr"] = TextBox15.Text;
             Session["idcard"] = TextBox2.Text;
             
         }




 SqlDataAdapter da;
         protected void Button2_Click(object sender, EventArgs e)
         {
           
             SqlConnection con = new SqlConnection(s);
             con.Open();
             if (DropDownList7.Text == "1")
             {
                 da = new SqlDataAdapter("select CUSTREGNO ,CUSTREGNO,	DATEOFCOM,	PLANANDTERM,	MODOFPAY,	CONSAMOUNT,	INSTSUBPAY,	SUBDUEDATE,	EXPPAY,	DATEOFLAST,	EXPIRYDATE,	AGENCYID,	NAMEDOBADDRESS,	APPNO,	PLOTSIZE,	NOMINEESNAME,	RECIPTNO,	AMOUNTWORD,	ESPR,	CHECKBY,	plotno,	mobile,	idcard,	regstatus	,date3	,mobile2,	usertype,	ragistry,	ragistryamt,	deletedate,	lastdate,	downpay from customerreg3 where CUSTREGNO='" + TextBox21.Text + "'", con);
             }
             else
             {
                 da = new SqlDataAdapter("select  * from customerreg3 where CUSTREGNO='" + TextBox21.Text + "'", con);
             }
             DataSet ds = new DataSet();
             da.Fill(ds);
             con.Close();
             if (ds.Tables[0].Rows.Count > 0)
             {
Label2.Text = " ";
                
                 TextBox1.Text = ds.Tables[0].Rows[0][2].ToString();
                 DropDownList2.Items.Add(ds.Tables[0].Rows[0][3].ToString());
                 DropDownList1.Items.Add(ds.Tables[0].Rows[0][4].ToString());
                 TextBox4.Text = ds.Tables[0].Rows[0][5].ToString();
                 TextBox5.Text = ds.Tables[0].Rows[0][6].ToString();
                 TextBox6.Text = ds.Tables[0].Rows[0][7].ToString();
                 TextBox7.Text = ds.Tables[0].Rows[0][8].ToString();
                 TextBox8.Text = ds.Tables[0].Rows[0][9].ToString();
                 TextBox9.Text = ds.Tables[0].Rows[0][10].ToString();
                 TextBox10.Text = ds.Tables[0].Rows[0][11].ToString();
                 TextBox11.Text = ds.Tables[0].Rows[0][12].ToString();
               DropDownList3.Items.Add(ds.Tables[0].Rows[0][13].ToString());
               arazi = ds.Tables[0].Rows[0][13].ToString();
                 TextBox13.Text = ds.Tables[0].Rows[0][14].ToString();
                 TextBox14.Text = ds.Tables[0].Rows[0][15].ToString();
                 TextBox16.Text = ds.Tables[0].Rows[0][16].ToString();
                 TextBox17.Text = ds.Tables[0].Rows[0][17].ToString();
                 TextBox15.Text = ds.Tables[0].Rows[0][18].ToString();
                 DropDownList4.Text = ds.Tables[0].Rows[0][19].ToString();
                // TextBox20.Text = ds.Tables[0].Rows[0][20].ToString();
                 TextBox3.Text = ds.Tables[0].Rows[0][21].ToString();
                 TextBox2.Text = ds.Tables[0].Rows[0][22].ToString();
                 TextBox18.Text = ds.Tables[0].Rows[0][12].ToString();
                 TextBox22.Text = ds.Tables[0].Rows[0][25].ToString();
                 ragistrystatus = ds.Tables[0].Rows[0][23].ToString();
                 TextBox18.ReadOnly = false;
                 TextBox15.ReadOnly = false;
                 TextBox16.ReadOnly = false;
                 if(ds.Tables[0].Rows[0][13].ToString()=="152")
                 {
                     Panel1.Visible=true;
                     Panel2.Visible=true;
                     Panel3.Visible = true;
                      //plotno = plotbind();
                     con.Open();
                     SqlDataAdapter da1 = new SqlDataAdapter("select plotno,block from arazi30beegha where CUSTREGNO='"+TextBox21.Text+"'", con);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);
                    con.Close();
                    ablock.Clear();
                    bblock.Clear();
                    cblock.Clear();
                    dblock.Clear();
					 eblock.Clear();
					 fblock.Clear();
                    if (ds1.Tables[0].Rows.Count > 0)
                     {
                        for(int j=0;j<ds1.Tables[0].Rows.Count;j++)
                        {
                            if(ds1.Tables[0].Rows[j][1].ToString()=="A")
                            {
                                ablock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));
                             }
                            if(ds1.Tables[0].Rows[j][1].ToString()=="B")
                            {
                                bblock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));
                             }
                            if(ds1.Tables[0].Rows[j][1].ToString()=="C")
                            {
                                cblock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));
                             }
                            if (ds1.Tables[0].Rows[j][1].ToString() == "D")
                            {
                                dblock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));
                            }
							if (ds1.Tables[0].Rows[j][1].ToString() == "E")
                            {
                                eblock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));
                            }
							if (ds1.Tables[0].Rows[j][1].ToString() == "F")
                            {
                                fblock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));
                            }
                        }
                        plotno=plotbind();
                        TextBox20.Text=plotno;
                        
                     }
                    else
                    {
                        plotno="0";
                    }
                 }
                 else
                 {
                     String ar = ds.Tables[0].Rows[0][13].ToString();
                   switch(ar)
                   {	   case "37 JAJMAU":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da187 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='37 JAJMAU'", con);
                           DataSet ds187 = new DataSet();
                           da187.Fill(ds187);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds187.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds187.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds187.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                       default :
                           plotno = ds.Tables[0].Rows[0][20].ToString();
                         TextBox20.Text = plotno;
                         break;
                   }
                   
                 }
                     
             }
             else
             {
                 Label2.Text = "Registration Number Not Found";
             }
         }
        
    public string plotbind()
         {
             string plot = "";
             
		if (DropDownList3.Text == "37 JAJMAU")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		
             return plot;
         }
         protected void Button3_Click(object sender, EventArgs e)
         {
             SqlConnection con = new SqlConnection(s);
             con.Open();
             SqlCommand cmd = new SqlCommand("delete from customerreg3 where CUSTREGNO='"+TextBox21.Text+"' ",con);
             int i = 0;
                 i= cmd.ExecuteNonQuery();
                 con.Close();
                 if (i != 0)
                 {
                     Label2.Text = "registration delete successfully";
                 }
                 else
                 {
                     Label2.Text = "registration number not founded ";
                 }


         }
         public void book()
         {
             SqlConnection con1 = new SqlConnection(s);
             
			 if (DropDownList3.Text == "37 JAJMAU")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='159'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 
         }
         public void cancel()
         {
             SqlConnection con1 = new SqlConnection(s);
             
			  if (DropDownList3.Text == "37 JAJMAU")
             {
                       
                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='37 JAJMAU'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 
         }
         public void cancel1()
         {
             SqlConnection con1 = new SqlConnection(s);
            
			 if (DropDownList3.Text == "37 JAJMAU")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='37 JAJMAU'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 
         }
         public Double dppay()
         {
             Double dppayamt = 0;
             String arazi = DropDownList3.Text;
             if (arazi=="37 JAJMAU")
             {
                 if (TextBox4.Text != "")
                 {
                     dppayamt = Convert.ToDouble(TextBox4.Text) * 0.50;
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
         protected void Button4_Click(object sender, EventArgs e)
         {
             try
             {
                 if (ragistrystatus == "Registry" || ragistrystatus == "completed")
                 {
                     Label2.Text = "This Bond Not Updatble Beacuse Ragistry Completed";
                 }
                 else
                 {
                     int i = 0;
                     string s1 = TextBox20.Text;
                     string dateString = TextBox1.Text;
                     string format = "dd/mm/yyyy";
                     DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
                     string ddd = dateTime.ToString("mm/dd/yyyy");
                     string s22 = TextBox8.Text;
                     string dd = s22.Substring(0, 2);
                     string mm = s22.Substring(3, 2);
                     string yy = s22.Substring(6, 4);
                     string date12 = mm + "/" + dd + "/" + yy;
                     Double totaldppay = dppay();
                     SqlConnection con1 = new SqlConnection(s);
                     if (arazi == "152")
                     {
                         if (arazi == DropDownList3.Text)
                         {
                             book();
                             cancel();
                             if (DropDownList7.Text == "1")
                             {
                                /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd.ExecuteNonQuery();
                                 con1.Close();*/
                                 SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd1.ExecuteNonQuery();
                                 con1.Close();
                             }
                             else
                             {
                                /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd.ExecuteNonQuery();
                                 con1.Close();*/
                                 SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd1.ExecuteNonQuery();
                                 con1.Close();
                             }
                            
                         }
                         if (arazi != DropDownList3.Text)
                         {
                             cancel1();
                             if (DropDownList7.Text == "1")
                             {
                                /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd.ExecuteNonQuery();
                                 con1.Close();*/
                                 SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd1.ExecuteNonQuery();
                                 con1.Close();
                             }
                             else
                             {
                                /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd.ExecuteNonQuery();
                                 con1.Close();*/
                                 SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd1.ExecuteNonQuery();
                                 con1.Close();
                             }
                         }
                     }
                     else
                     {
                         if (arazi != "152")
                         {
                             if (arazi == "37 JAJMAU")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                        /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                         /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                 }
                                 else
                                 {
                                     if (arazi != DropDownList3.Text)
                                     {
                                         cancel1();
                                         if (DropDownList7.Text == "1")
                                         {
                                            /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                         else
                                         {
                                            /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                            
                         }

                     }


                     if (i != 0)
                     {

                         Label2.Text = "REGISTRATION UPDATED SUCESSFULLY";
                         printreg();
                         arazi = "";
                         ablock.Clear();
                         ablock1.Clear();
                         bblock.Clear();
                         bblock1.Clear();
                         cblock.Clear();
                         cblock1.Clear();
                         dblock.Clear();
                         dblock1.Clear();
                         eblock.Clear();
                         eblock1.Clear();
						 fblock.Clear();
                         fblock1.Clear();
                         Response.Redirect("~/home/jajmausoft/printreg.aspx");
                     }
                     else
                     {
                         Label2.Text = "Due to internal error";
                     }

                 }
             }
             catch (Exception t)
             {
                 Label2.Text = "internal problem";
             }
         }

         protected void Button8_Click(object sender, EventArgs e)
         {
             try
             {
                 Panel2.Visible = false;
                 SqlConnection con = new SqlConnection(s);

                 if (TextBox24.Text != "")
                 {
                     if (DropDownList3.Text == "152")
                     {
                         con.Open();
                         SqlDataAdapter da = new SqlDataAdapter("select status from arazi30beegha where block='" + DropDownList5.Text + "' AND plotno=" + TextBox24.Text + "", con);
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
                                     st = st + "," + TextBox24.Text + DropDownList5.Text;
                                     TextBox20.Text = st;
                                     // plotbook();
                                     if (DropDownList5.Text == "A")
                                         ablock.Add(Convert.ToInt32(TextBox24.Text));
                                     if (DropDownList5.Text == "B")
                                         bblock.Add(Convert.ToInt32(TextBox24.Text));
                                     if (DropDownList5.Text == "C")
                                         cblock.Add(Convert.ToInt32(TextBox24.Text));
                                     if (DropDownList5.Text == "D")
                                         dblock.Add(Convert.ToInt32(TextBox24.Text));
									  if (DropDownList5.Text == "E")
                                         eblock.Add(Convert.ToInt32(TextBox24.Text));
									 if (DropDownList5.Text == "F")
                                         fblock.Add(Convert.ToInt32(TextBox24.Text));
                                     Label6.Text = "plot booked";


                                 }
                             }
                         }

                     }
                     if ( DropDownList3.Text == "37 JAJMAU")
                     {
                         con.Open();
                         SqlDataAdapter da = new SqlDataAdapter("select status from arazimap where arazi='" + DropDownList3.Text + "' AND plotno=" + TextBox24.Text + "", con);
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
                                     st = st + "," + TextBox24.Text;
                                     TextBox20.Text = st;
                                     // plotbook();
                                    
                                         ablock.Add(Convert.ToInt32(TextBox24.Text));
                                    
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
             catch (Exception tr)
             {
                 Label6.Text = "server error" + tr;
             }
         }
         protected void Button9_Click(object sender, EventArgs e)
         {
             Panel2.Visible = true;
         }
         protected void Button10_Click(object sender, EventArgs e)
         {
             
             if (DropDownList3.Text == "37 JAJMAU")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     int plot = Convert.ToInt32(TextBox23.Text);
                     if (Convert.ToInt32(ablock[i].ToString()) == Convert.ToInt32(TextBox24.Text))
                     {

                         ablock[i] = plot;
                         break;
                     }

                 }
             }
			             Label6.Text = "plot updated";
         }
         protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (DropDownList3.Text == "152")
             {
                 Panel1.Visible = true;
                 Panel3.Visible = true;
                 Panel2.Visible = true;
             }
             else
             {
                 if (DropDownList3.Text == "37 JAJMAU" )
                 {
                     Panel1.Visible = true;
                     Panel3.Visible = true;
                     Panel2.Visible = true;
                     Label7.Visible = false;
                     DropDownList5.Visible = false;
                     Label15.Visible = false;
                     DropDownList6.Visible = false;
                     TextBox20.ReadOnly = true;
                     
                 }
                 else
                 {
                     Panel1.Visible = false;
                     Panel2.Visible = false;
                     Panel3.Visible = false;

                 }
                
             }
         }
         protected void Button11_Click(object sender, EventArgs e)
         {
            
             if (DropDownList3.Text == "37 JAJMAU")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {

                     if (Convert.ToInt32(ablock[i].ToString()) == Convert.ToInt32(TextBox25.Text))
                     {
                         ablock1.Add(ablock[i]);
                         ablock.RemoveAt(i);
                         break;

                     }


                 }
             }
             Label14.Text = plotbind1();
             plotno = plotbind();
             TextBox20.Text = plotno;

         }
         public string plotbind1()
         {
             string plot = "";
            
             if (DropDownList3.Text == "37 JAJMAU" )
             {
                 for (int i = 0; i < ablock1.Count; i++)
                 {
                     plot = plot + ablock1[i].ToString();
                 }
                
             }
             return plot;
         }
         protected void Button12_Click(object sender, EventArgs e)
         {
             int i = 0;
             string s1 = TextBox20.Text;
             string dateString = TextBox1.Text;
             string format = "dd/mm/yyyy";
             DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
             string ddd = dateTime.ToString("mm/dd/yyyy");
             string s22 = TextBox8.Text;
             string dd = s22.Substring(0, 2);
             string mm = s22.Substring(3, 2);
             string yy = s22.Substring(6, 4);
             string date12 = mm + "/" + dd + "/" + yy;
             Double totaldppay = dppay();
             SqlConnection con1 = new SqlConnection(s);
             if (arazi == "152")
             {
                 if (arazi == DropDownList3.Text)
                 {
                     book();
                     cancel();
                     if (DropDownList7.Text == "1")
                     {
                         /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                          con1.Open();
                          i = cmd.ExecuteNonQuery();
                          con1.Close();*/
                         SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                         con1.Open();
                         i = cmd1.ExecuteNonQuery();
                         con1.Close();
                     }
                     else
                     {
                         /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                          con1.Open();
                          i = cmd.ExecuteNonQuery();
                          con1.Close();*/
                         SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                         con1.Open();
                         i = cmd1.ExecuteNonQuery();
                         con1.Close();
                     }

                 }
                 if (arazi != DropDownList3.Text)
                 {
                     cancel1();
                     if (DropDownList7.Text == "1")
                     {
                         /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                          con1.Open();
                          i = cmd.ExecuteNonQuery();
                          con1.Close();*/
                         SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                         con1.Open();
                         i = cmd1.ExecuteNonQuery();
                         con1.Close();
                     }
                     else
                     {
                         /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                          con1.Open();
                          i = cmd.ExecuteNonQuery();
                          con1.Close();*/
                         SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                         con1.Open();
                         i = cmd1.ExecuteNonQuery();
                         con1.Close();
                     }
                 }
             }
             else
             {
                 if (arazi != "152")
                 {
                     if (arazi == "37 JAJMAU")
                     {
                         if (arazi == DropDownList3.Text)
                         {
                             book();
                             cancel();
                             if (DropDownList7.Text == "1")
                             {
                                 /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                  con1.Open();
                                  i = cmd.ExecuteNonQuery();
                                  con1.Close();*/
                                 SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd1.ExecuteNonQuery();
                                 con1.Close();
                             }
                             else
                             {
                                 /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd.ExecuteNonQuery();
                                 con1.Close();*/
                                 SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                 con1.Open();
                                 i = cmd1.ExecuteNonQuery();
                                 con1.Close();
                             }
                         }
                         else
                         {
                             if (arazi != DropDownList3.Text)
                             {
                                 cancel1();
                                 if (DropDownList7.Text == "1")
                                 {
                                     /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                      con1.Open();
                                      i = cmd.ExecuteNonQuery();
                                      con1.Close();*/
                                     SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                     con1.Open();
                                     i = cmd1.ExecuteNonQuery();
                                     con1.Close();
                                 }
                                 else
                                 {
                                     /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                      con1.Open();
                                      i = cmd.ExecuteNonQuery();
                                      con1.Close();*/
                                     SqlCommand cmd1 = new SqlCommand("update customerreg3 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                     con1.Open();
                                     i = cmd1.ExecuteNonQuery();
                                     con1.Close();
                                 }
                             }
                         }
                     }
                     
                 }

             }


             if (i != 0)
             {

                 Label2.Text = "REGISTRATION UPDATED SUCESSFULLY";
                 printreg();
                 arazi = "";
                 ablock.Clear();
                 ablock1.Clear();
                 bblock.Clear();
                 bblock1.Clear();
                 cblock.Clear();
                 cblock1.Clear();
                 dblock.Clear();
                 dblock1.Clear();
                 eblock.Clear();
                 eblock1.Clear();
                 fblock.Clear();
                 fblock1.Clear();
                 Response.Redirect("~/home/jajmausoft/printreg.aspx");
             }
             else
             {
                 Label2.Text = "Due to internal error";
             }

         }
}
         

