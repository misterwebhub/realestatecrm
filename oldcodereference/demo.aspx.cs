using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _161GHA_Default : System.Web.UI.Page
{
    string filepath = @"D:\\test.txt";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRead_Click(object sender, EventArgs e)
    {
		 string filepath1 = Server.MapPath(filepath);
        if ( System.IO.File.Exists( filepath1 ) == true )
{

var strlist = new List<string>();
        var fileStream = new FileStream(filepath1, FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
        {
            string strline;
            while ((strline = streamReader.ReadLine()) != null)
            {
                txtText.InnerText += strline + "\n";
            }
        }

}
else
{

    txtFilepath.Text = "not";

}
        
    }
}