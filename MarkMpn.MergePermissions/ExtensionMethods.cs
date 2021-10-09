using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMpn.MergePermissions
{
    static class ExtensionMethods
    {
        public static void AddRange<T>(this ISet<T> set, IEnumerable<T> sequence)
        {
            foreach (var item in sequence)
                set.Add(item);
        }
    }
}
