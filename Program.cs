using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Demander la somme remise et le montant de l'achat
        Console.Write("Entrez la somme remise: ");
        int sommeRemise = int.Parse(Console.ReadLine());

        Console.Write("Entrez le montant de l'achat: ");
        int montantAchat = int.Parse(Console.ReadLine());

        // Calculer la monnaie à rendre
        int montantARendre = sommeRemise - montantAchat;

        // Vérifier si la somme remise est suffisante
        if (montantARendre < 0)
        {
            Console.WriteLine("La somme remise est insuffisante pour couvrir le montant de l'achat.");
        }
        else
        {
            Console.WriteLine($"Le montant total à rendre est de {montantARendre} francs.");
            CalculerMonnaieARendre(montantARendre);
        }
    }

    static void CalculerMonnaieARendre(int montant)
    {
        // Définir les coupures disponibles
        List<int> coupures = new List<int> { 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 1 };

        // Initialiser un dictionnaire pour le rendu
        Dictionary<int, int> rendu = new Dictionary<int, int>();

        // Décomposer le montant
        foreach (int coupure in coupures)
        {
            if (montant >= coupure)
            {
                int nombreDeCoupure = montant / coupure;
                montant -= nombreDeCoupure * coupure;
                rendu[coupure] = nombreDeCoupure;
            }
        }

        // Afficher le résultat
        foreach (var item in rendu)
        {
            int coupure = item.Key;
            int nombre = item.Value;
            if (coupure >= 1000)
            {
                Console.WriteLine($"{nombre} billet{(nombre > 1 ? "s" : "")} de {coupure}");
            }
            else
            {
                Console.WriteLine($"{nombre} pièce{(nombre > 1 ? "s" : "")} de {coupure}");
            }
        }
    }
}
