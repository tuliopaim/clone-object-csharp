using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassClone
{
    public static class CloneExtension
    {
        /// <summary>
        /// Create a new instance of an object.
        /// </summary>
        public static void CloneObject<T>(this T obj, T newObj) where T : class
        {
            var props = typeof(T)
                .GetProperties()
                .Where(p => p.CanWrite)
                .ToList();

            props.ForEach(prop => prop.SetValue(newObj, prop.GetValue(obj)));
        }
    }
}
