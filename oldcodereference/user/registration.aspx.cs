using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class user_registration : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "" || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "")
            {
                Label1.Text = "Please fill all text fields";
            }
            else
            {
                SqlConnection con = new SqlConnection(s);
                con.Open();
                string s2 = TextBox3.Text;
                string dd = s2.Substring(0, 2);
                string mm = s2.Substring(3, 2);
                string yy = s2.Substring(6, 4);
                string dob = mm + "/" + dd + "/" + yy;
                SqlCommand cmd = new SqlCommand("insert into logininfo(utype,name,address,dob,gender,username,password,mobile,aadhar)values('" + DropDownList2.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + DropDownList1.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')", con);
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    Label1.Text = "Record Added Sucessfully";
                }
                else
                {
                    Label1.Text = "Please fill all text fields";
                }
            }
        }
        catch (Exception t)
        {
            Label1.Text = "Error Receive From server";
        }
    }
}