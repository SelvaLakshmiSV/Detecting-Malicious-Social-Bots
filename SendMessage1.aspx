<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SendMessage1.aspx.cs" Inherits="SendMessage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1"  width="70%" align="center" >
        <tr>
            <th >
              
                <h1 style ="text-align :center ;">
                    Message</h1>
               
            </th>
        </tr>
        <tr>
        <td style ="text-align :center ;">
          <center>  
              <asp:GridView ID="GridView1" runat="server" 
                AutoGenerateColumns ="False" 
                 onrowcommand="GridView1_RowCommand" BackColor="#CCCCCC" 
                BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                CellSpacing="2" ForeColor="Black" Width="444px" >
            <Columns>
            <asp:BoundField DataField ="uname2" HeaderText ="Name" />
           <asp:ButtonField Text ="Message" HeaderText ="Send Message" CommandName ="cc"  ControlStyle-Font-Size="Small"  ControlStyle-ForeColor ="Green" ControlStyle-Font-Bold ="true" />
           <asp:TemplateField  >
           <ItemTemplate >
           <asp:TextBox ID="t1" runat ="server"   Visible ="false" TextMode ="MultiLine"   ></asp:TextBox>
           <br />
           <asp:LinkButton ID="l1" runat ="server" Text ="Send" CommandName ="ss" Visible ="false"  Font-Size="Small" ForeColor="green" Font-Bold ="true" ></asp:LinkButton>
             <asp:LinkButton ID="l2" runat ="server" Text ="Cancel" CommandName ="cc1" Visible ="false"  Font-Size="Small" ForeColor="green" Font-Bold ="true"  ></asp:LinkButton>
           
           </ItemTemplate>
         
           
           </asp:TemplateField>
         
         

          
            
           
          
            </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView></center>
            </td> 
        </tr>
         
         <tr>
        <td style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             </td> 
        </tr>
        </table> 

</asp:Content>

