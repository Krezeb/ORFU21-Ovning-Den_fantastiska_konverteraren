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

                                Console.Write("Svar: ");

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
                                Console.Write("Svar: ");

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
                                        
                                        //Console.WriteLine("Debug- exchangeVarOne: " + exchangeVarOne);
                                        //Console.WriteLine("Debug- valutaEtt     : " + valutaEtt);

                                        //Console.ReadLine();
                                        //break; //breaks out of miniminiLoop and back to miniLoop
                                    }
                                    Console.WriteLine("1: Gör en ny konvertering");
                                    Console.WriteLine("0: Återgå till huvudmeny\n");
                                    Console.Write("Svar: ");

                                    int returnQ = Convert.ToInt32(Console.ReadLine());

                                    bool returnMenu = true;

                                    if (returnMenu)
                                    {
                                        if (returnQ == 1)
                                        {
                                            returnMenu = false;
                                            miniMiniLoop = false;
                                        }
                                        if (returnQ == 0)
                                        {
                                            returnMenu = false;
                                            miniMiniLoop = false;
                                            miniLoop = false;
                                            //break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("-----------------------------");
                                            Console.WriteLine("Valutor");
                                            Console.WriteLine("-----------------------------\n");
                                            Console.WriteLine("Ogiltig val. Försök igen..");
                                        }
                                    }
                                }
                            }
                            break; //Breaks "Case 1" in "Switch(menyVal)"
                        }
                    case (2):
                        {
                            bool miniLoop = true;

                            while (miniLoop)
                            {
                                double svar = 0;
                                string fromUnit = "", toUnit = "";
                                double siffra = 0;
                                string svarString = "";
                                string siffraString = "";
                                double svarRound = 0;

                                Console.Clear();
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Längder");
                                Console.WriteLine("-----------------------------\n");
                                Console.WriteLine("Välj vilken enhet du ska konvertera FRÅN\n");
                                Console.WriteLine("1: Millimeter");
                                Console.WriteLine("2: Centimeter");
                                Console.WriteLine("3: Meter");
                                Console.WriteLine("4: Kilometer");
                                Console.WriteLine();
                                Console.Write("Svar: ");
                                int fromInput = Convert.ToInt32(Console.ReadLine());

                                Console.Clear();
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Längder");
                                Console.WriteLine("-----------------------------\n");

                                if (fromInput == 1) //Conversions from mm
                                {
                                    fromUnit = "mm";
                                    Console.WriteLine("Välj vilken enhet du ska konvertera TILL\n");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("1: Millimeter");
                                    Console.ResetColor();
                                    Console.WriteLine("2: Centimeter");
                                    Console.WriteLine("3: Meter");
                                    Console.WriteLine("4: Kilometer");
                                    Console.WriteLine();
                                    Console.Write("Svar: ");
                                    int toInput = Convert.ToInt32(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine("Längder");
                                    Console.WriteLine("-----------------------------\n");

                                    if (toInput == 1)
                                    {
                                        Console.WriteLine("Kan inte konvertera till samma enhet.");
                                        Console.WriteLine("Var god försök igen..");
                                        Console.ReadLine();
                                        break;
                                    }

                                    if (toInput == 2)
                                    {
                                        toUnit = "cm";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 10; //mm to cm t.ex. 10 mm = 1 cm
                                    }

                                    if (toInput == 3)
                                    {
                                        toUnit = "m";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 1000; //mm to m t.ex. 100 mm = 0.1 m
                                    }
                                    if (toInput == 4)
                                    {
                                        toUnit = "Km";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 1000000; //mm to Km t.ex. 1000 mm = 0.1 Km
                                    }
                                }
                                if (fromInput == 2) //Conversions from cm
                                {
                                    fromUnit = "cm";
                                    Console.WriteLine("Välj vilken enhet du ska konvertera TILL\n");
                                    Console.WriteLine("1: Millimeter");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("2: Centimeter");
                                    Console.ResetColor();
                                    Console.WriteLine("3: Meter");
                                    Console.WriteLine("4: Kilometer");
                                    Console.WriteLine();
                                    Console.Write("Svar: ");
                                    int toInput = Convert.ToInt32(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine("Längder");
                                    Console.WriteLine("-----------------------------\n");

                                    if (toInput == 1)
                                    {
                                        toUnit = "mm";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 0.1; //cm to mm t.ex. 10 cm = 100 mm
                                    }

                                    if (toInput == 2)
                                    {
                                        Console.WriteLine("Kan inte konvertera till samma enhet.");
                                        Console.WriteLine("Var god försök igen..");
                                        Console.ReadLine();
                                        break;
                                    }

                                    if (toInput == 3)
                                    {
                                        toUnit = "m";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 100; //cm to m t.ex. 10 cm = 100 mm
                                    }
                                    if (toInput == 4)
                                    {
                                        toUnit = "Km";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 1000000; //cm to Km t.ex. 1000 cm = 0.01 Km
                                    }
                                }
                                if (fromInput == 3) //Conversions from m
                                {
                                    fromUnit = "m";
                                    Console.WriteLine("Välj vilken enhet du ska konvertera TILL\n");
                                    Console.WriteLine("1: Millimeter");
                                    Console.WriteLine("2: Centimeter");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("3: Meter");
                                    Console.ResetColor();
                                    Console.WriteLine("4: Kilometer");
                                    Console.WriteLine();
                                    Console.Write("Svar: ");
                                    int toInput = Convert.ToInt32(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine("Längder");
                                    Console.WriteLine("-----------------------------\n");

                                    if (toInput == 1)
                                    {
                                        toUnit = "mm";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 0.001; //m to mm t.ex. 1 m = 100 mm
                                    }

                                    if (toInput == 2)
                                    {
                                        toUnit = "cm";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 0.01; //m to cm t.ex. 1 cm = 100 cm
                                    }

                                    if (toInput == 3)
                                    {
                                        Console.WriteLine("Kan inte konvertera till samma enhet.");
                                        Console.WriteLine("Var god försök igen..");
                                        Console.ReadLine();
                                        break;
                                    }

                                    if (toInput == 4)
                                    {
                                        toUnit = "km";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 1000; //m to Km t.ex. 1000 m = 1 Km
                                    }
                                }
                                if (fromInput == 4) //Conversions from km
                                {
                                    fromUnit = "Km";
                                    Console.WriteLine("Välj vilken enhet du ska konvertera TILL\n");
                                    Console.WriteLine("1: Millimeter");
                                    Console.WriteLine("2: Centimeter");
                                    Console.WriteLine("3: Meter");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.WriteLine("4: Kilometer");
                                    Console.ResetColor();
                                    Console.WriteLine();
                                    Console.Write("Svar: ");
                                    int toInput = Convert.ToInt32(Console.ReadLine());

                                    Console.Clear();
                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine("Längder");
                                    Console.WriteLine("-----------------------------\n");

                                    if (toInput == 1)
                                    {
                                        toUnit = "mm";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 0.000001; //km to mm t.ex. 0,001 km = 1000 mm
                                    }

                                    if (toInput == 2)
                                    {
                                        toUnit = "cm";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");

                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 0.00001; //km to cm t.ex. 0,01 km = 1000 cm
                                    }
                                    if (toInput == 3)
                                    {
                                        toUnit = "m";
                                        Console.WriteLine($"Hur många {fromUnit} ska konverteras till {toUnit}?\n");
                                        Console.Write("Svar: ");
                                        siffra = Convert.ToDouble(Console.ReadLine());

                                        svar = siffra / 0.001; //km to m t.ex. 1 km = 1000m
                                    }
                                    if (toInput == 4)
                                    {
                                        Console.WriteLine("Kan inte konvertera till samma enhet.");
                                        Console.WriteLine("Var god försök igen..");
                                        Console.ReadLine();
                                        break;
                                    }


                                }
                                svarRound = Math.Round(svar, 2);
                                svarString = svar.ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"));
                                siffraString = siffra.ToString("N2", CultureInfo.CreateSpecificCulture("sv-SE"));
                                Console.Clear();
                                Console.WriteLine("-----------------------------");
                                Console.WriteLine("Längder");
                                Console.WriteLine("-----------------------------\n");
                                Console.WriteLine($"{siffraString} {fromUnit} = {svarString} {toUnit}");

                                Console.WriteLine();
                                Console.WriteLine("1: Gör en ny konvertering");
                                Console.WriteLine("0: Återgå till huvudmeny\n");
                                Console.Write("Svar: ");
                                int returnQ = Convert.ToInt32(Console.ReadLine());
                                
                                bool returnMenu = true;

                                if (returnMenu)
                                {
                                    if (returnQ == 1)
                                    {
                                        returnMenu = false;
                                    }
                                    if (returnQ == 0)
                                    {
                                        returnMenu = false;
                                        miniLoop = false;
                                        //break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("-----------------------------");
                                        Console.WriteLine("Längder");
                                        Console.WriteLine("-----------------------------\n");
                                        Console.WriteLine("Ogiltig val. Försök igen..");
                                    }
                                }
                            }
                            break; //Breaks "Case 2" in "Switch(menyVal)"
                        }
                }
            }
        }
    }
}
