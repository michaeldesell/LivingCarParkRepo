using WebApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiModels.Model;
using CarParkApi.Data.Entities;
using CarParkApi.JwtModel;
using CarParkUser = WebApiModels.CarParkUser;

namespace CoreApiClient
{
    public partial class ApiClient
    {

        public Task<Message<applicationlogin>> Authenticate(applicationlogin model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/Authenticate"));
            return PostAuthenticationAsync<applicationlogin>(requestUrl, model);
        }

        public async Task<List<CarParkUser>> GetUsers()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetAllUsers"));
            return await GetAsync<List<CarParkUser>>(requestUrl);
        }

        public Task<Message<ChangeAdminPriviligies>> KickAdmin(ChangeAdminPriviligies user)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/KickAdmin"));
            return PostAsync<ChangeAdminPriviligies> (requestUrl, user);
        }

        public Task<Message<ChangeAdminPriviligies>> MakeAdmin(ChangeAdminPriviligies user)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/MakeAdmin"));
            return PostAsync<ChangeAdminPriviligies>(requestUrl, user);
        }

        public async Task<Message<Tuple<Carpark, string>>> SaveCarpark(Tuple<Carpark, string> model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/SaveCarPark"));
            return await PostAsync<Tuple<Carpark,string>>(requestUrl,model);
        }

        public async Task<Message<UserModel>> LoginUser(UserModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/LoginUser"));
            return await PostAsync<UserModel>(requestUrl, model);
        }

        public async Task<Message<Carpark>> GetUserCarPark(Carpark id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<Carpark>(requestUrl, id);
        }

        public async Task<Message<UserCarPark>> SaveCars(UserCarPark model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<UserCarPark>(requestUrl, model);
        }

        public async Task<Message<UserCarPark>> DeleteCars(UserCarPark model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<UserCarPark>(requestUrl, model);
        }

        public async Task<Message<ChangeCars>> ChangeCars(ChangeCars model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/ChangeCars"));
            return await PostAsync<ChangeCars>(requestUrl, model);
        }

        //public async Task<Message<ChangeCars>> Authenticate(applicationlogin model)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "User/Authenticate"));
        //    return await PostAsync<ChangeCars>(requestUrl, model);
        //}
    }
}
