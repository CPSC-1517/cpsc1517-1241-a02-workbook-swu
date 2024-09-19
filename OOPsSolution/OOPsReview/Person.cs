using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private string? _MiddleName;    // nullable field

        public string? MiddleName       // nullable property
        {
            get { return _MiddleName; }
            set 
            { 
                //if (value == null)
                //{
                //    _MiddleName = value;
                //}
                //else
                //{
                //    _MiddleName = value.Trim();
                //}
                 value = _MiddleName?.Trim();
            }
        }

        public Person(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;    
            MiddleName = middleName;
        }

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
