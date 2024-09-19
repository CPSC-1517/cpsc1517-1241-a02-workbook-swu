

namespace OOPsReview
{
    public class SimpleCalculator
    {
        public SimpleCalculator(int op1, int op2) 
        {
            Operand1 = op1;
            Operand2 = op2;
        }

        public int Operand1 { get; set; }
        public int Operand2 { get; set; }

        public int Add()
        {
            return Operand1 + Operand2;
        }

        public double Divide()
        {
            if (Operand2 == 0)
            {
                throw new DivideByZeroException();
            }
            return 1.0 * Operand1 / Operand2;
        }
    }
}