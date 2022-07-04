﻿namespace LoanCalc.Models
{
    public class LoanPayment
    {
        public int Month { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal MonthlyPrincipal { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal Balance { get; set; }
    }
}