﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Services.Models
{
    public class DepositCashDto
    {
        public string AccountNumber { get; set; }
        public decimal? Amount { get; set; }
    }
}
