using System;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
	public class ReportingStructureService : IReportingStructureService
	{
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeService employeeService)
		{
			_employeeService = employeeService;
            		_logger = logger;
		}

		public ReportingStructure GetReportingStructureById(string id)
		{
			Employee employee = _employeeService.GetById(id);

			var numOfReports = GetNumberOfReports(employee);

			return new ReportingStructure()
			{
				Employee = employee,
				NumberOfReports = numOfReports
			};
		}

  		//Recursive method to get the number of direct reports and the direct reports of those direct reports and so on
		private int GetNumberOfReports(Employee employee)
		{
			int count = 0;
			if(employee.DirectReports != null)
			{
				count += employee.DirectReports.Count;

				foreach (var eRef in employee.DirectReports)
				{
					var e = _employeeService.GetById(eRef.EmployeeId);

					count += GetNumberOfReports(e);
				}
			}
			return count;
		}
	}
}

