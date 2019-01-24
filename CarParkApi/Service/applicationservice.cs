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
using Microsoft.Extensions.Configuration;
using CarParkApi.Data;

namespace CarParkApi.Service
{

    public interface iapplicationservice
        {
        applicationlogin Authenticate(string username, string password);
        //IEnumerable<applicationlogin> GetAll();
    }


    public class applicationservice:iapplicationservice
    {
        private LivingCarParkContext _context;
        private readonly appsettings _appsettings;
       
        public applicationservice(IOptions<appsettings> appsettings,LivingCarParkContext context)
        {
            _appsettings = appsettings.Value;
            _context = context;
        }

        public applicationlogin Authenticate(string username, string password)
        {


            //var apps = applogins.FirstOrDefault(x => x.username == username && x.password == password);
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
            applicationlogin all = new applicationlogin()
            {
                Token = Tokenhandler.WriteToken(token),
                password = null
                
            };
            //apps.Token = Tokenhandler.WriteToken(token);
            //apps.password = null;

            return all;
        } 
        //public IEnumerable<applicationlogin> GetAll()
        //{
        //    // return users without passwords
        //    return _context.ApplicationLogins.Select(x => {
        //        x.password = null;
        //        return x;
        //    });
        //}


    }
}
