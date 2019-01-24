using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkApi.JwtModel;
using CarParkApi.JwtHelper;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CarParkApi.Service
{

    public interface iapplicationservice
        {
        applicationlogin Authenticate(string username, string password);
        IEnumerable<applicationlogin> GetAll();
    }


    public class applicationservice:iapplicationservice
    {
        private List<applicationlogin> applogins = new List<applicationlogin>() { new applicationlogin() { id = 0, username = "LivingCarParkWeb", password = "manycars" } };
        private readonly appsettings _appsettings;

        public applicationservice(IOptions<appsettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }

        public applicationlogin Authenticate(string username, string password)
        {
            var apps = applogins.FirstOrDefault(x => x.username == username && x.password == password);

            if (apps == null)
                return null;
            var Tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.secret);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,apps.id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = Tokenhandler.CreateToken(tokendescriptor);
            apps.Token = Tokenhandler.WriteToken(token);
            apps.password = null;

            return apps;
        } 
        public IEnumerable<applicationlogin> GetAll()
        {
            // return users without passwords
            return applogins.Select(x => {
                x.password = null;
                return x;
            });
        }


    }
}
