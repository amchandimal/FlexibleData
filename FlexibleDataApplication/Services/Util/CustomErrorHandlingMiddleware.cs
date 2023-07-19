using FlexibleDataApplication.Dto;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace FlexibleDataApplication.Services.Util
{
    public class CustomErrorHandlingMiddleware
    {


        private readonly ILogger<CustomErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CustomErrorHandlingMiddleware(ILogger<CustomErrorHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if(context.Response.StatusCode == 400)
                {
                    var response = new ErrorResponseDto { Error = "Invalid Request!" };
                    var json = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(json);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ErrorResponseDto { Error = "Internal Server Error" };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
