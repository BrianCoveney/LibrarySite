using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.MyAppCLI.Models
{
    public class MemberFactory
    {
        public static Member CreateMember(string name, DateTime dateOfBirth)
        {
            var age = CalculateAge(dateOfBirth);

            if (age < 18)
            {
                return new Child(name, dateOfBirth);
            }
            else
            {
                return new Adult(name, dateOfBirth);
            }
       
        }

        private static double CalculateAge(DateTime DateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            return age;
        }
       
    }
}
