using LoanCalc.Models;

namespace LoanCalc.Helpers
{
    public class LoanCalculation
    {

        public Loan GetPayments(Loan loan)
        {
            //Calculate monthly payment.
            loan.PaymentAmount = CalculatePayment(loan.Amount, loan.Rate, loan.Term);

            var balance = loan.Amount;
            var totalInterest = 0.0m;
            var monthlyInterest = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyRate = loan.Rate / 1200;

            //Loop over each month (i) for length of the term

            for (int i = 1; i <= loan.Term; i++)
            {
                monthlyInterest = CalculateMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.PaymentAmount - monthlyInterest;
                balance -= monthlyPrincipal;

                LoanPayment lp = new();
                lp.Month = i;
                lp.PaymentAmount = loan.PaymentAmount;
                lp.MonthlyPrincipal = monthlyPrincipal;
                lp.MonthlyInterest = monthlyInterest;
                lp.TotalInterest = totalInterest;
                lp.Balance = balance;

                loan.Payments.Add(lp);
            }
            loan.TotalInterest = totalInterest;
            loan.TotalCost = totalInterest + loan.Amount; 

            return loan;
        }

        private decimal CalculatePayment(decimal amount, decimal rate, int term)
        {
            var rateToDouble = Convert.ToDouble(rate / 1200);

            var amountToDouble = Convert.ToDouble(amount);

            var paymentAsDouble = (amountToDouble * rateToDouble / (1 - Math.Pow(1+rateToDouble, -term)));

            return Convert.ToDecimal(paymentAsDouble);
        }

        private decimal CalculateMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }

    }
}
