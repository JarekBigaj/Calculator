using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculatorWpfApplication
{
    class RelayCommand : ICommand
    {
        #region Private Members

        private Action<object> mAction;

        #endregion

        #region Public Event

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        public RelayCommand(Action<object> action) => mAction = action;


        #endregion



        #region Command
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }

        #endregion



    }
}
