using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.MyAppCLI.Models
{
    public abstract class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double FineOutstanding { get; set; }
        public abstract void CalculateFine(Member member);

        public List<Loan> Loans { get; set; }

        public Member(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Loans = new List<Loan>();
        }  
    }
}
