using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.MyAppCLI.Models
{
    public class Child : Member
    {
        private const double PI = 3.14159;
        private const double FINE_VALUE = 0.25;
        public const int MAX_CHILD_DAYS = 7;

        private double finesOutstanding
        {
            get
            {
                return this.finesOutstanding;
            }
            set
            {
                this.finesOutstanding = value;
            }
        }

        public Child(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
        {

        }

        public override void CalculateFine(Member member)
        {
            double daysOver = CalculateDaysOverLoanLimit();
            double currentFine = member.FineOutstanding;
            double updatedFine = daysOver * FINE_VALUE;
            double fine = currentFine + updatedFine;
            
            this.FineOutstanding = fine;
        }

        private double CalculateDaysOverLoanLimit()
        {
            double daysOver = 0;
            double days = CalculateDaysOnLoan();
            if (days > MAX_CHILD_DAYS)
            {
                daysOver += days - MAX_CHILD_DAYS;
            }
            return daysOver;
        }

        private double CalculateDaysOnLoan()
        {
            double days = 0;
            foreach (Loan loan in Loans)
            {
                days = (loan.ReturnDate - loan.LoanDate).TotalDays;
            }

            return days;
        }

        public override string ToString()
        {
            string result = "Child [MemberId= " + MemberId + ", Name=" + Name + ", Address=" + Address
                + ", DateOfBirth=" + DateOfBirth + ", FineOutstanding=" + FineOutstanding
                + "\n\t loan=[" + loanListToString() + "]]\n";
            return result;
        }

        private string loanListToString()
        {
            string loanResult = "";
            foreach (Loan loan in Loans)
            {
                loanResult += loan;
            }
            return loanResult;
        }


    }
}
