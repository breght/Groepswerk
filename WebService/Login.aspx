<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Panel ID="Panel1" runat="server">
       <h1>
       <asp:Label ID="lblMessage" runat="server" Text="Foute gebruikersnaam of wachtwoord" 
            Visible="False"></asp:Label>
       </h1> 
        <br />
        <div class="formLayout"> 
        <asp:Label ID="Label1" runat="server" Text="Gebruikersnaam:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtGebruikersnaam" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtGebruikersnaam" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Wachtwoord:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtwachtwoord" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtwachtwoord" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <asp:Button ID="btnInloggen" runat="server" Text="Inloggen" />
        <br />
        <br />
        <asp:Button ID="btnAccount" runat="server" 
            Text="Nog geen account? Klik hier!" />
            </div>
    </asp:Panel>

</asp:Content>