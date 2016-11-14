using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Account : IAccount
    {
        public bool ChangePassword()
        {
            return true;
            throw new NotImplementedException();
        }

        public bool Login(DataContracts.LoginRequest loginModel)
        {
            throw new NotImplementedException();
        }

        public bool Register(DataContracts.RegisterRequest registerModel)
        {
            if (registerModel == null)
            {
                throw new ArgumentNullException("Register Model");
            }
            //TODO check model validation and throw ModelValidatoinException if neede
            if (!checkPassword(registerModel.Password))
            {
                throw new Exceptions.WeakPasswordException();
            }

            SSOContext _db = new SSOContext();
            if (_db.CV_USER.SingleOrDefault(u => u.USERNAME.Equals(registerModel.Username)) != null)
            {
                // User with same username already exists
                throw new Exceptions.UsernameExistsException(registerModel.Username);
            }
            if (_db.CV_USER_INFO.SingleOrDefault(u => u.EMAIL.Equals(registerModel.Email)) != null)
            {
                // User with same email already exists
                throw new Exceptions.EmailExistsException(registerModel.Email);
            }

            // Make salt
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            // Salt should be long at least as hash algorith output. Sha256 output iz 32 bytes long.
            byte[] saltB = new byte[32];
            rng.GetBytes(saltB);
            var saltS = Convert.ToBase64String(saltB);

            // Make hash with salt
            byte[] passwordB = System.Text.Encoding.UTF8.GetBytes(registerModel.Password);
            var hashAlgorithm = new System.Security.Cryptography.SHA256Cng();
            byte[] passwordHashB = hashAlgorithm.ComputeHash(passwordB.Concat(saltB).ToArray());
            var passwordHashS = Convert.ToBase64String(passwordHashB);

            // Make new user
            CV_USER newUser = new CV_USER();
            newUser.USERNAME = registerModel.Username;
            newUser.SALT = saltS;
            newUser.PASSWORD = passwordHashS;

            CV_USER_INFO info = new CV_USER_INFO();
            info.EMAIL = registerModel.Email;
            info.FIRST_NAME = registerModel.FirstName;
            info.LAST_NAME = registerModel.LastName;

            newUser.CV_USER_INFO.Add(info);

            //Save user
            try
            {
                _db.CV_USER.Add(newUser);
            }
            catch (Exception e)
            {
                throw new Exceptions.SSOBaseException("add new user to db", e);
            }

            return true;
        }

        private bool checkPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            Boolean haveLowercase = false;
            Boolean haveUppercase = false;
            Boolean haveDigit = false;

            foreach (char letter in password)
            {
                if (Char.IsLower(letter))
                {
                    haveLowercase = true;
                }
                else if (Char.IsUpper(letter))
                {
                    haveUppercase = true;
                }
                else if (Char.IsDigit(letter))
                {
                    haveDigit = true;
                }

            }

            // Password is strong enought if it have at least one lowecare, uppercase letter 
            return haveLowercase && haveUppercase;
        }
    }
}