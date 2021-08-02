using System;
namespace SalesWebMvc2.Servicies.Exception
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message)
        { }
    }
}
