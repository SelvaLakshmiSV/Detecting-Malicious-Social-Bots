using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminCreateNewParameter : System.Web.UI.Page
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
                if (Request.QueryString.Get("ImgID") != null)
                {
                    TextBox1.Text = Request.QueryString.Get("ImgID");
                    cmd = new SqlCommand("select imgpath from imgtable where imgid=@imgid", con);
                    cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
                    rs = cmd.ExecuteReader();
                    string imgpath = "";
                    if (rs.Read())
                    {
                        imgpath = rs["imgpath"].ToString();
                        rs.Close();
                        cmd.Dispose();
                        ImageButton1.ImageUrl = Server.MapPath("CImage\\" + imgpath);
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Record Not Found.Check ImgTable.....";

                    }

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try 
        {

            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = e.X.ToString();
            TextBox3.Text = e.Y.ToString();
            cmd = new SqlCommand("select * from imgptable where imgid=@imgid and xpoint=@xpoint and ypoint=@ypoint", con);
            cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
            cmd.Parameters.AddWithValue("xpoint", TextBox2.Text);
            cmd.Parameters.AddWithValue("ypoint", TextBox3.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "X Position and Y Position is Already Found.....";
                return;
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            cmd = new SqlCommand("select * from imgptable where imgid=@imgid and pname=@pname", con);
            cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
            cmd.Parameters.AddWithValue("pname", TextBox4.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Parameter Name Already Found.....";
                return;
            }

            cmd = new SqlCommand("select * from imgptable where imgid=@imgid and xpoint=@xpoint and ypoint=@ypoint", con);
            cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
            cmd.Parameters.AddWithValue("xpoint", TextBox2.Text);
            cmd.Parameters.AddWithValue("ypoint", TextBox3.Text);
            rs = cmd.ExecuteReader();
            b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "X Position and Y Position is Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into imgptable values (@imgid,@xpoint,@ypoint, @pname)", con);
            cmd.Parameters.AddWithValue("imgid", TextBox1.Text);
            cmd.Parameters.AddWithValue("xpoint", TextBox2.Text);
            cmd.Parameters.AddWithValue("ypoint", TextBox3.Text);
            cmd.Parameters.AddWithValue("pname", TextBox4.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "New Parameter Details Inserted.....";




        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";

    }
}