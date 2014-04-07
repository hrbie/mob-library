<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Permiso>" %>

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
        <legend>Permiso</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idPermiso) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idPermiso) %>
            <%: Html.ValidationMessageFor(model => model.idPermiso) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrPermiso) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrPermiso) %>
            <%: Html.ValidationMessageFor(model => model.nbrPermiso) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionPermiso) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionPermiso) %>
            <%: Html.ValidationMessageFor(model => model.descripcionPermiso) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.codigoPermiso) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.codigoPermiso) %>
            <%: Html.ValidationMessageFor(model => model.codigoPermiso) %>
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
