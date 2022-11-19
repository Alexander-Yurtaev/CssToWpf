// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.Collections.ObjectModel;

namespace CssToWpf.Core.Data;

public class LookupNode : LookupItemBase
{
    public LookupNode(string title) : base(title)
    {
        Childs = new ObservableCollection<LookupItem>();
    }

    public ObservableCollection<LookupItem> Childs { get; set; }
}