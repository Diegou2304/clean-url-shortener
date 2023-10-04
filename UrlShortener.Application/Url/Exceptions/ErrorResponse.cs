

using Microsoft.AspNetCore.Diagnostics;

namespace UrlShortener.Application.Cars.Exceptions
{
    [Serializable]
    public class ErrorResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public ErrorResponse(int code, string response)
        {
            statusCode = code;
            message = response;
            
        }

    }
}
