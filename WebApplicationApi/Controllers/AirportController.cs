﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Services;

namespace WebApplicationApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirportController : ControllerBase
	{
		private readonly IAirportService _airportService;

		public AirportController(IAirportService airportService)
		{
			_airportService = airportService;
		}

		[HttpPost("build/{distance}")]
		public async Task<ActionResult> BuildGraphAsync(int distance)
		{
			await _airportService.BuildGraphAsync(distance);

			return Ok();
		}
	}
}
