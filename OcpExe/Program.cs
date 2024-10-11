using Microsoft.Extensions.DependencyInjection;
using OcpExe.Infrastructure;
using OcpExe.View;
using System;
using System.Reflection;
using Terminal.Gui;

namespace OcpExe
{
    internal class Program
    {
        // Define a generic attribute for example purposes
        public class FooAttribute<T> : System.Attribute { }

        // Example class with the generic attribute
        [Foo<int>]
        public class MyClass { }

        static void Main(string[] args)
        {
            //// Get the assembly you want to inspect (e.g., current assembly)
            //Assembly assembly = Assembly.GetExecutingAssembly();

            //// Loop through all types in the assembly
            //foreach (Type type in assembly.GetTypes())
            //{
            //    // Get custom attributes, checking if FooAttribute<T> is applied
            //    var attributes = type.GetCustomAttributes(false);

            //    foreach (var attribute in attributes)
            //    {
            //        Type attributeType = attribute.GetType();

            //        // Check if the attribute is a generic type and matches Foo<T>
            //        if (attributeType.IsGenericType &&
            //            attributeType.GetGenericTypeDefinition() == typeof(FooAttribute<>))
            //        {
            //            Console.WriteLine($"Class {type.Name} has Foo<> attribute");
            //        }
            //    }
            //}








            //var registerType = typeof(Register<>).GetGenericTypeDefinition();
            //var attributeType = typeof(MainView).CustomAttributes.Single().AttributeType;

            //var from = registerType.IsAssignableFrom(attributeType);
            //var to = attributeType.IsAssignableFrom(registerType);

            Application.Run<BootStrapper>();

            Application.Shutdown();

            //var bs = new BootStrapper();
            //await bs.Run();

            //Application.Run<ExampleWindow>();

            //// Before the application exits, reset Terminal.Gui for clean shutdown
            //Application.Shutdown();

            //// To see this output on the screen it must be done after shutdown,
            //// which restores the previous screen.
            //Console.WriteLine($@"Username: {ExampleWindow.UserName}");
        }
    }
}
