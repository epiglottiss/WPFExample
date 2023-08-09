using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfPrismCompositeCommand.Commands;
using WpfPrismCompositeCommand.Views;

namespace WpfPrismCompositeCommand
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // containerRegistry.Register<>();
            containerRegistry.Register<IDICompositeCommands, DICompositeCommands>();
            containerRegistry.Register<IActiveExecuteCommands, ActiveExecuteCommands>();

        }
    }
}
