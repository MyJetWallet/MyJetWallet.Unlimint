using System;
using System.Net;

namespace MyJetWallet.Unlimint
{
    public class UnlimintException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public string ErrorMessage { get; set; }

        public UnlimintException(HttpStatusCode code, string errorMessage) : base(
            $"Error response from Unlimint: [{code}] {errorMessage}")
        {
            Code = code;
            ErrorMessage = errorMessage;
        }
    }
}