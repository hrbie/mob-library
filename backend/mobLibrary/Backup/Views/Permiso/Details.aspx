<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Permiso>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Permiso</legend>

    <div class="display-label">idPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idPermiso) %>
    </div>

    <div class="display-label">nbrPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrPermiso) %>
    </div>

    <div class="display-label">descripcionPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionPermiso) %>
    </div>

    <div class="display-label">codigoPermiso</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.codigoPermiso) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
