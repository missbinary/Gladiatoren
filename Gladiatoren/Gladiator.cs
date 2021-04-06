using System;
using System.Collections;

namespace Gladiatoren
{
    class Gladiator
    {
        // gdgdgdgf
        Random rand = new Random();
        string gladName;
        int gladLevel;
        int gladLebenP;
        string gladArt;
        bool gladIstDran;
        ArrayList gladAngriffe = new ArrayList();

        public int GladLebenP { get => gladLebenP; set => gladLebenP = value; }
        public bool GladIstDran { get => gladIstDran; set => gladIstDran = value; }
        public string GladName { get => gladName; set => gladName = value; }
        public int GladLevel { get => gladLevel; set => gladLevel = value; }

        /// <summary>
        /// Der Konstruktor für die Gladiatorklasse. 
        /// Legt auch die Art der Angriffe fest.
        /// </summary>
        /// <param name="gladName"></param>
        /// <param name="gladLevel"></param>
        /// <param name="gladLebenP"></param>
        /// <param name="gladArt"></param>
        public Gladiator(string gladName, int gladLevel, int gladLebenP, string gladArt)
        {
            this.GladName = gladName;
            this.GladLevel = gladLevel;
            this.GladLebenP = gladLebenP;
            this.gladArt = gladArt;
            switch (this.gladArt)
            {
                case "Feuer":
                    gladAngriffe.Add(new Angriff("Feuersturm", 50));
                    gladAngriffe.Add(new Angriff("Flammenball", 30));
                    gladAngriffe.Add(new Angriff("Brennklinge", 20));
                    gladAngriffe.Add(new Angriff("Hitze", 10));
                    break;

                case "Wasser":
                    gladAngriffe.Add(new Angriff("Donnerwelle", 50));
                    gladAngriffe.Add(new Angriff("Wasserstrahl", 10));
                    gladAngriffe.Add(new Angriff("Flut", 20));
                    gladAngriffe.Add(new Angriff("Aquaknarre", 30));
                    break;


                case "Luft":
                    gladAngriffe.Add(new Angriff("Tornado", 50));
                    gladAngriffe.Add(new Angriff("Orkan", 30));
                    gladAngriffe.Add(new Angriff("Sturm", 20));
                    gladAngriffe.Add(new Angriff("Luftwirbel", 10));
                    break;

                case "Erde":
                    gladAngriffe.Add(new Angriff("Lawine", 50));
                    gladAngriffe.Add(new Angriff("Grabbohrer", 30));
                    gladAngriffe.Add(new Angriff("Bagger", 20));
                    gladAngriffe.Add(new Angriff("Schaufler", 10));
                    break;

                default:
                    gladAngriffe.Add(new Angriff("Faustbombe", 50));
                    gladAngriffe.Add(new Angriff("Superkick", 30));
                    gladAngriffe.Add(new Angriff("Rückhand", 20));
                    gladAngriffe.Add(new Angriff("Piekser", 10));
                    this.gladArt = "Standard";
                    break;
            }
        }
        /// <summary>
        /// Zieht den errechneten Schaden von den Lebenspunkten des Angegriffenen ab.
        /// </summary>
        /// <param name="schadenhoehe"></param>
        public void gladSchaden(int schadenhoehe)
        {
            this.GladLebenP = this.GladLebenP - schadenhoehe;
            Console.WriteLine(this.GladName + " hat " + schadenhoehe + " Schadenspunkte erlitten.");

        }
        /// <summary>
        /// Führt einen zufällig aus vier Angriffen ausgewählten Angriff aus.
        /// </summary>
        /// <param name="g"></param>
        public void gladGreifeAn(Gladiator g)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("////////////////////////////////////\n\n");
            Console.WriteLine(this.GladName + "s Angriffe sind: \n\n");
            
            for (int i = 0; i < this.gladAngriffe.Count; i++)
            {
                Angriff angriff = (Angriff)this.gladAngriffe[i];
                Console.WriteLine(angriff.AngriffName);

            }
            Console.WriteLine("\n");
            Console.WriteLine("////////////////////////////////////\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int angrindex = rand.Next(0, 4);
            Angriff a = (Angriff)gladAngriffe[angrindex];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*********************************************************************************\n");
            Console.WriteLine("                                                                                   ");
            Console.WriteLine("Der Kämpfer " + this.GladName + " hat die Attacke " + a.AngriffName + " ausgeführt!");
            Console.WriteLine("                                                                                   ");
            Console.WriteLine("*********************************************************************************\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (g.GladLebenP <= a.AngriffSchaden(this, g))
            {
                //Console.WriteLine("Name " + g.GladName + " Lebensp. " + g.GladLebenP + " Angriffsschaden " + a.angriffSchaden(this.gladLevel, g.gladLevel));
                g.GladLebenP = 0;
                g.gladIstLebend(g.GladLebenP);
            }
            else
            {
                //Console.WriteLine("Name: " + g.GladName + " Lebenspunkte verbleibend: " + g.GladLebenP + " Angriffsschaden " + a.AngriffSchaden(this.gladLevel, g.gladLevel));
                g.gladSchaden(a.AngriffSchaden(this, g));
                Console.WriteLine(g.GladName + " hat noch " + g.GladLebenP + " Lebenspunkte übrig.");
            }
        }

        /// <summary>
        /// Überprüft, ob ein Gladiator noch lebt.
        /// </summary>
        /// <param name="gladLebensPunkte"></param>
        /// <returns></returns>
        public bool gladIstLebend(int gladLebensPunkte)
        {

            this.GladLebenP = gladLebensPunkte;
            if (this.GladLebenP > 0)
            {
                //Console.WriteLine(this.GladName + " lebt noch");
                return true;
            }
            if (this.GladLebenP == 0)
            {
                return false;
                //Console.WriteLine(this.GladName + " ist ko.");
            }

            return true;

        }
    }
}
