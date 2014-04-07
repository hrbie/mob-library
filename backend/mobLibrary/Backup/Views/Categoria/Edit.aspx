<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Categoria>" %>

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
        <legend>Categoria</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idCategoria) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idCategoria) %>
            <%: Html.ValidationMessageFor(model => model.idCategoria) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionCategoria) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionCategoria) %>
            <%: Html.ValidationMessageFor(model => model.descripcionCategoria) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nivelCategoria) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nivelCategoria) %>
            <%: Html.ValidationMessageFor(model => model.nivelCategoria) %>
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

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idEscala_fk, "EscalaPuntaje") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idEscala_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idEscala_fk) %>
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
