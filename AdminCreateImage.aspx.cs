using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminCreateImage : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                autonumber();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void autonumber()
    {

        cmd = new SqlCommand("select isnull(max(imgid), 0)+ 1 from imgtable", con);
        TextBox1.Text = cmd.ExecuteScalar().ToString();
        cmd.Dispose();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try 
        {
            ViewState.Clear();
            Image1.ImageUrl = "";
            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Image Not Selected......";
                return;
            }

            string fname = FileUpload1 .FileName;
            Image1.ImageUrl = FileUpload1.PostedFile.FileName;
            string ext = fname.Substring(fname.LastIndexOf(".")).ToLower() ;
            if (!(ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png") || ext.Equals(".gif") || ext.Equals(".bmp")))
            {
                Label1.Text = "Select Only jpg or png or gif or bmp File Only......";
                return;
            }


            fname = DateTime.Now.Ticks + "_" + fname;

            FileUpload1.PostedFile .SaveAs (Server.MapPath ("CImage\\"+ fname ));
            ViewState.Add("CImage", fname);



 
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try 
        {
            if (ViewState["CImage"] == null)
            {
                Label1.Text = "Image Not Selected.....";
                return;
            }

            cmd = new SqlCommand("select imgid from imgtable where imgid=@imgid", con);
            cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "ImageID Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into imgtable values(@imgid,@imgpath)", con);
            cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
            cmd.Parameters.AddWithValue("imgpath", ViewState["CImage"].ToString());
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Image Details Inserted......";


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        Image1.ImageUrl = "";
        ViewState.Clear();
        autonumber();
    }
}