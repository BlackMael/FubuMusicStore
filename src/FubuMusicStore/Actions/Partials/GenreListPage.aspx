<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Partials.GenreListPage" %>

<%@ Import Namespace="FubuMusicStore.Actions.Store" %>
<ul class="genres">
    <% foreach (var genre in Model.Genres)
{ %>
    <li><a href="<%= Urls.UrlFor(new StoreIndexRequest{GenreSlug = genre.Slug}) %>">
        <%= genre.Name %>
    </a></li>
    <%
} %>
</ul>
