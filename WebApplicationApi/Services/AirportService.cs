using DataStorage;

namespace WebApplicationApi.Services
{
	public class AirportService : IAirportService
	{
		private readonly IAirportRepository _airportRepository;
		private readonly ILogger<AirportService> _logger;

		public AirportService(IAirportRepository airportRepository, ILogger<AirportService> logger)
		{
			_airportRepository = airportRepository;
			_logger = logger;
		}

		public async Task BuildGraphAsync(int distance)
		{
			_logger.LogInformation("in service");
			
			await _airportRepository.BuildGraphAsync(distance);
		}

		public string GetDestinationAirportCode(string priorAirportCode, int distance)
		{
			throw new NotImplementedException();
		}
	}
}
