<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%"  >
        <tr>
            <th colspan="2">
                <h1  style =" text-align :center ; line-height :50px;  font-size :x-large ;">
                    Admin
                     Login</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                UserName</td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Password</td>
            <td  style="text-align: left">
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" 
                    TextMode="Password" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click" Font-Size="Medium" >Login</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

