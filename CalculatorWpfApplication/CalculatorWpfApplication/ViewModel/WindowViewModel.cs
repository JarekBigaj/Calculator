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
        public string SecondMathField { get; set; }
        public double CalculationResult { get; set; } = 0;

       
        public ICommand DisplayMessageCommand { get; }


        public WindowViewModel(Window window)
        {
            mWindow = window;
            DisplayMessageCommand = new RelayCommand(DisplayMessage);
        }

        
        

        public void DisplayMessage(object sender)
        {
            if (sender as string == "AC")
                SecondMathField = null;
            else
                SecondMathField += sender as string;

            CalculationResult = MathOperationsViewModel.SendResult(MathField, CalculationResult);

            MathField = MathOperationsViewModel.InputNumber(sender as string, MathField, CalculationResult , SecondMathField);

            
            if (sender.ToString() == "+")
                Console.WriteLine("+");
            else
            Console.WriteLine("MathField "+ MathField);
            Console.WriteLine("CalculationResult " + CalculationResult);
        }
        
    }
}
