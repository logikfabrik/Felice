using System.Collections.Generic;

namespace Logikfabrik.Felice.Helpers
{
    public interface IPageHelper
    {
        T GetPageOfType<T>() 
            where T : class, new();

        IEnumerable<T2> GetChildPagesOfType<T1, T2>() 
            where T1 : class, new() 
            where T2 : class, new();
    }
}