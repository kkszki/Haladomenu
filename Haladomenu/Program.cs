using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haladomenu
{
    internal class Program
    {

        static string nev = "";
        static int szulEv = 0;
        static bool ffi = true;
        static double magassag = 1.7803;

        static void Main()
        {
            
            int currentPoint = 0;
           
            do
            {
                bool selected = false;
                do
                {

                    ShowMenu(currentPoint);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            selected = true;
                            break;


                        case ConsoleKey.UpArrow:
                            if (currentPoint > 0)
                            {
                                currentPoint--;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (currentPoint < 2)
                            {
                                currentPoint++;
                            }
                            break;




                        default:
                            Console.Beep();
                            break;
                    }

                } while (!selected);

                switch (currentPoint)
                {   
                    case 0:  //adatbekérés
                        InputData();
                        break;

                    case 1:  // adatkiírás
                        ShowData();
                        break;

                    case 2:  //kilépés
                        Console.Clear();
                        Console.WriteLine("Biztosan kilép (i/n): ");
                        if (Console.ReadKey().Key != ConsoleKey.I)
                        {
                            currentPoint = 0;
                        }
                        Console.Beep();
                        break;

                }
            } while (currentPoint!=2);

        }
        static void ShowData()
        {
            Console.Clear();
            Console.WriteLine("adatai:");
            Console.WriteLine($"A neve: {nev}");
            Console.WriteLine($"Születési éve: {szulEv}");
            Console.WriteLine($"Neme: {(ffi ? "Férfi" : "Nő")}");
            Console.WriteLine($"Magasság: {magassag:F2} m");
            Console.WriteLine("Enterre tovább");

            Console.ReadLine();
        }
        static void InputData()
        {
            Console.Clear();
            Console.Beep();
            Console.WriteLine("Kérem adja meg a nevét: ");
            nev = Console.ReadLine();
            bool good = false;
            do
            {
                try
                {
                    Console.WriteLine("Kérem adja meg a születési évét: ");
                    string SzulStr = Console.ReadLine();
                    szulEv = Convert.ToInt32(SzulStr);
                    good = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Számmal adja meg");
                }
            } while (!good);

            Console.WriteLine("Kérem adja meg, hogy férfi-e: (i/n)");
            ffi = Console.ReadLine().ToLower() == "i";
            Console.WriteLine("Az adatokat sikeresen rögzítettük enterre tovább");


            Console.ReadLine();
        }

        static void ShowMenu(int cPoint)
        {
            Console.Clear();
            if (cPoint == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("1 - Személyes adatok bekérése");

            if (cPoint == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("2 - Személyes adatok kiírása");

            if (cPoint == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("3 - Kilépés");

            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
