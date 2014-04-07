<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.PortafolioProyectos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Crear Portafolio de Proyectos</h2>
<br />
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Portafolio de Proyectos</legend>

        <div class="display-label">Nombre del Portafolio</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrPortafolioProyecto) %>
            <%: Html.ValidationMessageFor(model => model.nbrPortafolioProyecto) %>
        </div>

        <div class="display-label">Descripción</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionPortafolioProyectos) %>
            <%: Html.ValidationMessageFor(model => model.descripcionPortafolioProyectos) %>
        </div>
        <br />
        <p>
            <input type="submit" value="Crear" />
        </p>
    </fieldset>
<% } %>
<br />
<div>
    <%: Html.ActionLink("Volver a la lista", "Index") %>
</div>

</asp:Content>
