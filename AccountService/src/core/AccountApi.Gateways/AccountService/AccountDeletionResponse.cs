using System.Collections.Generic;

namespace AccountApi.Contracts
{
    public class AccountDeletionInitResponse
    {
        public string SessionId { get; set; }        
    }
    public class AccountDeletionResponse
    {
        public string AccountId { get; set; }
        public DeleteStatus Status { get; set; }
        public List<Error> Errors { get; } = new List<Error>();
    }
    public class Error
    {
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message { get;}
    }
}