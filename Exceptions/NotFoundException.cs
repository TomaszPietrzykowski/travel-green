using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Serialization;

namespace TravelGreen.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} and ({key}) was not found")
        {
            
        }

    }
}
// Inheritance: Object --> Exception --> ApplicationException
// ----------------------------------------------------------
// ApplicationException constructor overload:
// ApplicationException() <--- Initializes a new instance of the ApplicationException class.
// ApplicationException(String) <--- Initializes a new instance of the ApplicationException class with a specified error message.
// ApplicationException(String, Exception) <--- Initializes a new instance of the ApplicationException class with a specified error message and a reference to the inner exception that is the cause of this exception.
// ApplicationException(SerializationInfo, StreamingContext) <--- Initializes a new instance of the ApplicationException class with serialized data.