using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class CreateUserException : Exception
    {
        public CreateUserException() : base("Registration unsuccessful")
        {

        }

        public CreateUserException(string? message) : base(message)
        {
        }
        public CreateUserException(IEnumerable<string> messages) : base(string.Join(",", messages))
        {
        }
    }
}
