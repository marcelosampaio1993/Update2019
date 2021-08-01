using System;
namespace SalesWebMvc2.Servicies.Exception
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string message) : base(message)
        { 
        }
    }
}
