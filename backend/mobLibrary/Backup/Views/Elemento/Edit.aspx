<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Elemento>" %>

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
        <legend>Elemento</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idElemento) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.idElemento) %>
            <%: Html.ValidationMessageFor(model => model.idElemento) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.nbrElemento) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.nbrElemento) %>
            <%: Html.ValidationMessageFor(model => model.nbrElemento) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.descripcionElemento) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.descripcionElemento) %>
            <%: Html.ValidationMessageFor(model => model.descripcionElemento) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.idFactor_fk, "Factor") %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("idFactor_fk", String.Empty) %>
            <%: Html.ValidationMessageFor(model => model.idFactor_fk) %>
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
