<%@ Page Inherits="FubuMusicStore.Actions.Home.HomeView" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Shared/Home.Master" %>

<asp:Content ContentPlaceHolderID="HomeContent" runat="server">
    <% foreach (var track in Model.Tracks)
       {
    %>
    <div class="grid_2">
        <div class="mod box bg-color3">
            <div class="bd">
                <img src="<%= track.Album.ArtLarge %>" alt="<%= track.Name %>" />
            </div>
        </div>
    </div>
    <div class="grid_10">
        <div class="mod box bg-color3">
            <div class="bd content bg-color4">
                <div class="white">
                </div>
                <div class="artist bg-color5">
                    <h2 class="txt-hl">
                        <%=track.Album.Artist.Name %></h2>
                </div>
                <div class="title">
                    <h3>
                        <%= track.Name %></h3>
                </div>
            </div>
        </div>
    </div>
    <div class="clear"> </div>
    <%
} %>
</asp:Content>
