using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaffemaschine
{
    internal class Kaffeemaschine
    {
        private static int maxWasserstand = 2000;
        private static int maxBohnenmenge = 500;

        private int wasserstand;
        private int bohnenMenge;

        public Kaffeemaschine(int wasserstand, int bohnenMenge)
        {
            this.wasserstand = wasserstand;
            this.bohnenMenge = bohnenMenge;
        }

        public static int MaxWasserstand { get => maxWasserstand; }                  //Max-Zustand
        public static int MaxBohnenmenge { get => maxBohnenmenge; }                  //Max-Zustand
        public int Wasserstand { get => wasserstand; set => wasserstand = value; }   //Ist-Zustand
        public int BohnenMenge { get => bohnenMenge; set => bohnenMenge = value; }   //Ist-Zustand

        public void menue()
        {
            while (true)
            {
                Console.WriteLine("\r\n__     _   __         __   __                                           _       __\r\n\\ \\   | | / /        / _| / _|                                         | |     / /\r\n \\ \\  | |/ /   __ _ | |_ | |_  ______   ___   ______  _ __ ___    __ _ | |_   / / \r\n  > > |    \\  / _` ||  _||  _||______| / _ \\ |______|| '_ ` _ \\  / _` || __| < <  \r\n / /  | |\\  \\| (_| || |  | |          | (_) |        | | | | | || (_| || |_   \\ \\ \r\n/_/   \\_| \\_/ \\__,_||_|  |_|           \\___/         |_| |_| |_| \\__,_| \\__|   \\_\\\r\n                                                                                  \r\n                                                                                  \r\n\n\n");
                Console.WriteLine("\t\t\t\tWas möchten Sie tun?");
                Console.WriteLine("\t\t\t\t1: Kaffee machen");
                Console.WriteLine("\t\t\t\t2: Bohnen auffüllen");
                Console.WriteLine("\t\t\t\t3: Wasser auffüllen");
                Console.WriteLine("\t\t\t\t4: Status");
                Console.WriteLine("\t\t\t\t5: Beenden");

                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        Kaffee();
                        break;
                    case "2":
                        AuffüllenBohnen();
                        break;
                    case "3":
                        AuffüllenWasser();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine($"\nWasserstatus: {Wasserstand}ml\nBohnenstatus: {BohnenMenge}");
                        Thread.Sleep( 1000 );
                        Console.Clear();
                        break;
                    case "5":
                        Console.WriteLine("Auf Wiedersehen!");
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie 1, 2, 3 oder 4.");
                        break;
                }
            }
        }
        public void AuffüllenBohnen()
        {
            int füllmengeBohnen = MaxBohnenmenge - this.BohnenMenge;
            if (füllmengeBohnen > 0)
            {
                Console.WriteLine($"\nBohnenstatus: {this.BohnenMenge}g.");
                Console.WriteLine($"Bitte füllen Sie {füllmengeBohnen}g Bohnen in Ihren Kaff-o-mat");
                Thread.Sleep(2000);
                this.BohnenMenge = MaxBohnenmenge;
                Console.WriteLine($"Neuer Bohnenstatus: {this.BohnenMenge}g.");
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Der Bohnenbehälter ist bereits voll.");
            }
        }
        public void AuffüllenWasser()
        {
            int füllmengeWasser = MaxWasserstand - this.Wasserstand;
            if (füllmengeWasser > 0)
            {
                Console.WriteLine($"\nWasserstatus: {this.wasserstand}ml.");
                Console.WriteLine($"Bitte füllen Sie {füllmengeWasser}ml Wasser in Ihren Kaff-o-mat");
                Thread.Sleep(2000);
                this.Wasserstand = MaxWasserstand;
                Console.WriteLine($"Neuer Bohnenstatus {this.Wasserstand}ml.");
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Der Kaff-o-mat ist bereits voll");
            }
        }
        public bool PrüfeWasserstand()
        {
            int benötigtesWasser = 250;
            return this.wasserstand >= benötigtesWasser;
        }
        public bool PrüfeBohnenstand()
        {
            int benötigteBohnenmenge = 15;
            return this.bohnenMenge >= benötigteBohnenmenge;
        }
        public void Kaffee()
        {
            if (PrüfeBohnenstand() && PrüfeBohnenstand())
            {
                this.Wasserstand -= 250;
                this.BohnenMenge -= 15;
                string kaffeetasse = @"
                                        ***************************************
                                        *      ->Hier ist Ihr Kaffee<-        *
                                        *                                     *
                                        *               ( (                   *
                                        *                ) )                  *
                                        *             .-._.-.                 *
                                        *            |       |                *
                                        *            |       |                *
                                        *             `-._.-'                 *
                                        *                                     *
                                        ***************************************";
                Console.Clear();
                Console.Write("\n\n\n\n\t\t\t\t\tXXXXXXXXXX");
                Thread.Sleep(500);
                Console.Write("XXXXXXXXXX");
                Thread.Sleep(500);
                Console.Write("XXXXXXXXXX");
                Thread.Sleep(500);
                Console.Clear();


                Console.WriteLine(kaffeetasse);
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                if (!PrüfeWasserstand())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nicht genug Wasser. Bitte nachfüllen.");
                }
                if (!PrüfeBohnenstand())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nicht genug Bohnen. Bitte nachfüllen.");
                }
            }
        }
    }
}
