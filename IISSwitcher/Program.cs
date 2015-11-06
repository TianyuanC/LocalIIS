using System;

namespace IISSwitcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var user = new User();
            user.Check();
            
            var local = new LocalIIS();           
            local.RunTask();
            
            Console.ReadLine();
        }
    }
}
