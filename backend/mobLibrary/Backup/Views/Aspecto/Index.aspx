<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Aspecto>>" %>

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
            idAspecto
        </th>
        <th>
            nbrAspecto
        </th>
        <th>
            probabilidadAspecto
        </th>
        <th>
            impactoAspecto
        </th>
        <th>
            puntajeAspecto
        </th>
        <th>
            descripcionAspecto
        </th>
        <th>
            Elemento
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.idAspecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrAspecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.probabilidadAspecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.impactoAspecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.puntajeAspecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionAspecto) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Elemento.nbrElemento) %>
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
