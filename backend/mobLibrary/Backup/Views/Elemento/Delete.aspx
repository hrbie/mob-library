﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Elemento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Elemento</legend>

    <div class="display-label">idElemento</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idElemento) %>
    </div>

    <div class="display-label">nbrElemento</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrElemento) %>
    </div>

    <div class="display-label">descripcionElemento</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionElemento) %>
    </div>

    <div class="display-label">Factor</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Factor.nbrFactor) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
