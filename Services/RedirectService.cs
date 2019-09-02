using System.Text.RegularExpressions;
namespace IdentityWeb.Services
{
    public class RedirectService : IRedirectService
    {
        public string ExtractRedirectUriFromReturnUrl(string url)
        {
            var result = "";
            var decodeUrl = System.Net.WebUtility.HtmlDecode(url);
            var results = Regex.Split(decodeUrl, "redirect_uri=");
            if (results.Length < 2)
                return "";
            result = results[1];
            var SplitKey = "";
            if (result.Contains("singin-oidc"))
                SplitKey = "singin-oidc";
            else
                SplitKey = "scope";
            results = Regex.Split(result, SplitKey);
            if (results.Length < 2)
                return "";
            result = results[0];
            return result.Replace("%3A", ":").Replace("%2F", "/").Replace("&", "");
        }
    }
}