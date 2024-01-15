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

    }


    public class AuthService  : IAuthService
    {
        public ClaimsPrincipal CreateUserClaimsPrincipal(UserModel user, string AuthSchem)
        {
            List<Claim> claims = new List<Claim>
            {
                new ("Id"          ,user.User_Id.ToString()),
                new ("FirstName"   ,user.FirstName),
                new ("LastName"    ,user.LastName),
                new ("Email"       ,user.Email),
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
