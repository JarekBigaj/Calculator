using System;

namespace CalculatorWpfApplication
{
    class ResultState : MathOperationsState
    {
        public MathOperations mathOperations;
        public ResultState(MathOperations mathOperations)
        {
            this.mathOperations = mathOperations;
        }
        public string CreateElement()
        { 
            return mathOperations.secondElement;
        }

        public void IncludesExpression()
        {
            double fElement = Convert.ToDouble(mathOperations.firstElement);
            double sElement = Convert.ToDouble(mathOperations.secondElement);
            switch (mathOperations.senderElement)
            {
                case "+" :
                    mathOperations.secondElement = MathExpressionsLogic.Addition(fElement, sElement).ToString();
                    break;
                case "-":
                    mathOperations.secondElement = MathExpressionsLogic.Subtraction(fElement, sElement).ToString();
                    break;

                default:
                    break;
                    

            }
        }
    }
}
