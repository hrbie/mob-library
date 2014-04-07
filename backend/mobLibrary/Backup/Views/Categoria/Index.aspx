<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Categoria>>" %>

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
            descripcionCategoria
        </th>
        <th>
            nivelCategoria
        </th>
        <th>
            valorMinimo
        </th>
        <th>
            valorMaximo
        </th>
        <th>
            EscalaPuntaje
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <!--<td>
            <%: Html.DisplayFor(modelItem => item.idCategoria) %>
        </td>-->
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionCategoria) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.nivelCategoria) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.valorMinimo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.valorMaximo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EscalaPuntaje.nbrEscala) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id = item.idCategoria }) %> |
            <!--<%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) %> |-->
            <%: Html.ActionLink("Delete", "Delete", new { id = item.idCategoria }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
