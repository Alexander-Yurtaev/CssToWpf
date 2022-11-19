// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using CssToWpf.Core.Data;
using Prism.Ioc;
using Prism.Modularity;
using ModuleInfo = CssToWpf.Core.Data.ModuleInfo;

namespace TestModule
{
    public class TestModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var moduleStructure = containerProvider.Resolve<ModuleStructure>();
            moduleStructure.AddStructureItem("Test", new ModuleInfo("ViewA", "Test/ViewA"));
            moduleStructure.AddStructureItem("Test", new ModuleInfo("ViewB", "Test/ViewB"));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.ViewA>("Test/ViewA");
            containerRegistry.RegisterForNavigation<Views.ViewB>("Test/ViewB");
        }
    }
}