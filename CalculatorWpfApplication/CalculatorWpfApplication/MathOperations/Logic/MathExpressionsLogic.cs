using System;

namespace CalculatorWpfApplication
{
    public class MathExpressionsLogic
    {
        public static double Addition(double firstElement,double result) {return (result + firstElement);}

        public static double Subtraction(double firstElement,double result) { return (firstElement > 0) ? (result - firstElement) : (firstElement - result) ; }

        public static double Multiplication(double firstElement, double result) { return result * firstElement; }

        public static double Division(double firstElement, double result) { return (result / firstElement); }
    }


}
