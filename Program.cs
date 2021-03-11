using System;

class Program
{
    static void Main(string[] args)
    {
        int nTours = 13;
        int nJoueurs = 2;
        
        Joueur[] joueurs = new Joueur[nJoueurs];

        for (int i = 0; i < nJoueurs; i++) {
            Console.Write("Entrez le nom du joueur {0}: ", i + 1);
            string name = Console.ReadLine();
            joueurs[i] = new Joueur(name);
        }

        Console.WriteLine();

        for (int tour = 0; tour < nTours; tour++) {

            Console.WriteLine("╔═════ Tour: {0} ══════", tour + 1);

            for (int joueur = 0; joueur < nJoueurs; joueur++) {
                Console.WriteLine("║\n║ ╒═════ Joueur: {0} ══════", joueurs[joueur].nom, tour + 1);

                Lancer lancer = new Lancer();

                for (int i = 0; i < 2; i++) {
                    Console.Write("║ │ Entrez les indices (1-5) des dés que vous voulez changer:");
                    string line = Console.ReadLine();
                    
                    if (line == "") break;
                    
                    int[] nombres = new int[5]{-1, -1, -1, -1, -1};

                    for(int j = 0; j < line.Length; j++) {
                        try {
                            nombres[j] = Int32.Parse(line[j].ToString()) - 1;
                        }
                        catch {
                            Console.WriteLine("║ │ {0} n'est pas un nombre entier entre 0 et 5", line[j]);
                        }
                    }
                    
                    lancer.Relancer(nombres);
                }
                
                int résultat = lancer.Résultat();
                joueurs[joueur].points += résultat;

                Console.WriteLine("║ │\n║ │ {0} a marqué {1}pts et a maintenant {2}pts", joueurs[joueur].nom, résultat, joueurs[joueur].points);
                Console.WriteLine("║ ╘═════════════════════");
            }

            Console.WriteLine("║\n╚═════════════════════");
        }
    }
}