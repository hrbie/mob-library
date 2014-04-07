<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Proyecto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Eliminar Proyecto</h2>

<h3>¿Está seguro que desea eliminar este Proyecto?</h3>
<fieldset>
    <legend>Proyecto</legend>

    <%: Html.HiddenFor(model => model.idProyecto) %>

    <div class="display-label">Nombre del Proyecto</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrProyecto) %>
    </div>

    <div class="display-label">Descripción</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionProyecto) %>
    </div>

    <div class="display-label">Portafolio de Proyecto al que pertenece</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PortafolioProyectos.nbrPortafolioProyecto) %>
    </div>

    <div class="display-label">Escala Puntaje</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EscalaPuntaje.nbrEscala) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Eliminar" /> |
        <%: Html.ActionLink("Volver a la lista", "Index") %>
    </p>
<% } %>

</asp:Content>
