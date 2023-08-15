using Prism.Ioc;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfPrismViewModelLocator.ViewModels;
using WpfPrismViewModelLocator.Views;

namespace WpfPrismViewModelLocator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            Type viewType = typeof(MainWindow);
            var fullname = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var assmName = viewType.Assembly.FullName;
            var viewModelName = $"{fullname}VM, {assmName}";
            var vm = Type.GetType(viewModelName);

            //ViewModelLocationProvider.Register<MainWindow, MainWindowVM>();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.Assembly.FullName;
                var viewModelName = $"{viewName}VM, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });
        }
    }
}
