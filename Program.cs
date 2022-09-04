//Wiktoria Blomgren Strandberg
//wikblo-0@student.ltu.se
//L0002B Uppgift 1 - Console Application


using System;

namespace L0002B_Uppgift_1_Console_App_.NET
{
    internal class Växelberäknare
    {
        static int växel;//Totalt växelbelopp.
        static int sedel500, sedel200, sedel100, sedel50, sedel20, mynt10, mynt5, mynt1;//Valörer.


        static void Main(string[] args)//Metod med programmets huvudmeny.
        {
            Console.WriteLine("Välkommen till Växelberäknaren!");

            while (true)//Loopar så att man återkommer till huvudmenyn.
            {
                Console.WriteLine("\nTryck 1 för att beräkna växel, 2 för att avsluta: ");//Valinformation.

                //Meny med alternativ:
                string meny = Console.ReadLine();
                int väljMeny;

                if (int.TryParse(meny, out väljMeny))//Kontrollerar att inmatning innehåller, och endast innehåller, siffror.
                {
                    switch (väljMeny)
                    {
                        case 1://Tryck 1 för att beräkna växel.
                            beräknaVäxel();
                            break;

                        case 2://Tryck 2 för att avsluta.
                            Environment.Exit(0);
                            break;

                        default://Ger återkoppling vid felinmatning (fel siffra).
                            Console.WriteLine("\nFelinmatning, försök igen.");
                            break;
                    }
                }
                else//Ger återkoppling om inmatning inte innehåller, eller innehåller annat än, siffror.
                {
                    Console.WriteLine("\nFelinmatning, försök igen.");
                }
            }
        }


        private static void beräknaVäxel()//Beräkning av växel. Sker om 1 väljs i menyn.
        {
            //Inmatning av pris (belopp som ska betalas) och kontroll av input (endast siffror tillåts):
            Console.WriteLine("\nSkriv in belopp som ska betalas (kr): ");
            string inputPris = Console.ReadLine();
            int pris;

            if (!int.TryParse(inputPris, out pris))
            {
                Console.WriteLine("\nInmatning ska, och ska endast, innehålla siffor.");//Återkoppling vid felinmatning.
            }
            else
            {
                //Inmatning av betaladSumma (belopp som betalats) och kontroll av input (endast siffror tillåts):
                Console.WriteLine("\nSkriv in betalat belopp (kr): ");
                string inputBetalat = Console.ReadLine();
                int betaladSumma;

                if (!int.TryParse(inputBetalat, out betaladSumma))
                {
                    Console.WriteLine("\nInmatning ska, och ska endast, innehålla siffor.");//Återkoppling vid felinmatning.
                }
                else
                {
                    if (betaladSumma > pris)//Om växel krävs.
                    {
                        //Beräknar och skriver ut den totala växeln:
                        växel = betaladSumma - pris;
                        Console.WriteLine("\nBeräknad växel är " + växel + " kr:\n");

                        beräknaAntalValörer();//Beräknar antalet sedlar/kronor av respektive valör.
                        skrivUtAntalValörer();//Skriver ut antalet sedlar/kronor av respektive valör.
                    }
                    else if (betaladSumma == pris)//Om växel ej krävs.
                    {
                        Console.WriteLine("\nBetalat belopp överensstämmer med belopp som ska betalas, ingen växel krävs.\n");
                    }
                    else//Om betaladSumma är lägre än pris.
                    {
                        Console.WriteLine("\nBetalat belopp är lägre än beloppet som ska betalas, kontrollera inmatning.\n");
                    }
                }
            }
        }


        private static void beräknaAntalValörer()//Beräknar antalet sedlar/kronor av respektive valör.
        {
            //500-sedlar:
            sedel500 = (växel / 500);//Beräknar antalet 500-sedlar.
            int uppdateradSumma = växel % 500;//Beräknar återstående summa.

            //200-sedlar:
            sedel200 = (uppdateradSumma / 200);
            uppdateradSumma = (uppdateradSumma % 200);

            //100-sedlar:
            sedel100 = (uppdateradSumma / 100);
            uppdateradSumma = (uppdateradSumma % 100);

            //50-sedlar:
            sedel50 = (uppdateradSumma / 50);
            uppdateradSumma = (uppdateradSumma % 50);

            //20-sedlar:
            sedel20 = (uppdateradSumma / 20);
            uppdateradSumma = (uppdateradSumma % 20);

            //10-kronor:
            mynt10 = (uppdateradSumma / 10);
            uppdateradSumma = (uppdateradSumma % 10);

            //5-kronor:
            mynt5 = (uppdateradSumma / 5);
            uppdateradSumma = (uppdateradSumma % 5);

            //1-kronor:
            mynt1 = uppdateradSumma;
        }


        //Skriver ut antalet sedlar/kronor av respektive valör och ändrar ändelsen beroende på singular/plural:
        private static void skrivUtAntalValörer()
        {
            //500-sedlar:
            if (sedel500 > 1)//Om växeln består av flera 500-sedlar.
            {
                Console.WriteLine(sedel500 + " st 500-sedlar.");//Skriver ut antalet 500-sedlar med plural-ändelse.
            }
            else if (sedel500 == 1)//Om växeln består av en 500-sedel.
            {
                Console.WriteLine(sedel500 + " 500-sedel.");//Skriver ut antalet 500-sedlar med singular-ändelse.
            }

            //200-sedlar:
            if (sedel200 > 1)
            {
                Console.WriteLine(sedel200 + " st 200-sedlar.");
            }
            else if (sedel200 == 1)
            {
                Console.WriteLine(sedel200 + " 200-sedel.");
            }

            //100-sedlar:
            if (sedel100 > 1)
            {
                Console.WriteLine(sedel100 + " st 100-sedlar.");
            }
            else if (sedel100 == 1)
            {
                Console.WriteLine(sedel100 + " 100-sedel.");
            }

            //50-sedlar:
            if (sedel50 > 1)
            {
                Console.WriteLine(sedel50 + " st 50-sedlar.");
            }
            else if (sedel50 == 1)
            {
                Console.WriteLine(sedel50 + " 50-sedel.");
            }

            //20-sedlar:
            if (sedel20 > 1)
            {
                Console.WriteLine(sedel20 + " st 20-sedlar.");
            }
            else if (sedel20 == 1)
            {
                Console.WriteLine(sedel20 + " 20-sedel.");
            }

            //10-kronor:
            if (mynt10 > 1)
            {
                Console.WriteLine(mynt10 + " st 10-kronor.");
            }
            else if (mynt10 == 1)
            {
                Console.WriteLine(mynt10 + " 10-krona.");
            }

            //5-kronor:
            if (mynt5 > 1)
            {
                Console.WriteLine(mynt5 + " st 5-kronor.");
            }
            else if (mynt5 == 1)
            {
                Console.WriteLine(mynt5 + " 5-krona.");
            }

            //1-kronor:
            if (mynt1 > 1)
            {
                Console.WriteLine(mynt1 + " st 1-kronor.");
            }
            else if (mynt1 == 1)
            {
                Console.WriteLine(mynt1 + " 1-krona.");
            }
        }
    }
}
