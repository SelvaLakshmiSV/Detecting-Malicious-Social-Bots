using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class AdminCreateGroup : System.Web.UI.Page
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
                TextBox3.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                TextBox1.Focus();
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
            cmd = new SqlCommand("select * from gtable where gname=@gname", con);
            cmd.Parameters.AddWithValue("gname", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "Group Name Already Found.....";
                return;
            }
            cmd = new SqlCommand("insert into gtable values (@gname,@gdesc,@gcdate)", con);
            cmd.Parameters.AddWithValue("gname", TextBox1.Text);
            cmd.Parameters.AddWithValue("gdesc", TextBox2.Text);
            cmd.Parameters.AddWithValue("gcdate", TextBox3.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Group Creation Details Inserted.....";


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox1.Focus();
    }
}