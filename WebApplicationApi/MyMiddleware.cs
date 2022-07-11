namespace WebApplicationApi
{
	public class MyMiddleware
	{
		private readonly RequestDelegate _next;
		
		public MyMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			context.Response.Headers.Add("mmm", new string[] { "my header from middleware" });

			await _next.Invoke(context);
		}
	}
}
