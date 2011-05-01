using System;
using System.Web;
using FubuFastPack;
using FubuLocalization;
using FubuMusicStore.Actions.Account.Logoff;
using FubuMusicStore.Domain;
using FubuMusicStore.Membership.Services;
using FubuMVC.Core.Security;
using FubuMVC.Core.View;
using FubuValidation;

namespace FubuMusicStore.Actions.Account.ChangePassword
{
    public class GetChangePasswordAction
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserService<User> _userService;
        private readonly ISecurityContext _securityContext;

        public GetChangePasswordAction(IPasswordService passwordService, 
            IUserService<User> userService,
            ISecurityContext securityContext)
        {
            _passwordService = passwordService;
            _userService = userService;
            _securityContext = securityContext;
        }

        public AjaxContinuation Post(ChangePasswordModel model)
        {
          
            var user = _userService.GetUserByLogin(model.UserName);

            var notification = new Notification();

            if (user == null)
            
                notification.RegisterMessage(StringToken.FromKeyString("User Name", "User name does not exist!"));

            else
            {
                try
                {
                    user.ChangePassword(_passwordService, model.OldPassword, model.Password);
                }
                catch (Exception ex)
                {
                    notification.RegisterMessage(StringToken.FromKeyString("Password", ex.Message));
                }
            }

            return
                notification.IsValid()
                    ? AjaxContinuation.ForNavigateWholePage("/account/logoff")
                    : AjaxContinuation.ForError(notification);
        }


        public ChangePasswordModel Get(ChangePasswordRequest request)
        {
            if(!_securityContext.IsAuthenticated())
                throw new HttpException(403, "Must be signed in to change password");


            return new ChangePasswordModel() {UserName = _securityContext.CurrentUser.Identity.Name};
        }    
        
    }

    public class ChangePasswordModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordRequest
    {
    }

    public class ChangePassword : FubuPage<ChangePasswordModel> { }
}