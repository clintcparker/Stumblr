using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stumblr
{
    public class GenericTools
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            // T temp = lhs;
            var temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static T GetDefault<T>()
        {
            return default(T);
        }
    }
}
