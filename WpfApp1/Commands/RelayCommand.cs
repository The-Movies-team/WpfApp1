﻿using System.Windows.Input;

namespace WpfApp1.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public RelayCommand(Action<object> executeAction)
        {
            execute = executeAction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
