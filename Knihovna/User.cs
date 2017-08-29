using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna
{

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> BorrowedBooks { get; set; }
        public int NumberOfBooks { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }


        public User()
        {

        }
        public User(int id, string firstName, string lastName, DateTime dateOfBirth, List<int> books)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Age = CalculateAge();
            BorrowedBooks = books;
            NumberOfBooks = books.Count;
            Name = firstName + " " + lastName;

        }



        private int CalculateAge()
        {
            var today = DateTime.UtcNow;
            // Calculate the age.
            var age = today.Year - DateOfBirth.Year;
            // Do stuff with it.
            if (DateOfBirth > today.AddYears(-age)) age--;

            return age;
        }


    }
}
