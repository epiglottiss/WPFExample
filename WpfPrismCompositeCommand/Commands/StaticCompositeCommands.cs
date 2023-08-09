using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismCompositeCommand.Commands
{
    public static class StaticCompositeCommands
    {
        public static CompositeCommand StaticCompositeCommnd = new CompositeCommand();
    }
}
