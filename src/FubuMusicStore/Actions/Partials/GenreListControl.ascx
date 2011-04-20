<%@ Control Language="C#" Inherits="FubuMusicStore.Actions.Partials.GenreListControl" %>

<ul>
<% foreach (var genre in Model.Genres)
{ %>
  
  <li><%= genre.Name %></li>
  <%
} %>
</ul>
