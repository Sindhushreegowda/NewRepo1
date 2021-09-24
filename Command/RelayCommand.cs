using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFFirstTask.Command
{
    public class RelayCommand : ICommand
    {
       private Action<object> executeaction;
       private Func<object, bool> canExecute;
        bool _canExecuteCache;
        
        public RelayCommand(Action<object> executeaction, Func<object, bool> canExecute, bool _canExecuteCache)
        {
            this.canExecute = canExecute;
            this.executeaction = executeaction;
            _canExecuteCache = _canExecuteCache;
        }
        
        public bool CanExecute(object parameter)
        {
           
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;

            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                
            }
        }
        public void Execute(object parameter)
        {
            executeaction(parameter);

        }
    }
}
