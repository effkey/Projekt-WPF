using System.Windows.Input;

namespace ToDoList.Core.ViewModels.Helper
{
    public class RelayCommand : ICommand
    {
        private Action mAction;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action action)
        {
            mAction = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mAction();
        }
    }
}
