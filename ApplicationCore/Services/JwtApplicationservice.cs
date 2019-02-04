using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using CarPark.ApplicationCore.Entities;
using Microsoft.Extensions.Options;
using CarPark.ApplicationCore.Interfaces;

namespace CarPark.ApplicationCore.Services
{

    public class JwtApplicationservice : IJwtApplicationservice
    {
        private readonly appsettings _appsettings;

        public JwtApplicationservice(IOptions<JwtAppsettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }

        public JwtApplicationlogin Authenticate(string username, string password)
        {

            var apps = _context.ApplicationLogins.FirstOrDefault(x => x.username == username && x.password == password);

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
            JwtApplicationlogin all = new JwtApplicationlogin()
            {
                Token = Tokenhandler.WriteToken(token),
                password = null

            };

            return all;
        }



    }
}
