using System;
using System.Collections.Generic;
using MyApp.CLI;
using MyApp.MyAppCLI.Models;
using Xunit;

namespace MyApp.Tests
{
    public class MemberTests
    {
        private List<Loan> loans = new List<Loan>();
        private Member adult = MemberFactory.CreateMember("Donal", new DateTime(1950, 1, 1));
        private Member child = MemberFactory.CreateMember("Donal", new DateTime(2015, 1, 1));

        [Fact]
        public void MemberFactory_CreateMember_Should_Create_Child_Object()
        {
            DateTime childBirthdate = new DateTime(2015, 1, 1);
            Member m = MemberFactory.CreateMember("Kate", childBirthdate);

            Assert.Equal("Kate", m.Name);
            Assert.Equal(childBirthdate, m.DateOfBirth);

            Type childType = m.GetType();
            Assert.Equal(typeof(Child), childType);
        }

        [Fact]
        public void MemberFactory_CreateMember_Should_Create_Adult_Object()
        {
            DateTime adultBirthdate = new DateTime(1950, 1, 1);
            Member m = MemberFactory.CreateMember("Donal", adultBirthdate);

            Type adultType = m.GetType();
            Assert.Equal(typeof(Adult), adultType);
        }

        [Fact]
        public void Member_Should_Receive_List_Of_Loans()
        {
            List<Loan> loans = createLoans();
            adult.Loans = loans;
            Assert.Equal(adult.Loans, loans);
            Assert.Equal(2, actual: adult.Loans.Count);
        }

        [Fact]
        public void Member_CalculateFine_For_Adult_Should_Return_Expected_Result()
        {
            Member adultMember = createMemberWithALoan(adult);

            adultMember.CalculateFine(adultMember);

            Assert.Equal(1.0, adultMember.FineOutstanding);
        }

        [Fact]
        public void Member_CalculateFine_For_Child_Should_Return_Expected_Result()
        {
            Member childMember = createMemberWithALoan(child);

            childMember.CalculateFine(childMember);

            Assert.Equal(2.75, childMember.FineOutstanding);

        }

        private Member createMemberWithALoan(Member member) 
        {
            List<Loan> loanList = new List<Loan>();
            loanList.Add(new Loan()
            {
                BookId = "2",
                MemberId = "4",
                LoanDate = new DateTime(2018, 10, 01),
                ReturnDate = new DateTime(2018, 10, 19)
            });
            member.Loans = loanList;
            return member;
        }

        private List<Loan> createLoans()
        {
            loans.Add(new Loan()
            {
                BookId = "2",
                MemberId = "4",
                LoanDate = new DateTime(2018, 10, 01),
                ReturnDate = new DateTime(2018, 10, 07)
            });
            loans.Add(new Loan()
            {
                BookId = "3",
                MemberId = "5",
                LoanDate = new DateTime(2018, 10, 15),
                ReturnDate = new DateTime(2018, 10, 21)
            });
            return loans;
        }
    }
}
