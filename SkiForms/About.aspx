<%@ Page Title="O aplikacji" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SkiForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    

    <p>Aplikacja zapewnia warunki pogodowe dla surferów oraz narciarzy. Wyniki wyświetlane w textboxach odnoszą się do przykładowo wybranych zmiennych. Tak naprawdę w odpowiedzi od api otrzymujemy bardzo rozbudowaną prognozę pogodową, rozbitą na godziny, posiadającą wiele parametrów.
        Dla zobrazowania całych prognoz, w plikach projektu zawarte są dwa pliki xml: skii oraz marine pokazujące odpowiedź serwera.
    </p>

</asp:Content>
