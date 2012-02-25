<%@ Page Title="Registratie" Language="VB" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeFile="Registratie.aspx.vb" Inherits="Registratie" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<div class="formLayout"> 
    <asp:Label ID="Label1" runat="server" Text="Voornaam:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtVoornaam" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtVoornaam" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Achternaam:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAchternaam" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtAchternaam" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Adres:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAdres" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtAdres" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Postcode:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtPostcode" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Rijksregisternummer:"></asp:Label>
    <asp:TextBox ID="txtRijksregisternummer" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtRijksregisternummer" ErrorMessage="Verplicht" 
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Telefoonnummer:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtTelefoonnummer" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtTelefoonnummer" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label7" runat="server" Text="GSMNummer:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtGSMNummer" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Geboortedatum:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtGeboortedatum" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtGeboortedatum" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Emailadres:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtEmailadres" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtEmailadres" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Wachtwoord:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtWachtwoord1" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
        ControlToValidate="txtWachtwoord1" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Herhaal wachtwoord:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtwachtwoord2" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
        ControlToValidate="txtwachtwoord2" ErrorMessage="Verplicht" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;&nbsp;
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="txtwachtwoord2" ControlToValidate="txtWachtwoord1" 
        ErrorMessage="Wachtwoorden komen niet overeen" ForeColor="Red"></asp:CompareValidator>
     
    <br />
    <br />
    <asp:Button ID="btnAanmaken" runat="server" Text="Maak account aan!" />
    <br />
    </div>
   

</asp:Content>