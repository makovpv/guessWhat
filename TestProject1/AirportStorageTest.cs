using DataStorage.Repos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
	internal class AirportStorageTest
	{
		private AirportRepository? _airportRepository;

		[OneTimeSetUp]
		public void Setup()
		{
			_airportRepository = new AirportRepository();
		}

		[TestCase(0, 0, 0, 0, 0)]
		[TestCase(0, 0, 1, 0, 1852 * 60)]
		[TestCase(0, 0, 0, 1, 1852 * 60)]
		[TestCase(55.4170876, 37.8861311, 55.9676719, 37.3188646, 69710)]
		[TestCase(55.68368646494895, 37.59021071091278, 53.33368059820022, -6.330433499511915, 2798020)]
		public void GetDistanceBetweenPointsTest(double latA, double longA, double latB, double longB, int expectedDistance)
		{
			var result = AirportRepository.GetDistanceBetween(latA, longA, latB, longB);

			if (expectedDistance == 0)
			{
				Assert.AreEqual(result, expectedDistance);

				return;
			}
			
			Assert.LessOrEqual(Math.Abs(expectedDistance - result) / (double)expectedDistance, 0.001);
		}
	}
}
