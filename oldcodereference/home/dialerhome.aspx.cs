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
    string CUSTREGNO,mob;
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Submit(object sender, EventArgs e)
    {
        // Add Fake Delay to simulate long running process.
        System.Threading.Thread.Sleep(5000);
       // this.LoadCustomers();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Button3.Visible = false;
        if (!IsPostBack)
        {
           
            
        }
        if (Request.QueryString["CUSTREGNO"] != null && Request.QueryString["MOBILE"]!=null)
        {
            Label1.Text = Request.QueryString["CUSTREGNO"];
            CUSTREGNO = Request.QueryString["CUSTREGNO"];
            Label2.Text = Request.QueryString["MOBILE"];
            mob = Request.QueryString["MOBILE"];
            int l=mob.Length;
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
    public void feedback()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT TOP 5 * FROM callerfeedback where CUSTREGNO='" + CUSTREGNO + "' ORDER BY ID DESC", con);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        telNumber.Text = "";
    }
    public int  add()
    {
        int r = 0;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("SELECT CUSTREGNO FROM calldemo where CUSTREGNO='" + CUSTREGNO + "'", con);
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            string s2 = TextBox2.Text;
            string dd = s2.Substring(0, 2);
            string mm = s2.Substring(3, 2);
            string yy = s2.Substring(6, 4);
            string start = mm +"/"+ dd + "/" + yy;
            SqlConnection con1 = new SqlConnection(s);
            //DateTime dt = DateTime.Today;
            string ddd = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            SqlCommand cmd = new SqlCommand("insert into callerfeedback(date,reason,CUSTREGNO,feeddate)values('"+ddd+"','" + TextBox1.Text + "','"+Label1.Text+"','"+start+"')", con1);
            con1.Open();
            int y=cmd.ExecuteNonQuery();
            con1.Close();
            if (y != 0)
            {
                Label3.Text = "Feedback Added";
                int de=add();
                if (de != 0)
                {
                    string ddd3 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                    SqlCommand cmd3 = new SqlCommand("update calldemo set date='"+ddd+"',reason='"+TextBox1.Text+"',feeddate='"+start+"' where CUSTREGNO='"+Label1.Text+"'", con1);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    con1.Close();
                }
                else
                {
                   
                    //DateTime dt = DateTime.Today;
                    string ddd3 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                    SqlCommand cmd3 = new SqlCommand("insert into calldemo(date,reason,CUSTREGNO,feeddate)values('" + ddd + "','" + TextBox1.Text + "','" + Label1.Text + "','" + start + "')", con1);
                    con1.Open();
                    cmd3.ExecuteNonQuery();
                    con1.Close();
                }
                feedback();
                Response.Redirect("~/dailer/datewisepayment.aspx");
            }
            else
            {
                Label3.Text = "Error generated";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Button3.Visible = true;
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
    
   
        
    
}