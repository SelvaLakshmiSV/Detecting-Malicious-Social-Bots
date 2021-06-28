using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class UserAddGroup : System.Web.UI.Page
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
        adp = new SqlDataAdapter("select * from gtable", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }

    void bindgrid2(string gname)
    {

        adp = new SqlDataAdapter("select * from regtable where uname in (select uname from gmtable where gname=@gname)", con);
        adp.SelectCommand.Parameters.AddWithValue("gname", gname);
        dt = new DataTable();
        adp.Fill(dt);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string gname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();

            if (e.CommandName == "vg")
            {
                bindgrid2(gname);
            }
            else if (e.CommandName == "jg")
            {
                cmd = new SqlCommand("Select * from gmtable where gname=@gname and uname=@uname", con);
                cmd.Parameters.AddWithValue("gname", gname);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "Already Added this Group......."; 
                    return;
                }

                cmd = new SqlCommand("insert into gmtable values(@gname,@uname,@jdate)", con);
                cmd.Parameters.AddWithValue("gname", gname);
                cmd.Parameters.AddWithValue("uname", TextBox1.Text);
                cmd.Parameters.AddWithValue("jdate", DateTime.Now.ToString("dd-MMM-yyyy"));
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid2(gname);



            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}