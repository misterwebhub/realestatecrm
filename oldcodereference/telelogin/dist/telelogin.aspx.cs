using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class login_form_20_telelogin : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    public static String password3 = "";
    public static Double rand = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
        }
    }
    public static string SendSMS(string msg)
    {

        //Your authentication key  
        string authKey = "330026ALGWF9NXis645d2f3aP1";

        //Multiple mobiles numbers separated by comma  
        string mobileNumber = "9696446268,9170746268";
        //Sender ID,While using route4 sender id should be 6 characters long.  
        string senderId = "HEEDKP";
        //Your message to send, Add URL encoding here.  
        string msg1 = "REMINDER SMS " + msg + " HEED REAL ESTATE";
        string message = HttpUtility.UrlEncode(msg1);
        string dlt = "1207162356605424724";
        string route = "4";
        string country = "91";
        //Prepare you post parameters  
        StringBuilder sbPostData = new StringBuilder();
        sbPostData.AppendFormat("authkey={0}", authKey);
        sbPostData.AppendFormat("&mobiles={0}", mobileNumber);
        sbPostData.AppendFormat("&message={0}", message);
        sbPostData.AppendFormat("&sender={0}", senderId);
        sbPostData.AppendFormat("&route={0}", route);
        sbPostData.AppendFormat("&country={0}", country);
        sbPostData.AppendFormat("&DLT_TE_ID={0}", dlt);


        //Call Send SMS API  
        string sendSMSUri = "http://sms.webguard.in/api/sendhttp.php";
        //Create HTTPWebrequest  
        HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
        //Prepare and Add URL Encoded data  
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] data = encoding.GetBytes(sbPostData.ToString());
        //Specify post method  
        httpWReq.Method = "POST";
        httpWReq.ContentType = "application/x-www-form-urlencoded";
        httpWReq.ContentLength = data.Length;
        using (Stream stream = httpWReq.GetRequestStream())
        {
            stream.Write(data, 0, data.Length);
        }
        //Get the response  
        HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string responseString = reader.ReadToEnd();

        //Close the response  
        reader.Close();

        response.Close();
        return responseString;

    }
    public Double number()
    {
        Random r = new Random(); 
        rand=r.Next();
        return rand;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (username.Text == "MDJ003" || username.Text == "mdj003" && password.Text == "904474")
        {
            Response.Redirect("../home/advocatemenu.aspx");
        }
        else
        {
            String un = "", password2 = "" ;
            if ((username.Text == "aarti9170" || username.Text == "AARTI9170") && password.Text == "0786")
            {
                Panel1.Visible = true;
                password3 = "0786";
                Label1.Text = "";
                Double rand1 = number();
                String msg = "Your Session Code is " + rand1;
               SendSMS(msg);
               
            }
            else
            {
                if (username.Text == "office2" || username.Text == "OFFICE2" || username.Text == "OFFICE3" || username.Text == "office3" || username.Text == "amar517")
                {
                    Panel1.Visible = false;
                    SqlConnection con = new SqlConnection(s);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select office from telelogin where username='" + username.Text + "' AND password='" + password.Text + "' ", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].ToString() != "")
                        {
                            Session["idr"] = ds.Tables[0].Rows[0][0].ToString();
                            Session["ID"] = username.Text;
                            Response.Redirect("~/telelogin/home/home.aspx");
                            // Response.RedirectLocation("https://www.heedrealestate.com//telelogin//teleregform.asp");
                            // Label1.Text = "Please fill Correct Dugyugujgjufetails";
                        }
                        else
                        {
                            Label1.Text = "Please fill Correct Details";
                            Panel1.Visible = false;
                        }
                    }
                    else
                    {
                        Panel1.Visible = false;
                        Label1.Text = "Please fill Correct Details";
                    }
                }
                else
                {
                    Label1.Text = "Please fill Correct Details";
                    Panel1.Visible = false;
                }
                
            }
           
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == rand.ToString())
        {
       /* DateTime dt = new DateTime(2021, 6, 8, 25, 01, 20);
        TimeSpan currentTime = dt.TimeOfDay; */
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            int h = currentTime.Hours;
            int m = currentTime.Minutes;
            TimeSpan t3 = new TimeSpan(h,m,0,0);
            TimeSpan t1 = new TimeSpan(10,0,0,0);
            TimeSpan t2 = new TimeSpan(19,0,0, 0);
            if (TimeSpan.Compare(t3, t1) == 1)
            {
                if (TimeSpan.Compare(t2, t3) == 1)
                {
                  //  Label1.Text = "sc";
                //     Session["idr"] = "heedrealestate";
           // Session["ID"] = username.Text;
          //  Response.Redirect("~/telelogin/home/home.aspx");

                }
                else
                {
                    Label1.Text = "Your Working Hour between 10:30AM To 7:00 PM";
                }
            }
            else
            {
                Label1.Text = "Your Working Hour between 10:30AM To 7:00 PM";
            }
           
        }
        else
        {
            Label1.Text = "Please fill Correct Session Code";
        }
    }
}