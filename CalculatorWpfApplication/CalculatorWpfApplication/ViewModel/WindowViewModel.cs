

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorWpfApplication
{
    public class WindowViewModel : BaseViewModel
    {
        private Window mWindow;

        public double MinimumWindowHeight = 550;

        public ICommand ExecuteCommand { get; }
        public WindowViewModel(Window window)
        {
            mWindow = window;

            

        }


        
    }
}
