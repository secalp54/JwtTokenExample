using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace TokenExemble.DAL
{
    public class BuiltToken
    {
        public string createToken()
        {
            //startup tarafından tanımlanan anahtar değerimiz çağrılır
            var bytes = Encoding.UTF8.GetBytes("karisiksifregirin");
            SymmetricSecurityKey key= new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(issuer:"http://localhost",audience:"http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(20),signingCredentials:credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
