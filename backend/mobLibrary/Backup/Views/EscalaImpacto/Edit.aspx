<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaImpacto>" %>

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
        <legend>Escala de Impacto</legend>

        <%: Html.HiddenFor(model => model.idEscalaImpacto) %>

        <div class="display-label">Introduzca el nombre de la escala</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrEscalaImpacto) %>
            <%: Html.ValidationMessageFor(model => model.nbrEscalaImpacto) %>
        </div>

        <div class="display-label">Introduzca la descripcion</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionEscala) %>
            <%: Html.ValidationMessageFor(model => model.descripcionEscala) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.valorMinimo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.valorMinimo) %>
            <%: Html.ValidationMessageFor(model => model.valorMinimo) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.valorMaximo) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.valorMaximo) %>
            <%: Html.ValidationMessageFor(model => model.valorMaximo) %>
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
