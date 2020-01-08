﻿using System;
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

            typeof(T).GetProperties().ToList().ForEach(prop =>
            {
                var value = prop.GetValue(obj);
                if (value != null) prop.SetValue(newObj, value);
            });

            return newObj;
        }
    }
}
