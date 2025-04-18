using System;
using System.Linq;
using System.Reflection;

namespace ReflectionDemo
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RunnableAttribute : Attribute { }
    public class MathTasks
    {
        [Runnable]
        public void ShowPi()
        {
            Console.WriteLine($"Pi is approximately {Math.PI}");
        }

        [Runnable]
        public void SquareRootOf64()
        {
            Console.WriteLine($"Square root of 64 is {Math.Sqrt(64)}");
        }

        public void NotRunnable()
        {
            Console.WriteLine("You should not see this.");
        }
    }

    public class MessageTasks
    {
        [Runnable]
        public void SayHello()
        {
            Console.WriteLine("Hello from MessageTasks!");
        }

        [Runnable]
        public void Greet()
        {
            Console.WriteLine("Greetings, user!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Discovering [Runnable] methods usin reflection...\n");
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (var method in methods)
                {
                    var hasRunnableAttribute = method.GetCustomAttributes(typeof(RunnableAttribute), false).Any();

                    if (hasRunnableAttribute)
                    {
                        Console.WriteLine($"Found method: {type.Name}.{method.Name}");

           
                        var instance = Activator.CreateInstance(type);

         
                        method.Invoke(instance, null);
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine("Done running all [Runnable] methods.");
        }
    }
}
