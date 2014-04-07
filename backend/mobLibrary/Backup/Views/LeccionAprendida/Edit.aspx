<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.LeccionAprendida>" %>

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
        <legend>LeccionAprendida</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idLeccionAprendida) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idLeccionAprendida) %>
            <%: Html.ValidationMessageFor(model => model.idLeccionAprendida) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrLeccionAprendida) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrLeccionAprendida) %>
            <%: Html.ValidationMessageFor(model => model.nbrLeccionAprendida) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionLeccionAprendida) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionLeccionAprendida) %>
            <%: Html.ValidationMessageFor(model => model.descripcionLeccionAprendida) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.fchCreacion) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.fchCreacion) %>
            <%: Html.ValidationMessageFor(model => model.fchCreacion) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idProyecto_fk, "Proyecto") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idProyecto_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idProyecto_fk) %>
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
