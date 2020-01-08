﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class CloneExtension
    {
        /// <summary>
        /// Returns a new instance of an object.
        /// Do not use it with primitive types (int, double, string...)
        /// </summary>
        public static T CloneObject<T>(this T obj)
        {
            var newObj = (T)Activator.CreateInstance(typeof(T));
            var props = typeof(T).GetProperties().ToList();

            props.ForEach(prop => prop.SetValue(newObj, prop.GetValue(obj)));

            return newObj;
        }
    }
}
