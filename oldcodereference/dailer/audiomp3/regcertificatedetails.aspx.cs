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
		   if(Session["ID"] != null)
			{
				Label13.Text = Session["ID"].ToString();
			   //Label13.Text = "heedrealestate";
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
            SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino,loc from wjstar1.ploted1", con);
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
                 da = new SqlDataAdapter("select CUSTREGNO ,CUSTREGNO,	DATEOFCOM,	PLANANDTERM,	MODOFPAY,	CONSAMOUNT,	INSTSUBPAY,	SUBDUEDATE,	EXPPAY,	DATEOFLAST,	EXPIRYDATE,	AGENCYID,	NAMEDOBADDRESS,	APPNO,	PLOTSIZE,	NOMINEESNAME,	RECIPTNO,	AMOUNTWORD,	ESPR,	CHECKBY,	plotno,	mobile,	idcard,	regstatus	,date3	,mobile2,	usertype,	ragistry,	ragistryamt,	deletedate,	lastdate,	downpay from customerreg2 where CUSTREGNO='" + TextBox21.Text + "'", con);
             }
             else
             {
                 da = new SqlDataAdapter("select  * from wjstar1.customerreg1 where CUSTREGNO='" + TextBox21.Text + "'", con);
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
                   {
                       case "375KA": 

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da1 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='375KA'", con);
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
                               for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds1.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "30" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da2 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='30'", con);
                           DataSet ds2 = new DataSet();
                           da2.Fill(ds2);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						       fblock.Clear();
                           if (ds2.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds2.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "174MI" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da3 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='174MI'", con);
                           DataSet ds3 = new DataSet();
                           da3.Fill(ds3);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						       fblock.Clear();
                           if (ds3.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds3.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "506" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da4 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='506'", con);
                           DataSet ds4 = new DataSet();
                           da4.Fill(ds4);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds4.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds4.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds4.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "1989" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da5 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='1989'", con);
                           DataSet ds5 = new DataSet();
                           da5.Fill(ds5);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds5.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds5.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds5.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "436" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da6 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='436'", con);
                           DataSet ds6 = new DataSet();
                           da6.Fill(ds6);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds6.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds6.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds6.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "161GHA" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da7 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='161GHA'", con);
                           DataSet ds7 = new DataSet();
                           da7.Fill(ds7);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
						    fblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
                           if (ds7.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds7.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds7.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "1412" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da8 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='1412'", con);
                           DataSet ds8 = new DataSet();
                           da8.Fill(ds8);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds8.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds8.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds8.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						    case "186MI":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da91 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='186MI'", con);
                           DataSet ds91 = new DataSet();
                           da91.Fill(ds91);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds91.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds91.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds91.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "217":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da217 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='217'", con);
                           DataSet ds217 = new DataSet();
                           da217.Fill(ds217);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds217.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds217.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds217.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "372KA":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da9 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='372KA'", con);
                           DataSet ds9 = new DataSet();
                           da9.Fill(ds9);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds9.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds9.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds9.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "357":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da357 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='357'", con);
                           DataSet ds357 = new DataSet();
                           da357.Fill(ds357);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds357.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds357.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds357.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
                      case "2001GA":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da10 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='2001GA'", con);
                           DataSet ds10 = new DataSet();
                           da10.Fill(ds10);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds10.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds10.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds10.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "1452":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da1452 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='1452'", con);
                           DataSet ds1452 = new DataSet();
                           da1452.Fill(ds1452);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds1452.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds1452.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds1452.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						    case "159" :

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da333 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='159'", con);
                           DataSet ds333 = new DataSet();
                           da333.Fill(ds333);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds333.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds333.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds333.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   
						   
						    case "2011":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da11 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='2011'", con);
                           DataSet ds11 = new DataSet();
                           da11.Fill(ds11);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds11.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds11.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds11.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   
						   case "385KA":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da13 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='385KA'", con);
                           DataSet ds13 = new DataSet();
                           da13.Fill(ds13);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds13.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds13.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds13.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "185":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da19 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='185'", con);
                           DataSet ds19 = new DataSet();
                           da19.Fill(ds19);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds19.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds19.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds19.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "RAMAI137":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da14 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='RAMAI137'", con);
                           DataSet ds14 = new DataSet();
                           da14.Fill(ds14);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds14.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds14.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds14.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "1414 surpal":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da93= new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='1414 surpal'", con);
                           DataSet ds93 = new DataSet();
                           da93.Fill(ds93);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds93.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds93.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds93.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						    case "254":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da92 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='254'", con);
                           DataSet ds92 = new DataSet();
                           da92.Fill(ds92);
                           con.Close();
                           ablock.Clear();
                           bblock.Clear();
                           cblock.Clear();
                           dblock.Clear();
						    eblock.Clear();
						    fblock.Clear();
                           if (ds92.Tables[0].Rows.Count > 0)
                           {
                               for (int j = 0; j < ds92.Tables[0].Rows.Count; j++)
                               {

                                   ablock.Add(Convert.ToInt32(ds92.Tables[0].Rows[j][0].ToString()));


                               }
                               plotno = plotbind();
                               TextBox20.Text = plotno;

                           }
                           else
                           {
                               plotno = "0";
                           }
                           break;
						   case "187-KHA":

                           Panel1.Visible = true;
                           Panel2.Visible = true;
                           Panel3.Visible = true;
                           //plotno = plotbind();
                           con.Open();
                           SqlDataAdapter da187 = new SqlDataAdapter("select plotno,arazi from arazimap where CUSTREGNO='" + TextBox21.Text + "' AND arazi='187-KHA'", con);
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
             if (DropDownList3.Text == "152")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString() + "A,";
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
				 for (int i = 0; i < eblock.Count; i++)
                 {
                     plot = plot + eblock[i].ToString() + "E,";
                 }
				 for (int i = 0; i < fblock.Count; i++)
                 {
                     plot = plot + fblock[i].ToString() + "F,";
                 }
             }
             if (DropDownList3.Text == "375KA")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "30")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "174MI")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "357")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "506")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "1989")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "436")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "161GHA")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "1412")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "372KA")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             if (DropDownList3.Text == "2001GA")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "2011")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "385KA")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "RAMAI137")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "186MI")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "187-KHA")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "185")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "254")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "1414 surpal")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
             
		if (DropDownList3.Text == "159")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "217")
             {
                 for (int i = 0; i < ablock.Count; i++)
                 {
                     plot = plot + ablock[i].ToString();
                 }
             }
		if (DropDownList3.Text == "1452")
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
             SqlCommand cmd = new SqlCommand("delete from wjstar1.customerreg1 where CUSTREGNO='"+TextBox21.Text+"' ",con);
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
             if (DropDownList3.Text == "152")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND block='A'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < bblock.Count; k++)
                 {
                     int d = bblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND block='B'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < cblock.Count; k++)
                 {
                     int d = cblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND block='C'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < dblock.Count; k++)
                 {
                     int d = dblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND block='D'", con1);
                     cmd.ExecuteNonQuery();
                 }
				 for (int k = 0; k < eblock.Count; k++)
                 {
                     int d = eblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND block='E'", con1);
                     cmd.ExecuteNonQuery();
                 }
				 for (int k = 0; k < fblock.Count; k++)
                 {
                     int d = fblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND block='F'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "159")
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
             if (DropDownList3.Text == "375KA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='375KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "217")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='217'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "30")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='30'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "174MI")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='174MI'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "506")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='506'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "357")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='357'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "1989")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='1989'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "436")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='436'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "161GHA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='161GHA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "1412")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='1412'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "372KA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='372KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "2001GA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='2001GA'", con1);
                     cmd.ExecuteNonQuery();
                 }
				 con1.Close();
             }
				  if (DropDownList3.Text == "187-KHA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='187-KHA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "2011")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='2011'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "385KA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='385KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "RAMAI137")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='RAMAI137'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "254")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='254'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "1414 surpal")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='1414 surpal'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "186MI")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='186MI'", con1);
                     cmd.ExecuteNonQuery();
                 }
			  }
			 
                 con1.Close();
				  if (DropDownList3.Text == "185")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='185'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "1452")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='book' , CUSTREGNO='" + TextBox21.Text + "' where plotno=" + d + " AND arazi='1452'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
         }
         public void cancel()
         {
             SqlConnection con1 = new SqlConnection(s);
             if (DropDownList3.Text == "152")
             {
                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='A'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < bblock1.Count; k++)
                 {
                     int d = bblock1[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='B'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < cblock1.Count; k++)
                 {
                     int d = cblock1[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='C'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < dblock1.Count; k++)
                 {
                     int d = dblock1[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='D'", con1);
                     cmd.ExecuteNonQuery();
                 }
				 for (int k = 0; k < eblock1.Count; k++)
                 {
                     int d = eblock1[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='E'", con1);
                     cmd.ExecuteNonQuery();
                 }
				 for (int k = 0; k < fblock1.Count; k++)
                 {
                     int d = fblock1[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='F'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "159")
             {
                       
                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='159'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "375KA")
             {
                       
                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='375KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "30")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='30'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "174MI")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='174MI'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "217")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='217'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "506")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='506'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "1989")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1989'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "357")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='357'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "436")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='436'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "161GHA")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='161GHA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "1412")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1412'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "372KA")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='372KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "2001GA")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='2001GA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "187-KHA")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='187-KHA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "2011")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='2011'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "385KA")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='385KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "RAMAI137")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='RAMAI137'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "254")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='254'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "1414 surpal")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1414 surpal'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "186MI")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='186MI'", con1);
                     cmd.ExecuteNonQuery();
                 }
			 }
                 con1.Close();
				 if (DropDownList3.Text == "185")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='185'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "1452")
             {

                 con1.Open();
                 for (int k = 0; k < ablock1.Count; k++)
                 {
                     int d = ablock1[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1452'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
         }
         public void cancel1()
         {
             SqlConnection con1 = new SqlConnection(s);
             if (DropDownList3.Text == "152")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='A'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < bblock.Count; k++)
                 {
                     int d = bblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='B'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < cblock.Count; k++)
                 {
                     int d = cblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='C'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 for (int k = 0; k < dblock.Count; k++)
                 {
                     int d = dblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='D'", con1);
                     cmd.ExecuteNonQuery();
                 }
				  for (int k = 0; k < eblock.Count; k++)
                 {
                     int d = eblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='E'", con1);
                     cmd.ExecuteNonQuery();
                 }
				  for (int k = 0; k < fblock.Count; k++)
                 {
                     int d = fblock[k];
                     SqlCommand cmd = new SqlCommand("update arazi30beegha set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND block='F'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "159")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='159'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "375KA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='375KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "30")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='30'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "217")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='217'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "174MI")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='174MI'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "506")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='506'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "1989")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1989'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "436")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='436'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "161GHA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='161GHA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "1412")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1412'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "372KA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='372KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
             if (DropDownList3.Text == "2001GA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='2001GA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "187-KHA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='187-KHA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "2011")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='2011'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "385KA")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='385KA'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "254")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='254'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "1414 surpal")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1414 surpal'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			 if (DropDownList3.Text == "RAMAI137")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='RAMAI137'", con1);
                     cmd.ExecuteNonQuery();
                 }
                 con1.Close();
             }
			  if (DropDownList3.Text == "186MI")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='186MI'", con1);
                     cmd.ExecuteNonQuery();
                 }
			  }
                 con1.Close();
				  if (DropDownList3.Text == "185")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='185'", con1);
                     cmd.ExecuteNonQuery();
                 }
				  }
                 con1.Close();
				  
					  if (DropDownList3.Text == "1452")
             {
                 con1.Open();
                 for (int k = 0; k < ablock.Count; k++)
                 {
                     int d = ablock[k];
                     SqlCommand cmd = new SqlCommand("update arazimap set status='empty' , CUSTREGNO=NULL where plotno=" + d + " AND arazi='1452'", con1);
                     cmd.ExecuteNonQuery();
                 }
					  }
                 con1.Close();
             
         }
         public Double dppay()
         {
             Double dppayamt = 0;
             String arazi = DropDownList3.Text;
             if (arazi == "152" || arazi == "506" || arazi == "519" || arazi == "239" || arazi == "161GHA" || arazi == "186MI" || arazi == "RAMAI137" || arazi == "159" || arazi == "1452" || arazi == "357"  || arazi == "217" || arazi=="187-KHA")
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
                                 SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                 SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                 SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                 SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                             if (arazi == "375KA")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "30")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                         else
                                         {
                                           /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
							 if (arazi == "217")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
							 if (arazi == "357")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                         else
                                         {
                                         /*    SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "174MI")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                         else
                                         {
                                           /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "506")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                      /*   SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
							 if (arazi == "1452")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "254")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                         /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "1989")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                         /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                      /*   SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "436")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                      /*   SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                           /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "187-KHA")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                         /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
							 if (arazi == "161GHA")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                         /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "1412")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "372KA")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
							 if (arazi == "159")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             
                             if (arazi == "2001GA")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                      /*   SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "385KA")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "RAMAI137")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             /*SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "186MI")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "185")
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "1414 surpal")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                     else
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == "2011")
                             {
                                 if (arazi == DropDownList3.Text)
                                 {
                                     book();
                                     cancel();
                                     if (DropDownList7.Text == "1")
                                     {
                                       /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                         else
                                         {
                                           /*  SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd.ExecuteNonQuery();
                                             con1.Close();*/
                                             SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                             con1.Open();
                                             i = cmd1.ExecuteNonQuery();
                                             con1.Close();
                                         }
                                     }
                                 }
                             }
                             if (arazi == DropDownList3.Text)
                             {
                                 if (DropDownList7.Text == "1")
                                 {
                                    /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                     con1.Open();
                                     i = cmd.ExecuteNonQuery();
                                     con1.Close();*/
                                     SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                     SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                     con1.Open();
                                     i = cmd1.ExecuteNonQuery();
                                     con1.Close();
                                 }
                             }
                             else
                             {
                                 if (DropDownList3.Text == "152")
                                 {
                                     book();
                                     if (DropDownList7.Text == "1")
                                     {
                                        /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
                                     }
                                 }
                                 else
                                 {
                                     if (DropDownList7.Text == "1")
                                     {
                                        /* SqlCommand cmd = new SqlCommand("update customerreg2 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd.ExecuteNonQuery();
                                         con1.Close();*/
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
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
                                         SqlCommand cmd1 = new SqlCommand("update wjstar1.customerreg1 set DATEOFCOM='" + TextBox1.Text + "',PLANANDTERM='" + DropDownList2.Text + "',MODOFPAY='" + DropDownList1.Text + "',CONSAMOUNT=" + TextBox4.Text + ",INSTSUBPAY=" + TextBox5.Text + ",SUBDUEDATE='" + TextBox6.Text + "',EXPPAY=" + TextBox7.Text + ",DATEOFLAST='" + TextBox8.Text + "',EXPIRYDATE='" + TextBox9.Text + "',NAMEDOBADDRESS='" + TextBox11.Text + "',APPNO='" + DropDownList3.Text + "',PLOTSIZE=" + TextBox13.Text + ",NOMINEESNAME='" + TextBox14.Text + "',RECIPTNO='" + TextBox16.Text + "',AMOUNTWORD='" + TextBox17.Text + "',ESPR=" + TextBox15.Text + ",CHECKBY='" + DropDownList4.Text + "',plotno='" + TextBox20.Text + "',mobile='" + TextBox3.Text + "',idcard='" + TextBox2.Text + "',date3='" + ddd + "',mobile2='" + TextBox22.Text + "',usertype='" + Label13.Text + "',lastdate='" + date12 + "',downpay=" + totaldppay + "  where CUSTREGNO='" + TextBox21.Text + "'", con1);
                                         con1.Open();
                                         i = cmd1.ExecuteNonQuery();
                                         con1.Close();
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
                         Response.Redirect("~/home/printreg.aspx");
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
                     if (DropDownList3.Text == "375KA" || DropDownList3.Text == "30" || DropDownList3.Text == "174MI" || DropDownList3.Text == "506" || DropDownList3.Text == "1989" || DropDownList3.Text == "436" || DropDownList3.Text == "161GHA" || DropDownList3.Text == "1412" || DropDownList3.Text == "372KA" || DropDownList3.Text == "2001GA" || DropDownList3.Text == "2011" || DropDownList3.Text == "385KA" || DropDownList3.Text == "RAMAI137"  || DropDownList3.Text == "186MI" || DropDownList3.Text == "185" || DropDownList3.Text == "254" || DropDownList3.Text == "1414 surpal"  || DropDownList3.Text == "159" || DropDownList3.Text == "1452" || DropDownList3.Text == "357" || DropDownList3.Text == "217" || DropDownList3.Text == "187-KHA")
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
             if (DropDownList3.Text == "152")
             {
                 if (DropDownList5.Text == "A")
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
                 if (DropDownList5.Text == "B")
                 {
                     for (int i = 0; i < ablock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(bblock[i].ToString()) == Convert.ToInt32(TextBox24.Text))
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
                         if (Convert.ToInt32(cblock[i].ToString()) == Convert.ToInt32(TextBox24.Text))
                         {
                             cblock[i] = plot;
                             break;
                         }

                     }
                 }
                 if (DropDownList5.Text == "D")
                 {
                     for (int i = 0; i < ablock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(dblock[i].ToString()) == Convert.ToInt32(TextBox24.Text))
                         {
                             dblock[i] = plot;
                             break;
                         }

                     }
                 }
				 if (DropDownList5.Text == "E")
                 {
                     for (int i = 0; i < eblock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(eblock[i].ToString()) == Convert.ToInt32(TextBox24.Text))
                         {
                             eblock[i] = plot;
                             break;
                         }

                     }
                 }
				  if (DropDownList5.Text == "F")
                 {
                     for (int i = 0; i < fblock.Count; i++)
                     {
                         int plot = Convert.ToInt32(TextBox23.Text);
                         if (Convert.ToInt32(fblock[i].ToString()) == Convert.ToInt32(TextBox24.Text))
                         {
                             fblock[i] = plot;
                             break;
                         }

                     }
                 }
             }
             if (DropDownList3.Text == "375KA")
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
			  if (DropDownList3.Text == "159")
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
             if (DropDownList3.Text == "30")
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
             if (DropDownList3.Text == "174MI")
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
			 if (DropDownList3.Text == "217")
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
             if (DropDownList3.Text == "506")
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
             if (DropDownList3.Text == "1989")
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
			 if (DropDownList3.Text == "254")
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
			 if (DropDownList3.Text == "357")
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
             if (DropDownList3.Text == "436")
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
             if (DropDownList3.Text == "161GHA")
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
             if (DropDownList3.Text == "1412")
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
             if (DropDownList3.Text == "372KA")
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
             if (DropDownList3.Text == "2001GA")
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
			 if (DropDownList3.Text == "385KA")
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
			  if (DropDownList3.Text == "186MI")
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
			 if (DropDownList3.Text == "185")
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
			 if (DropDownList3.Text == "RAMAI137")
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
			 if (DropDownList3.Text == "2011")
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
			  if (DropDownList3.Text == "1452")
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
			 if (DropDownList3.Text == "1414 surpal")
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
			 if (DropDownList3.Text == "187-KHA")
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
                 if (DropDownList3.Text == "375KA" || DropDownList3.Text == "30" || DropDownList3.Text == "174MI" || DropDownList3.Text == "506" || DropDownList3.Text == "1989" || DropDownList3.Text == "436" || DropDownList3.Text == "161GHA" || DropDownList3.Text == "1412" || DropDownList3.Text == "372KA" || DropDownList3.Text == "2001GA" || DropDownList3.Text == "2011" || DropDownList3.Text == "385KA" || DropDownList3.Text == "RAMAI137" || DropDownList3.Text == "186MI" || DropDownList3.Text == "185" || DropDownList3.Text == "254" || DropDownList3.Text == "1414 surpal" || DropDownList3.Text == "159"  || DropDownList3.Text == "1452"  || DropDownList3.Text == "357"  || DropDownList3.Text == "217"  || DropDownList3.Text == "187-KHA")
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
             if (DropDownList3.Text == "152")
             {
                 if (DropDownList6.Text == "A")
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
                 if (DropDownList6.Text == "B")
                 {
                     for (int i = 0; i < bblock.Count; i++)
                     {

                         if (Convert.ToInt32(bblock[i].ToString()) == Convert.ToInt32(TextBox25.Text))
                         {
                             bblock1.Add(bblock[i]);
                             bblock.RemoveAt(i);

                             break;
                         }

                     }
                 }
                 if (DropDownList6.Text == "C")
                 {
                     for (int i = 0; i < cblock.Count; i++)
                     {

                         if (Convert.ToInt32(cblock[i].ToString()) == Convert.ToInt32(TextBox25.Text))
                         {
                             cblock1.Add(cblock[i]);
                             cblock.RemoveAt(i);
                             break;
                         }

                     }
                 }
                 if (DropDownList6.Text == "D")
                 {
                     for (int i = 0; i < dblock.Count; i++)
                     {

                         if (Convert.ToInt32(dblock[i].ToString()) == Convert.ToInt32(TextBox25.Text))
                         {
                             dblock1.Add(dblock[i]);
                             dblock.RemoveAt(i);
                             break;
                         }

                     }
                 }
				  if (DropDownList6.Text == "E")
                 {
                     for (int i = 0; i < eblock.Count; i++)
                     {

                         if (Convert.ToInt32(eblock[i].ToString()) == Convert.ToInt32(TextBox25.Text))
                         {
                             eblock1.Add(eblock[i]);
                             eblock.RemoveAt(i);
                             break;
                         }

                     }
                 }
				 if (DropDownList6.Text == "F")
                 {
                     for (int i = 0; i < fblock.Count; i++)
                     {

                         if (Convert.ToInt32(fblock[i].ToString()) == Convert.ToInt32(TextBox25.Text))
                         {
                             fblock1.Add(fblock[i]);
                             fblock.RemoveAt(i);
                             break;
                         }

                     }
                 }
             }
             if (DropDownList3.Text == "375KA" || DropDownList3.Text == "30" || DropDownList3.Text == "174MI" || DropDownList3.Text == "506" || DropDownList3.Text == "1989" || DropDownList3.Text == "436" || DropDownList3.Text == "161GHA" || DropDownList3.Text == "1412" || DropDownList3.Text == "372KA" || DropDownList3.Text == "2001GA" || DropDownList3.Text == "385KA" || DropDownList3.Text == "RAMAI137" || DropDownList3.Text == "2011" || DropDownList3.Text == "186MI" ||  DropDownList3.Text == "185" || DropDownList3.Text == "254" || DropDownList3.Text == "1414 surpal" || DropDownList3.Text == "159"  || DropDownList3.Text == "1452"  || DropDownList3.Text == "357" || DropDownList3.Text == "217"  || DropDownList3.Text == "187-KHA")
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
             if (DropDownList3.Text == "152")
             {
                 for (int i = 0; i < ablock1.Count; i++)
                 {
                     plot = plot + ablock1[i].ToString() + "A,";
                 }
                 for (int i = 0; i < bblock1.Count; i++)
                 {
                     plot = plot + bblock1[i].ToString() + "B,";
                 }
                 for (int i = 0; i < cblock1.Count; i++)
                 {
                     plot = plot + cblock1[i].ToString() + "C,";
                 }
                 for (int i = 0; i < dblock1.Count; i++)
                 {
                     plot = plot + dblock1[i].ToString() + "D,";
                 }
				 for (int i = 0; i < eblock1.Count; i++)
                 {
                     plot = plot + eblock1[i].ToString() + "E,";
                 }
				 for (int i = 0; i < fblock1.Count; i++)
                 {
                     plot = plot + fblock1[i].ToString() + "F,";
                 }
             }
             if (DropDownList3.Text == "375KA" || DropDownList3.Text == "30" || DropDownList3.Text == "174MI" || DropDownList3.Text == "506" || DropDownList3.Text == "1989" || DropDownList3.Text == "436" || DropDownList3.Text == "161GHA" || DropDownList3.Text == "1412" || DropDownList3.Text == "372KA" || DropDownList3.Text == "2001GA" || DropDownList3.Text == "385KA" || DropDownList3.Text == "RAMAI137" || DropDownList3.Text == "2011" || DropDownList3.Text == "186MI" ||  DropDownList3.Text == "185" || DropDownList3.Text == "254" || DropDownList3.Text == "1414 surpal" || DropDownList3.Text == "159"  || DropDownList3.Text == "1452"  || DropDownList3.Text == "357" || DropDownList3.Text == "217"  || DropDownList3.Text == "187-KHA")
             {
                 for (int i = 0; i < ablock1.Count; i++)
                 {
                     plot = plot + ablock1[i].ToString();
                 }
                
             }
             return plot;
         }
}
         

