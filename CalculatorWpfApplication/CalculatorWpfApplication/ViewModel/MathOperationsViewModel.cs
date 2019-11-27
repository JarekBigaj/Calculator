using System;

namespace CalculatorWpfApplication
{
    public class MathOperationsViewModel : BaseViewModel
    {

        public static bool anyOperators = false;
        public static string InputNumber(string number , string field , double result ) 
        {
            switch (number)
            {
                case "+":
                    anyOperators = true;
                    return AdditionOperation(field, result);

                case "-":
                    anyOperators = true;
                    return SubtractionOperation(field, result);

                default:
                    return CreateNumber(number, field);
            }
        }

        public static double SendResult(string mathField, double calculationResult)
        {
            if (anyOperators)
                return Convert.ToDouble(mathField);


            return calculationResult;
        }

        private static string SubtractionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Subtraction(Element, result).ToString();
        }

        private static string AdditionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Addition(Element,  result).ToString();
        }

        private static string MultiplicationOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Subtraction(Element, result).ToString();
        }

        private static string DivisionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Addition(Element,  result).ToString();
        }

        private static string CreateNumber(string number,string field)
        {
            if (anyOperators)
            {
                anyOperators = false;
                return number;
            }

            if (field != "0")
                return field += number;


            return number;
        }

    }
}
