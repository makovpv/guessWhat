using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace DataStorage
{
	public class PlaneRepository : IPlaneRepository
	{
		private IMemoryCache _cache; // = new MemoryCache(new MemoryCacheOptions());
		private readonly ILogger<PlaneRepository> _logger;

		public PlaneRepository(IMemoryCache memoryCache, ILogger<PlaneRepository> logger)
		{
			_cache = memoryCache;
			_logger = logger;
		}
		
		public string[] GetRandomData(long compulsarePlaneId)
		{
			using var db = new MatchPlaneContext();
			var planeCount = db.PlaneTypes.Count();

			var rnd = new Random();

			var plane1 = GetPlane(rnd.Next(1, planeCount));

			var plane2 = GetPlane(rnd.Next(1, planeCount));

			var compulsarePlane = GetPlane(compulsarePlaneId);

			Console.WriteLine($"GetRandomData: {plane1?.Name}, {plane2?.Name}, {compulsarePlane?.Name}");

			return new string[] { plane1?.Name, plane2?.Name, compulsarePlane?.Name };
		}

		private PlaneType? GetPlane(long id)
		{
			var result = _cache.GetOrCreate(id, x =>
			{
				x.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);

				using var db = new MatchPlaneContext();

				var plane = db.PlaneTypes.Where(x => x.Id == id).FirstOrDefault();

				return plane;
			});

			return result;
		}

		public PlaneImage GetRandomPlaneImage()
		{
			_logger.LogInformation("in GetRandomPlaneImage method");

			_logger.LogWarning("there are different types of log messages");

			using var db = new MatchPlaneContext();
			var images = db.PlaneImages.ToList();

			var count = images.Count;

			var gg = new Random();

			var rr = gg.Next(1, count);
			var zzy = images[rr];

			return zzy;
		}

		public async void SaveUserAnswerAsync(long imageId, string answer)
		{
			using var db = new MatchPlaneContext();
			var userPlaneId = db.PlaneTypes.Where(x => x.Name == answer).FirstOrDefault()?.Id;

			if (!userPlaneId.HasValue)
			{
				throw new Exception("Unknown plane type");
			}

			db.UserAnswers.Add(new UserAnswer
			{
				ImageId = imageId,
				PlaneId = userPlaneId
			});

			await db.SaveChangesAsync();
		}

		public long GetPlaneByImageId(long imageId)
		{
			return 100500;
		}

		public async Task<long> AddPlaneTypeAsync(string name, string imagePath)
		{
			using var db = new MatchPlaneContext();

			var newPlaneType = new PlaneType
			{
				Name = name
			};

			await db.PlaneTypes.AddAsync(newPlaneType);

			await db.SaveChangesAsync();

			var id = newPlaneType.Id;

			await db.PlaneImages.AddAsync(new PlaneImage
			{
				PlaneId = id,
				ImagePath = imagePath
			});

			await db.SaveChangesAsync();

			return id;
		}

		public string GetImagePath(long imageId)
		{
			using var db = new MatchPlaneContext();

			return db.PlaneImages
					.Where(x => x.ImageId == imageId)
					.FirstOrDefault().ImagePath;
		}
	}
}