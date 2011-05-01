<%@ Page AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Store.StoreIndexView" Language="C#" MasterPageFile="~/Shared/Store.Master" %>
<%@ Import Namespace="FubuMusicStore.Actions.Partials" %>
<%@ Import Namespace="FubuMusicStore.Actions.Store" %>

<asp:Content ContentPlaceHolderID="LeftPane" runat="server">
		<% this.PartialFor(new GenreListRequest()); %>
</asp:Content>

<asp:Content ContentPlaceHolderID="RightPane" runat="server">
		
			<%= this.PartialForEach(x => x.Albums).Using<AlbumBrowseControl>() %>
		
</asp:Content>
