using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public struct Variable
    {
        public string Name;
        public Type Type;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SEM CLONE");
            var itemA = new Item
            {
                Codigo = "A",
                Quantidade = 100,
                Endereco = "End-A",
                Lote = "Lote-A"
            };

            var itemB = AlteraValorSemClone("B", 400, itemA);

            Console.WriteLine(itemA);
            Console.WriteLine(itemB);
                        
            Console.WriteLine("COM CLONE");
            itemA = new Item
            {
                Codigo = "A",
                Quantidade = 100,
                Endereco = "End-A",
                Lote = "Lote-A"
            };
            itemB = AlteraValorComClone("B", 400, itemA);

            Console.WriteLine(itemA);
            Console.WriteLine(itemB);

            Console.ReadLine();
        }

        public static Item AlteraValorComClone(string codigo, int quantidade, Item item)
        {
            var itemB = item.CloneObject();

            itemB.Codigo = codigo;
            itemB.Quantidade = quantidade;

            return itemB;
        }

        public static Item AlteraValorSemClone(string codigo, int quantidade, Item item)
        {
            var itemB = item;

            itemB.Codigo = codigo;
            itemB.Quantidade = quantidade;

            return itemB;
        }

    }

    public class Item
    {
        public string Codigo { get; set; }
        public int Quantidade { get; set; }
        public string Endereco { get; set; }
        public string Lote { get; set; }

        public override string ToString()
        {
            return $"Codigo {Codigo} - Lote {Lote} - Quantidade: {Quantidade}";
        }

    }

    public static class ClassExtention
    {
        public static T CloneObject<T>(this T obj)
        {
            T newObj = (T)Activator.CreateInstance(typeof(T));
            var properties = GetProperties(typeof(T));

            foreach (var property in properties)
            {
                var propInfo = typeof(T).GetProperty(property.Name);
                var value = propInfo.GetValue(obj);
                if(value != null)
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
