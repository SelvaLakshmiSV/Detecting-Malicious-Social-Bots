<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminCreateNewParameter.aspx.cs" Inherits="AdminCreateNewParameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align="center" width ="70%">
<tr>
<th colspan ="2"><h1>Create New Parameter</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">Image ID</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Image</td>
<td>
    <asp:ImageButton ID="ImageButton1" runat="server" Height="300px" 
        onclick="ImageButton1_Click" Width="300px" />
    </td>

</tr>

<tr>
<td style ="text-align :right ;">X Postion</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Y Position</td>
<td>
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :right ;">Parameter Name</td>
<td>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
<td style ="text-align :center ;" colspan="2">
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        Font-Bold="True">Submit</asp:LinkButton>
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

