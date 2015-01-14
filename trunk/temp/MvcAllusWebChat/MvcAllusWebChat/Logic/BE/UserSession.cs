using System;
using System.Security.Claims;
using System.Security.Principal;

namespace WebChat.Common.Security
{
    public class UserSession : IUserSession
    {
        public UserSession()
        { }
        public UserSession(ClaimsPrincipal principal)
        {
            UserId = Guid.Parse(principal.FindFirst(ClaimTypes.Sid).Value);
            Firstname = principal.FindFirst(ClaimTypes.GivenName).Value;
            Lastname = principal.FindFirst(ClaimTypes.Surname).Value;
            Username = principal.FindFirst(ClaimTypes.Name).Value;
            Email = principal.FindFirst(ClaimTypes.Email).Value;
        }
        public int Id { get; set; }
        public Guid UserId { get; private set; }
        public string Firstname { get;  set; }
        public string Lastname { get;  set; }
        public string Username { get;  set; }
        public string Email { get;  set; }
            public string Name { get; set; }

        public string Cuenta { get; set; }
        public string Area { get; set; }
        public string SubArea { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }

        public static string DNI { get; set; }

        public Guid UserGuid { get; set; }
    }


    public interface IUserSession
    {
        Guid UserId { get; }
        string Firstname { get; }
        string Lastname { get; }
        string Username { get; }
        string Email { get; }
    }

    public class SecPortalPrincipal : IPrincipal
    {
        public SecPortalPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public UserSession User { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }


}