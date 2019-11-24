using System;

namespace CalculatorWpfApplication
{
    class MathOperationsViewModel : BaseViewModel
    {

        public static bool anyOperators = false;
        public static string InputNumber(string number , string field , double result ) 
        {
            if (number == "AC")
                return "0";


            if (number != null && field != "0" && number != "+" && number != "=" && anyOperators != true)
                return field + number;
            else if (number == "+" || number == "=")
            {
                anyOperators = true;
                return AdditionOperation(field, result);
            }
            else if (field == "0" || anyOperators)
            {
                anyOperators = false;
                return number;
            }


            return field;
        }

        public static string AdditionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            return MathExpressionsLogic.Addition(Element, result).ToString();
        }

        public MathOperationsViewModel()
        {
        }
    }
}
