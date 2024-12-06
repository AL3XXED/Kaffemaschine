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

        public void wiederholen()
        {
            while (true)
            {
                Kaffee();
                AuffüllenBohnen();
                AuffüllenWasser();
                Console.ReadLine();
            }
        }
        public void AuffüllenBohnen()
        {
            int füllmengeBohnen = MaxBohnenmenge - this.BohnenMenge;
            if (this.bohnenMenge < 500)
            {
                Console.WriteLine($"\nBohnenstatus: {this.BohnenMenge}g.");
                Console.WriteLine($"Bitte füllen Sie {füllmengeBohnen}g Bohnen in Ihren Kaff-o-mat");
            }
            else
            {
                Console.WriteLine("Der Kaff-o-mat ist bereits voll");
            }
        }
        public void AuffüllenWasser()
        {
            int füllmengeWasser = MaxWasserstand - this.Wasserstand;
            if (this.wasserstand < 2000)
            {
                Console.WriteLine($"\nWasserstatus: {this.wasserstand}ml.");
                Console.WriteLine($"Bitte füllen Sie {füllmengeWasser}ml Wasser in Ihren Kaff-o-mat");
            }
            else
            {
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

                Console.WriteLine(kaffeetasse);

            }
            else
            {
                if (!PrüfeWasserstand())
                {
                    Console.WriteLine("Nicht genug Wasser. Bitte nachfüllen.");
                }
                if (!PrüfeBohnenstand())
                {
                    Console.WriteLine("Nicht genug Bohnen. Bitte nachfüllen.");
                }
            }
        }
    }
}
