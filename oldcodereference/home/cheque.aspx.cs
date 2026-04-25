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
using System.Drawing;
using System.IO;

public partial class broker : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["amar"].ConnectionString.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bid();
            add();
        }
    }
    public void add()
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from chequedetsils", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
     
    }
    public void bid()
    {

        DropDownList1.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select DISTINCT arazino from wjstar1.ploted1", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
           
        }
        con.Close();
       
        


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        SqlConnection con = new SqlConnection(s);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select kname from wjstar1.kishan where arazino='"+DropDownList1.Text+"'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[i][0].ToString());

        }
        con.Close();
       
        
    }
    public string fp1, sp1, fpimg1, spimg1, sp2, spimg2, ft1, ftimg1, st1, stimg1, st2, stimg2, ar, ext;
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            sp1 = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/home/upload/" + sp1));
            spimg1 = "~/home/upload/" + sp1.ToString();

            ext = Path.GetExtension(sp1);
            if (ext == ".jpeg" || ext == ".jpg" || ext == ".png" || ext == ".bmp" || ext == ".gif")
            {
                Image1.ImageUrl = spimg1;
                spimg1 = "~/home/upload/" + sp1.ToString();
            }
            else
            {
                Label1.Text = "file only upload .jpg,.jpeg,.png,.bmp";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(s);
        con.Open();
        fpimg1 = Image1.ImageUrl;
        if (fpimg1 == "")
        {
            Label1.Text = "please upload photo";
        }
        else
        {

            SqlCommand cmd = new SqlCommand("insert into chequedetsils(arazino,name,kid,adhar,bname,chequeno,amount,customername,status,chequedate,cdate,cphoto,reason)values('" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + TextBox1.Text + "','" + TextBox9.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox10.Text + "','" + TextBox4.Text + "','" + TextBox11.Text + "','" +fpimg1 + "','" + TextBox7.Text + "')", con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                Label1.Text = "Record Added Successfully";
                add();
            }
            else
            {
                Label1.Text = "error";
            }
        }
    }
}