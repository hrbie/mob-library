<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.EscalaImpacto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<h2>Index</h2>

<p>
    <%: Html.ActionLink("Crear Nueva Escala de Impacto", "Create") %>
</p>

<table>
<%if (Model.Count() != 0)
      { %>
    <tr>
        <th>
            Nombre de la Escala de Impacto
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
            <%: Html.DisplayFor(modelItem => item.nbrEscalaImpacto) %>
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
            <%: Html.ActionLink("Modificar", "Edit", new { id = item.idEscalaImpacto }) %> |
            <!--<%: Html.ActionLink("Details", "Details", new { id = item.idEscalaImpacto })%> |-->
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.idEscalaImpacto })%>
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
