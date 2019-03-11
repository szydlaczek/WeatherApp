using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Application.Exceptions
{
    public class ItemExistsException : Exception
    {
        public ItemExistsException(string message) : base(message)
        {
        }
    }
}
