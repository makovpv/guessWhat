using DataStorage;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Caching.Memory;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : ControllerBase
	{
		private readonly IPlaneRepository _storage; // = new Class1();

		private readonly string imageStoragePath = "c:\\projects\\pet\\data\\planeimages";

		public QuestionController(IPlaneRepository planeRepository) // IMemoryCache memoryCache
		{
			_storage = planeRepository;
		}

		[HttpGet]
		[ProducesResponseType(typeof(QuestionViewModel), StatusCodes.Status200OK)]
		public QuestionViewModel Get()
		{
			var randomPlaneImage = _storage.GetRandomPlaneImage();

			var randomNames = _storage.GetRandomData(randomPlaneImage.PlaneId);
			
			var result = new QuestionViewModel()
			{
				ImageId = randomPlaneImage.ImageId,
				Options = randomNames
			};

			return result;
		}

		[HttpGet("image/{id}")]
		public IActionResult GetImage(long id)
		{
			var path = _storage.GetImagePath(id);

			var ext = Path.GetExtension(path);

			var bytes = System.IO.File.ReadAllBytes($"{imageStoragePath}\\{path}");

			return File(bytes, "image/jpeg");
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public void Post([FromBody] UserAnswerViewModel answer)
		{
			try
			{
				_storage.SaveUserAnswerAsync(answer.ImageId, answer.Answer);
			}
			catch (Exception ex)
			{

			}
			
		}
	}
}
