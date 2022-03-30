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
    }
}