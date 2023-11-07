﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        [Key]
        public String CompensationId { get; set; }

        public Employee Employee { get; set; }
        public int Salary { get; set; }
        public String EffectiveDate { get; set; }
    }
}

