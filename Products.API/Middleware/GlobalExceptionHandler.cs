using FluentValidation;
using Products.Domain.Exceptions;
using System.Net;

namespace Products.API.Middleware
{
    /// <summary>
    /// Middleware to handle all exceptions globally
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="next"></param>
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(ValidationException ex)
            {
                logger.LogInformation(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (NotFoundException ex)
            {
                logger.LogInformation(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync("An application error occured while processing the request");
            }
        }

    }
}
