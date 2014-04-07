<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.EscalaProbabilidad>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Escala de Probabilidad</h2>

<p>
    <%: Html.ActionLink("Crear Nueva Escala de Probabilidad", "Create") %>
</p>
<table>
    <%if (Model.Count() != 0)
    { %>
    <tr>
        <th>
            Nombre de la Escala de Probabilidad
        </th>
        <th>
            Descripcion
        </th>
        <th>
            Valor Minimo
        </th>
        <th>
            Valor Maximo
        </th>
        <th></th>
    </tr>

    <% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrEscalaProbabilidad) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionEscala) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.valorMinimo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.valorMaximo) %>
        </td>
        <td>
            <%: Html.ActionLink("Modificar", "Edit", new { id = item.idEscalaProbabilidad }) %> |
            <!--<%: Html.ActionLink("Details", "Details", new { id = item.idEscalaProbabilidad })%> |-->
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.idEscalaProbabilidad })%>   
        </td>
    </tr>
<%  } %>
<%} else { %>
  ||<tr>
        <th>
            <%: ViewBag.Message %>
        </th>
    </tr>
 <% } %>
</table>
<div>
    <%: Html.ActionLink("Volver a la lista", "Index","EscalaPuntaje")%>
</div>

</asp:Content>
