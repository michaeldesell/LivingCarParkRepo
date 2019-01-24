using CoreApiClient;
using LivingCarPark.Utility;
using Microsoft.Extensions.Caching.Memory;
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
        private static IMemoryCache memory;
        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(() => new ApiClient(apiUri,username,password,memory), LazyThreadSafetyMode.ExecutionAndPublication);

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
