<%@ Page Title="Result" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Result.aspx.vb" Inherits="Result" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<body>
<h1>
<asp:Label ID="lblresult" runat="server"></asp:Label>
</h1>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Terug naar homepage" />
</p>
</body>

    

</asp:Content>