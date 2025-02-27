//namespace App.EndPoints.MVC.MiddleWare
//{
//	public class LoggingMiddleware
//	{
//		private readonly RequestDelegate _next;
//		private readonly ILogger<LoggingMiddleware> _logger;

//		public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
//		{
//			_next = next;
//			_logger = logger;
//		}

//		public async Task InvokeAsync(HttpContext context)
//		{
//			try
//			{
//				// Log the request
//				_logger.LogInformation("Handling request: {RequestPath}", context.Request.Path);

//				// Call the next middleware in the pipeline
//				await _next(context);

//				// Log the response
//				_logger.LogInformation("Finished handling request.");
//			}
//			catch (Exception ex)
//			{
//				// Log the exception
//				_logger.LogError(ex, "An error occurred while handling the request.");
//				throw;
//			}
//		}
//	}
//}
