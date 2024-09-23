using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        // Define backing fields for properties
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
     
        // Define fully implement properties without backing fields
        public ResidentAddress Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        // Define read-only properties
        public string FullName => $"{LastName}, {FirstName}";

        public Person() 
        {
            FirstName = "unknown";
            LastName = "unknown";
        }

        public Person(string firstName, string lastName, ResidentAddress address, List<Employment> employmentpositions)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            if (employmentpositions != null)
            {
                EmploymentPositions = employmentpositions;
            }
         }
       
        //public Person(string firstName, string lastName, string? middleName)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;    
        
        //}

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get => _LastName;
            set { _LastName = value; }
        }


    }
}
