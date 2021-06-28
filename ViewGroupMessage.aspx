<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewGroupMessage.aspx.cs" Inherits="ViewGroupMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <table border="1"  width="70%" >
            <tr>
                <th >
                    <h1>
                    View Message</h1>
                </th>
            </tr>
            <tr>
                <td style ="text-align :center ;">
                    <center>
                        <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns ="False" 
                DataKeyNames ="mid,gname" onrowcommand="GridView1_RowCommand" 
                BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                CellPadding="4" CellSpacing="2" ForeColor="Black" Width="706px" >
                            <Columns>
                            <asp:BoundField DataField ="gname" HeaderText ="GroupName" />
                       
                            <asp:BoundField DataField ="uname" HeaderText ="UserName" />


                               
                                <asp:BoundField DataField ="msgdate"  HeaderText ="MessageDate" />
                                <asp:BoundField DataField ="msgInfo" HeaderText ="Message" />
                              
                                <asp:ButtonField Text ="Reply" CommandName ="rr"  ControlStyle-Font-Size="Small" ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
                                <asp:TemplateField  >
                                    <ItemTemplate >
                                        <asp:TextBox ID="t1" runat ="server"   Visible ="false" TextMode ="MultiLine"   ></asp:TextBox>
                                        <br />
                                        <asp:LinkButton ID="l1" runat ="server" Text ="Send" CommandName ="ss" Visible ="false"  Font-Size="Small" ForeColor="Green" Font-Bold ="true" ></asp:LinkButton>
                                        <asp:LinkButton ID="l2" runat ="server" Text ="Cancel" CommandName ="cc" Visible ="false"  Font-Size="Small" ForeColor="green" Font-Bold ="true"  ></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </center>
                </td>
            </tr>
            <tr>
                <td style ="text-align :center ;">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </center>
</asp:Content>

