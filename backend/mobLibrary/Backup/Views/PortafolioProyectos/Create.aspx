<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.PortafolioProyectos>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>
<br />
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>PortafolioProyectos</legend>

        <!--<div class="editor-label">
            <%: Html.LabelFor(model => model.idPortafolioProyecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idPortafolioProyecto) %>
            <%: Html.ValidationMessageFor(model => model.idPortafolioProyecto) %>
        </div>-->

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
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>
<br />
<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
