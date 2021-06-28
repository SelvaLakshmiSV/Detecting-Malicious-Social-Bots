using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class SearchFriends : System.Web.UI.Page
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
                    TextBox2.Text = Session["UserName"].ToString();
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
        try
        {
            GridView1.Visible = false;          
            
     adp=new SqlDataAdapter ("select * from regtable where uname=@uname  and (uname<>@uname1)  and (uname not in (select rto from reqtable where rfrom=@rfrom and status<>'Reject' ))", con);     
          
            adp.SelectCommand.Parameters.AddWithValue("uname", TextBox1 .Text );
            adp.SelectCommand.Parameters.AddWithValue("uname1", Session["UserName"].ToString());
            adp.SelectCommand.Parameters.AddWithValue("rfrom", Session["UserName"].ToString());
            dt = new DataTable();
            adp.Fill(dt);
            GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            bindgrid();
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {

            if (e.CommandName == "rr")
            {

                cmd = new SqlCommand("select * from frtable where (uname1=@uname1 and uname2=@uname2) or (uname1=@uname3 and uname2=@uname4)", con);
                cmd.Parameters.AddWithValue("uname1", TextBox1.Text);
                cmd.Parameters.AddWithValue("uname2", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("uname3", Session["UserName"].ToString());
                cmd.Parameters.AddWithValue("uname4", TextBox1.Text);
                rs = cmd.ExecuteReader();
                bool b = rs.Read();
                rs.Close();
                cmd.Dispose();
                if (b)
                {
                    Label1.Text = "Record Already Found...";
                    return;
                }


                string uname = GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString() ;
            
                cmd = new SqlCommand("select isnull(max(id),0)+1 from reqtable ", con);
                int id = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Dispose();

                cmd = new SqlCommand("insert into reqtable values (@id,@rfrom,@rto,@rdate,@status)", con);
                cmd.Parameters.AddWithValue("id", id);
          
                cmd.Parameters.AddWithValue("rfrom", Session["UserName"].ToString());
               
                cmd.Parameters.AddWithValue("rto", uname);
              
                cmd.Parameters.AddWithValue("rdate", DateTime.Now.ToString ("dd-MMM-yyyy hh:mm:ss tt"));
                cmd.Parameters.AddWithValue("status", "Request");
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                bindgrid();
            }
         
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
}