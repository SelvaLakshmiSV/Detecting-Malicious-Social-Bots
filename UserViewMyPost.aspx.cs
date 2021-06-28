using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text ;
using System.IO;

public partial class UserViewMyPost : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    SqlDataAdapter adp;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m3 = (Menu)Master.FindControl("Menu3");
            m3.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                    bindgrid1();
                    bindgrid2();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid1()
    {
        adp = new SqlDataAdapter("Select * from ptable where uname=@uname and utype='User'", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    void bindgrid2()
    {
        adp = new SqlDataAdapter("Select * from ptable where uname=@uname and utype='Bot'", con);
        adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int pid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            if (e.CommandName == "vc")
            {              

                cmd = new SqlCommand("Select * from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                rs = cmd.ExecuteReader();
                string ptype = "", pimage = "", pdesc = "";
                if (rs.Read())
                {
                    ptype = rs["ptype"].ToString();
                    pimage = rs["pimage"].ToString();
                    pdesc = rs["pdesc"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Record Not Found.Check PTable....";
                    return;
                }
                if (ptype.Equals("Message"))
                {
                    FileStream fs = new FileStream(Server.MapPath("PostData\\one.txt"), FileMode.Create, FileAccess.Write);
                    byte[] b = Encoding.ASCII.GetBytes(pdesc);
                    fs.Write(b, 0, b.Length);
                    fs.Close();

                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\one.txt"));

                }
                else if (ptype.Equals("Image") || ptype.Equals("Video") || ptype.Equals("Audio"))
                {
                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\" + pimage));
                }
            }
            else if (e.CommandName == "dp")
            {
                cmd = new SqlCommand("delete from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid1();

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
            cmd = new SqlCommand("delete from ptable where uname=@uname and utype='User'", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            bindgrid1();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int pid = int.Parse(GridView2.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            if (e.CommandName == "vc")
            {

                cmd = new SqlCommand("Select * from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                rs = cmd.ExecuteReader();
                string ptype = "", pimage = "", pdesc = "";
                if (rs.Read())
                {
                    ptype = rs["ptype"].ToString();
                    pimage = rs["pimage"].ToString();
                    pdesc = rs["pdesc"].ToString();
                    rs.Close();
                    cmd.Dispose();
                }
                else
                {
                    rs.Close();
                    cmd.Dispose();
                    Label1.Text = "Record Not Found.Check PTable....";
                    return;
                }
                if (ptype.Equals("Message"))
                {
                    FileStream fs = new FileStream(Server.MapPath("PostData\\one.txt"), FileMode.Create, FileAccess.Write);
                    byte[] b = Encoding.ASCII.GetBytes(pdesc);
                    fs.Write(b, 0, b.Length);
                    fs.Close();

                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\one.txt"));

                }
                else if (ptype.Equals("Image") || ptype.Equals("Video") || ptype.Equals("Audio"))
                {
                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\" + pimage));
                }
            }
            else if (e.CommandName == "dp")
            {
                cmd = new SqlCommand("delete from ptable where pid=@pid", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid2();

            }
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
            cmd = new SqlCommand("delete from ptable where uname=@uname and utype='Bot'", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            bindgrid2();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}