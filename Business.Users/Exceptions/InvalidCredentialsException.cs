using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Users.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        private const string ExceptionMessage = "Username e/o password errati! Si prega di riprovare.";

        public InvalidCredentialsException() : base(ExceptionMessage)
        {

        }

        public InvalidCredentialsException(Exception innerException) : base(ExceptionMessage, innerException)
        {

        }
    }
}
