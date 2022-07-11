using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage.Repos
{
	public class AirportRepository : IAirportRepository
	{
		private const int _earthRaduis = 6372795;
		private const int _nauticalMile = 1852;
		private readonly int _minDistance;

		private readonly ILogger<AirportRepository> _logger;

		public AirportRepository(ILogger<AirportRepository> logger, IConfiguration configuration)
		{
			_logger = logger;

			_minDistance = Convert.ToInt32(configuration.GetSection("MyAppData")["minDistance"]);
		}

		public void LogToConsole()
		{
			_logger.LogDebug("LogToConsole");
		}

		/// <summary>
		/// Build airport distances graph
		/// </summary>
		/// <param name="distance">max distance in nautical miles</param>
		/// <returns></returns>
		public async Task BuildGraphAsync(int distance)
		{
			_logger.LogDebug("BuildGraphAsync");

			Console.WriteLine("Console BuildGraphAsync");

			using var db = new AirportsContext();

			var distances = new List<Distance>();
			
			var airports = db.Airports;

			var priorStepDistanceCount = 0;

			foreach (var departure in airports)
			{
				foreach (var arrival in airports.Where(x => x.Id != departure.Id))
				{
					if (distances.Exists(x => x.AirportFromId == arrival.Id && x.AirportToId == departure.Id))
						continue;
					
					var dist = GetDistanceBetween(
							departure.LatDecimal,
							departure.LonDecimal,
							arrival.LatDecimal,
							arrival.LonDecimal
						);

					if (dist.HasValue &&
						dist.Value > _minDistance *_nauticalMile &&
						dist.Value < distance * _nauticalMile)
					{
						distances.Add(new Distance()
						{
							AirportFromId = departure.Id,
							AirportToId = arrival.Id,
							Value = dist.Value
						});
					}
				}

				if (priorStepDistanceCount != distances.Count)
				{
					_logger.LogDebug(distances.Count.ToString());
					Console.WriteLine($"{distances.Count} ***");

					priorStepDistanceCount = distances.Count;
				}
			}

			db.Distances.RemoveRange(db.Distances.Select(x => x));

			await db.Distances.AddRangeAsync(distances);

			await db.SaveChangesAsync();
		}

		public static int? GetDistanceBetween(double? latA, double? longA, double? latB, double? longB)
		{
			if (!latA.HasValue || latA == 0 || !latB.HasValue || latB == 0)
				return null;

			// https://ru.wikipedia.org/wiki/%D0%9E%D1%80%D1%82%D0%BE%D0%B4%D1%80%D0%BE%D0%BC%D0%B8%D1%8F

			var lat1 = latA.Value * Math.PI / 180;
			var lat2 = latB.Value * Math.PI / 180;
			var long1 = longA.Value * Math.PI / 180;
			var long2 = longB.Value * Math.PI / 180;

			var a = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(long2 - long1));
			
			return Convert.ToInt32(_earthRaduis * a);
		}
	}
}
