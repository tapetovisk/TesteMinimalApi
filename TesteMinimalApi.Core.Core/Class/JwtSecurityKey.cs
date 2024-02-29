using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TesteMinimalApi.Core.Core.Class
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
