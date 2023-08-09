using Prism;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPrismCompositeCommand.Commands;

namespace WpfPrismCompositeCommand.ViewModels
{
    public class MainWindowViewModel : BindableBase, IActiveAware
    {
        private CompositeCommand _basicCompositeCommand = new CompositeCommand();

        public CompositeCommand BasicCompositeCommand
        {
            get { return _basicCompositeCommand; }
        }

        public DelegateCommand BasicCommand1 { get; private set; }
        public DelegateCommand BasicCommand2 { get; private set; }
        public DelegateCommand BasicCommand3 { get; private set; }

        public DelegateCommand DIPartCommand { get; private set; }
        public DelegateCommand StaticPartCommand { get; private set; }


        private CompositeCommand _disabledCompositeCommand = new CompositeCommand();

        public CompositeCommand DisabledCompositeCommand
        {
            get { return _disabledCompositeCommand; }
        }

        public DelegateCommand EnabledCommand { get; private set; }
        public DelegateCommand DisabledCommand { get; private set; }

        private IDICompositeCommands _DICompositeCommands;

        public IDICompositeCommands DICompositeCommands
        {
            get { return _DICompositeCommands; }
            set { SetProperty(ref _DICompositeCommands, value); }
        }

        public IActiveExecuteCommands _activeExecuteCommands;
        public IActiveExecuteCommands ActiveExecuteCommands 
        { 
            get { return _activeExecuteCommands; }
            set { SetProperty(ref _activeExecuteCommands, value); }
        }

        public DelegateCommand ActiveCommand { get; private set; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set 
            { 
                _isActive = value;
                OnIsActiveChanged();
            }
        }

        private void OnIsActiveChanged()
        {
            ActiveCommand.IsActive = IsActive;
            IsActiveChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler IsActiveChanged;

        public MainWindowViewModel(IDICompositeCommands DICompositeCommands, IActiveExecuteCommands activeExecuteCommands)
        {
            BasicCommand1 = new DelegateCommand(BasicFunction1);
            BasicCommand2 = new DelegateCommand(BasicFunction2);
            BasicCommand3 = new DelegateCommand(BasicFunction3);
            BasicCompositeCommand.RegisterCommand(BasicCommand1);
            BasicCompositeCommand.RegisterCommand(BasicCommand2);
            BasicCompositeCommand.RegisterCommand(BasicCommand3);

            EnabledCommand = new DelegateCommand(EnabledFunction, CanExecute);
            DisabledCommand = new DelegateCommand(DisabledFunction, CannotExecute);
            DisabledCompositeCommand.RegisterCommand(DisabledCommand);
            DisabledCompositeCommand.RegisterCommand(EnabledCommand);

            DIPartCommand = new DelegateCommand(DIFunction);
            this.DICompositeCommands = DICompositeCommands;
            //DICompositeCommands.DICompositeCommand.RegisterCommand(DIPartCommand);
            this.DICompositeCommands.DICompositeCommand.RegisterCommand(DIPartCommand);

            StaticPartCommand = new DelegateCommand(StaticFunction);
            StaticCompositeCommands.StaticCompositeCommnd.RegisterCommand(StaticPartCommand);

            ActiveCommand = new DelegateCommand(ActiveFunction);
            this.ActiveExecuteCommands = activeExecuteCommands;
            this.ActiveExecuteCommands.ActiveExecuteCommand.RegisterCommand(ActiveCommand);
            //EnabledCommand will not be executed because ActiveExecuteCommands was constructed with true option for monitorCommandActivity.
            //It seems when monitorCommandActivity option was set, each DelegateCommand's IsActive property value should be allocated.
            this.ActiveExecuteCommands.ActiveExecuteCommand.RegisterCommand(EnabledCommand);

        }

        void BasicFunction1()
        {
            System.Windows.MessageBox.Show("Basic Function 1");
        }

        void BasicFunction2()
        {
            System.Windows.MessageBox.Show("Basic Function 2");
        }
        void BasicFunction3()
        {
            System.Windows.MessageBox.Show("Basic Function 3");
        }

        void EnabledFunction()
        {
            System.Windows.MessageBox.Show("EnabledFunction");
        }
        bool CanExecute()
        {
            return true;
        }

        void DisabledFunction()
        {
            System.Windows.MessageBox.Show("DisabledFunction");
        }
        bool CannotExecute()
        {
            return false;
        }
        void DIFunction()
        {
            System.Windows.MessageBox.Show("DI Function Called");
        }

        void StaticFunction()
        {
            System.Windows.MessageBox.Show("Static Function Called");
        }

        void ActiveFunction()
        {
            System.Windows.MessageBox.Show("ActiveFunction called.");
        }
    }
}
