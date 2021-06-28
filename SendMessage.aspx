<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table border="1" align ="center" width ="70%">
        <tr>
            <th colspan ="2">
                <h1  style =" text-align :center ;">
                    Send Message</h1>
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
                Message ID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Message Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Message
                Description</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right;">
                Message
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

