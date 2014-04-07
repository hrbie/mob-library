<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.LeccionAprendida>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            idLeccionAprendida
        </th>
        <th>
            nbrLeccionAprendida
        </th>
        <th>
            descripcionLeccionAprendida
        </th>
        <th>
            fchCreacion
        </th>
        <th>
            Proyecto
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.idLeccionAprendida) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrLeccionAprendida) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionLeccionAprendida) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.fchCreacion) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Proyecto.nbrProyecto) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
