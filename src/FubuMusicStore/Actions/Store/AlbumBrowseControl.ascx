<%@ Control Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Store.AlbumBrowseControl" %>
<%@ Import Namespace="FubuMusicStore.Actions.Albums" %>
<span class="album-browse">
<a href="<%= Urls.UrlFor(new GetAlbumRequest(){AlbumSlug = Model.Slug}) %>">
    <img alt="<%= Model.Name %>" src="<%= Model.ArtMedium ?? "/content/images/placeholder.png" %>" height="64px" width="64px" />
    <div class="name"><%= Model.Name %></div>
</a>
</span>