using System;
using System.Threading;

namespace Gladiatoren
{
    class Spiel
    {
        Gladiator g1;
        Gladiator g2;

        public Spiel()
        {
            initialisieren();
        }

     /// <summary>
     /// Initialisiert das Spiel.
     /// </summary>
        void initialisieren()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("**********************************\n");
            Console.WriteLine("Willkommen beim Gladiatorenspiel\n");
            Console.WriteLine("**********************************\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            //Erster Gladiator****************************************************
            Console.WriteLine("Bitte Namen des ersten Gladiators eingeben: \n");
            Console.BackgroundColor = ConsoleColor.Black;
            string g1name = Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Bitte das Level eingeben: ");
            Console.BackgroundColor = ConsoleColor.Black;
            bool g1levelbool = Int32.TryParse(Console.ReadLine(), out int g1level);
            while (!g1levelbool)
            {
                Console.WriteLine("Das ist keine Zahl. Bitte eine Zahl für das Level eingeben!");
                g1levelbool = Int32.TryParse(Console.ReadLine(), out g1level);
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Bitte die Lebenspunkte eingeben: ");
            Console.BackgroundColor = ConsoleColor.Black;
            bool g1lebensbool = Int32.TryParse(Console.ReadLine(), out int g1lebensp);
            while (!g1lebensbool)
            {
                Console.WriteLine("Das ist keine Zahl. Bitte eine Zahl für die Lebenspunkte eingeben!");
                g1lebensbool = Int32.TryParse(Console.ReadLine(), out g1lebensp);
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Bitte eine Art eingeben. Du kannst wählen zwischen: \n 1. 'f' für Feuer \n 2. 'w' für Wasser \n 3. 'l' für Luft \n 4. 'e' für Erde.\n" +
               "Gib den gewünschten Buchstaben ein. Bei einem beliebigen anderen Wort wird Standard gewählt.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleKeyInfo g1key;
            g1key = Console.ReadKey();
            Console.WriteLine("\n");
            //string g1gladarteing = Console.ReadLine();

            string g1gladart;
            switch (g1key.Key)
            {
                case ConsoleKey.F :
                    g1gladart = "Feuer";
                    break;
                case ConsoleKey.W:
                    g1gladart = "Wasser";
                    break;
                case ConsoleKey.L:
                    g1gladart = "Luft";
                    break;
                case ConsoleKey.E:
                    g1gladart = "Erde";
                    break;
                default:
                    g1gladart = "Standard";
                    break;
            }

            g1 = new Gladiator(g1name, g1level, g1lebensp, g1gladart);
            Console.WriteLine("Erster Gladiator wurde erstellt");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // Zweiter Gladiator **************************************************
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Bitte Namen des zweiten Gladiators eingeben:\n ");
            Console.BackgroundColor = ConsoleColor.Black;
            string g2name = Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Bitte das Level eingeben: ");
            Console.BackgroundColor = ConsoleColor.Black;
            bool g2levelbool = Int32.TryParse(Console.ReadLine(), out int g2level);
            while (!g2levelbool)
            {
                Console.WriteLine("Das ist keine Zahl. Bitte eine Zahl für das Level eingeben!");
                g2levelbool = Int32.TryParse(Console.ReadLine(), out g2level);
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Bitte die Lebenspunkte eingeben: ");
            Console.BackgroundColor = ConsoleColor.Black;
            bool g2lebensbool = Int32.TryParse(Console.ReadLine(), out int g2lebensp);
            while (!g2lebensbool)
            {
                Console.WriteLine("Das ist keine Zahl. Bitte eine Zahl für die Lebenspunkte eingeben!");
                g2lebensbool = Int32.TryParse(Console.ReadLine(), out g2lebensp);
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Bitte eine Art eingeben. Du kannst wählen zwischen: \n 1. 'f' für Feuer \n 2. 'w' für Wasser \n 3. 'l' für Luft \n 4. 'e' für Erde.\n" +
                "Gib den gewünschten Buchstaben ein. Bei einem beliebigen anderen Wort wird Standard gewählt.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            //string g2gladarteing = Console.ReadLine();
            ConsoleKeyInfo g2key;
            g2key = Console.ReadKey();
            Console.WriteLine("\n");
            string g2gladart;
            switch (g2key.Key)
            {
                case ConsoleKey.F:
                    g2gladart = "Feuer";
                    break;
                case ConsoleKey.W:
                    g2gladart = "Wasser";
                    break;
                case ConsoleKey.L:
                    g2gladart = "Luft";
                    break;
                case ConsoleKey.E:
                    g2gladart = "Erde";
                    break;
                default:
                    g2gladart = "Standard";
                    break;
            }

            g2 = new Gladiator(g2name, g2level, g2lebensp, g2gladart);
            Console.WriteLine("Zweiter Gladiator wurde erstellt");
            Thread.Sleep(TimeSpan.FromSeconds(2));

        }
        ///<summary>Steuert den Spielablauf</summary>
        public void spiellauf()
        {

            Console.WriteLine("LOS GEHTS !");
            //g1 = new Gladiator("Horst", 10, 1480, "Feuer");
            //g2 = new Gladiator("Hildegard", 10, 1580, "Wasser");
            g1.GladIstDran = true;
            g2.GladIstDran = false;
            while (g1.gladIstLebend(g1.GladLebenP) && g2.gladIstLebend(g2.GladLebenP))
            {

                if (g1.GladIstDran)
                {
                    Console.WriteLine(g1.GladName + " ist dran");
                    g1.gladGreifeAn(g2);
                    g1.GladIstDran = false;
                    g2.GladIstDran = true;
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                }
                else if (g2.GladIstDran)
                {
                    Console.WriteLine(g2.GladName + " ist dran");
                    g2.gladGreifeAn(g1);
                    g2.GladIstDran = false;
                    g1.GladIstDran = true;
                    Thread.Sleep(TimeSpan.FromSeconds(1));

                }

            }

            if (!g1.gladIstLebend(g1.GladLebenP))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*****************************");
                Console.WriteLine("                             ");
                Console.WriteLine(g2.GladName + " hat gewonnen  ");
                Console.WriteLine("                             ");
                Console.WriteLine("*****************************");
                spielNochmal();
            }
            else if (!g2.gladIstLebend(g2.GladLebenP))
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*****************************");
                Console.WriteLine("                             ");
                Console.WriteLine(" "+g1.GladName + "   hat gewonnen");
                Console.WriteLine("                             ");
                Console.WriteLine("*****************************");
                spielNochmal();
            }
            {

            }

        }

        /// <summary>
        /// Wenn der Spieler nach Beendigung des Spiels erneut spielen möchte,
        /// wird diese Methode ausgeführt.
        /// </summary>
        void spielNochmal()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Nochmal? Dann tippe 'y' ein. Jede andere Eingabe beendet das Spiel");

            ConsoleKeyInfo ckey;
            ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.Y)
            {
                Console.Clear();
                initialisieren();
                spiellauf();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bis dann!");
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Console.WriteLine("****************************");
                Environment.Exit(0);


            }
        }

    }
}
