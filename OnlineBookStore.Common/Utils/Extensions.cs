using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Common.Utils
{
    public static class Exstensions
    {
        public static string StringJoin(this IEnumerable<string> list)
        {
            if (!list.Any())
                return string.Empty;
            else
                return string.Join(Environment.NewLine, list);
        }
    }
}
