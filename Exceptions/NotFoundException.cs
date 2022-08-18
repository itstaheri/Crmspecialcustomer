using System;

namespace Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Object NotFound!")
        {

        }
        public NotFoundException(string entityName, object key) : base($"Entity {entityName} not found with {key}")
        {

        }
        public NotFoundException(string entityName) : base($"There is no value inside the {entityName}")
        {

        }
    }
}
