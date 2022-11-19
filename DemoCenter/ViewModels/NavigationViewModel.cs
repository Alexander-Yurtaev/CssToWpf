// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using CssToWpf.Core.Data;
using CssToWpf.Core.Events;
using System.Collections.ObjectModel;

namespace DemoCenter.ViewModels
{
    public class NavigationViewModel : BindableBase
    {
        private readonly IContainerProvider _container;
        private readonly IRegionManager _regionManager;
        private readonly ModuleStructure _moduleStructure;
        private readonly ModuleCatalogInitializedEvent _moduleCatalogInitializedEvent;
        private LookupItemBase _selectedLookupItem;

        public NavigationViewModel(IContainerProvider container,
                                   IEventAggregator eventAggregator,
                                   IRegionManager regionManager,
                                   ModuleStructure moduleStructure)
        {
            _container = container;
            _regionManager = regionManager;
            _moduleStructure = moduleStructure;

            LookupNodes = new ObservableCollection<LookupNode>();

            _moduleCatalogInitializedEvent = eventAggregator.GetEvent<ModuleCatalogInitializedEvent>();
            Subscribe();
        }

        public ObservableCollection<LookupNode> LookupNodes { get; set; }

        public LookupItemBase SelectedLookupItem
        {
            get => _selectedLookupItem;
            set
            {
                if (!SetProperty(ref _selectedLookupItem, value)) return;
                
                _selectedLookupItem = value;
                _regionManager.Regions["ContentRegion"].RemoveAll();

                if (_selectedLookupItem is LookupItem lookupItem)
                {
                    _regionManager.RequestNavigate("ContentRegion", lookupItem.View);
                }
            }
        }

        private void Subscribe()
        {
            _moduleCatalogInitializedEvent.Subscribe(OnModuleCatalogInitialized);
        }

        private void OnModuleCatalogInitialized()
        {
            LookupNodes.Clear();
            foreach (var valuePair in _moduleStructure)
            {
                var lookupNode = new LookupNode(valuePair.Key);
                foreach (var moduleInfo in valuePair.Value)
                {
                    var lookupItem = new LookupItem(moduleInfo);
                    lookupNode.Childs.Add(lookupItem);
                }
                LookupNodes.Add(lookupNode);
            }
        }
    }
}
