using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Text;

public partial class ViewPostComment : System.Web.UI.Page
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
                if (Session["UserName"] != null && Request.QueryString.Get("PID") != null)
                {
                    bindview();
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

    void bindview()
    {
        adp = new SqlDataAdapter("select * from ptable where pid=@pid", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", Request.QueryString.Get("PID"));
        dt = new DataTable();
        adp.Fill(dt);
        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
    }

    void bindgrid1()
    {
        adp = new SqlDataAdapter("select * from pctable where pid=@pid and utype='User'", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", Request.QueryString.Get("PID"));
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    void bindgrid2()
    {
        adp = new SqlDataAdapter("select * from pctable where pid=@pid and utype='Bot'", con);
        adp.SelectCommand.Parameters.AddWithValue("pid", Request.QueryString.Get("PID"));
        dt = new DataTable();
        adp.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "vc")
            {

                cmd = new SqlCommand("select * from ptable where pid=@pid and utype='User'", con);
                cmd.Parameters.AddWithValue("pid", Request.QueryString.Get("PID"));
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
                    Label1.Text = "Record Not Found.Check PTable......";
                    return;
                }
                if (ptype.Equals("Message"))
                {
                    string fname = Server.MapPath("PostData\\one.txt");
                    FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write);

                    byte[] b = Encoding.ASCII.GetBytes(pdesc);
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                    System.Diagnostics.Process.Start(fname);
                }
                else if (ptype.Equals("Image") || ptype.Equals("Video") || ptype.Equals("Audio"))
                {
                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\" + pimage));

                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}