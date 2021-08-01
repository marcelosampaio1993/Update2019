using System;
namespace SalesWebMvc2.Servicies.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message):base(message)
        {
        }
    }
}
