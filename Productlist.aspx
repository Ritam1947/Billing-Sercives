<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="Productlist.aspx.cs" Inherits="ERP.Productlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">








    <asp:LinkButton runat="server" OnClick="Unnamed1_Click">ADD PRODUCT</asp:LinkButton>
    <br />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PRODUCTID" DataSourceID="SqlDataSource1" Height="85px" Width="1132px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand" AllowPaging="True">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="PRODUCTID" HeaderText="PRODUCTID" InsertVisible="False" ReadOnly="True" SortExpression="PRODUCTID" />
        <asp:BoundField DataField="PRODUCTNAME" HeaderText="PRODUCTNAME" SortExpression="PRODUCTNAME" />
        <asp:BoundField DataField="CODE" HeaderText="CODE" SortExpression="CODE" />
        <asp:BoundField DataField="DESCP" HeaderText="DESCP" SortExpression="DESCP" />
        <asp:BoundField DataField="MRP" HeaderText="MRP" SortExpression="MRP" />
        <asp:BoundField DataField="TAX" HeaderText="TAX" SortExpression="TAX" />
        <asp:BoundField DataField="GST" HeaderText="GST" SortExpression="GST" />
        <asp:TemplateField Headertext ="Action">
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
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ERPConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ERPConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [tblproduct] where companyname=@companyname">
    <SelectParameters>
        <asp:SessionParameter Name="companyname" Type="String" SessionField="company" />
    </SelectParameters>
</asp:SqlDataSource>
<p>
</p>









</asp:Content>
