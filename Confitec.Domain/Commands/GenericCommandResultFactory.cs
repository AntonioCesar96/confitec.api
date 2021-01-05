using System.Collections.Generic;

namespace Confitec.Domain.Commands
{
    public class GenericCommandResultFactory
    {
        public static GenericCommandResult CreateMessageSuccess(string message)
        {
            return new GenericCommandResult(true, message, null);
        }

        public static GenericCommandResult CreateMessageError(string message)
        {
            return new GenericCommandResult(false, "Ops!", new List<string> { message });
        }

        public static GenericCommandResult CreateMessageError(List<string> messages)
        {
            return new GenericCommandResult(false, "Ops!", messages);
        }
    }
}