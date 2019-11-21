namespace CalculatorWpfApplication
{
    class MathOperationsViewModel : BaseViewModel
    {
        public static string InputNumber(string number) 
        {
            if (number != null)
                return number;
            return "0";
        }

        public static int AdditionOperation(int element, int result)
        {
            return MathExpressionsLogic.Addition(element, result);
        }
    }
}
