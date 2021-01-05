using Confitec.Domain.Commands.Contracts;
using System.Collections.Generic;

namespace Confitec.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public GenericCommandResult() { }

        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static GenericCommandResult CreateMessageError(string message)
        {
            return new GenericCommandResult(false, "Ops!", new List<string> { message });
        }
    }
}