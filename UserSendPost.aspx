<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserSendPost.aspx.cs" Inherits="UserSendPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th colspan ="2">
<h1>Send Post</h1>
</th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Select Option</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>Message</asp:ListItem>
        <asp:ListItem>Image</asp:ListItem>
        <asp:ListItem>Audio</asp:ListItem>
        <asp:ListItem>Video</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Next</asp:LinkButton>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>

</table>
</asp:Content>

