using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class CreateUserException : Exception
    {
        public CreateUserException() : base("An unexpected error while creating user")
        {

        }

        public CreateUserException(string? message) : base(message)
        {
        }
    }
}
