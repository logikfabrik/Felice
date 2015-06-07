//----------------------------------------------------------------------------------
// <copyright file="IPageHelper.cs" company="Logikfabrik">
//     Copyright (c) 2015 anton(at)logikfabrik.se
// </copyright>
//----------------------------------------------------------------------------------

namespace Logikfabrik.Felice.Helpers
{
    using System.Collections.Generic;

    public interface IPageHelper
    {
        T GetPageOfType<T>() 
            where T : class, new();

        IEnumerable<T2> GetChildPagesOfType<T1, T2>() 
            where T1 : class, new() 
            where T2 : class, new();
    }
}