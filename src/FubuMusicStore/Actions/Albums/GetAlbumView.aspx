<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Albums.GetAlbumView" MasterPageFile="~/Shared/Home.master" %>

<asp:Content ID="Main" ContentPlaceHolderID="HomeContent" runat="server">
    <div class="grid_12">
        <div class="mod box bg-color3">
            <div class="bd content bg-color4">
                <div class="white">
                </div>
                <div class="art">
                    <img src="<%= Model.Album.ArtLarge ?? "/content/images/placeholder.png" %>" height="174" width="174" /></div>
                <div class="upper">
                    <div class="artist bg-color5">
                        <h2 class="txt-hl">
                            <%= Model.Album.Artist.Name %></h2>
                    </div>
                    <div class="title bold txt-hl">
                        <h3>
                            <%= Model.Album.Name %></h3>
                    </div>
                </div>
                <div class="info bold txt-hl">
                    <ul>
                        <li>Genre:
                            <%= Model.Album.Genre.Name %></li>
                        <li>Released:</li>
                        <li>CopyRight Crapz</li>
                        <li>CopyRight Crapz</li>
                    </ul>
                </div>
                <div id="tracks">
                    <table class="track-table">
                        <thead>
                            <tr>
                                <td></td>
                                <td>Name:</td>
                                <td>Time:</td>
                                <td>Price:</td>
                            </tr>
                        </thead>
                        <tbody>
                            <% for (int i = 0; i < Model.Album.Tracks.Count; i++)
                       {
                           var track = Model.Album.Tracks[i];
                            %>
                            <tr class="<%= i%2 == 0 ? "even" : "odd" %>">
                                <td>
                                    <%= i + 1%>
                                </td>
                                <td><%= track.Name%></td>
                                <td><%= TimeSpan.FromMilliseconds(track.Milliseconds).Minutes%>:<%= TimeSpan.FromMilliseconds(track.Milliseconds).Seconds %></td>
                                <td>Buy It Meow!</td>
                            </tr>
                            <% } %>
                        </tbody>
                    </table>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
