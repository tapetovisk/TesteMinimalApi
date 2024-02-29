using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TesteMinimalApi.Core.Core.Class
{
    public class TokenJWTBuilder
    {
        private SecurityKey securityKey = null;
        private string subject = "";
        private string issuer = "";
        private string audience = "";
        public List<Claim> LstClaims = new List<Claim>();
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expiryInMinutes = 120;

        public TokenJWTBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        public TokenJWTBuilder AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public TokenJWTBuilder Addissuer(string issuer)
        {
            this.issuer = issuer;
            return this;
        }

        public TokenJWTBuilder Addaudience(string audience)
        {
            this.audience = audience;
            return this;
        }

        internal object AddSecurityKey(object p)
        {
            throw new NotImplementedException();
        }

        public TokenJWTBuilder Addclaims(string Type, string value)
        {
            this.claims.Add(Type, value);
            return this;
        }

        public TokenJWTBuilder AddclaimsList(Dictionary<string, string> LstClaims)
        {
            foreach (var item in LstClaims)
            {
                this.claims.Add(item.Key.ToString(), item.Value.ToString());
            }

            return this;
        }

        public TokenJWTBuilder AddListclaims(List<Claim> obj)
        {
            LstClaims.AddRange(obj);
            return this;
        }

        public TokenJWTBuilder Addclaims(Dictionary<string, string> claims)
        {
            this.claims.Union(claims);
            return this;
        }

        public TokenJWTBuilder Addclaims(int expiryInMinutes)
        {
            this.expiryInMinutes = expiryInMinutes;
            return this;
        }

        public TokenJWT Builder()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, this.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }.Union(this.claims.Select(item => new Claim(item.Key, item.Value)))
            .Union(LstClaims);

            var Token = new JwtSecurityToken(
                issuer: this.issuer,
                audience: this.audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                signingCredentials: new SigningCredentials(this.securityKey, SecurityAlgorithms.HmacSha256)
                );

            return new TokenJWT(Token);
        }

        private void EnsureArguments()
        {
            if (this.securityKey == null)
                throw new ArgumentNullException("Security Key");

            if (string.IsNullOrEmpty(this.subject))
                throw new ArgumentNullException("Subject");

            if (string.IsNullOrEmpty(this.issuer))
                throw new ArgumentNullException("Issuer");

            if (string.IsNullOrEmpty(this.audience))
                throw new ArgumentNullException("Audience");
        }
    }
}
