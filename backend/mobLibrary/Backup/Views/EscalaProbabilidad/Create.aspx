<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.EscalaProbabilidad>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Crear Nueva Escala de Probabilidad</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Escala de Probabilidad</legend>

        <!--<div class="editor-label">
            <%: Html.LabelFor(model => model.idEscalaProbabilidad) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idEscalaProbabilidad) %>
            <%: Html.ValidationMessageFor(model => model.idEscalaProbabilidad) %>
        </div>-->

        <div class="display-label">Nombre de la Escala Probabilidad</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrEscalaProbabilidad) %>
            <%: Html.ValidationMessageFor(model => model.nbrEscalaProbabilidad) %>
        </div>

        <div class="display-label">Descripcion</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionEscala) %>
            <%: Html.ValidationMessageFor(model => model.descripcionEscala) %>
        </div>

        <div class="display-label">Valor Minimo</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.valorMinimo) %>
            <%: Html.ValidationMessageFor(model => model.valorMinimo) %>
        </div>

        <div class="display-label">Valor Maximo</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.valorMaximo) %>
            <%: Html.ValidationMessageFor(model => model.valorMaximo) %>
        </div>

        <p>
            <input type="submit" value="Crear" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Volver a la lista", "Index") %>
</div>

</asp:Content>
