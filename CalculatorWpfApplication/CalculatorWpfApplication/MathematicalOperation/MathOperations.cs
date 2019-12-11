namespace CalculatorWpfApplication
{
    class MathOperations : MathOperationsState
    {
        public ElementState elementState { get; private set; }

        public ResultState resultState { get; private set; }

        public MathOperationsState state { get; set; }

        public string firstElement { get; set; }

        public string secondElement { get; set; }

        public string senderElement { get; set; }

        public bool IsDone { get; set; } = false;

        public bool afterAnyOperator { get; set; }

        public MathOperations(string sender , string mathField , string savedElement , bool isAfterAnyOperator)
        {
            elementState = new ElementState(this);
            resultState = new ResultState(this);
            IsDone = IsAnyOperators(sender);
            afterAnyOperator = isAfterAnyOperator;
            senderElement = sender;
            secondElement = savedElement;
            firstElement = mathField;
            if (IsDone)
                state = resultState;
            else
                state = elementState;
        }
        public string CreateElement()
        {
            return state.CreateElement();
        }

        public void IncludesExpression()
        {
            state.IncludesExpression();
        }

        public bool IsAnyOperators(string sender) 
        {
            if (sender == "+" || sender == "-" || sender == "*" || sender == "/" || sender == "=")
                return true;

            return false;   
        } 

    }
}
