using System;
using System.Collections.Generic;

class Yams
{
    public static int Nombre_Itérations(int nombre, int[] nombres)
    {
        int nIterations = 0;
        
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i] == nombre) nIterations++;
        }

        return nIterations;
    }

    public static bool Suite(int[] nombres, int longueurSuite)
    {
        for (int i = 1; i < nombres.Length; i++)
        {
            if (nombres[i] != nombres[i-1]+1 && i >= nombres.Length - longueurSuite) return false; //TODO: test
        }

        return true;
    }

    static bool DésIdentiques(int[] nombres, int quantité) {
        for (int i = 0; i < nombres.Length; i++)
        {
            if (Nombre_Itérations(nombres[i], nombres) >= quantité) return true;
        }
        return false;
    }

    public static bool Brelan(int[] nombres)
    {
        return DésIdentiques(nombres, 3);
    }
    
    public static bool Carré(int[] nombres)
    {
        return DésIdentiques(nombres, 4);
    }
    
    public static bool Yahtzee(int[] nombres)
    {
        return DésIdentiques(nombres, 5);
    }

    public static bool Full(int[] nombres)
    {
        int nombre = -1;

        for (int i = 0; i < nombres.Length; i++)
        {
            if (Nombre_Itérations(nombres[i], nombres) == 3)
            {
                nombre = nombres[i];
                break;
            }
        }

        if (nombre == -1)
            return false;

        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombre != nombres[i] && Nombre_Itérations(nombres[i], nombres) == 2) return true;
        }

        return false;
    }
}