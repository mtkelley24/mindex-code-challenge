using System;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Controllers
{
	[ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
	{
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
		{
            _logger = logger;
            _compensationService = compensationService;
		}

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation.CompensationId}'");

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationById", new { id = compensation.Employee.EmployeeId }, compensation);
        }

        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(string id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetCompensationById(id);

            if (compensation == null)
                return NotFound();

            return Ok(compensation);
        }
	}
}

