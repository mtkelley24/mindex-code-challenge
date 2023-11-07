using System;
using CodeChallenge.Models;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
	public class CompensationService : ICompensationService
	{
		private readonly ICompensationRepository _comensationRepository;

		public CompensationService(ICompensationRepository compensationRepository)
		{
			_comensationRepository = compensationRepository;
		}

		public Compensation Create(Compensation compensation)
		{
			if(compensation != null)
			{
				_comensationRepository.Add(compensation);
				_comensationRepository.SaveAsync().Wait();
			}

			return compensation;
		}

		public Compensation GetCompensationById(string id)
		{
			if(!String.IsNullOrEmpty(id))
			{
				return _comensationRepository.GetCompensationById(id);
			}

			return null;
		}
	}
}

