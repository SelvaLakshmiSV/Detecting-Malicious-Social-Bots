using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class SendComment : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
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
                if (Session["UserName"] != null && Request.QueryString.Get("PID") != null && Request .QueryString .Get ("UType")!=null )
                {
                    TextBox1.Text = Session["UserName"].ToString();
                    TextBox2.Text = Request.QueryString.Get("PID");
                    TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                }
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
            cmd = new SqlCommand("select * from pctable where uname =@uname and pid =@pid", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            cmd.Parameters.AddWithValue("pid", TextBox2.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Already Send Your Comment......";
                return;
            }
            cmd = new SqlCommand("insert into pctable values(@uname,@pid,@ctext,@cdate,@utype)", con);
            cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
            cmd.Parameters .AddWithValue ("pid",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("ctext",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("cdate",TextBox4 .Text );
            cmd.Parameters.AddWithValue("utype", Request.QueryString.Get("UType"));
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1 .Text ="Successfully Send Your Comment ......";


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}