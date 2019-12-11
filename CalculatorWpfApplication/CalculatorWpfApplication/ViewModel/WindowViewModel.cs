using System.Windows;
using System.Windows.Input;

namespace CalculatorWpfApplication
{

    class WindowViewModel : BaseViewModel
    {
        #region Private properties
        private Window mWindow { get; set; }
        #endregion

        #region Window Properties
        public double MinimumWindowHeight { get; set; } = 550;
        #endregion

        #region Math Operations Properties
        public MathOperations mathOperations { get; set; }
        public string MathField { get; set; } = "0";
        public string savedElement { get; set; }

        public bool isAfterAnyOperator { get; set; } = false;
        #endregion

        #region Command Properties
        public ICommand DisplayMessageCommand { get; }

        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;
            DisplayMessageCommand = new RelayCommand(DisplayMessage);
        }
        #endregion

        #region Helper Methods

        #endregion
        public void DisplayMessage(object sender)
        {
            mathOperations = new MathOperations(sender as string , MathField, savedElement , isAfterAnyOperator);
            mathOperations.IncludesExpression();
            MathField = mathOperations.CreateElement();

            if (mathOperations.IsDone)
                savedElement = MathField;

            isAfterAnyOperator = mathOperations.IsAnyOperators(sender as string);


        }

    }
}
