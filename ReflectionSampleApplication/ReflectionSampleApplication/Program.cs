using System;
using System.Reflection;
using System.Linq;

namespace ReflectionSampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            // print current assembly name
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Type: "+type.Name);
                var props = type.GetProperties();
                // print properties of current type
                foreach (var prop in props)
                {
                    Console.WriteLine("\tProperty: "+prop.Name+ "\tPropertyType: "+prop.PropertyType);
                }

                var fields = type.GetFields();
                //print fields in current type
                foreach (var field in fields)
                {
                    Console.WriteLine("\tField: ",field);
                }

                var methods = type.GetMethods();
                // print methods in current type
                foreach (var method in methods)
                {
                    Console.WriteLine("\tMethod: "+method.Name+ "\tReturnType: "+method.ReturnType);
                }

            
            }

            //Acess property value using type
            Sample sample = new Sample { Name = "Ajay", Age = 24 };
            var sampleType = sample.GetType();
            var sampleProp = sampleType.GetProperty("Name");
            Console.WriteLine("Sample has name: {0}", sampleProp.GetValue(sample, null));

            //get classes Having Myclass Attribute
            var type1 = assembly.GetTypes().Where(x => x.GetCustomAttributes<MyClassAttribute>().Count() > 0);
            foreach (var type in type1)
            {
                Console.WriteLine("This Class have MyAttribute: "+type.Name);
            }
            Console.ReadKey();
        }
    }

    [MyClass]
    public class Sample {
        public string Name { get; set; }
        public int Age;
        [MyMethod]
        public void MyMethod() { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MyClassAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyMethodAttribute : Attribute { }
}
