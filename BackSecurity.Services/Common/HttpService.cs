using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BackSecurity.Services.Common.ICommon;
using Newtonsoft.Json;

namespace BackSecurity.Services.Common
{
    public class HttpService : IHttpService
    {
        private static readonly HttpClient _client = new();

        public HttpService()
        {
        }

        public T RequestJson<T>(string url)
        {
            return RequestJson<T>(url, HttpMethod.Get, null);
        }

        public T RequestJson<T>(string url, HttpMethod method)
        {
            return RequestJson<T>(url, method, null, null);
        }

        public T RequestJson<T>(string url, HttpMethod method, string payload)
        {
            return RequestJson<T>(url, method, payload, null);
        }

        public T RequestJson<T>(string url, HttpMethod method, string payload, string authorization)
        {
            HttpRequestMessage requestMessage = new(method, url);
            if (authorization != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
            }
            if (payload != null)
            {
                requestMessage.Content = new StringContent(
                    payload,
                    Encoding.UTF8,
                    "application/json"
                );
            }
            HttpResponseMessage responseMessage = _client.Send(requestMessage);
            Stream receiveStream = responseMessage.Content.ReadAsStream();
            StreamReader readStream = new(receiveStream, Encoding.UTF8);
            string content = readStream.ReadToEnd();
            if(((int)responseMessage.StatusCode)  >= 400 && ((int)responseMessage.StatusCode) < 500)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}

