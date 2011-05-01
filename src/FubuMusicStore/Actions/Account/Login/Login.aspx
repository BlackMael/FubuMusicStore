<%@ Page Language="C#" AutoEventWireup="true" Inherits="FubuMusicStore.Actions.Account.Login.Login" Title="Fieldbook - Login" %>


<%@ Import Namespace="FubuMusicStore.Actions.Account.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Log In</title>
    <script type="text/javascript">
        jQuery(function ($) {
            //$('form').validate();
        });
    </script>
</head>
<body class="bg-color0">
<div class="container_16">
    <!-- new login form -->
   <div class="prefix_5 grid_6 suffix_5">
        <div class="login-box bg-color14">
            <div class="banner"><img src="/content/images/login.png" /></div>
            <div class="form-area">
                <%=this.FormFor(new LoginViewModel(){ReturnUrl = Model.ReturnUrl}) %>
                        <%=this.Edit(x => x.UserName) %>
                        <%=this.Edit(x => x.Password) %>
                        <!-- dirty but its pretty simple -->
                        <% if (Model.LoginFailed)
                           {%>
                        <div class="mod bg-color8 border-red bold">
                            <div class="txt-c color0">
                                <p>Invalid Username or Password</p>
                            </div>
                        </div>
                        <%
                            }%>
            </div>
            <div class="action bg-color15"> 
                 <fieldset>
                    <img src="/content/images/companylogo.png" class="inline-middle "/>
                    <a class="button button-confirm f-right inline-middle"><input type="submit" value="Login" /></a>
                    </fieldset>
                 <%=this.EndForm() %>
            </div>
        </div>
   </div>
   <div class="clear"></div>
</div>

     
</body>
</html>
