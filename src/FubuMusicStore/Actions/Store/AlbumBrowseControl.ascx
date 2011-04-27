<%@ Control Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Store.AlbumBrowseControl" %>
<li>
<a href="">
    <img alt="<%= Model.Name %>" src="<%= Model.AlbumArtUrl %>" />
    <span><%= Model.Name %></span>
</a>
</li>