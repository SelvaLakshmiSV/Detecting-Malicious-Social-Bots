<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendImage.aspx.cs" Inherits="SendImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" align ="center" width ="70%">
        <tr>
            <th colspan ="2">
                 
                  <h1  style =" text-align :center ;">
                    Add Post</h1>
                  
            </th>
        </tr>
        <tr>
            <td style ="text-align :right;">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Post ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Post Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
     
        <tr>
            <td style ="text-align :right;">
                Post
                Image</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
                    Font-Bold="True">View</asp:LinkButton>
                <br />
                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                <br />
            </td>
        </tr>
           <tr>
            <td style ="text-align :right;">
                Description</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Post Date</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Add</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style ="text-align :center;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

