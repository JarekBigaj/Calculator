

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorWpfApplication
{

    public class WindowViewModel : BaseViewModel
    {
        private Window mWindow;

        public double MinimumWindowHeight = 550;

        public string MathField { get; set; }

       
        public ICommand DisplayMessageCommand { get; }


        public WindowViewModel(Window window)
        {
            mWindow = window;
            DisplayMessageCommand = new RelayCommand(DisplayMessage);
        }


        

        public void DisplayMessage(object sender)
        {


            if (sender != null)
                MathField += sender.ToString();

            if ((sender as string) == "AC")
                MathField = null;
        }
        
    }
}
