// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

namespace CssToWpf.Core.Data
{
    public class LookupItem : LookupItemBase
    {
        private readonly ModuleInfo _moduleInfo;

        public LookupItem(ModuleInfo moduleInfo) : base(moduleInfo.Title)
        {
            _moduleInfo = moduleInfo;
        }

        public string View => _moduleInfo.View;
    }
}
