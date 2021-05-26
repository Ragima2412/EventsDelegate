using System;

namespace EventNew 
{ 
    class Ping 
{
        public delegate void Hit(string message);
        public event Hit Vivod;
        public void Hits()
        {
            Vivod?.Invoke("Ping received Pong");
        }
    }
class Pong
{
        public delegate void Hit(string message);
        public event Hit Vivod;
        public void Hits()
        {
            Vivod?.Invoke("Pong received Ping");
        }
    }
    class Program
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
           string swt;
            bool result1 = true;
            Console.WriteLine("Welcome to Ping Pong Game");
            do {
                Console.WriteLine("Choose:\n 1.Start the game\n 2.Exit. ");
                swt = Console.ReadLine();
                switch (swt) 
                {
                    case "1":
                        bool result = true; 
                        do
                        {
                            Console.WriteLine("Seychas vash xod. Dla udara vvedite lubuyu knopku. Dla prekraweniya igri vvedite knopku E");
                            string Hit;
                            do
                            {
                                Hit = Console.ReadLine();                                
                                if (Hit.Length > 1)
                                {
                                    Console.WriteLine("Enter correct data");
                                }
                            }
                            while (Hit.Length > 1); 

                            if (Hit != "E")
                            {                               
                                Ping ping = new Ping();
                                Pong pong = new Pong();

                                ping.Vivod += DisplayMessage;
                                pong.Vivod += DisplayMessage;

                                ping.Hits();
                                Console.WriteLine("The second player made a move");
                                pong.Hits();
                            }
                            else 
                            {
                                result = false;                            
                            }
                        }
                        while (result);
                        break;

                    case "2":
                        Console.WriteLine("Exit from game");
                        result1 = false;
                        break;

                    default:
                        Console.WriteLine("Choose only 1 or 2" );
                        break;
                }
            }
            while (result1);
        }
    }
}
