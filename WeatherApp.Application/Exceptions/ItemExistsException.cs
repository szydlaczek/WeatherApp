using System;

namespace WeatherApp.Application.Exceptions
{
    public class ItemExistsException : Exception
    {
        public ItemExistsException(string message) : base(message)
        {
        }
    }
}