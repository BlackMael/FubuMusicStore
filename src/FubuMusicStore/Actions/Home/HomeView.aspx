<%@ Page Inherits="FubuMusicStore.Actions.Home.HomeView" Language="C#" AutoEventWireup="true"
    MasterPageFile="~/Shared/Home.Master" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $('.album-covers .album').first().show();
            $('.track-names-home li:first').addClass('select');

            $('.track-names-home li').click(function () {
                $('.album-covers .album:visible').hide();

                $('.track-names-home .select').removeClass('select');

                $(this).addClass('select');

                var art = $('.album-covers .album')[$(this).index()];
                $(art).show();
            });


        });

    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="HomeContent" runat="server">
<div class="stripe"></div>
<div class="grid_12">
    <div class="mod home-box bg-color3">
        <div class="bd content bg-color4">
            <div class="grid_8 alpha omega" >
                <div class="album-covers">
                    <% foreach (var track in Model.Tracks)
                       {
                    %>
                    
                    <div class="prefix_2 album hide suff_2">
                        <img src="<%= track.Album.ArtLarge %>" alt="<%= track.Name %>" width="290px" height="288px"/>
                    </div>
                    
                    <%
       } %>
                </div>
            </div>
            <div class="grid_4 omega alpha">
                <ul class="track-names-home">
                    <% foreach (var track in Model.Tracks)
                       {
                    %>
                    <li class="track-name">
                        <%= track.Name %></li>
                    <%
       } %>
                </ul>
            </div>
            <div class="clear">
        </div>
    </div>
    </div>
    
    </div>
</asp:Content>
