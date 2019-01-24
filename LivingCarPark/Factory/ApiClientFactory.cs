using CoreApiClient;
using LivingCarPark.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LivingCarPark.Factory
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        private static string username;
        private static string password;
        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(apiUri,username,password), LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
            username = ApplicationSettings.username;
            password = ApplicationSettings.password;
        }

        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }

    }
}
