﻿using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismCompositeCommand.Commands
{
    public interface IActiveExecuteCommands
    {
        public CompositeCommand ActiveExecuteCommand { get; }
    }
}
