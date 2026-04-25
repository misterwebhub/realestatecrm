using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _37jajmau_AREACAL : System.Web.UI.Page
{
    public Double sum = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
 if (!IsPostBack)
        {
         Label1.Text="";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Double ab = 0, bc = 0, cd = 0, da = 0,ac=0;
        if (TextBox1.Text == "")
        {
            ab = 0;
        }
        else
        {
            ab = Convert.ToDouble(TextBox1.Text);
        }
        if (TextBox2.Text == "")
        {
            bc = 0;
        }
        else
        {
            bc = Convert.ToDouble(TextBox2.Text);
        }
        if (TextBox3.Text == "")
        {
            cd = 0;
        }
        else
        {
            cd = Convert.ToDouble(TextBox3.Text);
        }
        if (TextBox4.Text == "")
        {
            da = 0;
        }
        else
        {
            da = Convert.ToDouble(TextBox4.Text);
        }
        if (TextBox5.Text == "")
        {
            ac = 0;
        }
        else
        {
            ac = Convert.ToDouble(TextBox5.Text);
        }
        Double s = (ab + bc + ac) / 2;
        Double s1 = (da + cd + ac) / 2;
        Double area = Math.Sqrt(s * (s - ab) * (s - bc) * (s - ac));
        Double area1 = Math.Sqrt(s1 * (s1 - da) * (s1 - cd) * (s1 - ac));
        Double total = (area + area1) / 9;
        Label1.Text = total.ToString()+" SqYard";
    }
}