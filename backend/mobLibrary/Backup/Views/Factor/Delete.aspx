<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Factor>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Factor</legend>

    <div class="display-label">idFactor</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idFactor) %>
    </div>

    <div class="display-label">nbrFactor</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrFactor) %>
    </div>

    <div class="display-label">tipoFactor</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.tipoFactor) %>
    </div>

    <div class="display-label">descripcionFactor</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionFactor) %>
    </div>

    <div class="display-label">Riesgo</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Riesgo.nbrRiesgo) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
