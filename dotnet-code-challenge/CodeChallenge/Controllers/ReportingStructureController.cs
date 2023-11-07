using System;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Controllers
{
	[ApiController]
	[Route("api/reporting-structure")]
	public class ReportingStructureController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly IReportingStructureService _reportingService;

		public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
		{
			_logger = logger;
			_reportingService = reportingStructureService;
		}

		[HttpGet("{id}", Name = "getReportingStructureByEmployeeId")]
		public IActionResult getReportingStructureById(String id)
		{
			_logger.LogDebug($"Received reporting structure get request for '{id}'");

			var reportingStructure = _reportingService.GetReportingStructureById(id);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }
	}
}

