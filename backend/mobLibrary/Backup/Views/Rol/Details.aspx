<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<ProyectoFinalDisenio.Models.Rol>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details</h2>

<fieldset>
    <legend>Rol</legend>

    <div class="display-label">idRol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.idRol) %>
    </div>

    <div class="display-label">nbrRol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.nbrRol) %>
    </div>

    <div class="display-label">descripcionRol</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.descripcionRol) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
    <%: Html.ActionLink("Back to List", "Index") %>
</p>

</asp:Content>
