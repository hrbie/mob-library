<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Aspecto>" %>

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
        <legend>Aspecto</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idAspecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idAspecto) %>
            <%: Html.ValidationMessageFor(model => model.idAspecto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrAspecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrAspecto) %>
            <%: Html.ValidationMessageFor(model => model.nbrAspecto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.probabilidadAspecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.probabilidadAspecto) %>
            <%: Html.ValidationMessageFor(model => model.probabilidadAspecto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.impactoAspecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.impactoAspecto) %>
            <%: Html.ValidationMessageFor(model => model.impactoAspecto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.puntajeAspecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.puntajeAspecto) %>
            <%: Html.ValidationMessageFor(model => model.puntajeAspecto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionAspecto) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionAspecto) %>
            <%: Html.ValidationMessageFor(model => model.descripcionAspecto) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idElemento_fk, "Elemento") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idElemento_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idElemento_fk) %>
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
