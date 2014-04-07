<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.PortafolioProyectos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar Portafolio Proyectos</h2>
<br />
<h3>¿Está seguro que desea eliminar este Portafolio de Proyectos?</h3>
<br />
<fieldset>
    <legend>Portafolio de Proyectos</legend>

    <%: Html.HiddenFor(model => model.idPortafolioProyecto) %>

    <div class="display-label">Nombre del Portafolio</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrPortafolioProyecto) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionPortafolioProyectos) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Volver a la lista", "Index") %>
    </p>
<% } %>

</asp:Content>
