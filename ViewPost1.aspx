<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPost1.aspx.cs" Inherits="ViewPost1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" border="1" width="70%">
        <tr>
            <th colspan ="2">
               
                <h1 style ="text-align :center ;">
                    Post Details</h1>
                
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">
        User Name
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly ="true" ></asp:TextBox>
        </td>
        
        </tr>
       
        <tr>
            <td style="text-align :center ;" colspan ="2" >
                <asp:MultiView ID="MultiView1" runat="server">
                <table width ="100%">
                <tr>
                <td>
                     <asp:View ID="View1" runat="server">
                     <table width ="100%">
                     <tr>
                     <td>
                         <asp:Image ID="Image1" runat="server" Width ="150" Height ="150"  />
                     </td>
                     </tr>
                     
                     </table>
                    </asp:View>
                </td>
                </tr>
                   <tr>
                <td>
                     <asp:View ID="View2" runat="server">
                      <table width ="100%">
                     <tr>
                     <td>
                        <embed src="<%#vpath%>" runat="server" width="200" height="200"></embed>
                     </td>
                     </tr>
                     
                     </table>
                    </asp:View>
                </td>
                </tr>
                   <tr>
                <td>
                     <asp:View ID="View3" runat="server">
                      <table width ="100%">
                     <tr>
                     <td>
                        <embed src="<%#apath%>" runat="server" width="200" height="200"></embed>
                     </td>
                     </tr>
                     
                     </table>
                    </asp:View>
                </td>
                </tr>
                </table>
               
                </asp:MultiView>
            </td>
        </tr>
       
        <tr>
            <td style="text-align :center ;" colspan ="2" >
                <center>
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="197px" Width="311px" 
                    AutoGenerateRows="False" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields >
                
                        <asp:BoundField DataField ="pdesc" HeaderText ="Post Description" />
                        <asp:BoundField DataField ="pdate" HeaderText ="PostDate" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:BoundField  DataField ="uname" HeaderText ="UserName" />
                     
                </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" HorizontalAlign="Left" />
                </asp:DetailsView></center>
            </td>
        </tr>
        <tr>
        <td style ="text-align :right ;">Click Stream</td>
        <td>
    <asp:ImageButton ID="ImageButton1" runat="server" Height="300px" 
        Width="300px" onclick="ImageButton1_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" colspan ="2" >
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
                    Font-Bold="True">Like</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
                    Font-Bold="True">Send Comment</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align :center ;" colspan ="2" >
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

