<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminCreateGroup.aspx.cs" Inherits="AdminCreateGroup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center"  width ="70%">
<tr>
<th colspan ="2" ><h1>Group Creation</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">Group Name</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </td>

</tr>
<tr>
<td style ="text-align :right ;">Group Description</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>

</tr>
<tr>
<td style ="text-align :right ;">Group Creation Date</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </td>

</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Create</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
        Font-Bold="True">Clear</asp:LinkButton>
    </td>

</tr>
<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>

</tr>
</table>
</asp:Content>

