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



public partial class dialer_dialerhome : System.Web.UI.Page
{
    public static string entryheed, entryashok, entrymach;
	
    string CUSTREGNO,mob,user1;
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Submit(object sender, EventArgs e)
    {
        // Add Fake Delay to simulate long running process.
        System.Threading.Thread.Sleep(5000);
       // this.LoadCustomers();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //  Button3.Visible = false;
        String id = "";
        if (!IsPostBack)
        {
            entryheed = ""; entryashok = ""; entrymach="";
            TextBox3333.Text = "";
           // callid.Text = "";
           Session["idr"] = "heedrealestate";
            if (Session["idr"] != null)
            {
                // id = "heedrealestate";
                id = Session["idr"].ToString();
                Label4444.Text = id;
                if (Request.QueryString["CUSTREGNO"] != null && Request.QueryString["MOBILE"] != null)
                {
                    Label1111.Text = Request.QueryString["CUSTREGNO"];
                    CUSTREGNO = Request.QueryString["CUSTREGNO"];
                    Label2222.Text = Request.QueryString["MOBILE"];
                    mob = Request.QueryString["MOBILE"];
                    user1 = Label4444.Text;
                    int l = mob.Length;
                    if (l >= 10)
                    {
                        String mob2 = mob.Substring(0, 10);
                        telNumber.Text = mob2;
                    }
                    else
                    {
                        telNumber.Text = "";

                    }
                    //Label13.Text = "heedrealestate";
                    feedback();
                }
                else
                {
                    Response.Redirect("~/dialer/datewisepayment.aspx");
                }

            }

            else
            {
                Response.Redirect("~/telelogin/dist/telelogin.aspx");
            }
            

            }
        if (Request.QueryString["CUSTREGNO"] != null && Request.QueryString["MOBILE"] != null)
        {
            Label1111.Text = Request.QueryString["CUSTREGNO"];
            CUSTREGNO = Request.QueryString["CUSTREGNO"];
            Label2222.Text = Request.QueryString["MOBILE"];
            mob = Request.QueryString["MOBILE"];
            user1 = Label4444.Text;
            int l = mob.Length;
            if (l >= 10)
            {
                String mob2 = mob.Substring(0, 10);
               
            }
            
            //Label13.Text = "heedrealestate";
            feedback();
        }
        else
        {
            Response.Redirect("~/dialer/datewisepayment.aspx");
        }
           


       

        

    }
    public void feedback()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT TOP 5 * FROM callerfeedback1 where CUSTREGNO='" + CUSTREGNO + "' ORDER BY ID DESC", con);
        DataSet ds = new DataSet();
        da2.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }
   
    public int  add()
    {
        int r = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT CUSTREGNO FROM calldemo1 where CUSTREGNO='" + CUSTREGNO + "'", con);
        DataSet ds = new DataSet();
        da2.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() != "")
            {
                r = 1;
            }
            else
            {
                r = 0;
            }
        }
        else
        {
            r = 0;
        }
        return r;
    }
    public void calladd( string tm)
    {
        if (TextBox1111.Text != "")
        {
           // string s2 = TextBox2.Text;
           /* string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string start = mm + "/" + dd + "/" + yy;*/
			DateTime start = Convert.ToDateTime( TextBox2222.Text);
			//DateTime date1 = DateTime.Today;
        
        
       /* int result = DateTime.Compare(date1, start);
        string relationship;

        if (result < 0)
		{
            relationship = "less than";
		}
        else 

     */
			
			
			
			
			
            SqlConnection con1 = new SqlConnection(s);
            //DateTime dt = DateTime.Today;
            string ddd = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
           string callid1="";
              callid1=TextBox3333.Text;
              if (callid1 != "")
              {
                  callid1 = callid1;
              }
              else
              {
                  callid1 = "";
                                }
            tm=DateTime.Now.ToString("h:mm:ss tt");
            SqlCommand cmd = new SqlCommand("insert into callerfeedback1(date,reason,CUSTREGNO,feeddate,userid,entrytime,callid,entrytime1)values('" + ddd + "','" + TextBox1111.Text + "','" + Label1111.Text + "','" + start + "','" + Label4444.Text + "','" + tm + "','"+callid1+"','" + tm + "')", con1);
            con1.Open();
            int y = cmd.ExecuteNonQuery();
            con1.Close();

            if (y != 0)
            {
                Label3333.Text = "Feedback Added";
                int de = add();
                if (de != 0)
                {
                    string ddd3 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                    //string entrytime2 = DateTime.Now.ToString("h:mm:ss tt");
					tm=DateTime.Now.ToString("h:mm:ss tt");
                    SqlCommand cmd3 = new SqlCommand("update calldemo1 set date='" + ddd3 + "',reason='" + TextBox1111.Text + "',feeddate='" + start + "',entrytime='" + tm + "',callid='"+callid1+"',entrytime1='" + tm + "' where CUSTREGNO='" + Label1111.Text + "'", con1);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    con1.Close();
                }
                else
                {

                    //DateTime dt = DateTime.Today;
                    string ddd3 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                    //	string entrytime3 = DateTime.Now.ToString("h:mm:ss tt");
					tm=DateTime.Now.ToString("h:mm:ss tt");
                    SqlCommand cmd3 = new SqlCommand("insert into calldemo1(date,reason,CUSTREGNO,feeddate,userid,entrytime,callid,entrytime1)values('" + ddd3 + "','" + TextBox1111.Text + "','" + Label1111.Text + "','" + start + "','" + Label4444.Text + "','" + tm + "','"+callid1+"','" + tm + "')", con1);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    con1.Close();
                }
                feedback();

                // Session["idr"]="heedrealestate";
                //Label13.Text = 
                string strScript = "window.close();";
                ScriptManager.RegisterStartupScript(this, typeof(string), "key", strScript, true);
                // Response.Redirect("~/dailer/datewisepayment.aspx");
            }
            else
            {
                Label3333.Text = "Error generated";
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
		DateTime start = Convert.ToDateTime(TextBox2222.Text);
			DateTime date1 = DateTime.Today;
        
        
        int result = DateTime.Compare(start,date1);
        string relationship;

        if (result < 0)
		{
            Label3333.Text = "You Can't Enter Back Date";
		}
        else 
		{
        if (user1 == "heedrealestate")
        {
            calladd(entryheed);

        }
		else
		{
              if (user1 == "Ashok8396")
               {
                  calladd(entryashok);
 
                  }
		     	else
			     {
                  if (user1 == "MACHHARIYAOFFICE")
                     {
                      calladd(entrymach);
				  }
				}

        }
		}
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        entryheed = ""; entryashok = ""; entrymach = "";
        if (user1 == "heedrealestate")
        {
            entryheed = DateTime.Now.ToString("h:mm:ss tt");

        }
		else
		{
             if (user1 == "Ashok8396")
                 {
                     entryashok = DateTime.Now.ToString("h:mm:ss tt");

                 }
			else
			    {
                    if (user1 == "MACHHARIYAOFFICE")
                         {
                               entrymach = DateTime.Now.ToString("h:mm:ss tt");

                         }
			    }
		}
      //  Session["CUSTID"] = CUSTREGNO;
       // HttpCookie cookie = new HttpCookie("CUSTID");
       // cookie.Value = ;
        TextBox1.Text = CUSTREGNO;
        search(CUSTREGNO);
       // Response.Redirect("https://www.heedrealestate.com/dailer/emical.aspx");
        
		string script = "window.onload = function() { fetch1(); };";
    ClientScript.RegisterStartupScript(this.GetType(), "fetch1", script, true);
 
	
       // Response.Redirect("default2.aspx ?firstname=" + TextBox1.Text + "&lastname=" + TextBox2.Text);
       // Response.Redirect("https://heedrealestate.com/advocate/app/index.html?mobile="+telNumber.Text);
       /* var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Post,
    RequestUri = new Uri("https://panelv2.cloudshope.com/api/click_to_call?from_number=9129822343&to_number=9616554748&callback_url=from_number%2Cto_number%2Canswer_time%2Cstatus%20"),
    Headers =
    {
        { "Authorization", "Bearer 240309|eKcU1Z1vWhnjBbdzpTlC6irpczB4xYl4sUTQwmF9" },
    },
};
using (HttpResponseMessage  response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
   // Console.WriteLine(body);
}*/
   }





    protected void Button2_Click(object sender, EventArgs e)
    {
        telNumber.Text = "";
        string script = "window.onload = function() { fetch3(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "fetch3", script, true);
    }
    protected void rat_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
       Panel3.Visible = true;
       string script = "window.onload = function() { show1(); };";
       ClientScript.RegisterStartupScript(this.GetType(), "show1", script, true);
    }
    public void search(String reg)
    {
        int total1 = 0, total = 0, balance = 0;
        Label1.Text = "";

        try
        {
            reg = TextBox1.Text;
            SqlConnection con1 = new SqlConnection(s);
            con1.Open();

            SqlDataAdapter da = new SqlDataAdapter("select LEFT(NAMEDOBADDRESS,20),CONSAMOUNT,plotno,PLOTSIZE,date3,APPNO,lastdate,regstatus FROM wjstar1.customerreg1 where CUSTREGNO='" + reg + "'", con1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con1.Close();
            con1.Open();

            SqlDataAdapter da2 = new SqlDataAdapter("select TOP 1 DATE1,AMOUNTR from wjstar1.recipt1 where CUSTREGNO='" + reg + "' order by DATE1 DESC", con1);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con1.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0][0].ToString() != "")
                {
                    Label25.Text = Convert.ToDateTime(ds2.Tables[0].Rows[0][0]).ToString("dd/MM/yyyy");
                    Label26.Text = ds2.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Label25.Text = "0";
                    Label26.Text = "0";
                }
            }
            SqlCommand cmd1 = new SqlCommand("select sum(AMOUNTR) from wjstar1.recipt1 where CUSTREGNO='" + reg + "'", con1);

            con1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            total1 = Convert.ToInt32(ds.Tables[0].Rows[0][1].ToString());
            if (dr1.HasRows == true)
            {
                while (dr1.Read())
                {
                    // total1 = Convert.ToInt32(dr.GetValue(1));
                    total = Convert.ToInt32(dr1.GetValue(0));
                }
                balance = total1 - total;

                Label7.Text = total.ToString();
                Label8.Text = balance.ToString();
            }

            con1.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][7].ToString() != "Cancel")
                {
                    if (ds.Tables[0].Rows[0][0].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0][7].ToString() != "completed")
                        {
                            Label5.Text = ds.Tables[0].Rows[0][0].ToString();
                            Label6.Text = ds.Tables[0].Rows[0][1].ToString();
                            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                            Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                            //Label14.Text = ds.Tables[0].Rows[0][4].ToString();
                            String drbook = ds.Tables[0].Rows[0][4].ToString();
                            Label14.Text = Convert.ToDateTime(drbook).ToString("dd/MM/yyyy");
                            Label2.Text = ds.Tables[0].Rows[0][5].ToString();
                            //Label15.Text = ds.Tables[0].Rows[0][6].ToString();
                            String drend = ds.Tables[0].Rows[0][6].ToString();
                            Label15.Text = Convert.ToDateTime(drend).ToString("dd/MM/yyyy");
                            arazisearch(Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Label2.Text, total);
                        }
                        else
                        {
                            Label1.Text = "Plot Completed";
                            Label2.Text = ds.Tables[0].Rows[0][5].ToString();
                            Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                            Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                            String drbook = ds.Tables[0].Rows[0][4].ToString();
                            Label14.Text = Convert.ToDateTime(drbook).ToString("dd/MM/yyyy");
                            String drend = ds.Tables[0].Rows[0][6].ToString();
                            Label15.Text = Convert.ToDateTime(drend).ToString("dd/MM/yyyy");
                            Label5.Text = ds.Tables[0].Rows[0][0].ToString();
                            Label6.Text = ds.Tables[0].Rows[0][1].ToString();
                            Label16.Text = "0";
                            Label9.Text = "0";
                            Label20.Text = "0";
                            Label12.Text = "0";
                            Label7.Text = total.ToString();
                            Label8.Text = balance.ToString();
                            Label17.Text = "0";
                            Label10.Text = "0";
                            Label21.Text = "0";
                            Label13.Text = "0";

                            Label18.Text = "0";
                            Label11.Text = "0";
                            Label22.Text = "0";
                            Label19.Text = "0";
                        }
                        //amountbal();
                    }
                    else
                    {
                        Label5.Text = "";
                        Label6.Text = "";
                        Label3.Text = "";
                        Label4.Text = "";
                        Label14.Text = "";
                        Label2.Text = "";
                        Label15.Text = "";

                    }
                }
                else
                {
                    Label1.Text = "Plot Cancel";
                    Label2.Text = "0";
                    Label3.Text = "0";
                    Label4.Text = "0";
                    Label14.Text = "0";
                    Label15.Text = "0";
                    Label5.Text = "0";
                    Label6.Text = "0";
                    Label16.Text = "0";
                    Label9.Text = "0";
                    Label20.Text = "0";
                    Label12.Text = "0";
                    Label7.Text = "0";
                    Label17.Text = "0";
                    Label10.Text = "0";
                    Label21.Text = "0";
                    Label13.Text = "0";
                    Label8.Text = "0";
                    Label18.Text = "0";
                    Label11.Text = "0";
                    Label22.Text = "0";
                    Label19.Text = "0";
                }
            }


        }
        catch (Exception t)
        {
            Label1.Text = "Due to error";
        }
    }

    public void arazisearch(Double custotalpayment, string arazi, Double totalrecieve)
    {
        Double dp = 0, instpaid = 0, dppaid = 0, dpbal = 0, lateemiamount = 0, lateemi = 0, totalmonthfixedemi = 0, advancamount = 0, balemi = 0;
        int fixedemi = 0, paidemi = 0;
        SqlConnection con = new SqlConnection(s);
        SqlDataAdapter da = new SqlDataAdapter("select DATEDIFF(MONTH,date3,lastdate),date3 from  wjstar1.customerreg1 where CUSTREGNO='" + TextBox1.Text + "'", con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();

        Double mont = 0;
        if (ds.Tables[0].Rows[0][0].ToString() != "")
        {
            mont = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());

            Label20.Text = mont.ToString();
        }
        else
        {
            mont = 0;
        }

        SqlDataAdapter da1 = new SqlDataAdapter("select floor(DATEDIFF(DAY,(select date3 from  wjstar1.customerreg1 where CUSTREGNO='" + TextBox1.Text + "'),getdate())/30.46) ", con);
        con.Open();
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Double bal = 0, rec = 0;
        if (ds1.Tables[0].Rows[0][0].ToString() != "")
        {
            bal = Convert.ToDouble(ds1.Tables[0].Rows[0][0].ToString());
        }
        else
        {
            bal = 0;
        }


        if (arazi == "152" || arazi == "506" || arazi == "519" || arazi == "239" || arazi == "161GHA" || arazi == "186MI" || arazi == "RAMAI137")
        {
            dp = custotalpayment * 0.50;
            fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
            Label23.Text = fixedemi.ToString();
            if (totalrecieve <= dp)
            {
                dppaid = totalrecieve;
                dpbal = dp - dppaid;
                Label16.Text = dp.ToString();
                Label17.Text = dppaid.ToString();
                Label18.Text = dpbal.ToString();
                Label9.Text = (custotalpayment - dp).ToString();
                instpaid = 0;
                totalmonthfixedemi = fixedemi * (bal);
                lateemiamount = totalmonthfixedemi;
                advancamount = 0;
                lateemi = bal;
                paidemi = 0;
                balemi = mont - bal;
                Label21.Text = paidemi.ToString();
                Label22.Text = balemi.ToString();
                Label19.Text = Convert.ToInt32(advancamount).ToString();
                Label12.Text = lateemi.ToString();
                Double bal11 = Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
                }
                Label10.Text = instpaid.ToString("N0");
                Label24.Text = instpaid.ToString("N0");
                Label11.Text = (custotalpayment - dp).ToString();
                //an other calculation of emi

            }
            else
            {
                instpaid = totalrecieve - dp;

                totalmonthfixedemi = fixedemi * (bal);
                if (instpaid >= totalmonthfixedemi)
                {
                    advancamount = instpaid - totalmonthfixedemi;
                }
                else
                {
                    advancamount = 0;
                }

                paidemi = Convert.ToInt32(instpaid) / fixedemi;

                lateemi = bal - paidemi;
                if (lateemi <= 0)
                {
                    lateemi = 0;
                    totalmonthfixedemi = 0;
                }
                else
                {
                    lateemi = lateemi;
                    lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                    lateemiamount = (lateemi * fixedemi) - lateemiamount;
                }
                balemi = mont - bal;
                Label16.Text = dp.ToString();
                Label17.Text = dp.ToString();
                Label18.Text = "0";
                Label21.Text = Convert.ToInt32(bal).ToString();
                Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                Label22.Text = balemi.ToString();
                Label19.Text = Convert.ToInt32(advancamount).ToString();
                Label12.Text = lateemi.ToString();
                Double bal11 = Convert.ToDouble(Label8.Text);
                if (lateemiamount < bal11)
                {
                    Label13.Text = lateemiamount.ToString();
                }
                else
                {
                    Label13.Text = bal11.ToString();
                }
                Label9.Text = (custotalpayment - dp).ToString();
                Label10.Text = instpaid.ToString("N0");
                Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

            }



        }
        else
        {
            if (arazi == "375KA" || arazi == "30" || arazi == "174MI" || arazi == "372KA" || arazi == "385KA")
            {
                dp = custotalpayment * 0.35;
                fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                Label23.Text = fixedemi.ToString();
                if (totalrecieve <= dp)
                {
                    dppaid = totalrecieve;
                    dpbal = dp - dppaid;
                    Label16.Text = dp.ToString();
                    Label17.Text = dppaid.ToString();
                    Label18.Text = dpbal.ToString();
                    Label9.Text = (custotalpayment - dp).ToString();
                    instpaid = 0;
                    totalmonthfixedemi = fixedemi * (bal);
                    lateemiamount = totalmonthfixedemi;
                    advancamount = 0;
                    lateemi = bal;
                    paidemi = 0;
                    balemi = mont - bal;
                    Label21.Text = paidemi.ToString();
                    Label22.Text = balemi.ToString();
                    Label19.Text = Convert.ToInt32(advancamount).ToString();
                    Label12.Text = lateemi.ToString();
                    Double bal11 = Convert.ToDouble(Label8.Text);
                    if (lateemiamount < bal11)
                    {
                        Label13.Text = lateemiamount.ToString();
                    }
                    else
                    {
                        Label13.Text = bal11.ToString();
                    }
                    Label10.Text = instpaid.ToString("N0");
                    Label24.Text = instpaid.ToString("N0");
                    Label11.Text = (custotalpayment - dp).ToString();
                    //an other calculation of emi

                }
                else
                {
                    instpaid = totalrecieve - dp;

                    totalmonthfixedemi = fixedemi * (bal);
                    if (instpaid >= totalmonthfixedemi)
                    {
                        advancamount = instpaid - totalmonthfixedemi;
                    }
                    else
                    {
                        advancamount = 0;
                    }

                    paidemi = Convert.ToInt32(instpaid) / fixedemi;

                    lateemi = bal - paidemi;
                    if (lateemi <= 0)
                    {
                        lateemi = 0;
                        totalmonthfixedemi = 0;
                    }
                    else
                    {
                        lateemi = lateemi;
                        lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                        lateemiamount = (lateemi * fixedemi) - lateemiamount;
                    }
                    balemi = mont - bal;
                    Label16.Text = dp.ToString();
                    Label17.Text = dp.ToString();
                    Label18.Text = "0";
                    Label21.Text = Convert.ToInt32(bal).ToString();
                    Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                    Label22.Text = balemi.ToString();
                    Label19.Text = Convert.ToInt32(advancamount).ToString();
                    Label12.Text = lateemi.ToString();
                    Double bal11 = Convert.ToDouble(Label8.Text);
                    if (lateemiamount < bal11)
                    {
                        Label13.Text = lateemiamount.ToString();
                    }
                    else
                    {
                        Label13.Text = bal11.ToString();
                    }
                    Label9.Text = (custotalpayment - dp).ToString();
                    Label10.Text = instpaid.ToString("N0");
                    Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                }

            }
            else
            {
                if (arazi == "0" || arazi == "100" || arazi == "1204" || arazi == "1412" || arazi == "1414 surpal" || arazi == "1989" || arazi == "2011" || arazi == "24KA" || arazi == "254" || arazi == "274" || arazi == "239A" || arazi == "343" || arazi == "364" || arazi == "369" || arazi == "432" || arazi == "436" || arazi == "1989")
                {
                    dp = custotalpayment * 0.25;
                    fixedemi = Convert.ToInt32((custotalpayment - dp) / mont);
                    Label23.Text = fixedemi.ToString();
                    if (totalrecieve <= dp)
                    {
                        dppaid = totalrecieve;
                        dpbal = dp - dppaid;
                        Label16.Text = dp.ToString();
                        Label17.Text = dppaid.ToString();
                        Label18.Text = dpbal.ToString();
                        Label9.Text = (custotalpayment - dp).ToString();
                        instpaid = 0;
                        totalmonthfixedemi = fixedemi * (bal);
                        lateemiamount = totalmonthfixedemi;
                        advancamount = 0;
                        lateemi = bal;
                        paidemi = 0;
                        balemi = mont - bal;
                        Label21.Text = paidemi.ToString();
                        Label22.Text = balemi.ToString();
                        Label19.Text = Convert.ToInt32(advancamount).ToString();
                        Label12.Text = lateemi.ToString();
                        Double bal11 = Convert.ToDouble(Label8.Text);
                        if (lateemiamount < bal11)
                        {
                            Label13.Text = lateemiamount.ToString();
                        }
                        else
                        {
                            Label13.Text = bal11.ToString();
                        }
                        Label10.Text = instpaid.ToString("N0");
                        Label24.Text = instpaid.ToString("N0");
                        Label11.Text = (custotalpayment - dp).ToString();
                        //an other calculation of emi

                    }
                    else
                    {
                        instpaid = totalrecieve - dp;

                        totalmonthfixedemi = fixedemi * (bal);
                        if (instpaid >= totalmonthfixedemi)
                        {
                            advancamount = instpaid - totalmonthfixedemi;
                        }
                        else
                        {
                            advancamount = 0;
                        }

                        paidemi = Convert.ToInt32(instpaid) / fixedemi;

                        lateemi = bal - paidemi;
                        if (lateemi <= 0)
                        {
                            lateemi = 0;
                            totalmonthfixedemi = 0;
                        }
                        else
                        {
                            lateemi = lateemi;
                            lateemiamount = -(totalmonthfixedemi - (lateemi * fixedemi) - instpaid);
                            lateemiamount = (lateemi * fixedemi) - lateemiamount;
                        }
                        balemi = mont - bal;
                        Label16.Text = dp.ToString();
                        Label17.Text = dp.ToString();
                        Label18.Text = "0";
                        Label21.Text = Convert.ToInt32(bal).ToString();
                        Label24.Text = (Convert.ToInt32(bal) * fixedemi).ToString();
                        Label22.Text = balemi.ToString();
                        Label19.Text = Convert.ToInt32(advancamount).ToString();
                        Label12.Text = lateemi.ToString();
                        Double bal11 = Convert.ToDouble(Label8.Text);
                        if (lateemiamount < bal11)
                        {
                            Label13.Text = lateemiamount.ToString();
                        }
                        else
                        {
                            Label13.Text = bal11.ToString();
                        }
                        Label9.Text = (custotalpayment - dp).ToString();
                        Label10.Text = instpaid.ToString("N0");
                        Label11.Text = ((custotalpayment - dp) - instpaid).ToString();

                    }
                }
            }
        }
    }
}