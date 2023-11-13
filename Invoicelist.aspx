<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="Invoicelist.aspx.cs" Inherits="ERP.Invoicelist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton runat="server" OnClick="Unnamed1_Click" >ADD INVOICE</asp:LinkButton>
    <br />
<br />
    <asp:GridView ID="GridView1" DataKeyNames="ID"  runat="server" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None" Height="67px" Width="1134px" AutoGenerateColumns="False" AllowPaging="True">
     <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="CUSTOMERNAME" HeaderText="CUSTOMERNAME" SortExpression="CUSTOMERNAME" />
            <asp:BoundField DataField="createddate" HeaderText="createddate" SortExpression="createddate" />
            <asp:BoundField DataField="TOTAL" HeaderText="TOTAL" ReadOnly="True" SortExpression="TOTAL" />
            <asp:CommandField HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" />
        </Columns>
   
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
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ERPConnectionString %>" SelectCommand="Select IH.ID as ID,CUSTOMERNAME,createddate,SUM(TOTAL) AS TOTAL from invoiceheader IH 
INNER JOIN 
tblcustomer TC ON IH.custid=TC.CUSTOMERID
INNER JOIN invoiceDetails ID on IH.ID=ID.INVOICEID
GROUP BY CUSTOMERNAME,CREATEDDATE,IH.companyname ,IH.ID
HAVING IH.companyname =@companyname;" DeleteCommand="del_invoice" DeleteCommandType="StoredProcedure" >
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="companyname" SessionField="company" />
        </SelectParameters>
</asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
