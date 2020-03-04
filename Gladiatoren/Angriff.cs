namespace Gladiatoren
{
    class Angriff
    {

        string angriffName;

        int angriffBasisSchaden;

        public Angriff(string angriffName, int angriffBasisSchaden)
        {
            this.AngriffName = angriffName;
            this.angriffBasisSchaden = angriffBasisSchaden;
        }

        public string AngriffName { get => angriffName; set => angriffName = value; }

        /// <summary>
        /// Berechnet basierend auf dem Basisschaden der aktuellen Attacke den Gesamtschaden.
        /// </summary>
        /// <param name="g1">Benötigt den Angreifer.</param>
        /// <param name="g2">Benötigt den Angegriffenen (Opfer).</param>
        /// <returns>Gibt den Gesamtschaden als int zurück.</returns>
        public int AngriffSchaden(Gladiator g1, Gladiator g2)
        {
            int schadenspunkte = angriffBasisSchaden + (g1.GladLevel* 2);

           if (g1.GladLevel > g2.GladLevel)
            {
                schadenspunkte = schadenspunkte + (g1.GladLevel - g2.GladLevel);

            }
            else if (g1.GladLevel < g2.GladLevel)
            {
                schadenspunkte = schadenspunkte - (g2.GladLevel - g1.GladLevel);
            }

            return schadenspunkte;

        }
    }
}
