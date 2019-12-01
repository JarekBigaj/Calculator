using System;

namespace CalculatorWpfApplication
{
    public class MathOperationsViewModel : BaseViewModel
    {
        // checks last insert operators , change to true if there are any operators
        public static bool anyOperators { get; set; } = false;
        // cheks last operation if its first operation set a true  
        public static bool firstOperation { get; set; } = true;
        // check last Operator and set it as last operator
        public static string lastOperator { get; set; } = null;
        // check last operator if its different from the current set true
        public static bool anotherOperator { get; set; } = false;
        // set last element send there 
        public static string lastElement { get; set; }
        // check , if last operator is equals set true
        public static bool equalOperator { get; set; } = false;

        public static string differentOperator { get; set; }
        
        public static string InputNumber(string number, string field, double result, string secondField)
        {
            if(anyOperators == false)
                lastElement = field;
            switch (number)
            {
                case "+":
                    if (lastOperator == "-" || lastOperator == "*" || lastOperator == "/")
                        anotherOperator = true;
                    lastOperator = number;
                    if (lastOperator == "+")
                        field = lastElement;
                    anyOperators = true;
                    return AdditionOperation(field, result);

                case "-":
                    if (lastOperator == "+" || lastOperator == "*" || lastOperator == "/")
                        anotherOperator = true;
                    lastOperator = number;
                    if (lastOperator == "-")                   
                        field = lastElement;
                    anyOperators = true;
                    return SubtractionOperation(field, result);

                case "*":
                    if (lastOperator == "+" || lastOperator =="-" || lastOperator == "/")
                        anotherOperator = true;
                    lastOperator = number;
                    if (lastOperator == "*")
                        field = lastElement;
                    anyOperators = true;
                    return MultiplicationOperation(field, result);

                case "/":
                    if (lastOperator == "+" || lastOperator == "-" || lastOperator == "*")
                    { 
                        anotherOperator = true;
                        differentOperator = lastOperator;
                    }
                    lastOperator = number;
                    if (lastOperator == "/")
                        field = lastElement;
                    anyOperators = true;
                    return DivisionOperation(field, result);

                case "=":
                    if (anyOperators)
                        field = lastElement;
                    equalOperator = true;
                    return LastOperation(lastOperator , field , result);



                case "AC":
                    firstOperation = true;
                    return "0";

                default:
                    if (field == "Error")
                        field = "0";
                    return CreateNumber(number, field, secondField);
            }
        }

        public static double SendResult(string mathField, double calculationResult)
        {
            if (mathField == "Error")
                mathField = "0";
            if (equalOperator)
            {
                equalOperator = false;
                firstOperation = true;
                return Convert.ToDouble(mathField);
            }
            if (anyOperators)
                return Convert.ToDouble(mathField);

            return calculationResult;
        }

        private static string SubtractionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            if (firstOperation )
            {
                firstOperation = false;
                return element;
            }


            return MathExpressionsLogic.Subtraction(Element, result).ToString();
        }

        private static string AdditionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            if (anotherOperator && equalOperator!=true)
            {
                anotherOperator = false;
                return MathExpressionsLogic.Addition(-Element, result).ToString();
            }
            
            
            return MathExpressionsLogic.Addition(Element, result).ToString();
        }

        private static string MultiplicationOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            if (firstOperation)
            {
                firstOperation = false;
                return element;
            }
            return MathExpressionsLogic.Multiplication(Element, result).ToString();
        }

        private static string DivisionOperation(string element, double result)
        {
            double Element = Convert.ToDouble(element);
            if (Element == 0)
                return "Error";
            if (firstOperation)
            {
                firstOperation = false;
                return element;
            }
            if (anotherOperator)
            {
                anotherOperator = false;
                return LastOperation(differentOperator, element, result);
            }
            return MathExpressionsLogic.Division(Element, result).ToString();
        }

        private static string CreateNumber(string number, string field, string secondField)
        {

            if (anyOperators)
            {
                anyOperators = false;
                return number;
            }

            if (field == secondField)
                firstOperation = true;


            if (field != "0" )
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
                case "*":
                    return MultiplicationOperation(field, result);
                case "/":
                    return DivisionOperation(field, result);
                    

                default:
                    return null;
            }

            
        }

    }
}
