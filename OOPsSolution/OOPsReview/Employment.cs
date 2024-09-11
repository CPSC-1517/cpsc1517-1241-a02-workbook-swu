using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        #region data fields
        // Define data fields for storing data
        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years;
        #endregion

        #region Properties - fully-implemented with a backing field
        // Define fully-implemented properties with a backing field
        public SupervisoryLevel Level
        {
            //get { return _Level; }
            get => _Level;
            
            private set
            {
                // Business rule: Level must be a pre-defined Level
                if ( !Enum.IsDefined( typeof( SupervisoryLevel ), value ) )
                {
                    throw new ArgumentException($"Supervisory Level {value} is invalid.");
                }
                _Level = value;
            }
        }
        public string Title
        {
            get => _Title;
            set
            {
                // Business rule: Title cannot be blank
                //if (string.IsNullOrWhiteSpace(value))
                if (Utilities.IsBlankString( value ))
                {
                    throw new ArgumentNullException("Title cannot be blank.");
                }
                // For best practices always trim string values before assignment
                _Title = value.Trim();
            }
        }
        public double Years
        {
            get => _Years;
            private set
            {
                // Business rule: Year must be a positive or zero value
                //if (value < 0.0)
                if (Utilities.IsNotPositiveOrZero( value ))
                {
                    throw new ArithmeticException($"Years {value} is less than 0. Years must be positive or zero.");
                }
                _Years = value;
            }
        }
        #endregion

        #region Properties - auto-implemented without a backing field
        // Define auto-implemented properties that does not have backing field
        public DateTime StartDate { get; set; }
        #endregion

        #region Constructors - for initialzing properties with meaningful values
        // Define constructors for initializing properties to meaning values
        public Employment()
        {
            //  Set each property to a meaningful value
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Now;
            Years = 0;
        }

        public Employment(
            string title,
            SupervisoryLevel level,
            DateTime startdate,
            double years = 0.0)
        {
            // Set each property to corresponding method parameter
            Title = title;
            Level = level;
            StartDate = startdate;
            Years = years;
        }
        #endregion

        #region methods - use fields/properties to perform some task
        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";
        }
        #endregion

    }
}
