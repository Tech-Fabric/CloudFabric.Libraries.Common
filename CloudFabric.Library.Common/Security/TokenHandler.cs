using System.Linq;

namespace CloudFabric.Library.Common.Security
{
    public static class TokenHandler
    {
        public static string GetBearerToken(string authHeader)
        {
            if (!string.IsNullOrEmpty(authHeader))
            {
                var token = authHeader.ToString().Split(' ');

                if(token.Count() == 2)
                {
                    return token[1];
                }                
            }

            return null;
        }
    }
}
