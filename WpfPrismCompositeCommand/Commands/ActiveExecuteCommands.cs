using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismCompositeCommand.Commands
{
    public class ActiveExecuteCommands : IActiveExecuteCommands
    {
        private CompositeCommand _activeExecuteCommand = new CompositeCommand(true);
        public CompositeCommand ActiveExecuteCommand 
        { 
            get { return _activeExecuteCommand; }
        }
    }
}
