using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfPrismCommand.Views;

namespace WpfPrismCommand.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region IsEnabled

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
                //RaisingCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region ObserveEnabled

        private bool _observeEnabled;

        public bool ObserveEnabled
        {
            get { return _observeEnabled; }
            set { SetProperty(ref _observeEnabled, value); }
        }
        #endregion

        #region ObserveChainEnabled

        private bool _observeChainEnabled;

        public bool ObserveChainEnabled
        {
            get { return _observeChainEnabled; }
            set { SetProperty(ref _observeChainEnabled, value); }
        }

        private bool _observeChainEnabled2;

        public bool ObserveChainEnabled2
        {
            get { return _observeChainEnabled2; }
            set { SetProperty(ref _observeChainEnabled2, value); }
        }
        #endregion

        public MainWindowViewModel()
        {
            BasicCommand = new DelegateCommand(Basic, CanBasic);
            RaisingCommand = new DelegateCommand(Raising, CanRaising).ObservesProperty(()=>IsEnabled);
            ObserveCommand = new DelegateCommand(Observe).ObservesCanExecute(() => ObserveEnabled);
            //ObserveChainCommand = new DelegateCommand(ObserveChain, CanObserveChain).ObservesProperty(() => ObserveChainEnabled);
            ObserveChainCommand = new DelegateCommand(ObserveChain).ObservesCanExecute(() => ObserveChainEnabled).ObservesCanExecute(() => ObserveChainEnabled2);
            AsyncExecuteCommand = new DelegateCommand(AsyncExecute);
            AsyncTaskCommand = new DelegateCommand(async () => await AsyncTaskExecute());
            CommandWithParam = new DelegateCommand<object>(ExecuteWithParam);
        }
        #region BasicCommand
        public DelegateCommand BasicCommand { get; private set; }

        void Basic()
        {
            System.Windows.MessageBox.Show("Basic Command.");
        }

        bool CanBasic()
        {
            return true;
        }
        #endregion

        #region RaisingCommand
        public DelegateCommand RaisingCommand { get; private set; }

        void Raising()
        {
            System.Windows.MessageBox.Show("Raising Command");
        }
        bool CanRaising()
        {
            return IsEnabled;
        }
        #endregion

        #region ObserveCommand

        public DelegateCommand ObserveCommand { get; private set; }

        void Observe()
        {
            System.Windows.MessageBox.Show("Observe Command");
        }

        #endregion

        #region ObserveChainCommand
        public DelegateCommand ObserveChainCommand { get; private set; }

        void ObserveChain()
        {
            System.Windows.MessageBox.Show("ObserveChain");
        }

        bool CanObserveChain()
        {
            return ObserveChainEnabled && ObserveChainEnabled2;
        }

        #endregion

        #region AsyncExecuteCommand
        public DelegateCommand AsyncExecuteCommand { get; private set; }

        async void AsyncExecute()
        {
            System.Windows.MessageBox.Show("Async Method Execute");
        }
        #endregion

        #region AsyncTaskCommand
        public DelegateCommand AsyncTaskCommand { get; private set; }

        Task AsyncTaskExecute()
        {
            Task task = new Task(() => AsyncMethod());
            task.Start();
            return task;
        }

        void AsyncMethod()
        {
            Thread.Sleep(3000);
            System.Windows.MessageBox.Show("Async Task");
        }
        #endregion

        #region CommandWithParam
        public DelegateCommand<object> CommandWithParam { get; private set; }

        void ExecuteWithParam(object param)
        {
            System.Windows.MessageBox.Show($"Executed with param : {param}");
        }

        #endregion
    }
}
