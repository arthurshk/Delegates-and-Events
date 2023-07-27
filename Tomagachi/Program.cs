using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Tomagachi
{
    public delegate void delegator(string task);
    public delegate void ElapsedEventHandler(Object source, System.Timers.ElapsedEventArgs e);
    class Program
    {
        private static string task;
        public static int count;

        static void Main(string[] args)
        {
            Time(); 

        }
        public static void Time()
        {
            Actions actions = new Actions();
            actions.eventz += actions.Play;
            actions.eventz += actions.Sleep;
            actions.eventz += actions.Eat;
            actions.eventz += actions.Walk;
            actions.eventz += actions.Cure;
            var random = new Random();
            List<delegator> delegators = new List<delegator>();
            delegators.Add(actions.Play);
            delegators.Add(actions.Sleep);
            delegators.Add(actions.Eat);
            delegators.Add(actions.Walk);
            delegators.Add(actions.Cure);
            delegators[random.Next(0, 4)](task);
            
            for (int i = 0; i < 120; i++)
            {

                System.Timers.Timer timer = new System.Timers.Timer(1000);
                timer.Interval = 3000;
                timer.Elapsed += Enabler;
                timer.Start();
                
                if (i == 0)
                {
                    timer.Start();
                    Console.WriteLine("The Timer has started");
                }
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(i);
                if(i % 5 == 0)
                {
                    timer.Stop();
                    DialogResult dialogResult = MessageBox.Show("Would you like to either Play, Sleep, Eat, Walk or Cure the Tomagachi?", "Alert!", MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.Yes)
                    {
                        timer.Start();
                        delegators[random.Next(0, 4)](task);
                    }
                    else if(dialogResult == DialogResult.No)
                    {
                        count++;
                        if (count == 3 || count == 6 || count == 9)
                        {
                            DialogResult dialogResult2 = MessageBox.Show("Your Tomagachi has fallen sick, would you like to cure it?", "Alert!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                timer.Start();
                                delegators[random.Next(0, 4)](task);
                                
                            }
                            else
                            {
                                Console.WriteLine("The game is over! Tomagachi is dead!");
                                timer.Stop();
                                break;
                            }
                        }
                    }
                    
                }
                if(i == 120)
                {
                    timer.Stop();
                    Console.WriteLine("The Timer has ended");
                    Console.WriteLine("Game Over");
                    break;
                }
            }
            Console.WriteLine("Game Over");
        }
        public static void Enabler(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("The Timer is going at {0}", e.SignalTime);
        }
    }
}
  