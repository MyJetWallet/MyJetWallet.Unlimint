using System;
using System.Net;

namespace MyJetWallet.Unlimint
{
    public class CircleException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public string ErrorMessage { get; set; }

        public CircleException(HttpStatusCode code, string errorMessage) : base(
            $"Error response from Circle: [{code}] {errorMessage}")
        {
            Code = code;
            ErrorMessage = errorMessage;
        }
    }
}