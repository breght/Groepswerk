<%@ Page Title="Verhuur" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Verhuur.aspx.vb" Inherits="Verhuur" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Auto_ID" DataSourceID="SqlDataSource1">
        <Columns>
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
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
        
        SelectCommand="SELECT [Merk], [Model], [Brandstof], [Transmissie], [Vermogen], [Zitplaatsen], [Carrosserietype], [Kilometerstand], [Bouwjaar], [Kleur], [Prijs], [Auto_ID] FROM [tblAuto] WHERE ([Auto_ID] = @Auto_ID)">
        <SelectParameters>
            <asp:SessionParameter Name="Auto_ID" SessionField="carid" 
                Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
   <h3> <asp:Label ID="Label1" runat="server" Text="van:"></asp:Label> </h3>
    <br />
    <asp:Calendar ID="Cvan" runat="server" BackColor="White" BorderColor="Black" 
        BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" 
        ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
            Font-Size="12pt" ForeColor="White" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
    <br />
    <h3><asp:Label ID="Label2" runat="server" Text="tot:"></asp:Label></h3>
    <br />
    <asp:Calendar ID="Ctot" runat="server" BackColor="White" BorderColor="Black" 
        BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" 
        ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
            Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
            Font-Size="12pt" ForeColor="White" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
    <br />
    <asp:Button ID="btnBevestig" runat="server" Text="Bevestig" />
    </center>
</asp:Content>
