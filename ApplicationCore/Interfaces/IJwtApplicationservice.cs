using CarPark.ApplicationCore.Entities;

namespace CarPark.ApplicationCore.Interfaces
{
    public interface IJwtApplicationservice
    {
        JwtApplicationlogin Authenticate(string username, string password);
    }
}