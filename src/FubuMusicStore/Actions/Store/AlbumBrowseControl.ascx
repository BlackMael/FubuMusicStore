<%@ Control Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Store.AlbumBrowseControl" %>
<%@ Import Namespace="FubuMusicStore.Actions.Albums" %>
<li>
<a href="<%= Urls.UrlFor(new GetAlbumRequest(){AlbumSlug = Model.Slug}) %>">
    <img alt="<%= Model.Name %>" src="<%= Model.ArtLarge %>" />
    <span><%= Model.Name %></span>
</a>
</li>