using System;
using System.Threading.Tasks;
using CodeChallenge.Models;

namespace CodeChallenge.Repositories
{
	public interface ICompensationRepository
	{
		Compensation GetCompensationById(String id);
		Compensation Add(Compensation compensation);
		Task SaveAsync();
	}
}

