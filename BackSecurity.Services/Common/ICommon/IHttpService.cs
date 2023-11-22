using System;
using System.Net.Http;
using BackSecurity.Dto.Authentication;

namespace BackSecurity.Services.Common.ICommon
{

    public interface IHttpService
    {

        T RequestJson<T>(string url);

        T RequestJson<T>(string url, HttpMethod method);

        T RequestJson<T>(string url, HttpMethod method, string payload);

        T RequestJson<T>(string url, HttpMethod method, string payload, string authorization);

    }
}

