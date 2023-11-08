using System;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Repositories
{
	public class CompensationRepository : ICompensationRepository
	{
		private readonly EmployeeContext _employeeContext;

		public CompensationRepository(EmployeeContext employeeContext)
		{
			_employeeContext = employeeContext;
		}

		public Compensation Add(Compensation compensation)
		{
  			// get employee from employee context. 
            		compensation.Employee = _employeeContext
                		.Employees
                		.FirstOrDefault(i => i.EmployeeId == compensation.Employee.EmployeeId);

            		//Set compensation id key
	      		compensation.CompensationId = Guid.NewGuid().ToString();

  			//Add to compensations
			_employeeContext.Compensations.Add(compensation);
			return compensation;
		}

		public Compensation GetCompensationById(string id)
		{
  			//match compensation using employee id
			return _employeeContext.Compensations
				.Include(c => c.Employee)
				.FirstOrDefault(c => c.Employee.EmployeeId == id);
		}

        	public Task SaveAsync()
       		{
            		return _employeeContext.SaveChangesAsync();
        	}
    }
}

