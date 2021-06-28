using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

public partial class UserViewBotBasedPostDetails : System.Web.UI.Page
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
                    bindgrid();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void bindgrid()
    {
        adp = new SqlDataAdapter("Select * from ptable where uname in (select uname2 from frtable where uname1=@uname1) and utype='Bot'", con);
        adp.SelectCommand.Parameters.AddWithValue("uname1", TextBox1.Text);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "vc")
            {
                int pid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());

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
                    FileStream fs =new FileStream (Server .MapPath ("PostData\\one.txt"), FileMode .Create , FileAccess .Write );
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
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}