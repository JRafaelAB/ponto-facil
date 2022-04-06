using Microsoft.AspNetCore.Http;

namespace Domain.Extensions
{
    public static class IResponseCookiesExtensions
    {
        private const string X_ACCESS_TOKEN = "X-Access-Token";
        public const string REFRESH_TOKEN = "Refresh-Token";
        
        public static void AppendAccessToken(this IResponseCookies cookies, string token)
        {
            cookies.Append(X_ACCESS_TOKEN, token, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
        }
        
        public static void AppendRefreshToken(this IResponseCookies cookies, string refreshToken)
        {
            cookies.Append(REFRESH_TOKEN, refreshToken, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Strict, Secure = true });
        }
    }
}
