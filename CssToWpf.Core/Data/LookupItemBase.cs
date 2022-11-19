// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

namespace CssToWpf.Core.Data;

public abstract class LookupItemBase
{
    protected LookupItemBase(string title)
    {
        Title = title;
    }

    public string Title { get; }
}