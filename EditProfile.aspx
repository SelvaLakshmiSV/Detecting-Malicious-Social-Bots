<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" width ="70%" align="center" >
        <tr>
            <th colspan ="2">
                <h1>
                    Edit Profile</h1>
            </th>
        </tr>
         <tr>
            <td style ="text-align :right ;">
                Profile Photo</td>
            <td>
                <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" />
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                &nbsp;User Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                EMail ID</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Gender</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Date Of Birth</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Address</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Location</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                PinCode</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Contact Number</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Security Question</td>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>What is Your Favourite Subject?</asp:ListItem>
                    <asp:ListItem>What is Your Favourite Music Director?</asp:ListItem>
                    <asp:ListItem>What is Your Favourite Sports?</asp:ListItem>
                    <asp:ListItem>What is Favourite TV Show?</asp:ListItem>
                    <asp:ListItem>What is Your Favourite Hero?</asp:ListItem>
                    <asp:ListItem>What is Your First School Name?</asp:ListItem>
                    <asp:ListItem>What is Your Pet Name?</asp:ListItem>
                    <asp:ListItem>What is Your Favourite Person?</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Security Answer 
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Update</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

