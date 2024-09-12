namespace ObjectClassLibrary
{
    public class BodyMassIndex
    {
        private double _weight;
        private double _height;

        public string Name { get; private set; }
        

        public double Weight
        {
            get
            {
                return _weight;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("Weight must be a positive non-zero value");
                }
                _weight = value;
            }

        }

        public double Height
        {
            get
            {
                return _height; 
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be a positive non-zero value");
                }
                _height = value;
            }

        }

        public BodyMassIndex(string name, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(name) == false) 
            { 
                Name = name;
            }
        else
            {
                throw new ArgumentException("Name cannot be blank");
            }
            this.Weight = weight;
            this.Height = height;
        }

        /// <summary>
        /// Calculate the body mass index (BMI) using the weight and height of the person.
        /// 
        /// The BMI of a person is calculated using the formula: BMI = 700 * weight / (height * height)
        /// where weight is in pounds and height is in inches.
        /// </summary>
        /// <returns>the body mass index (BMI) value of the person</returns>
        public double Bmi()
        {
            double bmiValue = 703 * Weight / Math.Pow(Height, 2);
            bmiValue = Math.Round(bmiValue, 1);
            return bmiValue;
        }

        /// <summary>
        /// Determines the BMI Category of the person using their BMI value.
        /// </summary>
        /// <returns>one of following: underweight, normal, overweight, obese.</returns>
        public string BmiCategory()
        {
            string category = "Unknown";
            double bmiValue = Bmi();

            if (bmiValue < 18.5)
            {
                category = "underweight";
            }
            if (bmiValue < 24.9)
            {
                category = "normal";
            }
            if (bmiValue < 29.9)
            {
                category = "overweight";
            }
            if (bmiValue >= 30)
            {
                category = "obese";
            }

            return category;
        }
    }


}