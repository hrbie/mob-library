<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Factor>>" %>

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
            idFactor
        </th>
        <th>
            nbrFactor
        </th>
        <th>
            tipoFactor
        </th>
        <th>
            descripcionFactor
        </th>
        <th>
            Riesgo
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.idFactor) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrFactor) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.tipoFactor) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionFactor) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Riesgo.nbrRiesgo) %>
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
