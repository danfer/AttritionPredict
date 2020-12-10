using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDCA.Common
{
    public static class ExtensionMethods
    {
        public static string[] ToPropertyList<T>(this Type objType, string labelName)
            => objType.GetProperties().Where(x => x.Name != labelName)
            .Select(x => x.Name).ToArray();
    }
}
