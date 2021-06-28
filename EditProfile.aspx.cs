using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class EditProfile : System.Web.UI.Page
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

                DropDownList1.Items.Add("Day");
                int i = 0;
                for (i = 1; i <= 31; i++)
                    DropDownList1.Items.Add(i.ToString());

                string[] mon = { "Month", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                for (i = 0; i < mon.Length; i++)
                    DropDownList2.Items.Add(mon[i]);

                DropDownList3.Items.Add("Year");
                for (i = 1970; i <= DateTime.Now.Year - 10; i++)
                    DropDownList3.Items.Add(i.ToString());


                if (Session["UserName"] != null)
                {
                    TextBox1.Text = Session["UserName"].ToString();
                    cmd = new SqlCommand("select * from regtable where uname=@uname", con);
                    cmd.Parameters.AddWithValue("uname", TextBox1 .Text );
                    rs = cmd.ExecuteReader();
                    if (rs.Read())
                    {
                        Image1.ImageUrl = Server.MapPath("PImage\\" + rs["PImage"].ToString());
                        TextBox2.Text = rs["emailid"].ToString();
                        RadioButtonList1.Text = rs["gender"].ToString();
                        DateTime dob = DateTime.Parse(rs["dob"].ToString());
                        DropDownList1.Text = dob.Day.ToString();
                        DropDownList2.Text = dob.ToString("MMM");
                        DropDownList3.Text = dob.Year.ToString();
                        TextBox3.Text = rs["address"].ToString();
                        TextBox4.Text = rs["location"].ToString();
                        TextBox5.Text = rs["pcode"].ToString();
                        TextBox6.Text = rs["cno"].ToString();
                        DropDownList4.Text = rs["squestion"].ToString();
                        TextBox7.Text = rs["sanswer"].ToString();
                        rs.Close();
                        cmd.Dispose();
                    }
                    else
                    {
                        rs.Close();
                        cmd.Dispose();
                        Label1.Text = "Record Not Found.Check RegTable....";

                    }
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
            if (RadioButtonList1.SelectedIndex == -1 || DropDownList1.SelectedIndex == 0 || DropDownList2.SelectedIndex == 0 || DropDownList3.SelectedIndex == 0 || DropDownList4.SelectedIndex == 0)
            {
                Label1.Text = "Select All Option.....";
                return;
            }
            DateTime dob = DateTime.Parse(DropDownList1.SelectedItem.Text + "-" + DropDownList2.SelectedItem.Text + "-" + DropDownList3.SelectedItem.Text);



            cmd = new SqlCommand("update regtable set emailid=@emailid, gender=@gender,@dob=@dob,address=@address, location=@location,pcode=@pcode, cno=@cno , squestion=@squestion, sanswer=@sanswer where uname = @uname", con);
          
            cmd.Parameters .AddWithValue ("emailid",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("dob",dob.ToString ("dd-MMM-yyyy"));
            cmd.Parameters .AddWithValue ("address",TextBox3 .Text  );
            cmd.Parameters .AddWithValue ("location",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("pcode",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("cno",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("squestion",DropDownList4 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("sanswer",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Label1.Text = "Edit User Profile Details......";


        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }


    }
}