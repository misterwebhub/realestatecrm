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


public partial class smsse : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
       DateTime r = DateTime.Now;
        DateTime next=r.AddDays(7);
        String p=r.ToShortDateString();
        String n=next.ToShortDateString();
        SqlConnection con = new SqlConnection(s);
        con.Open();
         SqlDataAdapter da = new SqlDataAdapter("select arazi,refno,left(cheqdate,11),kpaidamt,cheqno from kishanrecipt where cheqdate between '" + p + "' and '" + n + "' and status='UNPAID' ORDER BY date ASC", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
       
       String data = "",m="";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            data = "";
            m = "";
			String dw=ds.Tables[0].Rows[i][0].ToString();
			String dy=dw.Substring(0, 4);
            data = data + dy + "*";
           // data = data + ds.Tables[0].Rows[i][0].ToString() + "*";
            m=ds.Tables[0].Rows[i][1].ToString();
            m=m.Substring(0,7);
            data = data +m + "*";
			string s111="",yy1="",dd1="",mm1="";
			 s111 = ds.Tables[0].Rows[i][2].ToString();
        yy1 = s111.Substring(0, 4);
        mm1 = s111.Substring(5, 2);
        dd1 = s111.Substring(8, 2);
            data = data + dd1+"/"+mm1+"/"+yy1 + "*";

            data = data + ds.Tables[0].Rows[i][4].ToString() + "*";
            data = data + ds.Tables[0].Rows[i][3].ToString();
            Label1.Text = SendSMS(data); //Response.Redirect("http://sms.webguard.in/api/sendhttp.php?authkey=330026A7runOjvu5f533531P1&mobiles=9696446268&message=REMINDER SMS '" + data + "' HEED REAL ESTATE&sender=HEEDKP&route=4&DLT_TE_ID=1207162356605424724");
        }
        
    }
	public static string SendSMS(string msg)
    {

        //Your authentication key  
        string authKey = "330026ALGWF9NXis645d2f3aP1";

        //Multiple mobiles numbers separated by comma  
        string mobileNumber = "9935142277";
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
}