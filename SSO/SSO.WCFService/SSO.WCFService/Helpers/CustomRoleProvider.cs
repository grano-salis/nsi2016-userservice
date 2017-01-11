using SSO.WCFService.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SSO.WCFService.Helpers
{
    public class CustomRoleProvider : RoleProvider
    {
        private SSOContext _db { get; set; }
        private string _applicationName;

        public CustomRoleProvider()
        {
            _db = new SSOContext();
        }

        public CustomRoleProvider(SSOContext db)
        {
            _db = db;            
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            if (config["applicationName"] != null)
                ApplicationName = config["applicationName"];
        }

        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }

            set
            {
                _applicationName = value;
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var userIds = new List<int>();
            var roleIds = new List<int>();

            for (int i = 0; i < roleNames.Length; i++)
            {
                var name = roleNames[i];
                var role = _db.Roles.SingleOrDefault(r => r.Name.Equals(name));
                if (role == null)
                    throw new RoleNotFound(roleNames[i]);
                roleIds.Add(role.ID);
            }

            for (int i = 0; i < usernames.Length; i++)
            {
                var name = usernames[i];
                var user = _db.Users.SingleOrDefault(u => u.Username.Equals(name));
                if (user == null)
                    throw new UserNotFound(usernames[i]);
                userIds.Add(user.ID);
            }

            for (int i = 0; i < userIds.Count; i++)
            {
                for (int j = 0; j < roleIds.Count; j++)
                {

                    int id = userIds[i];
                    int roleID = roleIds[j];
                    _db.ManageRoles.Add(new ManageRole { RoleID = roleID, UserID = id });
                }
            }
        }

        public void AddUsersToRoles (int[] userIds, string[] roleNames)
        {
            for (int i = 0; i < roleNames.Length; i++)
            {
                var name = roleNames[i];
                var role = _db.Roles.SingleOrDefault(r => r.Name == name);
                if (role == null)
                    throw new RoleNotFound(roleNames[i]);

            }

            for (int i = 0; i < userIds.Length; i++)
            {
                var id = userIds[i];
                var user = _db.Users.SingleOrDefault(u => u.ID == id);
                if (user == null)
                    throw new UserNotFound(userIds[i]);
            }

            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < roleNames.Length; j++)
                {
                    var name = roleNames[i];
                    var id = userIds[i];
                    _db.ManageRoles.Add(new ManageRole { RoleID = _db.Roles.SingleOrDefault(r => r.Name == name).ID, UserID =  id});

                }
            }
            _db.SaveChanges();

        }

        public override void CreateRole(string roleName)
        {
            Roles r = new Roles();
            r.Name = roleName;
            _db.Roles.Add(r);
            _db.SaveChanges();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            Roles r = _db.Roles.SingleOrDefault(role => role.Name.Equals(roleName));

            if (r == null)
                throw new RoleNotFound(roleName);
             
            if (throwOnPopulatedRole)
            {
                bool exists = _db.ManageRoles.Any(mr => mr.RoleID == r.ID);
                if (exists)
                    throw new Exception("There are users assigned to this role.");
            }
            List<ManageRole> mngroles = _db.ManageRoles.Where(m => m.RoleID == r.ID).ToList();
            _db.ManageRoles.RemoveRange(mngroles);
            _db.Roles.Remove(r);
            _db.SaveChanges();
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            Roles r = _db.Roles.SingleOrDefault(role => role.Name.Equals(roleName));

            if (r == null)
                throw new Exception("Role with that name doesn't exist.");

            return _db.ManageRoles.Include("User").Where(m => m.RoleID == r.ID && m.User.Username.Contains(usernameToMatch)).Select(m => m.User.Username).ToArray();
        }

        public List<User> FindUsersInRole(string roleName)
        {
            Roles r = _db.Roles.SingleOrDefault(role => role.Name.Equals(roleName));

            if (r == null)
                throw new RoleNotFound(roleName);

            return _db.ManageRoles.Include("User").Where(m => m.RoleID == r.ID).Select(m => m.User).ToList();
        }

        public override string[] GetAllRoles()
        {
            return _db.Roles.Select(r => r.Name).ToArray();

        }

        public override string[] GetRolesForUser(string username)
        {
            var user = _db.Users.SingleOrDefault(u => u.Username.Equals(username));
            if (user == null)
                throw new UserNotFound(username);
            return _db.ManageRoles.Include("Role").Where(mr => mr.UserID == user.ID).Select(mr => mr.Role.Name).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var role = _db.Roles.SingleOrDefault(r => r.Name.Equals(roleName));
            if (role == null)
                throw new Exception("Role with specified name does not exist.");
            return _db.ManageRoles.Include("User").Where(mr => mr.RoleID == role.ID).Select(mr => mr.User.Username).ToArray();

        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _db.Users.SingleOrDefault(u => u.Username.Equals(username));
            if (user == null)
                throw new UserNotFound(username);

            var role = _db.Roles.SingleOrDefault(r => r.Name.Equals(roleName));
            if (role == null)
                throw new RoleNotFound(roleName);

            return _db.ManageRoles.Any(mr => mr.RoleID == role.ID && mr.UserID == user.ID);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            List<ManageRole> mrs = _db.ManageRoles.Include("User").Include("Role").Where(mr => usernames.Contains(mr.User.Username) && roleNames.Contains(mr.Role.Name)).ToList();
            _db.ManageRoles.RemoveRange(mrs);
        }

        public void RemoveUsersFromRoles(int[] userIds, string[] roleNames)
        {
            for (int i = 0; i < roleNames.Length; i++)
            {
                var name = roleNames[i];
                var role = _db.Roles.SingleOrDefault(r => r.Name == name);
                if (role == null)
                    throw new RoleNotFound(roleNames[i]);

            }

            for (int i = 0; i < userIds.Length; i++)
            {
                var id = userIds[i];
                var user = _db.Users.SingleOrDefault(u => u.ID == id);
                if (user == null)
                    throw new UserNotFound(userIds[i]);
            }

            List<ManageRole> mrs = _db.ManageRoles.Include("Role").Where(mr => userIds.Contains(mr.UserID) && roleNames.Contains(mr.Role.Name)).ToList();
            _db.ManageRoles.RemoveRange(mrs);
            _db.SaveChanges();
        }

        public override bool RoleExists(string roleName)
        {
            var role = _db.Roles.SingleOrDefault(r => r.Name.Equals(roleName));
            if (role == null)
                return false;
            return true;
        }
    }
}