using System;
using Refit;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PokeDex.Common.Constant;
using Newtonsoft.Json.Serialization;
using Microsoft.Maui.Storage;

namespace PokeDex.Services
{
    [ExcludeFromCodeCoverage]
    public class HttpClientProvider
    {
        public static HttpClientProvider Instance { get; } = new HttpClientProvider();

        private readonly HttpClient _httpClient;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private HttpClientProvider()
        {
            _httpClient = new HttpClient(new HttpLoggingHandler())
            {
                BaseAddress = new Uri(Server.ApiUrl)
            };
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            };
        }

        public T GetApi<T>()
        {
            return RestService.For<T>(_httpClient, new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(_jsonSerializerSettings)
            });
        }
    }
}

