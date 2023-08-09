using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismCompositeCommand.Commands
{
    public class BasicCompositeCommands
    {
        private CompositeCommand _basicCompositCommand = new CompositeCommand();
        public CompositeCommand BasicCompositeCommand
        {
            get { return _basicCompositCommand; }
        }

    }
}
