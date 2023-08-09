using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismCompositeCommand.Commands
{
    class DICompositeCommands : IDICompositeCommands
    {
        private CompositeCommand _DICompositCommand = new CompositeCommand();
        public CompositeCommand DICompositeCommand
        {
            get { return _DICompositCommand; }
        }
    }
}
