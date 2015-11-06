using System;

namespace IISSwitcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var local = new LocalIIS();           
            local.RunTask();
            Console.ReadLine();
        }
    }
}
