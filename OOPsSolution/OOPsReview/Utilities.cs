using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    // static classes cannot be instantiated
    //      for example: Utilities util = new Utilities(); // this is not allowed
    // static class items are referenced using: classname.xxx
    //      for example: Utilities.IsPositiveOrZero(99)
    // static class contain only static class-level methods
    public static class Utilities
    {
        //public static bool IsPositiveOrZero(double value)
        //{
        //    return value >= 0;
        //}
        public static bool IsPositiveOrZero(double value) => value >= 0.0;
        public static bool IsPositiveOrZero(int value) => value >= 0;
        public static bool IsNotPositiveOrZero(double value) => value < 0.0;

        public static bool IsBlankString(string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsNotBlankString(string value) => string.IsNullOrWhiteSpace(value) == false;
    }
}
