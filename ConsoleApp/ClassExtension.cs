using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class CloneExtension
    {
        public static T CloneObject<T>(this T obj)
        {
            T newObj = (T)Activator.CreateInstance(typeof(T));
            var properties = GetProperties(typeof(T));

            foreach (var property in properties)
            {
                var propInfo = typeof(T).GetProperty(property.Name);
                var value = propInfo.GetValue(obj);
                if (value != null)
                {
                    propInfo.SetValue(newObj, value);
                }
            }

            return newObj;
        }

        public static List<Variable> GetProperties(Type type)
        {
            var propertyValues = type.GetProperties();
            var result = new List<Variable>();

            foreach (var property in propertyValues)
            {
                result.Add(new Variable
                {
                    Name = property.Name,
                    Type = property.PropertyType,
                });
            }

            return result;
        }

    }
}
