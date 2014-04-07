<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Factor>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

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
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
