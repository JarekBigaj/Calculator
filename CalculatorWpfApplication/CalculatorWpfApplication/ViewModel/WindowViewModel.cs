using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorWpfApplication
{

    public class WindowViewModel : BaseViewModel
    {
        private Window mWindow;

        public double MinimumWindowHeight = 550;

        public string MathField { get; set; } = "0";
        public int CalculationResult { get; set; } = 0;

       
        public ICommand DisplayMessageCommand { get; }


        public WindowViewModel(Window window)
        {
            mWindow = window;
            DisplayMessageCommand = new RelayCommand(DisplayMessage);
        }

        


        public void DisplayMessage(object sender)
        {

            if (MathField == "0")
                MathField = MathOperationsViewModel.InputNumber(sender as string);
            else
            {
                if (sender as string == "+" )
                {
                    int helperVariable = Int32.Parse(MathField);
                    MathField = null;
                    CalculationResult = MathOperationsViewModel.AdditionOperation(helperVariable, CalculationResult);
                    MathField = CalculationResult.ToString();
                }
                else
                    MathField += MathOperationsViewModel.InputNumber(sender as string);
            }


            // if ((sender as string) == "+")
            // {
            //     
            //     CalculationResult = MathExpressionsLogic.Addition(helperVariable, CalculationResult);
            //     MathField = CalculationResult.ToString();
            // }
            // else
            //
            //
            // if ((sender as string) == "AC")
            //     MathField = "0";

        }
        
    }
}
