<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.PortafolioProyectos>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Portafolio de Proyectos</h2>
<br />
<p>
    <%: Html.ActionLink("Crear Nuevo Portafolio de Proyectos", "Create") %>
</p>
<br />
<table>
    <% if (Model.Count() != 0)
       { %>
    <tr>
        <th>
            Nombre del Portafolio
        </th>
        <th>
            Descripción
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model)
   { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrPortafolioProyecto)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionPortafolioProyectos)%>
        </td>
        <td>
            <%: Html.ActionLink("Modificar", "Edit", new { id = item.idPortafolioProyecto })%> |
       <!-- <%: Html.ActionLink("Detalles", "Details", new { id=item.idPortafolioProyecto }) %> |-->
            <%: Html.ActionLink("Eliminar", "Delete", new { id = item.idPortafolioProyecto })%> |
            <%: Html.ActionLink("Ver Proyectos", "IndexProyectos", "Proyecto", new { portafolio = item.idPortafolioProyecto }, null)%>
       </td>
    </tr>
<% } %>
<% }
       else
       { %>

    <tr>
        <th>
            <%: ViewBag.mensaje %>
        </th>
    </tr>
 <% } %>
</table>

</asp:Content>
