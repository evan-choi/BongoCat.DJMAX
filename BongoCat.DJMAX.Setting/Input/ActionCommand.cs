using System;
using System.Windows.Input;

namespace BongoCat.DJMAX.Setting.Input
{
    internal sealed class ActionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }

    internal sealed class ActionCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action<T> _action;

        public ActionCommand(Action<T> action)
        {
            _action = action;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
