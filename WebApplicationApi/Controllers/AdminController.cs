using DataStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplicationApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly PlaneRepository _storage;

		private readonly ILogger _logger;

		public AdminController(ILogger<PlaneRepository> logger, IMemoryCache memoryCache)
		{
			_logger = logger;

			_storage = new PlaneRepository(memoryCache, logger);
		}

		[HttpPost("plane")]
		[ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
		//public async Task<ActionResult<long>> AddNewPlaneAsync([FromBody] string name, [FromForm] IFormFile file)
		public async Task<ActionResult<long>> AddNewPlaneAsync([FromForm] string name, [FromForm] IFormFile file)
		{
			_logger.LogInformation("I'm gonna add new plane");
			
			var extension = Path.GetExtension(file.FileName);

			var randomFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());

			var relativeFileName = $"0100\\{randomFileName}{extension}";

			var path = $"c:\\projects\\pet\\data\\planeimages\\{relativeFileName}";

			using var fs = System.IO.File.Create(path);

			await file.CopyToAsync(fs);

			await fs.FlushAsync();


			
			var gg = await _storage.AddPlaneTypeAsync(name, relativeFileName);

			return Ok(gg);
		}
	}
}
