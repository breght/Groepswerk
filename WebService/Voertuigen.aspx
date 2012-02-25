<%@ Page Title="Voertuigen" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Voertuigen.aspx.vb" Inherits="Voertuigen" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
   
   <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
    EmptyDataText="There are no data records to display." AllowPaging="True" 
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataKeyNames="Auto_ID">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="Merk" HeaderText="Merk" SortExpression="Merk" />
            <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
            <asp:BoundField DataField="Brandstof" HeaderText="Brandstof" 
                SortExpression="Brandstof" />
            <asp:BoundField DataField="Transmissie" HeaderText="Transmissie" 
                SortExpression="Transmissie" />
            <asp:BoundField DataField="Vermogen" HeaderText="Vermogen" 
                SortExpression="Vermogen" />
            <asp:BoundField DataField="Zitplaatsen" HeaderText="Zitplaatsen" 
                SortExpression="Zitplaatsen" />
            <asp:BoundField DataField="Carrosserietype" HeaderText="Carrosserietype" 
                SortExpression="Carrosserietype" />
            <asp:BoundField DataField="Kilometerstand" HeaderText="Kilometerstand" 
                SortExpression="Kilometerstand" />
            <asp:BoundField DataField="Bouwjaar" HeaderText="Bouwjaar" 
                SortExpression="Bouwjaar" />
            <asp:BoundField DataField="Kleur" HeaderText="Kleur" SortExpression="Kleur" />
            <asp:BoundField DataField="Prijs" HeaderText="Prijs" SortExpression="Prijs" />
            <asp:BoundField DataField="Auto_ID" HeaderText="Auto_ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="Auto_ID" Visible="False" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
        
    
        SelectCommand="selectAuto" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    
   
</asp:Content>
