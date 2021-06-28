<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendComment.aspx.cs" Inherits="SendComment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Send Comment</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">User Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Post ID</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;">Comment Text</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :right ;" class="style1">Comment Date</td>
<td class="style1">
    <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Send</asp:LinkButton>
    </td>
</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>

</table>
</asp:Content>

