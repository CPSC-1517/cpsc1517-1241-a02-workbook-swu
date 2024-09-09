﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        // Define data fields for storing data
        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years;

        // Define fully-implemented properties with a backing field
        public SupervisoryLevel Level
        {
            //get { return _Level; }
            get => _Level;
            
            private set
            {
                // Validate new value is a valid SupervisoryLevel enum
                _Level = value;
            }
        }
        public string Title
        {
            get => _Title;
            set
            {
                // Validate new value is not blank
                _Title = value;
            }
        }
        public double Years
        {
            get => _Years;
            private set
            {
                // Validate new value is 0 or higher
                _Years = value;
            }
        }

        // Define auto-implemented properties that does not have backing field
        public DateTime StartDate { get; set; }
    }
}