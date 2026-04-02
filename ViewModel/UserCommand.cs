using System;
using System.Windows.Input;

namespace ViewModel
{
    public class UserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> action;

        public UserCommand(Action<object> action)

        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                action(parameter);
            }
           
        }
    }

}
