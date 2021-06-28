using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class SendMessage : System.Web.UI.Page
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
                if (Session["UserName"] != null)
                {
                    TextBox5.Text = Session["UserName"].ToString();
                    TextBox4.Text = DateTime.Now.ToString("dd-MMM-yyyy");

                    autopostid();
                }
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    void autopostid()
    {
        try
        {
            cmd = new SqlCommand("select isnull(max(pid),0)+1 from ptable", con);
            TextBox1.Text = cmd.ExecuteScalar().ToString();
            cmd.Dispose();
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
            cmd = new SqlCommand("select * from ptable where pid=@pid", con);
            cmd.Parameters.AddWithValue("pid", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "PostID Already Found......";
                return;
            }
           
            ArrayList p = new ArrayList();
            p.Add(Session["UserName"].ToString());
            p.Add("Message");
            p.Add(TextBox1.Text);
            p.Add(TextBox2.Text);
            p.Add("Message");
            p.Add(TextBox3.Text);
            p.Add(TextBox4.Text);
            Session.Add("PData3", p);
            Response.Redirect("SelectClickStreamOption.aspx?PType=Message");

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

}