using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class BankAccount
    {
        private string wlasciciel;
        private decimal saldo;

        public string Wlasciciel
        {
            get { return wlasciciel; }
            set
            {
                wlasciciel = value;
            }
        }

        public decimal Saldo
        {
            get { return saldo; }
            private set { saldo = value; }
        }

        public BankAccount(string wlasciciel, decimal saldo)
        {
            Wlasciciel = wlasciciel;
            Saldo = saldo;
        }

        public void Wplata(decimal kwota)
        {
            if (kwota <= 0) { Console.WriteLine("Kwota do wpłaty nie może być ujemna"); return; }
            Saldo += kwota;
            Console.WriteLine($"Wpłacono: {kwota:C}. Aktualny stan konta: {Saldo:C}.");
        }

        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0) { Console.WriteLine("Kwota do wypłaty nie może być ujemna"); return; }
            if (kwota > Saldo) { Console.WriteLine("Niewystarczająco środków na koncie"); return; }
            Saldo -= kwota;
            Console.WriteLine($"Wypłacono: {kwota:C}. Aktualny stan konta: {Saldo:C}.");
        }

        public void View()
        {
            Console.WriteLine($"Właściciel:{wlasciciel}\t\tSaldo:{saldo:C}");
        }
    }
}