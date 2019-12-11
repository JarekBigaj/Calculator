
namespace CalculatorWpfApplication 
{
    class ElementState : MathOperationsState
    {
        public MathOperations mathOperations;
        public ElementState(MathOperations mathOperations)
        {
            this.mathOperations = mathOperations;
        }
        public string CreateElement()
        {
            
            if (mathOperations.firstElement != "0")
                return mathOperations.firstElement += mathOperations.senderElement;
            else
                return mathOperations.senderElement;
        }

        public void IncludesExpression()
        {
            if (mathOperations.afterAnyOperator)
                mathOperations.firstElement = "0";
        }
    }
}
