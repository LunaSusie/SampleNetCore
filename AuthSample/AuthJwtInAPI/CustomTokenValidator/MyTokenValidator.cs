using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AuthJwtInAPI.CustomTokenValidator
{
    public class MyTokenValidator: ISecurityTokenValidator
    {
        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters,
            out SecurityToken validatedToken)
        {
            validatedToken = null;
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
            if (securityToken == "abcdefg！")
            {  
                identity.AddClaim(new Claim("Name", "luna"));
                identity.AddClaim(new Claim("Role", "admin"));
            }
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }

        public bool CanValidateToken => true;
        public int MaximumTokenSizeInBytes { get; set; }
    }
}