namespace LoanCalc.Models
{
    public class Loan
    {
        public decimal Amount { get; set; }

        public decimal Rate { get; set; }

        public int Term { get; set; }

        public decimal PaymentAmount { get; set; }

        public decimal TotalInterest { get; set; }

        public decimal TotalCost { get; set; }

        //public List<LoanPayment> Payments { get; set; } = new();
        public List<LoanPayment> Payments { get; set; } = new List<LoanPayment>();

    }
}
