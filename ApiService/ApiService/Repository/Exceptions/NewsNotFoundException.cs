using System;

namespace Repository.Exceptions
{
    public class NewsNotFoundException : Exception
    {
        public NewsNotFoundException( string message) : base(message) { }
    }
}