<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Account.Login.Login"
    Title="Login" MasterPageFile="~/Shared/Site.Master" %>

<%@ Import Namespace="FubuMusicStore.Actions.Account.Login" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Log In</title>
    <script type="text/javascript">
        jQuery(function ($) {
            //$('form').validate();
        });
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <!-- new login form -->
    <div class="prefix_3 grid_6 suffix_3">
        <div class="mod box bg-color2">
            <div class="inner">
                <div class="hd bg-color2">
                    <h2 class="color0">
                        Sign in to your Account</h2>
                </div>
                <div class="bd content bg-color0">
                    <div class="form-area">
                        <%=this.FormFor(new LoginViewModel(){ReturnUrl = Model.ReturnUrl}) %>
                        <%=this.Edit(x => x.UserName) %>
                        <%=this.Edit(x => x.Password) %>
                        <!-- dirty but its pretty simple -->
                        <% if (Model.LoginFailed)
                           {%>
                        <div class="mod bg-color8 border-red bold">
                            <div class="txt-c color0">
                                <p>
                                    Invalid Username or Password</p>
                            </div>
                        </div>
                        <%
                           }%>
                    </div>
                    <div class="action bg-color15">
                        <fieldset>
                            <img src="/content/images/companylogo.png" class="inline-middle " />
                            <a class="button button-confirm f-right inline-middle">
                                <input type="submit" value="Login" /></a>
                        </fieldset>
                        <%=this.EndForm() %>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
