<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Proyecto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CreateProyecto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Crear Proyecto</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Proyecto</legend>
        
        <!--<div class="editor-label">
            <%: Html.LabelFor(model => model.idProyecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idProyecto) %>
            <%: Html.ValidationMessageFor(model => model.idProyecto) %>
        </div>-->

        <div class="display-label">Nombre del Proyecto</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrProyecto) %>
            <%: Html.ValidationMessageFor(model => model.nbrProyecto) %>
        </div>

        <div class="display-label">Descripción</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionProyecto) %>
            <%: Html.ValidationMessageFor(model => model.descripcionProyecto) %>
        </div>

        <div class="display-label">Portafolio de Proyecto al que pertenece</div>
        <div class="editor-field">
            <%: Html.DropDownList("idPortafolioProyecto_fk") %>
            <%: Html.ValidationMessageFor(model => model.idPortafolioProyecto_fk) %>
        </div>

        <div class="display-label">Escala Puntaje</div>
        <div class="editor-field">
            <%: Html.DropDownList("idEscalaPuntaje") %>
            <%: Html.ValidationMessageFor(model => model.idEscalaPuntaje) %>
        </div>

        <p>
            <input type="submit" value="Crear" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Volver a la lista", "IndexProyectos", new { portafolio = ViewBag.portafolio})%>
</div>

</asp:Content>
