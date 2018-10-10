using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Af_List_BankKonto_Transaction_List_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //BankAccount.BankName = "Roskilde Bank";
            //BankAccount.BankName = "h1pd080118 Bank";
            // Da BankName i klassen BankAccount er defineret som en statisk variabel
            // (en statisk variabel er en der virker på klassen og ikke på de enkelte 
            // objekter af klassen !!!), skal jeg følgelig arbejde direkte på klassen 
            // og ikke på et objekt af klassen.

            List<List<BankAccount>> bankAccount_obj_List_Of_List = new List<List<BankAccount>>();
            // Her opretter jeg en liste af liste af objekter klassen BankAccount
            // Dette giver mening, hvis f.eks alle kunder i samme rækker af liste er 
            // kunde i samme bank. 
            // Eksempelvis kunne alle kunder i første række i oisten være kunder i 
            // Danske Bank, mens alle kunder i anden række i listen kunne være kunder
            // i Spar Nord.

            BankAccount.BankName = "Danske Bank";
            // Da bankNames er defineret son en statisk liste i klassen BankAccount,
            // skal vi følgelig arbejde direkte på klassen, når vi tildeler værdier
            // til BankName.
            // Sætningen BankAccount.BankName = "Danske Bank"; vil lægge navnet
            // Danske Bank ind som element i listen over bank navne. Således vil
            // alle bankAccount objekter i række 0 i bankAccount_obj_List_Of_List
            // nu være kunder i Danske Bank.

            BankAccount.BankName = "Spar Nord Bank";
            // Da bankNames er defineret son en statisk liste i klassen BankAccount,
            // skal vi følgelig arbejde direkte på klassen, når vi tildeler værdier
            // til BankName.
            // Sætningen BankAccount.BankName = "Spar Nord Bank"; vil lægge navnet
            // Danske Bank ind som element i listen over bank navne. Således vil
            // alle bankAccount objekter i række 1 i bankAccount_obj_List_Of_List
            // nu være kunder i Spar Nord Bank.

            BankAccount.BankName = "Række 2 Bank";
            // Da bankNames er defineret son en statisk liste i klassen BankAccount,
            // skal vi følgelig arbejde direkte på klassen, når vi tildeler værdier
            // til BankName.
            // Sætningen BankAccount.BankName = "Række 2 Bank"; vil lægge navnet
            // Række 2 Bank ind som element i listen over bank navne. Således vil
            // alle bankAccount objekter i række 2 i bankAccount_obj_List_Of_List
            // nu være kunder i Række 2 Bank.

            BankAccount bankAccount_obj = new BankAccount();
            // Her opretter jeg et objekt af klassen BankAccount, der anvender default
            // constructor for BankAccount klassen.

            bankAccount_obj.KontoNummer = 12345;
            bankAccount_obj.setName("Joakim Von And");
            bankAccount_obj.deposit(12345678.5);
            PrintAccountInfo(bankAccount_obj, 0);

            bankAccount_obj_List_Of_List.Add(new List<BankAccount>());
            // Opret ny række (række 0) i den 2 dimensionelle liste af BankAccount
            // objekter.

            bankAccount_obj_List_Of_List[0].Add(bankAccount_obj);
            // Adder et objekt af klassen BankAccount til min BankAccount liste i række 0.

            BankAccount bankAccount_obj_Mathias = new BankAccount();
            // Her opretter jeg et objekt af klassen BankAccount, der anvender default
            // constructor for BankAccount klassen.

            bankAccount_obj_List_Of_List[0].Add(bankAccount_obj_Mathias);
            // Adder et objekt af klassen BankAccount til min BankAccount liste i række 0. 

            bankAccount_obj_Mathias.KontoNummer = 54321;
            bankAccount_obj_Mathias.setName("Mathias Von Græsholt");
            bankAccount_obj_Mathias.deposit(1000);
            bankAccount_obj_Mathias.withdraw(1200);
            bankAccount_obj_Mathias.withdraw(200);
            PrintAccountInfo(bankAccount_obj_Mathias, 0);

            bankAccount_obj_Mathias.deposit(5000);
            PrintAccountInfo(bankAccount_obj_Mathias, 0);

            bankAccount_obj_List_Of_List.Add(new List<BankAccount>());
            // Opret ny række (række 1) i den 2 dimensionelle liste af BankAccount
            // objekter.

            BankAccount bankAccount_obj_Martin = new BankAccount("Martin", 300, 43345);
            // Her opretter jeg et objekt af klassen BankAccount, der anvender den
            // constructor for BankAccount klassen, som overloader default constructoren
            // for BankAcount klassen.

            bankAccount_obj_Martin.KontoNummer = 800;
            bankAccount_obj_Martin.KontoNummer = 1200;

            BankAccount bankAccount_obj_Malthe;
            bankAccount_obj_Malthe = bankAccount_obj_Martin;

            PrintAccountInfo(bankAccount_obj_Martin, 1);
            PrintAccountInfo(bankAccount_obj_Malthe, 1);

            bankAccount_obj_List_Of_List[1].Add(bankAccount_obj_Martin);
            // Adder et objekt af klassen BankAccount til min BankAccount liste i række 1.

            bankAccount_obj_List_Of_List[1].Add(bankAccount_obj_Malthe);
            // Adder et objekt af klassen BankAccount til min BankAccount liste i række 1.

            bankAccount_obj_List_Of_List.Add(new List<BankAccount>());
            // Opret ny række (række 2) i den 2 dimensionelle liste af BankAccount
            // objekter.

            bankAccount_obj_List_Of_List[2].Add(new BankAccount("Oprettet og lagt i listen samtidig", 800, 5555));
            // Opret og adder et objekt af klassen BankAccount til min BankAccount liste i række 2.

            Console.WriteLine("Nu udskriver vi alle BankAccount objekter i vores liste ----->");
            Console.WriteLine("");

            for (int RowCounter = 0; RowCounter < bankAccount_obj_List_Of_List.Count; RowCounter++)
            {
                for (int ColumnCounter = 0; ColumnCounter < bankAccount_obj_List_Of_List[RowCounter].Count; ColumnCounter++)
                {
                    Console.WriteLine("Konto indehaver nummer : ({0}; {1}) ", RowCounter, ColumnCounter);
                    PrintAccountInfo(bankAccount_obj_List_Of_List[RowCounter][ColumnCounter], RowCounter);
                }
            }

            Console.ReadLine();
        }

        private static void PrintAccountInfo(BankAccount bankAccount_obj, int RowCounter)
        {
            Console.WriteLine("Konto oplysninger for : {0}. Der er kunde i {1}", bankAccount_obj.getName(), BankAccount.BankNames[RowCounter]);
            Console.WriteLine("Konto Nummer : {0}", bankAccount_obj.KontoNummer);
            Console.WriteLine("Indestående på Konto : {0}kr", bankAccount_obj.getIndesaaende());
            PrintAccountTransactions(bankAccount_obj);
            Console.WriteLine("");
        }

        private static void PrintAccountTransactions(BankAccount bankAccount_obj)
        {
            Console.WriteLine("Transaktioner på {0} konto : ", bankAccount_obj.getName());
            for (int Counter = 0; Counter < bankAccount_obj.BankAccountTransactionList.Count; Counter++)
            {
                if (bankAccount_obj.BankAccountTransactionList[Counter] >= 0)
                {
                    Console.WriteLine("Der er her indsat {0}kr på kontoen", bankAccount_obj.BankAccountTransactionList[Counter]);
                }
                else
                {
                    Console.WriteLine("Der er her hævet {0}kr på kontoen", Math.Abs(bankAccount_obj.BankAccountTransactionList[Counter]));
                }
            }
        }
    }
}
