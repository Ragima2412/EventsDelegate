using System;

namespace EvetsPingPong
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
        static int GameMove()
        {
            int _GameMove = 0;
            bool IsNumber = false;
            while (!IsNumber)
            {
                Console.WriteLine("How many steps will be taken in the game ");
                bool result = Int32.TryParse(Console.ReadLine(), out _GameMove);
                if (result == false)
                {
                    Console.WriteLine("You enter inccorect data");
                }
                else
                {
                    IsNumber = true;
                }
            }

            return _GameMove;
        }
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to PING PONG GAME\n");
            int _GameMove = GameMove();

            Ping ping1 = new Ping();
            Pong pong1 = new Pong();
            Ping ping2 = new Ping();
            Pong pong2 = new Pong();

            ping1.Vivod += DisplayMessage;
            pong1.Vivod += DisplayMessage;

            Console.WriteLine("First team\n *****");
            for (int i = 0; i < _GameMove; i++)
            {
                ping1.Hits();
                pong1.Hits();
            }
            ping2.Vivod += DisplayMessage;
            pong2.Vivod += DisplayMessage;
            Console.WriteLine("Second  team\n *****");
            for (int i = 0; i < _GameMove; i++)
            {
                ping2.Hits();
                pong2.Hits();
            }
        }
    }
}


