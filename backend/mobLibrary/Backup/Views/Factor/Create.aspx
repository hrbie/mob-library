<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Factor>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Factor</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idFactor) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idFactor) %>
            <%: Html.ValidationMessageFor(model => model.idFactor) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrFactor) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrFactor) %>
            <%: Html.ValidationMessageFor(model => model.nbrFactor) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.tipoFactor) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.tipoFactor) %>
            <%: Html.ValidationMessageFor(model => model.tipoFactor) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionFactor) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionFactor) %>
            <%: Html.ValidationMessageFor(model => model.descripcionFactor) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idRiesgo_fk, "Riesgo") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idRiesgo_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idRiesgo_fk) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
