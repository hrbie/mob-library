<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProyectoFinalDisenio.Models.Riesgo>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    IndexRiesgos
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>IndexRiesgos</h2>

<p>
    <%: Html.ActionLink("Crear un nuevo Riesgo", "CreateRiesgo", new { proyecto = TempData["idProyecto"] })%>
</p>
<table>
    <%if (Model.Count() != 0)
      { %>
    <tr>
        <!--<th>
            idRiesgo
        </th>-->
        <th>
            Nombre del Riesgo
        </th>
        <!--<th>
            Puntaje del Riesgo
        </th>
        <th>
            Status del Riesgo
        </th>
        <th>
            Estrategia
        </th>
        <th>
            Tipo de Riesgo
        </th>
        <th>
            Plan de Respuesta
        </th>-->
        <th>
            Descripcion del Riesgo
        </th>
        <!--<th>
            Nivel del Riesgo
        </th>-->
        <th>
            Proyecto al que Pertenece
        </th>
        <!--<th>
            Usuario Responsable
        </th>-->
        <th></th>
    </tr>

<% foreach (var item in Model)
   { %>
    <tr>
        <!--<td>
            <%: Html.DisplayFor(modelItem => item.idRiesgo) %>
        </td>-->
        <td>
            <%: Html.DisplayFor(modelItem => item.nbrRiesgo) %>
        </td>
        <!--<td>
            <%: Html.DisplayFor(modelItem => item.puntajeRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.status) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Estrategia.nbrEstrategia) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.TipoRiesgo.nbrTipoRiesgo) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.planRespuesta) %>
        </td>-->
        <td>
            <%: Html.DisplayFor(modelItem => item.descripcionRiesgo) %>
        </td>
        <!--<td>
            <%: Html.DisplayFor(modelItem => item.nivelRiesgo) %>
        </td>-->
        <td>
            <%: Html.DisplayFor(modelItem => item.Proyecto.nbrProyecto) %>
        </td>
        <!--<td>
            <%: Html.DisplayFor(modelItem => item.Usuario.nbrUsuario) %>
        </td>-->
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id = item.idRiesgo })%> |
            <!--<%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) %> |-->
            <%: Html.ActionLink("Delete", "Delete", new { id = item.idRiesgo }) %>
            <%: Html.ActionLink("Configuración", "IndexFactores", new { id = item.idRiesgo }) %> |
            <%: Html.ActionLink("Calificación", "IndexFactores", new { id = item.idRiesgo }) %> |
            <%: Html.ActionLink("Seguimiento y Monitoreo", "IndexFactores", new { id = item.idRiesgo }) %> |
            <%: Html.ActionLink("Ver Factores", "IndexFactores", new { id = item.idRiesgo }) %>
         </td>
    </tr>
<% } %>
<% } 
   else
   {%>
   <tr>
        <th>
            <%: ViewBag.mensajeRiesgo %>
        </th>
    </tr>
 <% } %>
    

</table>
<div>
    <%: Html.ActionLink("Volver a la lista", "Index","Proyecto") %>
</div>

</asp:Content>
