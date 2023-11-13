<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="customerlist.aspx.cs" Inherits="ERP.customerlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:LinkButton runat="server" OnClick="Unnamed1_Click">ADD CUSTOMER</asp:LinkButton>
    <br />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CUSTOMERID" DataSourceID="SqlDataSource1" Height="85px" Width="1139px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="CUSTOMERID" HeaderText="CUSTOMERID" InsertVisible="False" ReadOnly="True" SortExpression="CUSTOMERID" />
        <asp:BoundField DataField="CUSTOMERNAME" HeaderText="CUSTOMERNAME" SortExpression="CUSTOMERNAME" />
        <asp:BoundField DataField="PHONENUMBER" HeaderText="PHONENUMBER" SortExpression="PHONENUMBER" />
        <asp:BoundField DataField="EMAILID" HeaderText="EMAILID" SortExpression="EMAILID" />
        <asp:BoundField DataField="ADDR" HeaderText="ADDR" SortExpression="ADDR" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>

                <asp:Button runat="server" Text="EDIT" CommandName="select" CommandArgument="<%#Container.DataItemIndex %>"/>

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERPConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ERPConnectionString3.ProviderName %>" SelectCommand="SELECT * FROM [tblcustomer] where companyname=@companyname">
    <SelectParameters>
 <asp:SessionParameter Name="companyname" Type="String" SessionField="company" />
    </SelectParameters>
</asp:SqlDataSource>
<p>
</p>
</asp:Content>
