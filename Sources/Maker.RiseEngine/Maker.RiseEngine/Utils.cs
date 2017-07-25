using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine
{
    public static class Utils
    {

        public static int GetSize(this object obj)
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(obj.GetType());
        }

        public static int GetSize(this Type type)
        {
            return System.Runtime.InteropServices.Marshal.SizeOf(type);
        }

    }
}
