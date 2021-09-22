using System;
using System.Globalization;

namespace ORFU21_Ovning_Den_fantastiska_konverteraren
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;


            while (isRunning)
            {
                int menyVal;

                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Den fantastiska konverteraren");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("1: Valutor");
                Console.WriteLine("2: Längder");
                Console.WriteLine("3: Måttenheter");
                Console.WriteLine("\n");
                Console.WriteLine("Vad vill du göra?\n");
                Console.Write("Svar: ");
                menyVal = Convert.ToInt32(Console.ReadLine());

                switch (menyVal)
                {
                    case (1):
                        {
                            //string inputVal;
                            bool miniLoop = true;

                            while (miniLoop)
                            {
                                //null and 0 are used to keep index 0 clear and simplify for loops and assignments later on
                                string[] valutaArray = new string[4] { null, "(SEK) Svenska Kronor", "(USD) Amerikanska Dollar", "(GPB) Brittiska Pund" };
                                string[] shortCode = new string[4] { null, "SEK", "USD", "GBP" };
                                string[] localeCode = new string[4] { null, "sv-SE", "en-US", "en-GB" };

                                double[] exchangeArrayToSEK = new double[4] { 0, 0, 8.66, 11.8 };
                                double[] exchangeArrayToUSD = new double[4] { 0, 0.12, 0, 1.36 };
                                double[] exchangeArrayToGBP = new double[4] { 0, 0.085, 0.73, 0 };

                                double exchangeVarOne = 0.0;

                                Console.Clear();
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Valutor");
                                Console.WriteLine("-----------------------------\n");
                                Console.WriteLine("Vilken valuta vill du konvertera?\n");

                                for (int i = 1; i < valutaArray.Length; i++) //For each index in valutaArray, a line is written describing it.
                                {
                                    Console.WriteLine(i + ": " + valutaArray[i]);
                                }
                                Console.WriteLine();
                                Console.WriteLine("0: Return to Main Menu\n");

                                Console.Write("Svar: \n");

                                var valutaEtt = Convert.ToInt32(Console.ReadLine());

                                if (valutaEtt == 0) // If 0 is chosen, loop is broken and user is returned to Main Menu
                                {
                                    break;
                                }

                                //----------------------------------------------------------

                                Console.Clear();
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Valutor");
                                Console.WriteLine("-----------------------------\n");
                                Console.WriteLine("Vilken valuta vill du konvertera till?\n");

                                for (int i = 1; i < valutaArray.Length; i++)
                                {
                                    if (valutaEtt == i) //If an index was previously chosen, it's greyed out here.
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine(i + ": " + valutaArray[i]);
                                        Console.ResetColor();
                                    }
                                    if (valutaEtt != i)
                                    {
                                        Console.WriteLine(i + ": " + valutaArray[i]);
                                    }
                                }

                                Console.WriteLine();
                                Console.Write("Svar: \n");

                                int valutaTwo = Convert.ToInt32(Console.ReadLine());

                                if (valutaTwo == 1)
                                {
                                    exchangeVarOne = exchangeArrayToSEK[valutaEtt];
                                }
                                if (valutaTwo == 2)
                                {
                                    exchangeVarOne = exchangeArrayToUSD[valutaEtt];
                                }
                                if (valutaTwo == 3)
                                {
                                    exchangeVarOne = exchangeArrayToGBP[valutaEtt];
                                }

                                bool miniMiniLoop = true;
                                while (miniMiniLoop)
                                {

                                    double svar;
                                    int amountInput;

                                    if (valutaTwo == valutaEtt) //If the same currency is chosen twice, error message
                                    {
                                        Console.Clear();
                                        Console.WriteLine("-----------------------------");
                                        Console.WriteLine("Valutor");
                                        Console.WriteLine("-----------------------------\n");
                                        Console.WriteLine("Man kan inte konvertera till samma valuta.");
                                        Console.WriteLine("Var god försök igen..");
                                        Console.ReadLine();
                                        break;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("-----------------------------");
                                        Console.WriteLine("Valutor");
                                        Console.WriteLine("-----------------------------\n");
                                        Console.WriteLine($"Current ExchangeRate from {shortCode[valutaEtt]} to {shortCode[valutaTwo]} is: {exchangeVarOne}");
                                        Console.WriteLine($"Hur mycket {valutaArray[valutaEtt]} vill du vandla till {valutaArray[valutaTwo]}");
                                        Console.WriteLine();

                                        amountInput = Convert.ToInt32(Console.ReadLine());

                                        svar = exchangeVarOne * amountInput;

                                        string svarFormatted = svar.ToString("C", CultureInfo.GetCultureInfo(localeCode[valutaTwo]));
                                        string amountFormatted = amountInput.ToString("C", CultureInfo.GetCultureInfo(localeCode[valutaEtt]));

                                        //----------------------------------------------------------

                                        Console.Clear();
                                        Console.WriteLine("-----------------------------");
                                        Console.WriteLine("Valutor");
                                        Console.WriteLine("-----------------------------\n");
                                        Console.WriteLine($"{amountFormatted} blir {svarFormatted}");
                                        Console.WriteLine();
                                        Console.WriteLine("Tryck ENTER för att göra en ny beräknning");

                                        //Console.WriteLine("Debug- exchangeVarOne: " + exchangeVarOne);
                                        //Console.WriteLine("Debug- valutaEtt     : " + valutaEtt);

                                        Console.ReadLine();
                                        break; //breaks out of miniminiLoop and back to miniLoop
                                    }
                                }
                            }
                            break; //Breaks out of miniLoop and back into isRunning
                        }
                }
            }
        }
    }
}
