using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomagachi
{
    public class Actions
    {
        public event delegator eventz;
        public void Toma(string task)
        {
            if (eventz != null)
            {
                eventz.Invoke(task);
            }
        }

        public void Sleep(string task)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("I am Sleeping zzzzzzzzzzzzzzzzz!");
            Console.ResetColor();
        }
        public void Eat(string task)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("I am eating YUM!");
            Console.ResetColor();
        }
        public void Walk(string task)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("I am walking and exersizing in my neighborhood!");
            Console.ResetColor();
        }
        public void Cure(string task)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("I am now healthy again YAY!");
            Console.ResetColor();
            
        }
        public void Play(string task)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("I am playing basketball with my owner!");
            Console.ResetColor();
            
        }
    }
}
