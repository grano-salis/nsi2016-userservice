﻿using SSO.WCFService.DataContracts;
using SSO.WCFService.Exceptions;
using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using System.Web;

namespace SSO.WCFService.BusinessLogic
{

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Account : IAccount
    {
        private AccountService _mngr { get; set; }
        private SSOContext _db { get; set; }

        public Account()
        {
            _db = new SSOContext();
            _mngr = new AccountService(_db);

        }

        public ActionResult ChangePassword()
        {
            WebOperationContext ctx = WebOperationContext.Current;
            try
            {
                _mngr.ChangePassword();
                return new ActionResult { Message = "Password is successfully changed." };
            }
            catch (WebFaultException<MyFault> e)
            {
                ctx.OutgoingResponse.StatusCode = e.StatusCode;
                return new ActionResult { Message = e.Detail.Details };
            }
        }

        public ActionResult Login(LoginRequest loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentNullException("Login Model required.");
            }

            var user = _db.Users.SingleOrDefault(u => u.Username.Equals(loginModel.Username));
            if (user == null)
            {
                throw new Exceptions.WeakPasswordException();
            }

            byte[] saltB = Convert.FromBase64String(user.Salt);

            byte[] passwordB = System.Text.Encoding.UTF8.GetBytes(loginModel.Password);
            var hashAlgorithm = new System.Security.Cryptography.SHA256Cng();
            byte[] passwordHashB = hashAlgorithm.ComputeHash(passwordB.Concat(saltB).ToArray());
            var passwordHashS = Convert.ToBase64String(passwordHashB);

            // TODO change database password field to nvarchar
            // 44 is length of
            if (!passwordHashS.Equals(user.Password.Substring(0, 44)))
            {
                throw new Exceptions.WrongCredentialsException();
            }

            // Succeful login
            // Make token
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] tokenB = new byte[40];
            rng.GetBytes(tokenB);

            //Convert to hex
            String tokenHex = BitConverter.ToString(tokenB).Replace("-", String.Empty);
            Claim claim = new Claim();
            claim.Token = tokenHex;
            //claim.VALID = '1';
            claim.Created = DateTime.Now;
            claim.User = user;

            try
            {
                _db.Claims.Add(claim);
                _db.SaveChanges();
                HttpContext.Current.Response.Cookies.Add(new HttpCookie("token", tokenHex));
                return new ActionResult
                {
                    Message = "Successful login."
                };
            }
            catch (Exception e)
            {
                throw new Exceptions.SSOBaseException("Add claim error", e);
            }
        }

        public Task<ActionResult> Register(DataContracts.RegisterRequest registerModel)
        {
            if (registerModel == null)
            {
                throw new ArgumentNullException("Register Model required.");
            }
            //TODO check model validation and throw ModelValidatoinException if neede
            if (!checkPassword(registerModel.Password))
            {
                throw new Exceptions.WeakPasswordException();
            }

            try
            {
                if (_db.Users.SingleOrDefault(u => u.Username.Equals(registerModel.Username)) != null)
                {
                    // User with same username already exists
                    throw new Exceptions.UsernameExistsException(registerModel.Username);
                }
                if (_db.UserInfoes.SingleOrDefault(u => u.Email.Equals(registerModel.Email)) != null)
                {
                    // User with same email already exists
                    throw new Exceptions.EmailExistsException(registerModel.Email);
                }

            }
            catch (Exceptions.UsernameExistsException)
            {
                throw;
            }
            catch (Exceptions.EmailExistsException)
            {
                throw;
            }
            catch (Exception e)
            {

                throw new Exceptions.SSOBaseException("bla", e);
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
            User newUser = new User();
            newUser.Username = registerModel.Username;
            newUser.Salt = saltS;
            newUser.Password = passwordHashS;

            UserInfo info = new UserInfo();
            info.Email = registerModel.Email;
            info.FirstName = registerModel.FirstName;
            info.LastName = registerModel.LastName;

            info.User = newUser;

            //Save user
            try
            {

                _db.UserInfoes.Add(info);
                Task<int> a = _db.SaveChangesAsync();
                a.Wait();
            }
            catch (Exception e)
            {
                throw new Exceptions.SSOBaseException("add new user to db", e);
            }


            return Task<bool>.FromResult(new ActionResult
            {
                Message = "Successful register."
            });
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