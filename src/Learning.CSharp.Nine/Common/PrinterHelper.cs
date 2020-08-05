using System;

namespace Learning.CSharp.Nine.Common
{
    public static class PrinterHelper
    {
        public static void Print(object item)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(item);
            Console.WriteLine(json);
        }
    }
}
