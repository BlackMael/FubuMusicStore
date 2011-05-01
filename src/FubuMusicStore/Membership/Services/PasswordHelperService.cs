#region

using System;
using System.Text;

#endregion

namespace FubuMusicStore.Membership.Services
{
    public class PasswordHelperService : IPasswordHelperService
    {
        #region IPasswordHelperService Members

        public string CreatePassword(string password)
        {
            return SimpleHash.ComputeHash(password, "MD5", null);
        }

        public bool ComparePassword(string password, string passwordHash)
        {
            return SimpleHash.VerifyHash(password, "MD5", passwordHash);
        }

        private string RandomPassword(int length)
        {
            if (length <= 0)
            {
                length = 8;
            }

            var random = new Random();
            String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var newString = new StringBuilder();
            while (length-- > 0)
            {
                newString.Append(characters[(int)(random.NextDouble() * characters.Length)]);
            }

            return newString.ToString();
        }

        public string RandomPassword(int length, int nonAlphaNumberic)
        {

            var newString = new StringBuilder();
            newString.Append(RandomPassword(length));

            var random = new Random();
            String characters = "~!@#$%^&*()_+";
            while (nonAlphaNumberic-- > 0)
            {
                newString.Append(characters[(int)(random.NextDouble() * characters.Length)]);
            }

            return newString.ToString();
        }


        #endregion
    }
}