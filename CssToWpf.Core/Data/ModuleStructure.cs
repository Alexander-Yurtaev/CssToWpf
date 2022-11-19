// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.Data;

namespace CssToWpf.Core.Data
{
    public class ModuleStructure : Dictionary<string, List<ModuleInfo>>
    {
        public void AddStructureItem(string name, ModuleInfo moduleInfo)
        {
            if (!this.ContainsKey(name))
            {
                this[name] = new List<ModuleInfo>();
            }

            var list = this[name];
            if (list.Any(l => l.View == moduleInfo.View)) throw new DuplicateNameException(moduleInfo.View);
            list.Add(moduleInfo);
        }
    }
}
