﻿using System;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public interface ICompensationService
	{
		Compensation Create(Compensation compensation);
		Compensation GetCompensationById(String id);
	}
}

