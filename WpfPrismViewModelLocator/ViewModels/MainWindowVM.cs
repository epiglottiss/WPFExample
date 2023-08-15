using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismViewModelLocator.ViewModels
{
    public class MainWindowVM : BindableBase
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set {
                SetProperty(ref _text, value); 
            }
        }

        public DelegateCommand CheckCommand { get; private set; }

        public MainWindowVM()
        {
            CheckCommand = new DelegateCommand(Check, CanCheck);
            Text = "check VM attach";
        }

        void Check()
        {
            Text = "VM naming Convention";
        }

        bool CanCheck()
        {
            return true;
        }
    }
}
