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

public partial class AdminViewBotBasedPostDetails : System.Web.UI.Page
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
            Menu m2 = (Menu)Master.FindControl("Menu2");
            m2.Visible = true;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                bindgrid1();
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    void bindgrid1()
    {
        adp = new SqlDataAdapter("select * from ptable where utype='Bot'", con);
        dt = new DataTable();
        adp.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            Label1.Text = "";
            if (ViewState["PID"] != null)
                ViewState.Remove("PID");


            int pid = int.Parse(GridView1.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
            ViewState.Add("PID", pid);
            if (e.CommandName == "vc1")
            {
                string ptype = GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[1].Text;
                if (ptype.Equals("Message"))
                {
                    string pdesc = GridView1.Rows[int.Parse(e.CommandArgument.ToString())].Cells[3].Text;
                    byte[] b = Encoding.ASCII.GetBytes(pdesc);
                    FileStream fs = new FileStream(Server.MapPath("PostData\\one.txt"), FileMode.Create, FileAccess.Write);
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\one.txt"));

                }
                else if (ptype.Equals("Audio") || ptype.Equals("Video") || ptype.Equals("Image"))
                {

                    cmd = new SqlCommand("select pimage from ptable where pid=@pid", con);
                    cmd.Parameters.AddWithValue("pid", pid);
                    rs = cmd.ExecuteReader();
                    string pimage = "";
                    if (rs.Read())
                    {
                        pimage = rs["pimage"].ToString();
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
                    System.Diagnostics.Process.Start(Server.MapPath("PostData\\" + pimage));
                }

            }

            /*else if (e.CommandName == "vc2")
            {

                adp = new SqlDataAdapter("select * from pctable where pid=@pid and utype='Bot'", con);
                adp.SelectCommand.Parameters.AddWithValue("pid", pid);
                dt = new DataTable();
                adp.Fill(dt);
                GridView2.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }

           /* else if (e.CommandName == "vl")
            {
                adp = new SqlDataAdapter("select * from pltable where pid=@pid and utype='Bot'", con);
                adp.SelectCommand.Parameters.AddWithValue("pid", pid);
                dt = new DataTable();
                adp.Fill(dt);
                GridView3.Visible = true;
                GridView3.DataSource = dt;
                GridView3.DataBind();
                int lc = 0, uc = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string poption = dt.Rows[i]["poption"].ToString();
                    if (poption.Equals("Like"))
                        lc += 1;
                    else if (poption.Equals("Unlike"))
                        uc += 1;
                }

                Label1.Text = "Total Number of Likes :" + lc + "<br>Total Number of Unlike : " + uc;

            }*/
            else if (e.CommandName == "dp")
            {
               
                Label1.Text = "";

                cmd = new SqlCommand("delete from ptable where pid=@pid and utype='Bot'", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                cmd = new SqlCommand("delete from pctable where pid=@pid and utype='Bot'", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new SqlCommand("delete from pltable where pid=@pid and utype='Bot'", con);
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
   /* protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string uname = GridView2.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
            int pid = int.Parse(GridView2.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString());
            if (e.CommandName == "dc")
            {
                cmd = new SqlCommand("delete from pctable where uname=@uname and pid=@pid", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                adp = new SqlDataAdapter("select * from pctable where pid=@pid and utype='Bot'", con);
                adp.SelectCommand.Parameters.AddWithValue("pid", pid);
                dt = new DataTable();
                adp.Fill(dt);
                GridView2.Visible = true;
                GridView2.DataSource = dt;
                GridView2.DataBind();
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
            if (ViewState["PID"] != null)
            {
                int pid = int.Parse(ViewState["PID"].ToString());
                cmd = new SqlCommand("delete from pctable where pid=@pid and utype='Bot'", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                GridView2.Visible = false;

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string uname = GridView3.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
            int pid = int.Parse(GridView3.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString());
            if (e.CommandName == "dl")
            {
                cmd = new SqlCommand("delete from pltable where uname=@uname and pid=@pid", con);
                cmd.Parameters.AddWithValue("uname", uname);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                adp = new SqlDataAdapter("select * from pltable where pid=@pid and utype='Bot'", con);
                adp.SelectCommand.Parameters.AddWithValue("pid", pid);
                dt = new DataTable();
                adp.Fill(dt);
                GridView3.Visible = true;
                GridView3.DataSource = dt;
                GridView3.DataBind();
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
            if (ViewState["PID"] != null)
            {
                int pid = int.Parse(ViewState["PID"].ToString());
                cmd = new SqlCommand("delete from pltable where pid=@pid and utype='Bot'", con);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                GridView3.Visible = false;

            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }*/
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try
        {
            cmd = new SqlCommand("delete from ptable where utype='Bot'", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from pctable where utype='Bot'", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            cmd = new SqlCommand("delete from pltable where utype='Bot'", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();

            GridView1.Visible = false;
          //  GridView2.Visible = false;
           // GridView3.Visible = false;

        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }
    }
}