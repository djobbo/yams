using System;
using System.Linq;

class Lancer
{
    int[] dés = new int[5];

    public Lancer()
    {
        Relancer(new int[5]{0, 1, 2, 3, 4});
    }
    
    public void Relancer(int[] indexDésChangés)
    {
        Random rand = new Random();

        Console.Write("║ │\n║ │ [");
        for (int i = 0; i < 5; i++)
        {
            bool change = indexDésChangés.Contains(i);

            if (change)
                dés[i] = rand.Next(5) + 1;
            
            Console.Write(i == 0 ? "{0}{1}" : ", {0}{1}", dés[i], change ? "⮀" : "✓");
        }
        Console.WriteLine("]\n║ │");
    }
    
    public int Résultat(bool peutUtiliserChance = false) {

        bool chance = false;

        if (Yams.Yahtzee(dés))
        {
            Console.WriteLine("║ │ Yahtzee! +50pts");
            return 50;
        }

        if (Yams.Suite(dés, 5))
        {
            Console.WriteLine("║ │ Suite! +40pts");
            return 40;
        }
        
        if (Yams.Suite(dés, 4))
        {
            Console.WriteLine("║ │ Yahtzee! +30pts");
            return 30;
        }

        if (Yams.Full(dés))
        {
            Console.WriteLine("║ │ Full! +25pts");
            return 25;
        }
                
        if (Yams.Carré(dés))
        {
            int somme = SommeDés();
            Console.WriteLine("║ │ Carré! +{0}pts", somme);
            return SommeDés();
        }

        if (Yams.Brelan(dés))
        {
            int somme = SommeDés();
            Console.WriteLine("║ │ Brelan! +{0}pts", somme);
            return SommeDés();
        }
        
        if (peutUtiliserChance) {
            Console.WriteLine("║ │ Utiliser \"Chance\" [Y/N]");
            string chanceStr = Console.ReadLine();
            chance = chanceStr.ToLower() == "y";
        }

        if (chance) {
            int somme = SommeDés();
            Console.WriteLine("║ │ Chance! +{0}pts", somme);
            return SommeDés();
        }
        
        Console.WriteLine("║ │ Raté! +0pts");
        return 0;
    }

    int SommeDés() {
        int somme = 0;

        for (int i = 0; i < dés.Length; i++)
        {
            somme += dés[i];
        }
        
        return somme;
    }
}