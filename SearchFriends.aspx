<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchFriends.aspx.cs" Inherits="SearchFriends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" width ="70%" align="center" >
        <tr>
            <th colspan ="2">
             
                <h1  style ="text-align :center ;">Search Friends</h1>
               
            </th>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
               </td>
        </tr>
        <tr>
            <td style ="text-align :right ;">
                Search Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Search</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                    <center><asp:GridView ID="GridView1" runat="server" 
                        AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                        ForeColor="Black" 
                        PageSize="3" Width="702px" DataKeyNames="uname" 
                        onrowcommand="GridView1_RowCommand">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                        <Columns>
                          <asp:BoundField DataField ="uname" HeaderText ="User Name" />
                         
                         <asp:ImageField DataImageUrlField ="pimage" DataImageUrlFormatString ="PImage/{0}" HeaderText ="Photo">
                <ControlStyle  Width ="100" Height ="100" /> 
                </asp:ImageField>  
             
                <asp:ButtonField Text ="Request" HeaderText ="Request" CommandName ="rr"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
                        </Columns>
                    </asp:GridView></center>
            </td>
        </tr>
        <tr>
            <td style ="text-align :center ;" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

