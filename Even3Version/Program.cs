using System;
using System.Threading;
namespace Even3Version
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
        public static void Music()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125);
            Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375);
            Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250);
            Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42);
            Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125);
            Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125);
            Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125);

        }
        public static string StartGame()
        {
            int Score1 = 0;
            int Score2 = 0;
            bool result = true, result2;
            Ping ping = new Ping();
            Pong pong = new Pong();
            ping.Vivod += DisplayMessage;
            pong.Vivod += DisplayMessage;


            do
            {
                int userHit = 0;
                Console.WriteLine("Enter number between 1 to 3 for Player1 hit");
                do
                {
                    result2 = Int32.TryParse(Console.ReadLine(), out userHit);
                    if (result2 == true && userHit <= 3 && userHit >= 1)
                    {
                        result = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct number");
                    }
                }
                while (result == true);
                Random random = new Random();
                int Number = random.Next(1, 3);
                ping.Hits();
                Console.Beep(300, 500);
                pong.Hits();
                Console.Beep(520, 130);
                if (Number == userHit)
                {
                    Console.WriteLine("Player1 deflected the blow. Player1 earned 1 point");

                    Score1 += 1;
                }
                else
                {
                    Console.WriteLine("Player1 missed an opponent hit. ");
                    Score2 += 1;
                }
                Console.WriteLine($"Player1 Score = {Score1} Player2 Score = {Score2} ");

            }

            while (Score1 != 3 && Score2 != 3);

            if (Score1 == 3) { return "Player1"; }

            else { return "Player2"; }

        }
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO PING PONG GAME \n ***********************\n");
            Console.WriteLine("Rules of game:\nThe game involves two teams: WHITE  and BLUE\nTwo participants of each team compete with each other.\n" +
                "\nWinning players from each team at the end  of the Tournament compete with each other,\n" +
                "the winning player receives the Cup of the tournament!!! \n" +
                "The participant who collected 3 points wins" +
                "\n****************");
            string swt;
            bool result1 = true;

            do
            {
                Console.WriteLine("Choose:\n 1.Start the game\n 2.Exit. ");
                swt = Console.ReadLine();
                switch (swt)
                {
                    case "1":
                        bool result = true;
                        do
                        {
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
                                Console.WriteLine("WHITE team begin the game\n -----------");
                                string Winner = StartGame();
                                Console.WriteLine($"\n****{Winner} WIN****");
                                Console.WriteLine("BLUE  team begin the game\n -----------");
                                string Winner1 = StartGame();
                                Console.WriteLine($"\n****{Winner1} WIN****");
                                Console.WriteLine("FINAL GAME BETWEEN WINNERS\n -----------");
                                string Winner3 = StartGame();
                                Console.WriteLine("-----------------------------------------------------------------");
                                Console.WriteLine($"\n*******Congratulations!!!!! {Winner3} won the final game*****");
                                Music();
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
                        Console.WriteLine("Choose only 1 or 2");
                        break;
                }
            }
            while (result1);
        }
    }
}
