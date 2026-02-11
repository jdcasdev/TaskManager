using FluentValidation;
using TaskManager.Application.DTOs;

namespace TaskManager.Api.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                var responseDto = new Response<object>(){ Success = false, Message = ex.Message };
                switch (ex)
                {
                    case KeyNotFoundException:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    case ValidationException validationErrors:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        responseDto.Errors = [.. validationErrors.Errors.Select(e => e.ErrorMessage)];
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                await context.Response.WriteAsJsonAsync(responseDto);
            }
        }
    }
}
