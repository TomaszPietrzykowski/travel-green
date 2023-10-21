using Newtonsoft.Json;
using System.Net;
using TravelGreen.Exceptions;

namespace TravelGreen.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;  
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await CustomErrorHandler(context, ex);
            }
        }

        private Task CustomErrorHandler(HttpContext context, Exception ex)
        {
            // set up fallback, default error aka worse case scenario:
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new DevErrorDetails
            {
                ErrorType = "ServerError",
                ErrorMessage = ex.Message
            };

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "NotFound";
                    break;
                case Microsoft.Data.SqlClient.SqlException dbTimoutException:
                    if (dbTimoutException.Number == -2)
                    {
                        statusCode = HttpStatusCode.GatewayTimeout;
                        errorDetails.ErrorType = "DatabaseQueryTimeOut";
                    }
                    // handle other db errors..
                    break;
                // handle as many custom cases as needed...
                default:
                    break;
            }

            var response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(response);

            //var response = new ApiOperationResult.Error(errorDetails);
            //context.Response.StatusCode = (int)statusCode;
            //return context.Response.WriteAsJsonAsync(response);

        }
    }

    public class DevErrorDetails
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}

// RequestDelegate grants us access to request object: 
// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.requestdelegate?view=aspnetcore-7.0

// Write object to response body
// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.http.httpresponsejsonextensions.writeasjsonasync?view=aspnetcore-7.0