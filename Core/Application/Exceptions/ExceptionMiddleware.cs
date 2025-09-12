using FluentValidation;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;

namespace Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext,ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            int statusCode = GetStatusCode(ex);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            if (ex.GetType() == typeof(ValidationException)) 
            {
                return httpContext.Response.WriteAsync(new ExceptionModel()
                {
                    StatusCode=StatusCodes.Status400BadRequest,
                    Errors = ((ValidationException)ex).Errors.Select(e => e.ErrorMessage),
                }.ToString());
            }
            List<string> errors = new()
            {
                $"Xeta:{ex.Message}",
            };
            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                StatusCode = statusCode,
                Errors = errors,
            }.ToString());
        }

        private static int GetStatusCode(Exception ex) => ex switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException=>StatusCodes.Status422UnprocessableEntity,
            _=>StatusCodes.Status500InternalServerError
        };
    }
}
