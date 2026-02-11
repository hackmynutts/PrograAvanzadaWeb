using ReservationWeb.API.Exceptions;
namespace ReservationWeb.API.Middleware
{
    public class ErrorHandling_MW
    {
        private readonly RequestDelegate _next;
        public ErrorHandling_MW(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessExceptions ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    Exceptions.BusinessExceptions => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
        }
    }
}
