using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TesteMinimalApi.Core.Core.Class;

namespace TesteMinimalApi.Core.Core.Core
{
    public class LoginCore
    {
        public IResult GetLogin()
        {
            Dictionary<string, string> role = new Dictionary<string, string>();
            role.Add("Nome", "Anderson Matos Nascimento");

            var Claim = new List<Claim>();
            Claim.Add(new Claim(ClaimTypes.Role, "Adm"));

            return TypedResults.Ok(new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("C6664E6E-8DA0-4E16-B763-E23DFFAA9E3B"))
                    .AddSubject("Anderson")
                    .Addissuer("APIGeral.Security.Bearer")
                    .Addaudience("APIGeral.Security.Bearer")
                    .AddclaimsList(role)
                    .AddListclaims(Claim)
                    .Builder());
        }

    }
}
