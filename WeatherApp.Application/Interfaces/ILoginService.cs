﻿using System.Threading.Tasks;
using WeatherApp.Application.Infrastructure;

namespace WeatherApp.Application.Interfaces
{
    public interface ILoginService
    {
        Task<Response> LoginUser(string password, string userName);
    }
}