using Benri.APIs.Test.Report;
using BenriShop;
using Microsoft.AspNetCore.Mvc.Testing;
using Nancy.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Benri.APIs.Test
{
    public class UnitTestAPI
    {
        private readonly HttpClient _client;
        public UnitTestAPI()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
            _client.BaseAddress = new Uri("https://localhost:5001/");
        }
        public string GetMessageClearly(HttpResponseMessage response)
        {
            var message = response.Content.ReadAsStringAsync().Result;
            return ClearMessage(message);
        }
        public string ClearMessage(string message)
        {
            string result = message;
            result = result.Replace("\r", "");
            result = result.Replace("\t", "");
            result = result.Replace("\n", "");
            return result;
        }
        public string CreateUniqueUserName()
        {
            string uniqueUserName = Guid.NewGuid().ToString();
            return uniqueUserName;
        }
        public async Task<HttpResponseMessage> ContentObject_PostRequest(string URI, Object inputData)
        {
            return await _client.PostAsJsonAsync(URI, inputData);
        }
        public async Task<HttpResponseMessage> ContentObject_GetRequest(string URI)
        {
            return await _client.GetAsync(URI);
        }
        public async Task<HttpResponseMessage> ContentObject_PutRequest(string URI, Object inputData)
        {
            return await _client.PutAsJsonAsync(URI, inputData);
        }
        public async Task<HttpResponseMessage> ContentObject_DelteRequest(string URI)
        {
            return await _client.DeleteAsync(URI);
        }
        public async Task<string> ContentAsString_PostRequest(string URI, Object inputData)
        { 
            var response = await ContentObject_PostRequest(URI, inputData);
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            return responseMessage;
        }
        public async Task<string> ContentAsString_GetRequest(string URI)
        {
            var response = await ContentObject_GetRequest(URI);
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            return responseMessage;
        }
        public async Task<string> ContentAsString_PutRequest(string URI, Object inputData)
        {
            var response = await ContentObject_PutRequest(URI, inputData);
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            return responseMessage;
        }
        public async Task<string> ContentAsString_DeleteRequest(string URI)
        {
            var response = await ContentObject_DelteRequest(URI);
            var responseMessage = response.Content.ReadAsStringAsync().Result;
            return responseMessage;
        }
    }
}
