// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using DemoCenter.Views;
using Prism.Ioc;
using System.Windows;
using Prism.Modularity;
using System.IO;
using System.Globalization;
using System.Windows.Markup;
using System.Windows.Threading;
using CssToWpf.Core.Data;
using Prism.Events;
using CssToWpf.Core.Events;
using Prism.DryIoc;
using System.Collections.Generic;

namespace DemoCenter
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
            containerRegistry.RegisterSingleton<ModuleStructure>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var modulePath = @"./Modules/";

            if (!Directory.Exists(modulePath))
            {
                Directory.CreateDirectory(modulePath);
            }

            var result = new DirectoryModuleCatalog{ModulePath = modulePath};
            List<IModuleCatalogItem> items = new List<IModuleCatalogItem>();

            foreach (string dirPath in Directory.GetDirectories(modulePath))
            {
                var dirCatalog = new DirectoryModuleCatalog { ModulePath = dirPath };
                dirCatalog.Initialize();
                items.AddRange(dirCatalog.Items);
            }

            foreach (var item in items)
            {
                result.Items.Add(item);
            }

            return result;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        CultureInfo.CurrentCulture.IetfLanguageTag)));
            base.OnStartup(e);
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            var eventAggregator = Container.Resolve<IEventAggregator>();
            eventAggregator.GetEvent<ModuleCatalogInitializedEvent>().Publish();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            if (this.MainWindow != null)
            {
                MessageBox.Show(this.MainWindow, e.Exception.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(e.Exception.Message, "ERROR*", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
