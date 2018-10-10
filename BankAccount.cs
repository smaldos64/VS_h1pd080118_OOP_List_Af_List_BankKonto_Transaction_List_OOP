using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Af_List_BankKonto_Transaction_List_OOP
{
    public class BankAccount
    {
        private List<double> bankAccountTransactionList = new List<double>();

        private double indestaaende;
        private int kontoNummer;
        private String kundeNavn;
        // Da de 4 variable herover alle er erklæret som private, kan de kun tilgås
        // ved brug af metoder inde i klassen selv. 

        private static List<string> bankNames = new List<string>();

        public static List<string> BankNames
        {
            get
            {
                return (bankNames);
            }
            //set
            //{
            //    if (value == "Roskilde Bank")
            //    {
            //        Console.WriteLine("Banken er gået konkurs og direktørerne er fortsat i fængsel !!!");
            //    }
            //    else
            //    {
            //        bankNames.Add(value);
            //    }
            //}
        }

        public static string BankName
        {
            set
            {
                bankNames.Add(value);
            }
        }

        public List<double> BankAccountTransactionList
        {
            get
            {
                return (this.bankAccountTransactionList);
            }
        }

        public BankAccount()
        {
            this.indestaaende = 500;
            this.bankAccountTransactionList.Add(this.indestaaende);
        }


        // Har laver vi en overload af klassens default constuctor !!!
        public BankAccount(string kundeNavn, double indestaaende, int detteKontoNummer)
        {
            this.kundeNavn = kundeNavn;
            this.indestaaende = indestaaende;
            this.kontoNummer = detteKontoNummer;
            this.bankAccountTransactionList.Add(this.indestaaende);
        }

        public int KontoNummer
        {
            get
            {
                return (this.kontoNummer);
            }

            set
            {
                if (value >= 1000)
                {
                    this.kontoNummer = value;
                }
                else
                {
                    Console.WriteLine("Kontonummer må ikke være mindre end 1000 !!!");
                }
            }
        }
        // Get-Set blokken herover gør det samme de 2 udkommenterede metoder herunder. 
        // Og det er en virkelig sej feature ved C#. For brugeren af klassen ser det ud til,
        // at han/hun direkte tilgår klassens variable. Men det gør man ikke og man derfor
        // mulighed for at lave beskyttelse af klassens variable.

        //public int getKontoNummer()
        //{
        //    return (this.kontoNummer);
        //}

        //public void setKontoNummer(int kontoNummer)
        //{
        //    this.kontoNummer = kontoNummer;
        //}

        public void setName(string name)
        {
            this.kundeNavn = name;
        }

        public string getName()
        {
            //return (kundeNavn);
            return (this.kundeNavn);
            // Jeg vælger altid at bruge this. foran et variabel navn, der refererer til
            // en ikke statisk variabel erklæret i klassen, da jeg dervdd gøt det let
            // både for mig og for andre at læse min kode !!!.
        }

        public double withdraw(double drawAmount)
        {
            if (getIndesaaende() >= drawAmount)
            {
                this.indestaaende = this.indestaaende - drawAmount;
                this.bankAccountTransactionList.Add(drawAmount * -1);
            }
            else
            {
                Console.WriteLine("Du kan ikke lave overtræk : {0}", this.kundeNavn);
            }

            return (getIndesaaende());
        }

        public double deposit(double depositAmount)
        {
            this.indestaaende = this.indestaaende + depositAmount;
            this.bankAccountTransactionList.Add(depositAmount);

            return (getIndesaaende());
        }

        public double getIndesaaende()
        {
            return (this.indestaaende);
        }

        public void ClearAllTransactionsOnAccount()
        {
            this.bankAccountTransactionList.Clear();
        }
    }
}

