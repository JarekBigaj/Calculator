using System;

namespace CalculatorWpfApplication
{
    public class MathOperationsViewModel : BaseViewModel
    {

        public static bool anyOperators = false;
        public static bool firstOperation = true;
        public static string lastOperator = null;
        public static bool anotherOperator = false;
        
        public static string InputNumber(string number, string field, double result, string secondField)
        {
            switch (number)
            {
                case "+":
                    if (lastOperator == "-")
                        anotherOperator = true;
                    lastOperator = number;
                    anyOperators = true;
                    return AdditionOperation(field, result);

                case "-":
                    lastOperator = number;
                    anyOperators = true;
                    return SubtractionOperation(field, result);

                case "=":  
                    return LastOperation(lastOperator , field , result);

                default:
                    return CreateNumber(number, field, secondField);
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
            if (firstOperation)
                return element;

            return MathExpressionsLogic.Subtraction(Element, result).ToString();
        }

        private static string AdditionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            if (anotherOperator)
            {
                anotherOperator = false;
                return MathExpressionsLogic.Addition(-Element, result).ToString();
            }
            
            
            return MathExpressionsLogic.Addition(Element, result).ToString();
        }

        private static string MultiplicationOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Subtraction(Element, result).ToString();
        }

        private static string DivisionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Addition(Element, result).ToString();
        }

        private static string CreateNumber(string number, string field, string secondField)
        {

            if (anyOperators)
            {
                anyOperators = false;
                firstOperation = false;
                return number;
            }

            if (field == secondField)
                firstOperation = true;

            if (field != "0")
                return field += number;


            return number;
        }

        private static string LastOperation(string number , string field , double result) 
        {
            switch (number)
            {
                case "+":
                    return AdditionOperation(field, result);
                case "-":
                    return SubtractionOperation(field, result);

                default:
                    return null;
            }

            
        }

    }
}
