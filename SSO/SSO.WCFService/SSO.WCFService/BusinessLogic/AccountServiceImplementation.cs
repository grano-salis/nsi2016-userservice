using SSO.WCFService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSO.WCFService.DataContracts;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using SSO.WCFService.Exceptions;
using System.Net;
using SSO.WCFService.Helpers;

namespace SSO.WCFService.BusinessLogic
{
    public class AccountServiceImplementation
    {
        private SSOContext _db;

        public AccountServiceImplementation(SSOContext _db)
        {
            this._db = _db;
        }

        public Claim Login(LoginRequest loginModel)
        {
           
            if (loginModel == null)
            {
                throw new SSOBaseException("Login Model required.", HttpStatusCode.BadRequest);
            }

            var user = _db.Users.SingleOrDefault(u => u.Username.Equals(loginModel.Username));
            if (user == null)
            {
                throw new WrongCredentialsException();
            }

            var passwordHashS = CryptoHelper.generateHash(user.Salt, loginModel.Password);
            if (!passwordHashS.Equals(user.Password.Substring(0, 44)))
            {
                throw new WrongCredentialsException();
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
            claim.Valid = "1";
            claim.Created = DateTime.Now;
            claim.User = user;

            _db.Claims.Add(claim);
            _db.SaveChanges();

            return claim;
            
        }

        public ActionResult Register(RegisterRequest registerModel)
        {
            if (registerModel == null)
                    throw new ArgumentNullException();
            //TODO check model validation and throw ModelValidatoinException if neede
            if (!CryptoHelper.checkPassword(registerModel.Password))
            {
                throw new WeakPasswordException();
            }
            if (_db.Users.SingleOrDefault(u => u.Username.Equals(registerModel.Username)) != null)
            {
                // User with same username already exists
                throw new UsernameExistsException(registerModel.Username);
            }
            if (_db.UserInfoes.SingleOrDefault(u => u.Email.Equals(registerModel.Email)) != null)
            {
                // User with same email already exists
                throw new EmailExistsException(registerModel.Email);
            }

            string freshSalt = CryptoHelper.generateSalt();

            // Make new user
            User newUser = new User();
            newUser.Username = registerModel.Username;
            newUser.Salt = freshSalt;
            newUser.Password = CryptoHelper.generateHash(freshSalt, registerModel.Password);

            UserInfo info = new UserInfo();
            info.Email = registerModel.Email;
            info.FirstName = registerModel.FirstName;
            info.LastName = registerModel.LastName;

            info.User = newUser;

            //Save user

            _db.UserInfoes.Add(info);
            _db.SaveChanges();

            return new ActionResult { Message = "Successfully registered." };
        }

        private async Task<ActionResult> asyncFinish(Task t, String m)
        {
            //bla bla nesto neovisno od t
            await t;
            return new ActionResult { Message = m };
        }

    }
}