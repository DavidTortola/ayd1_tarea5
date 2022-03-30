using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

        }


        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        
        [TestMethod]
        public void Prueba_Funcional()
        {
            //Prueba de cordura
            double beginningBalance = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            double amount = 20.00;
            int time = 5;
            double expected = beginningBalance + (amount * System.Math.Pow(1 + 0.05, time));
            account.Ahorro(amount, time);
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.01, "El ahorro no se efectuo con exito");
        }

        [TestMethod]
        public void Prueba_NoFuncional()
        {
            //Prueba de carga
            string[] nombres = new string[] { "Hugo", "Martín", "Leo", "Daniel", "CAROLINA", "MARCELA", "ADRIANA ", "Alejandro", "Mateo", "Lucas", };
            BankAccount[] cuentas = new BankAccount[10];
            var rand = new Random();
            double beginningBalance = 0;
            double expected = 0;
            double amount = 0;
            double actual = 0;
            int time = 0;
            for (int i = 0; i < nombres.Length; i++)
            {
                rand = new Random();
                beginningBalance = rand.Next(100, 1000);
                cuentas[i] = new BankAccount(nombres[i], beginningBalance);
                amount = Math.Round((1 + rand.NextDouble()) * rand.Next(100, 1000), 2);
                time = rand.Next(1, 30);
                expected = beginningBalance + (amount * System.Math.Pow(1 + 0.05, time));
                cuentas[i].Ahorro(amount, time);
                actual = cuentas[i].Balance;
                Assert.AreEqual(expected, actual, 0.01, "El ahorro no se efectuo con exito para " + nombres[i]);
            }
        }

        [TestMethod]
        public void PruebaUnitaria()
        {
            // Error por tiempo menor a 0
            double beginningBalance = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            double amount = 20.00;
            int time = -5;
            double expected = beginningBalance + (amount * System.Math.Pow(1 + 0.05, time));
            account.Ahorro(amount, time);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Ahorro(amount, time));
        }
    }
}