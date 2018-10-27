using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.MyAppCLI.Models
{
    public class Loan
    { 
        public string BookId { get; set; }
        public string MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public override string ToString()
        {
            return "BookId: " + BookId + " MemberId: " + MemberId + " LoanDate: " + LoanDate + " Return Date: " + ReturnDate;
        }
    }
}
