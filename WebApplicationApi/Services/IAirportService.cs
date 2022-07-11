namespace WebApplicationApi.Services
{
	public interface IAirportService
	{
		public Task BuildGraphAsync(int distance);

		public string GetDestinationAirportCode(string priorAirportCode, int distance);
	}
}
