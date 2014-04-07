<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaImpacto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>EscalaImpacto</legend>

    <%: Html.HiddenFor(model => model.idEscalaImpacto) %>

    <div class="display-label">Nombre de la escala: <%: Html.DisplayFor(model => model.nbrEscalaImpacto) %></div>
    
    <div class="display-label">Descripcion: <%: Html.DisplayFor(model => model.descripcionEscala) %></div>

    <div class="display-label">Valor minimo: <%: Html.DisplayFor(model => model.valorMinimo) %></div>

    <div class="display-label">Valor maximo: <%: Html.DisplayFor(model => model.valorMaximo) %></div>
        
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Volver a la Lista", "Index") %>
    </p>
<% } %>

</asp:Content>
