using App.API.Models;
using App.Models.Dtos.User.Query;
using System.Security.Claims;

namespace App.API.AuthenticationService
{

    public static class Auth
    {
        public static class Scheme
        {
            public const string UserCookie = "user-cookie";
        }

        public static class Policy
        {
            public const string RequireUser = "require-user-policy";
        }

        public class UserClaims
        {
            public static readonly string Id = "Id";
            public static readonly string FirstName = "FirstName";
            public static readonly string LastName = "LastName";
            public static readonly string Email = "Email";
        }
    }


    public class AuthService  : IAuthService
    {
        public ClaimsPrincipal CreateUserClaimsPrincipal(UserModel user, string AuthSchem)
        {
            List<Claim> claims = new List<Claim>
            {
                new (Auth.UserClaims.Id          ,user.User_Id.ToString()),
                new (Auth.UserClaims.FirstName   ,user.FirstName),
                new (Auth.UserClaims.LastName    ,user.LastName),
                new (Auth.UserClaims.Email       ,user.Email),
            };
            ClaimsIdentity claimsIdentity = new(claims, AuthSchem);
            ClaimsPrincipal userClaimsPrincipal = new(claimsIdentity);

            return userClaimsPrincipal;
        }

    }

    public interface IAuthService
    {
        ClaimsPrincipal CreateUserClaimsPrincipal(UserModel user, string AuthSchem);
    }
}
