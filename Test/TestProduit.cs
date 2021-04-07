using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPtestUnitaire;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private Produit NouveauProduit(string reference = "AT20", string libelle = "Mortier", decimal prixAchat = 4.00m,
            decimal pourcentageMarge = 0.15m)
            => new Produit(reference, libelle, prixAchat, pourcentageMarge);

        #region Initialisation

        #region CasNominal

        [TestMethod]
        public void InitialisationProduit()
        {
            var test = NouveauProduit();

            Assert.AreEqual("AT20", test.Reference);
            Assert.AreEqual("mortier", test.Libelle);
            Assert.AreEqual(4.00m, test.PrixAchat);
            Assert.AreEqual(0, test.Stocks);
        }

        #endregion

        #region CasExtreme

        [TestMethod]
        public void InitialisationProduitMargeZero()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0m;
            int stocks = 0;

            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.AreEqual("AT20", reference);
            Assert.AreEqual("mortier", libelle);
            Assert.AreEqual(4.00m, prixAchat);
            Assert.AreEqual(0m, pourcentageMarge);
            Assert.AreEqual(0, stocks);
        }

        #endregion

        #region CasErreur

        [TestMethod]
        public void InitialisationProduitReferenceVide()
        {
            string reference = "", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentException>(act);
        }

        [TestMethod]
        public void InitialisationProduitLibelleVide()
        {
            string reference = "AT20", libelle = "";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentException>(act);
        }

        [TestMethod]
        public void InitialisationProduitPrixAchatZero()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 0, pourcentageMarge = 0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void InitialisationProduitPourcentageMargeNeg()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = -0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void InitialisationProduitPrixAchatNeg()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = -4.00m, pourcentageMarge = 0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void InitialisationProduitReferenceNull()
        {
            string reference = null, libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentNullException>(act);
        }

        [TestMethod]
        public void InitialisationProduitLibelleNull()
        {
            string reference = "AT20", libelle = null;
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            int stocks = 0;

            Action act = () => new Produit(reference, libelle, prixAchat, pourcentageMarge);

            Assert.ThrowsException<ArgumentNullException>(act);
        }

        #endregion

        #endregion

        #region Test Rentrer

        #region Cas Nominal

        [TestMethod]
        public void RentrerCasNominal()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;

            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(30);

            Assert.AreEqual(30, test.Stocks);
        }

        #endregion

        #region Cas Extreme

        [TestMethod]
        public void RentrerCasQuantiteNull()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;

            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(0);

            Assert.AreEqual(0, test.Stocks);
        }


        [TestMethod]
        public void RentrerCasQuantiteNeg()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;

            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(-15);

            Assert.AreEqual(0, test.Stocks);
        }

        #endregion

        #endregion

        #region Test EstEnRupture

        #region Cas Nominal

        [TestMethod]
        public void EstEnRuptureCasNominalStockNul()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(10);

            test.Sortir(10);
            bool b = test.EstEnRupture;

            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void EstEnRuptureCasNominalStockNonNul()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(10);

            test.Sortir(5);
            bool b = test.EstEnRupture;

            Assert.AreEqual(false, b);
        }

        [TestMethod]
        public void EstEnRuptureCasNominalStockCreation()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);

            bool b = test.EstEnRupture;

            Assert.AreEqual(true, b);
        }

        #endregion

        #endregion

        #region Test Sortir

        #region Cas Nominal

        [TestMethod]
        public void SortirCasNominal()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(30);

            test.Sortir(10);

            Assert.AreEqual(20, test.Stocks);
        }

        #endregion

        #region Cas Extreme

        [TestMethod]
        public void SortirCasQuantiteNull()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(30);

            test.Sortir(0);

            Assert.AreEqual(30, test.Stocks);
        }

        [TestMethod]
        public void SortirCasQuantiteNeg()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(30);

            test.Sortir(-10);

            Assert.AreEqual(40, test.Stocks);
        }

        [TestMethod]
        public void SortitCasStockNeg()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);
            test.Rentrer(10);

            test.Sortir(15);

            Assert.AreEqual(0, test.Stocks);
        }

        #endregion

        #endregion

        #region Test Prix Vente

        [TestMethod]
        public void PrixVente()
        {
            string reference = "AT20", libelle = "mortier";
            decimal prixAchat = 4.00m, pourcentageMarge = 0.15m;
            int stocks = 0;

            var test = new Produit(reference, libelle, prixAchat, pourcentageMarge);

            decimal PrixVente = test.PrixVente;

            Assert.AreEqual(4.60m, PrixVente);
        }

        #endregion
    }
}