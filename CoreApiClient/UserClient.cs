using WebApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiModels;
using CarParkApi.Data.Entities;
using CarParkApi.JwtModel;
using CarParkUser = WebApiModels.CarParkUserModel;

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

      public async Task<Message<CarParkModel>> SaveCarpark(CarParkModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/SaveCarPark"));
            return await PostAsync<CarParkModel>(requestUrl,model);
        }

        public async Task<Message<CarParkUserModel>> LoginUser(CarParkUserModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/LoginUser"));
            return await PostAsync<CarParkUserModel>(requestUrl, model);
        }

        public async Task<Message<Carpark>> GetUserCarPark(Carpark id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<Carpark>(requestUrl, id);
        }

        public async Task<Message<GetUserCarParks>> GetUserCarParks(GetUserCarParks id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarParks"));
            return await PostAsync<GetUserCarParks>(requestUrl,id);
        }


        public async Task<Message<CarParkModel>> SaveCars(CarParkModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<CarParkModel>(requestUrl, model);
        }

        public async Task<Message<CarParkModel>> DeleteCars(CarParkModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<CarParkModel>(requestUrl, model);
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
