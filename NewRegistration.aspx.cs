using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class NewRegistration : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label1.Text = "";
            Menu m1 = (Menu)Master.FindControl("Menu1");
            m1.Visible = true;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            con.Open();
            if (!IsPostBack)
            {
                int i;
                    DropDownList1.Items.Add("Day");
                    for (i = 1; i <= 31; i++)
                        DropDownList1.Items.Add(i.ToString());
                    string[] mon = { "Month", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                    for (i = 0; i < mon.Length; i++)
                        DropDownList2.Items.Add(mon[i]);
                    DropDownList3.Items.Add("Year");
                    for (i = 1970; i <= DateTime.Now.Year - 10; i++)
                        DropDownList3.Items.Add(i.ToString());
            }
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        try 
        {
            ViewState.Clear();
            Image1.ImageUrl = "";
            if (FileUpload1.HasFile == false)
            {
                Label1.Text = "Profile Image Not Selected......";
                return;
            }

            string fname = FileUpload1.FileName;
            Image1.ImageUrl = FileUpload1.PostedFile.FileName;
            string ext = fname.Substring(fname.LastIndexOf(".")).ToLower();
            if (!(ext.Equals(".jpg") || ext.Equals(".jpeg") || ext.Equals(".png") || ext.Equals(".gif") || ext.Equals(".bmp")))
            {
                Label1.Text = "Select Only jpg or png or gif or bmp File Only......";
                return;
            }


            fname = DateTime.Now.Ticks + "_" + fname;

            FileUpload1.PostedFile.SaveAs(Server.MapPath("PImage\\" + fname));
            ViewState.Add("PImage", fname);


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
                Label1.Text = "Select All Options.......";
                return;
            }

            if (ViewState["PImage"] == null)
            {
                Label1.Text = "Profile Image Not Selected......";
                return;
            }

            DateTime dob = DateTime.Parse(DropDownList1.SelectedItem.Text + "-" + DropDownList2.SelectedItem.Text + "-" + DropDownList3.SelectedItem.Text);

            if (TextBox8.Text == "" || TextBox9.Text == "")
            {
                Label1.Text = "Please Retype Password and Confirm Password......";
                return;
            }

            if (TextBox8.Text.Equals(TextBox9.Text) == false)
            {
                Label1.Text = "Password is Mismatched.......";
                return;
            }

            cmd = new SqlCommand("select uname from regtable where uname=@uname", con);
            cmd.Parameters.AddWithValue("uname", TextBox1.Text);
            rs = cmd.ExecuteReader();
            bool b = rs.Read();
            rs.Close();
            cmd.Dispose();
            if (b)
            {
                Label1.Text = "UserName Already Found.....";
                return;
            }

            cmd = new SqlCommand("insert into regtable values(@uname,@emailid,@gender,@dob,@address,@location,@pcode,@cno,@squestion,@sanswer,@pimage,@pword,@rdate)", con);
            cmd.Parameters .AddWithValue ("uname",TextBox1 .Text );
           
            cmd.Parameters .AddWithValue ("emailid",TextBox2 .Text );
            cmd.Parameters .AddWithValue ("gender",RadioButtonList1 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("dob",dob.ToString  ("dd-MMM-yyyy"));
            cmd.Parameters .AddWithValue ("address",TextBox3 .Text );
            cmd.Parameters .AddWithValue ("location",TextBox4 .Text );
            cmd.Parameters .AddWithValue ("pcode",TextBox5 .Text );
            cmd.Parameters .AddWithValue ("cno",TextBox6 .Text );
            cmd.Parameters .AddWithValue ("squestion",DropDownList4 .SelectedItem .Text );
            cmd.Parameters .AddWithValue ("sanswer",TextBox7 .Text );
            cmd.Parameters .AddWithValue ("pimage",ViewState ["PImage"].ToString ());           
            cmd.Parameters .AddWithValue ("pword",TextBox8 .Text );
            cmd.Parameters .AddWithValue ("rdate",DateTime .Now .ToString ("dd-MMM-yyyy"));
            cmd.ExecuteNonQuery ();
            cmd.Dispose ();
            Label1 .Text ="Register New User Details .......";
            Response .Redirect ("Login.aspx");





        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
        }

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        DropDownList1.SelectedIndex = 0;
        DropDownList2.SelectedIndex = 0;
        DropDownList3.SelectedIndex = 0;
        DropDownList4.SelectedIndex = 0;
        RadioButtonList1.SelectedIndex = -1;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        Image1.ImageUrl = "";
        ViewState.Clear();

      
    }
   
}