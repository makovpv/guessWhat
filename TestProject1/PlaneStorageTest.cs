using DataStorage;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace TestProject1
{
	[TestFixture]
	public class PlaneStorageTest
	{
		private PlaneRepository? _planeRepository;
		
		[OneTimeSetUp]
		public void Setup()
		{
			var logger = new LoggerFactory().CreateLogger<PlaneRepository>();

			var options = new MemoryCacheOptions();

			_planeRepository = new PlaneRepository(new MemoryCache(options), logger);
		}

		[Test]
		public void Test1()
		{
			var result = _planeRepository.GetPlaneByImageId(123);

			Assert.AreEqual(result, 111);
		}

		[Test]
		public void Test2()
		{
			var result = _planeRepository.GetPlaneByImageId(123);

			Assert.AreEqual(result, 100500);
		}
	}
}
