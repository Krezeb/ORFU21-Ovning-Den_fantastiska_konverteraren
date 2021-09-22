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
                Console.WriteLine("Den fantastiska konverteraren");
                Console.WriteLine("-----------------------------\n");
                Console.WriteLine("1: Valutor");
                Console.WriteLine("2: Längder");
                Console.WriteLine("3: Måttenheter");
                Console.WriteLine("\n");
                Console.WriteLine("Vad vill du göra?");
                Console.Write("Svar: ");
                menyVal = Convert.ToInt32(Console.ReadLine());

                switch (menyVal)
                {
                    case (1):
                        {
                            //string inputVal;
                            int valutaEttInt, valutaTwoInt;
                            bool miniLoop = true;

                            /// exchangeArray ska vara FRÅN - valutaArray ska vara TILL
                            while (miniLoop)
                            {
                                string[] valutaArray = new string[4] { null, "(SEK) Svenska Kronor", "(USD) Amerikanska Dollar", "(GPB) Brittiska Pund" };
                                string[] localeCode = new string[4] { null, "sv-SE", "en-US", "en-GB" };

                                //double[] exchangeArrayTo = new double[4] { 0, 10, 5, 2 };
                                //double[] exchangeArrayFrom = new double[4] { 0, 11, 6, 3 };

                                double[] exchangeArrayFromSEK = new double[4] { 1, 2, 3, 4 };
                                double[] exchangeArrayFromUSD = new double[4] { 5, 6, 7, 8 };
                                double[] exchangeArrayFromGBP = new double[4] { 9, 10, 11, 12 };

                                double exchangeVarOne = 100.0;

                                Console.Clear();
                                Console.WriteLine("Valutor");
                                Console.WriteLine("-----------------------------\n");
                                Console.WriteLine("Vilken valuta vill du konvertera?\n");

                                for (int i = 1; i < valutaArray.Length; i++)
                                {
                                    Console.WriteLine(i + ": " + valutaArray[i]);
                                }
                                Console.WriteLine();
                                Console.Write("Svar: ");
                                
                                var valutaEtt = Convert.ToInt32(Console.ReadLine());
                                
                                if (valutaEtt == 1)
                                {
                                    exchangeVarOne = exchangeArrayFromSEK[valutaEtt];
                                }
                                if (valutaEtt == 2)
                                {
                                    exchangeVarOne = exchangeArrayFromUSD[valutaEtt];
                                }
                                if (valutaEtt == 3)
                                {
                                    exchangeVarOne = exchangeArrayFromGBP[valutaEtt];
                                }


                                Console.WriteLine(exchangeVarOne);
                                Console.ReadLine();
                                //----------------------------------------------------------

                                Console.Clear();
                                Console.WriteLine("Valutor");
                                Console.WriteLine("-----------------------------\n");
                                Console.WriteLine("Vilken valuta vill du konvertera till?\n");

                                for (int i = 1; i < valutaArray.Length; i++)
                                {
                                    if (valutaEtt == i)
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
                                Console.Write("Svar: ");
                                var valutaTwo = Convert.ToInt32(Console.ReadLine());

                                while (miniLoop)
                                {

                                    double svar;
                                    int amountInput;

                                    if (valutaTwo == valutaEtt)
                                    {
                                        Console.WriteLine("FELFELFELFELFELFELFELFELFEL");
                                        Console.WriteLine("Var god försök igen..");
                                        Console.ReadLine();
                                        break;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Valutor");
                                        Console.WriteLine("-----------------------------\n");
                                        Console.WriteLine($"Hur mycket {valutaArray[valutaEtt]} vill du vandla? till {valutaArray[valutaTwo]}");
                                        Console.WriteLine();
                                        
                                        Console.WriteLine(exchangeVarOne);

                                        amountInput = Convert.ToInt32(Console.ReadLine());

                                        svar = exchangeVarOne * amountInput;

                                        string svarFormatted = svar.ToString("C", CultureInfo.GetCultureInfo(localeCode[valutaTwo]));
                                        string amountFormatted = amountInput.ToString("C", CultureInfo.GetCultureInfo(localeCode[valutaEtt]));

                                        //----------------------------------------------------------

                                        Console.Clear();
                                        Console.WriteLine("Valutor");
                                        Console.WriteLine("-----------------------------\n");
                                        Console.WriteLine($"{amountFormatted} blir {svarFormatted}");
                                        Console.ReadLine();
                                        break;
                                    }

                                }





                                //Console.Write("Svar: ");
                                //valutaEtt = Console.ReadLine();


                                //Console.Clear();
                                //Console.WriteLine("Valutor");
                                //Console.WriteLine("-----------------------------\n");
                                //Console.WriteLine("Vilken valuta vill du konvertera till?");
                                //Console.WriteLine("1: (SEK) Svenska Kronor");
                                //Console.WriteLine("2: (USD) Amerikanska Dollar");
                                //Console.WriteLine("3: (GPB) Brittiska Pund");
                                //Console.WriteLine();
                                //Console.Write("Svar: ");
                                //valutaEtt = Console.ReadLine();





                            }
                            break;
                        }
                }
            }
        }
    }
}
