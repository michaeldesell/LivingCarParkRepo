using WebApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiModels.Model;
using CarParkApi.Data.Entities;

namespace CoreApiClient
{
    public partial class ApiClient
    {

        public async Task<List<CarParkUser>> GetUsers()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetAllUsers"));
            return await GetAsync<List<CarParkUser>>(requestUrl);
        }

        public async Task<Message<UserModel>> LoginUser(UserModel model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/LoginUser"));
            return await PostAsync<UserModel>(requestUrl, model);
        }

        public async Task<Message<UserCarPark>> GetUserCarPark(UserCarPark model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "User/GetUserCarPark"));
            return await PostAsync<UserCarPark>(requestUrl, model);
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
    }
}
