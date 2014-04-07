<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Usuario>" %>

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
        <legend>Usuario</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idUsuario) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idUsuario) %>
            <%: Html.ValidationMessageFor(model => model.idUsuario) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrUsuario) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrUsuario) %>
            <%: Html.ValidationMessageFor(model => model.nbrUsuario) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.apellido1) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.apellido1) %>
            <%: Html.ValidationMessageFor(model => model.apellido1) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.apellido2) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.apellido2) %>
            <%: Html.ValidationMessageFor(model => model.apellido2) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.email) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.email) %>
            <%: Html.ValidationMessageFor(model => model.email) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.telefono) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.telefono) %>
            <%: Html.ValidationMessageFor(model => model.telefono) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idRol_fk, "Rol") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idRol_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idRol_fk) %>
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
