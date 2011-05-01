#region

using System;
using FubuFastPack.Domain;
using FubuFastPack.Persistence;
using FubuLocalization;
using FubuMusicStore.Membership.Security;
using FubuValidation;

#endregion

namespace FubuMusicStore.Membership.Services
{
    public class UserService<USER> : IUserService<USER> where USER : DomainEntity, IUser
    {
        private readonly IRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IValidator _validator;

        public UserService(IRepository userRepository, 
            IPasswordService passwordService,
            IValidator validator)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _validator = validator;
        }

        public Notification Update(USER user)
        {
           return ValidateAndUpdate(user);
        }

        private Notification ValidateAndUpdate(USER entity)
        {
            var notification = _validator.Validate(entity);

            var user = Retrieve(entity.Id);

            if(UserNameChanged(entity, user))
            {
                //make sure user is unique
                USER foundUser = _userRepository.FindBy<USER>(x => x.UserName == entity.UserName);
                if (foundUser != null)
                {
                    if (foundUser.Id != entity.Id)
                        notification.RegisterMessage(StringToken.FromKeyString("UserName", "User name already exists!"));
                }
            }

            if(EmailChanged(entity, user))
            {
                //make sure email is unique
                USER foundUser = _userRepository.FindBy<USER>(x => x.Email == entity.Email);
                if (foundUser != null)
                {
                    if (foundUser.Id != entity.Id)
                        notification.RegisterMessage(StringToken.FromKeyString("Email", "Email already exists!"));
                }
            }

            if (notification.IsValid())
            {
                _userRepository.Save(entity);
            }
            else
            {
                _userRepository.RejectChanges(entity);
            }

            return notification;
        }

        private bool EmailChanged(USER entity, USER user)
        {
            return entity.Email != user.Email;
        }

        private bool UserNameChanged(USER entity, USER user)
        {
            return entity.UserName != user.UserName;
        }

        public void Delete(USER user)
        {
            _userRepository.Delete(user);
        }

        public USER Retrieve(object id)
        {
            return _userRepository.Find<USER>((Guid) id);
        }

        public USER GetUserByLogin(string name)
        {
            return _userRepository.FindBy<USER>(x => x.UserName == name);
        }

        public USER GetUserByEmail(string email)
        {
            return _userRepository.FindBy<USER>(x => x.Email == email);
        }


        public Notification Create(USER user, string password)
        {
            var notification = new Notification();

            if (user == null)
            {
                notification.RegisterMessage(StringToken.FromKeyString("User", "User cannot be null"));
                return notification;
            }

            try
            {
                user.ResetPassword(_passwordService, password);
            }
            catch (Exception ex)
            {
                notification.RegisterMessage(StringToken.FromKeyString("Password", ex.Message));
                return notification;
            }

            return ValidateAndSave(user);
        }

        private Notification ValidateAndSave(USER user)
        {
            var notification = _validator.Validate(user);
            if (notification.IsValid())
            {
                //make sure user is unique
                if(_userRepository.FindBy<USER>(x => x.UserName == user.UserName) != null)
                {
                    notification.RegisterMessage(StringToken.FromKeyString("UserName", "User name already exists!"));
                    return notification;
                }

                //make sure email is unique
                if (_userRepository.FindBy<USER>(x => x.Email == user.Email) != null)
                {
                    notification.RegisterMessage(StringToken.FromKeyString("Email", "Email already exists!"));
                    return notification;
                }
                _userRepository.Save(user);
            }
            return notification;
        }

    }
}