// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

namespace CssToWpf.Core.Data
{
    public class ModuleInfo
    {
        public ModuleInfo(string title, string view)
        {
            Title = title;
            View = view;
        }

        public string Title { get; }
        public string View { get; }
    }
}
