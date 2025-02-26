namespace ApiEvalD2P2P3.Middlewares
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var apiKey = _configuration["ApiSettings:ApiKey"];

            if (!context.Request.Headers.ContainsKey("x-api-key"))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("API key is missing");
                return;
            }

            var requestApiKey = context.Request.Headers["x-api-key"];
            if (requestApiKey != apiKey)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Invalid API key");
                return;
            }

            await _next(context);
        }
    }

}
