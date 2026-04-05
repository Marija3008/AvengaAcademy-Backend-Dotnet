using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    public class Customer
    {
        public string FullName { get; private set; }
        public string CardNumber { get; private set; }

        private int Pin;
        private double Balance;


        public Customer() { }

        public Customer(string fullName, string cardNumber, int pin, double balance)
        {
            FullName = fullName;
            CardNumber = cardNumber;
            Pin = pin;
            Balance = balance;
        }

        public bool ValidatePin(int enteredPin)
        {
            return Pin == enteredPin;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }
    }
}
