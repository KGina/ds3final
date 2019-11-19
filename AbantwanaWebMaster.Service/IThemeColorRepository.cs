using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IThemeColorRepository : IDisposable
    {
        ThemeColor GetById(Int32 id);
        List<ThemeColor> GetAll();
        void Insert(ThemeColor model);
        void Update(ThemeColor model);
        void Delete(ThemeColor model);
        IEnumerable<ThemeColor> Find(Func<ThemeColor, bool> predicate);   

    }
}
