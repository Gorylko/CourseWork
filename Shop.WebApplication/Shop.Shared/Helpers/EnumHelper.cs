using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Shared.Helpers
{
    public static class EnumHelper/*<T> where T : Enum*/
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        //public static void MoveToFirstPlace<T>(this T[]array, T value)
        //{

        //}
    }
}
