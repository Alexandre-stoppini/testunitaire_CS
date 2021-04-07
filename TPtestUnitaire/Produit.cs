using System;

namespace TPtestUnitaire
{
    public class Produit
    {
        private decimal prixAchat, pourcentageMarge;
        private int stocks;
        private string reference, libelle;

        private void VerifierChaine(string chaine, string nomVariable)
        {
            if (chaine == null)
            {
                throw new ArgumentNullException(nomVariable, $"La variable '{nomVariable} 'ne peut être nulle");
            }

            if (chaine.Length == 0)
            {
                throw new ArgumentException(nomVariable, $"La variable '{nomVariable}' ne peut etre vide");
            }
        }

        private void VerifierInt(decimal valeur, string nomVar, bool zeroTolere)
        {
            if (valeur < 0 || !zeroTolere && valeur == 0m)
            {
                throw new ArgumentOutOfRangeException(paramName: nomVar,
                    message: $"La valeur décimale de '{nomVar}' doit être positive.");
            }
        }

        public Produit(string reference, string libelle, decimal prixAchat, decimal pourcentageMarge)
        {
            VerifierChaine(reference, nameof(reference));
            VerifierChaine(libelle, nameof(libelle));
            VerifierInt(prixAchat, nameof(prixAchat), zeroTolere: false);
            VerifierInt(pourcentageMarge, nameof(pourcentageMarge), zeroTolere: true);
            this.reference = reference;
            this.libelle = libelle;
            this.prixAchat = prixAchat;
            this.pourcentageMarge = pourcentageMarge;
            stocks = 0;
        }

        #region Accesseurs

        public string Reference => reference;
        public string Libelle => libelle;
        public int Stocks => stocks; // { get { return stocks; } }
        public decimal PrixVente => prixAchat * (1m + pourcentageMarge);
        public decimal PrixAchat => prixAchat;

        #endregion

        #region Stocks

        /// <summary>
        /// Sort la quantité spécifiée des stocks pour le produit concerné. Prend en compte la rupture de stock.
        /// </summary>
        /// <param name="quantite">Quantité à retirer</param>
        /// <returns>Valeur réellement retirée inférieure (rupture) ou égale à la quantité</returns>
        public int Sortir(int quantite)
        {
            if (quantite < 0)
            {
                Rentrer(-quantite);
                return quantite;
            }
            else if (quantite <= stocks)

            {
                stocks -= quantite;
                return quantite;
            }
            else
            {
                stocks = 0;
                return quantite;
            }
        }

        public void Rentrer(int quantite)
        {
            if (quantite < 0)
            {
                Sortir(-quantite);
            }
            else
            {
                stocks += quantite;
            }
        }

        public bool EstEnRupture => stocks == 0;

        #endregion
    }
}