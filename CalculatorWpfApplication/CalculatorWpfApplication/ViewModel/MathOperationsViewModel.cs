using System;

namespace CalculatorWpfApplication
{
    public class MathOperationsViewModel : BaseViewModel
    {

        public static bool anyOperators = false;
        public static string InputNumber(string number , string field , double result ) 
        {
            if (number == "AC")
                return "0";


            if (number != null && field != "0" && number != "+" && number!="-" && number != "=" && number != "*" && number != "/" && anyOperators != true)
                return field + number;
            else if (number == "+" || number == "=" )
            {
                anyOperators = true;
                return AdditionOperation(field, result);
            }
            else if (number == "-")
            {
                anyOperators = true;
                return SubtractionOperation(field, result);
            }
            else if (number == "*")
            {
                anyOperators = true;
                return MultiplicationOperation(field, result);
            }
            else if (number == "/")
            {
                anyOperators = true;
                return DivisionOperation(field, result);
            }
            else if (field == "0" || anyOperators)
            {
                anyOperators = false;
                return number;
            }


            return field;
        }

        private static string SubtractionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Subtraction(Element, result).ToString();
        }

        private static string AdditionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
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


    }
}
