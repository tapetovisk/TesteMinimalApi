using System.IdentityModel.Tokens.Jwt;

namespace TesteMinimalApi.Core.Core.Class
{
    public class TokenJWT
    {
        private JwtSecurityToken Token;

        internal TokenJWT(JwtSecurityToken Token)
        {
            this.Token = Token;
        }

        public DateTime ValidTo => Token.ValidTo;

        public string Value => new JwtSecurityTokenHandler().WriteToken(this.Token);
    }
}
