using System;

namespace TPtestUnitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Produit p1 = new Produit("AT23", "Parpaing", 0.50m, 0.30m);
            Produit p2 = new Produit("AT1", "Ciment", 7.50m, 0.10m);


            p1.Rentrer(25);
            p2.Rentrer(36);

            p1.Sortir(10);

            Console.WriteLine($"{p1.Reference} | {p1.Libelle} | {p1.Stocks} | {p1.PrixVente}");
            Console.WriteLine($"{p2.Reference} | {p2.Libelle} | {p2.Stocks} | {p2.PrixVente}");
        }
    }
}