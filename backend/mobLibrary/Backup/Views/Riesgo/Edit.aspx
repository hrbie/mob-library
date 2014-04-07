<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Riesgo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Riesgo</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idRiesgo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idRiesgo) %>
            <%: Html.ValidationMessageFor(model => model.idRiesgo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrRiesgo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrRiesgo) %>
            <%: Html.ValidationMessageFor(model => model.nbrRiesgo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.puntajeRiesgo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.puntajeRiesgo) %>
            <%: Html.ValidationMessageFor(model => model.puntajeRiesgo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.status) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.status) %>
            <%: Html.ValidationMessageFor(model => model.status) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idEstrategia_fk, "Estrategia") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idEstrategia_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idEstrategia_fk) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idTipoRiesgo_fk, "TipoRiesgo") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idTipoRiesgo_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idTipoRiesgo_fk) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.planRespuesta) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.planRespuesta) %>
            <%: Html.ValidationMessageFor(model => model.planRespuesta) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionRiesgo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionRiesgo) %>
            <%: Html.ValidationMessageFor(model => model.descripcionRiesgo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nivelRiesgo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nivelRiesgo) %>
            <%: Html.ValidationMessageFor(model => model.nivelRiesgo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idProyecto_fk, "Proyecto") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idProyecto_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idProyecto_fk) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idUsuario_fk, "Usuario") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idUsuario_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idUsuario_fk) %>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
