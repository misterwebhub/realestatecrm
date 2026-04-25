using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;


public partial class kishan_landsizedetails : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel4.Visible = false;
            Panel2.Visible = false;
            bind();
        }
    }
    public void bind()
    {
        DropDownList1.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList1.Items.Add("----Select-----");
        DropDownList3.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            
            SqlConnection con = new SqlConnection(s);
            
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into landsizedetails (arazino,kname,plandsize,slandsize,srate)values('" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + TextBox1.Text + "'," + TextBox3.Text + "," + TextBox4.Text + ")",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                Label17.Text = "Record addedd";
            }
            else
            {
                Label17.Text = "error";
            }
        }
        catch (Exception t)
        {
            Label17.Text = "error";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel4.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Panel4.Visible = false;
        Panel3.Visible = true;
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='" + DropDownList3.Text + "' AND kname='" + DropDownList4.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        con.Open();
        SqlDataAdapter da2 = new SqlDataAdapter("select amount from chequekishan where arazino='" + DropDownList3.Text + "' AND kname='" + DropDownList4.Text + "'", con);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        con.Close();
        con.Open();
        SqlDataAdapter da1 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='" + DropDownList3.Text + "' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        con.Close();
        Label7.Text = ds.Tables[0].Rows[0][0].ToString();
        Label8.Text = ds.Tables[0].Rows[0][1].ToString();
        Label9.Text = ds.Tables[0].Rows[0][2].ToString();
        Label10.Text = ds2.Tables[0].Rows[0][0].ToString();
        Label11.Text = ds.Tables[0].Rows[0][3].ToString();
        Label12.Text = ds.Tables[0].Rows[0][4].ToString();
        Label13.Text = ds1.Tables[0].Rows[0][0].ToString();
        Double salerate=0, saleland=0, soldland=0, soldamt=0, balland=0, ballandamt=0;
        saleland = Convert.ToDouble(Label11.Text);
        salerate = Convert.ToDouble(Label12.Text);
        soldland =  Convert.ToDouble(Label13.Text);
        balland = saleland - soldland;
        soldamt = soldland * salerate;
        ballandamt = balland * salerate;
        Label14.Text = soldamt.ToString();
        Label15.Text = balland.ToString();
        Label16.Text = ballandamt.ToString();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT kname from chequekishan where arazino='" + DropDownList1.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList2.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
       
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList4.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT kname from chequekishan where arazino='" + DropDownList3.Text + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        DropDownList4.Items.Add("----Select-----");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            DropDownList4.Items.Add(ds.Tables[0].Rows[i][0].ToString());


        }
    }
    
    
    protected void Button5_Click(object sender, EventArgs e)
    {
       


    }
    protected void Button5_Click1(object sender, EventArgs e)
    {
        string[] arazi = { "1412", "152", "174MI", "239", "254", "30", "375KA", "506" };
        Panel3.Visible = false;
        Panel4.Visible = true;
        SqlConnection con = new SqlConnection(s);
        for (int i = 0; i < arazi.Length; i++)
        {
            if (arazi[i] == "1412")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='1412' AND kname='RAGHUNATH'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='1412' AND kname='RAGHUNATH'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='1412' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                if (ds1412.Tables[0].Rows[0][0].ToString() != "")
                    Label18.Text = ds1412.Tables[0].Rows[0][0].ToString();
                else
                    Label18.Text = "0";
                if(ds1412.Tables[0].Rows[0][1].ToString()!="")
                Label19.Text = ds1412.Tables[0].Rows[0][1].ToString();
                else
                    Label19.Text = "0";
                if (ds1412.Tables[0].Rows[0][2].ToString() != "")
                    Label20.Text = ds1412.Tables[0].Rows[0][2].ToString();
                else
                    Label20.Text = "0";
                if (ds21412.Tables[0].Rows[0][0].ToString() != "")
                    Label21.Text = ds21412.Tables[0].Rows[0][0].ToString();
                else
                    Label21.Text = "0";
                if (ds1412.Tables[0].Rows[0][3].ToString()!= "")
                    Label22.Text = ds1412.Tables[0].Rows[0][3].ToString();
                else
                    Label22.Text = "0";
                if (ds1412.Tables[0].Rows[0][4].ToString() != "")
                    Label23.Text = ds1412.Tables[0].Rows[0][4].ToString();
                else
                    Label23.Text = "0";
                if (ds11412.Tables[0].Rows[0][0].ToString() != "")
                    Label24.Text = ds11412.Tables[0].Rows[0][0].ToString();
                else
                    Label24.Text = "0";
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label22.Text);
                salerate = Convert.ToDouble(Label23.Text);
                soldland = Convert.ToDouble(Label24.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label25.Text = soldamt.ToString();
                Label26.Text = balland.ToString();
                Label27.Text = ballandamt.ToString();
            }
            if (arazi[i] == "152")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='152' AND kname='VIKASH CHATURVEDI'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='152' AND kname='VIKASH CHATURVEDI'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='152' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                Label28.Text = ds1412.Tables[0].Rows[0][0].ToString();
                Label29.Text = ds1412.Tables[0].Rows[0][1].ToString();
                Label30.Text = ds1412.Tables[0].Rows[0][2].ToString();
                Label31.Text = ds21412.Tables[0].Rows[0][0].ToString();
                Label32.Text = ds1412.Tables[0].Rows[0][3].ToString();
                Label33.Text = ds1412.Tables[0].Rows[0][4].ToString();
                Label34.Text = ds11412.Tables[0].Rows[0][0].ToString();
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label32.Text);
                salerate = Convert.ToDouble(Label33.Text);
                soldland = Convert.ToDouble(Label34.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label35.Text = soldamt.ToString();
                Label36.Text = balland.ToString();
                Label37.Text = ballandamt.ToString();
            }
            if (arazi[i] == "174MI")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='174MI' AND kname='BALDEV SINGH'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='174MI' AND kname='BALDEV SINGH'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='174MI' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                Label38.Text = ds1412.Tables[0].Rows[0][0].ToString();
                Label39.Text = ds1412.Tables[0].Rows[0][1].ToString();
                Label40.Text = ds1412.Tables[0].Rows[0][2].ToString();
                Label41.Text = ds21412.Tables[0].Rows[0][0].ToString();
                Label42.Text = ds1412.Tables[0].Rows[0][3].ToString();
                Label43.Text = ds1412.Tables[0].Rows[0][4].ToString();
                Label44.Text = ds11412.Tables[0].Rows[0][0].ToString();
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label42.Text);
                salerate = Convert.ToDouble(Label43.Text);
                soldland = Convert.ToDouble(Label44.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label45.Text = soldamt.ToString();
                Label46.Text = balland.ToString();
                Label47.Text = ballandamt.ToString();
            }
            if (arazi[i] == "239")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='239' AND kname='vinay sharma'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='239' AND kname='vinay sharma'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='239' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                Label48.Text = ds1412.Tables[0].Rows[0][0].ToString();
                Label49.Text = ds1412.Tables[0].Rows[0][1].ToString();
                Label50.Text = ds1412.Tables[0].Rows[0][2].ToString();
                Label51.Text = ds21412.Tables[0].Rows[0][0].ToString();
                Label52.Text = ds1412.Tables[0].Rows[0][3].ToString();
                Label53.Text = ds1412.Tables[0].Rows[0][4].ToString();
                Label54.Text = ds11412.Tables[0].Rows[0][0].ToString();
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label52.Text);
                salerate = Convert.ToDouble(Label53.Text);
                soldland = Convert.ToDouble(Label54.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label55.Text = soldamt.ToString();
                Label56.Text = balland.ToString();
                Label57.Text = ballandamt.ToString();
            }
            if (arazi[i] == "254")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='254' AND kname='NARAYAN SANKER'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='254' AND kname='NARAYAN SANKER'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='254' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                Label58.Text = ds1412.Tables[0].Rows[0][0].ToString();
                Label59.Text = ds1412.Tables[0].Rows[0][1].ToString();
                Label60.Text = ds1412.Tables[0].Rows[0][2].ToString();
                Label61.Text = ds21412.Tables[0].Rows[0][0].ToString();
                Label62.Text = ds1412.Tables[0].Rows[0][3].ToString();
                Label63.Text = ds1412.Tables[0].Rows[0][4].ToString();
                Label64.Text = ds11412.Tables[0].Rows[0][0].ToString();
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label62.Text);
                salerate = Convert.ToDouble(Label63.Text);
                soldland = Convert.ToDouble(Label64.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label65.Text = soldamt.ToString();
                Label66.Text = balland.ToString();
                Label67.Text = ballandamt.ToString();
            }
            if (arazi[i] == "30")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='30' AND kname='DHARMBEER SIGH'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='30' AND kname='DHARMBEER SIGH'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='30' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                Label68.Text = ds1412.Tables[0].Rows[0][0].ToString();
                Label69.Text = ds1412.Tables[0].Rows[0][1].ToString();
                Label70.Text = ds1412.Tables[0].Rows[0][2].ToString();
                Label71.Text = ds21412.Tables[0].Rows[0][0].ToString();
                Label72.Text = ds1412.Tables[0].Rows[0][3].ToString();
                Label73.Text = ds1412.Tables[0].Rows[0][4].ToString();
                Label74.Text = ds11412.Tables[0].Rows[0][0].ToString();
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label72.Text);
                salerate = Convert.ToDouble(Label73.Text);
                soldland = Convert.ToDouble(Label74.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label75.Text = soldamt.ToString();
                Label76.Text = balland.ToString();
                Label77.Text = ballandamt.ToString();
            }
            if (arazi[i] == "375KA")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='375KA' AND kname='RGHUNATH'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='375KA' AND kname='RGHUNATH'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='375KA' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                Label78.Text = ds1412.Tables[0].Rows[0][0].ToString();
                Label79.Text = ds1412.Tables[0].Rows[0][1].ToString();
                Label80.Text = ds1412.Tables[0].Rows[0][2].ToString();
                Label81.Text = ds21412.Tables[0].Rows[0][0].ToString();
                Label82.Text = ds1412.Tables[0].Rows[0][3].ToString();
                Label83.Text = ds1412.Tables[0].Rows[0][4].ToString();
                Label84.Text = ds11412.Tables[0].Rows[0][0].ToString();
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label82.Text);
                salerate = Convert.ToDouble(Label83.Text);
                soldland = Convert.ToDouble(Label84.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label85.Text = soldamt.ToString();
                Label86.Text = balland.ToString();
                Label87.Text = ballandamt.ToString();
            }
            if (arazi[i] == "506")
            {
                con.Open();
                SqlDataAdapter da1412 = new SqlDataAdapter("select arazino ,kname,plandsize,slandsize,srate from landsizedetails where arazino='506' AND kname='RAGHUNATH'", con);
                DataSet ds1412 = new DataSet();
                da1412.Fill(ds1412);
                con.Close();
                con.Open();
                SqlDataAdapter da21412 = new SqlDataAdapter("select amount from chequekishan where arazino='506' AND kname='RAGHUNATH'", con);
                DataSet ds21412 = new DataSet();
                da21412.Fill(ds21412);
                con.Close();
                con.Open();
                SqlDataAdapter da11412 = new SqlDataAdapter("select sum(PLOTSIZE) from  wjstar1.customerreg1 where APPNO='506' AND CUSTREGNO NOT IN (select CUSTREGNO from wjstar1.customerreg1 where regstatus='Cancel')", con);
                DataSet ds11412 = new DataSet();
                da11412.Fill(ds11412);
                con.Close();
                if (ds1412.Tables[0].Rows[0][0].ToString() != "")
                    Label88.Text = ds1412.Tables[0].Rows[0][0].ToString();
                else
                    Label88.Text = "0";
                if (ds1412.Tables[0].Rows[0][1].ToString() != "")
                    Label89.Text = ds1412.Tables[0].Rows[0][1].ToString();
                else
                    Label89.Text = "0";
                if (ds1412.Tables[0].Rows[0][2].ToString() != "")
                    Label90.Text = ds1412.Tables[0].Rows[0][2].ToString();
                else
                    Label90.Text = "0";
                if (ds21412.Tables[0].Rows[0][0].ToString() != "")
                    Label91.Text = ds21412.Tables[0].Rows[0][0].ToString();
                else
                    Label91.Text = "0";
                if (ds1412.Tables[0].Rows[0][3].ToString() != "")
                    Label92.Text = ds1412.Tables[0].Rows[0][3].ToString();
                else
                    Label92.Text = "0";
                if (ds1412.Tables[0].Rows[0][4].ToString() != "")
                    Label93.Text = ds1412.Tables[0].Rows[0][4].ToString();
                else
                    Label93.Text = "0";
                if (ds11412.Tables[0].Rows[0][0].ToString() != "")
                    Label94.Text = ds11412.Tables[0].Rows[0][0].ToString();
                else
                    Label94.Text = "0";
                Double salerate = 0, saleland = 0, soldland = 0, soldamt = 0, balland = 0, ballandamt = 0;
                saleland = Convert.ToDouble(Label92.Text);
                salerate = Convert.ToDouble(Label93.Text);
                soldland = Convert.ToDouble(Label94.Text);
                balland = saleland - soldland;
                soldamt = soldland * salerate;
                ballandamt = balland * salerate;
                Label95.Text = soldamt.ToString();
                Label96.Text = balland.ToString();
                Label97.Text = ballandamt.ToString();
            }
        }
    }
}