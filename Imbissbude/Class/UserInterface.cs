using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO.Pipes;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Imbissbude.Class
{
    public class UserInterface
    {
       /// <summary>
       /// In the game setting can be selected the difficulty. You can also read the Rules of the game
       /// </summary>
       /// <param name="money">is the currency of the game</param>
       /// <param name="inv"> is the Inventar of the player</param>
        public static void GameSettings(ref double money, out inventar inv)
        {
            int slots = 0;
            int answer = 0;
            bool input = false;
            inv = new inventar();
            //Show the menue
            do { 
            PlaceHolder();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                    --------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                          Willkommen bei Eggsplatter The Game   ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("                                      Schwierigkeitgrade");
            Console.WriteLine("                                      [1] Wartschen Einfach | startest mit 80 Coins");
            Console.WriteLine("                                      [2] Normal | startest mit 50 Coins ");
            Console.WriteLine("                                      [3] Schwer | startest ohne Coins aber mit vollem Inventar");
            Console.WriteLine();
            Console.WriteLine("                                      [4] Regelwerk");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                                    --------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("                                      Antwort = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
           


            try
            {
                answer = Convert.ToInt32(Console.ReadLine());
                   
                    if (answer > 0 && answer < 5)
                    {
                        

                        switch (answer)
                        {
                            //you will start with 80 Coins
                            case 1:
                                money = 80;
                                input = true;
                                break;
                            //you will start with 50 Coins
                            case 2:
                                money = 50;
                                input = true;
                                break;
                            //you will start with no Coins but with full inventory
                            case 3:
                                box valueE = new box(25, 30, 'E');
                                inv.AddToInvetory( valueE, out slots);
                                box valueT = new box(25, 20, 'T');
                                inv.AddToInvetory(valueT, out slots);
                                box valueP = new box(10, 10, 'P');
                                inv.AddToInvetory(valueP, out slots);
                                input = true;
                                break;
                            case 4:
                                Rules();
                                break;
                        }
                    }
                    else {
                        Console.Clear();
                        PlaceHolder();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                      Falsche Eingabe");
                        Console.ReadKey();
                        Console.Clear();
                    }
                
            }
            catch
            {
                Console.Clear();
                PlaceHolder();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                      Falsche Eingabe");
                Console.ReadKey();
                Console.Clear();
            }

        } while (input == false);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="answer"> input from user</param>
        /// <param name="money"> is the currency from the game</param>
        /// <param name="runde"> in wich round we are</param>
        /// <param name="punkte"> how many score has been archived</param>
        /// <param name="servicetime">how many Rounds for the next service</param>
        public static void Selection(out int answer, double money, int runde,int punkte, int servicetime)
        {
            //service indicator
            string lastService = "";
            switch (servicetime)
            {
                case 1:
                    lastService = @"[00||]";
                    break;
                case 2:
                    lastService = @"[000|]";
                    break;
                case 3:
                    lastService = @"[0000]";
                    break;
                default:
                    lastService = @"[0|||]";
                    break;
            }
            
            answer = 0;
            bool input = false;
            //Shows the menue of actions
            do
            {
                Console.Clear();

                PlaceHolder();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                    --------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("                                      Wechle Aktion wollen Sie diese Runde machen ?    ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} Coins", money);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("                                      [1] Zutaten kaufen");
                Console.WriteLine("                                      [2] Kunden servieren");
                Console.WriteLine("                                      [3] Inventur machen");
                Console.WriteLine("                                      [4] Müll aussortieren");
                Console.WriteLine();
                Console.WriteLine("                                      Runde: {0}              {1}                 Punkte: {2}  ", runde,lastService,punkte);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                    --------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("                                      Antwort = ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                //check if a wron input
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());

                    if (answer > 0 && answer < 5)
                    {
                        input = true;
                    }
                    else
                    {
                        Console.Clear();
                        PlaceHolder();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                      Falsche Eingabe");
                        Console.ReadKey();
                        Console.Clear();
                    }
                   
                }
                catch
                {
                    Console.Clear();
                    PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                      Falsche Eingabe");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (input == false);

        }

        /// <summary>
        /// have Placeholder for the formatation
        /// </summary>
        public static void PlaceHolder()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        /// <summary>
        /// user is selecting an Item from the shop.if something get buyed, the money will decreased. the buyed item will declared as box.
        /// The box get stored in the inventory
        /// </summary>
        /// <param name="money"></param>
        /// <param name="value"></param>
        public static void Shop(ref double money, out box value)
        {
            value = new box(0, 0, ' ');
            bool input = false;
            int answer;
            Console.ForegroundColor = ConsoleColor.Gray;
            do
            {
                Console.Clear();
                //Anzeige
                PlaceHolder();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                    --------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("                                      Was wollen Sie Kaufen ?                           ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} Coins", money);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("                                      [1] 25 Stk Eier = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("7.5 Coins");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("                                      [2] 25 Stk Paradiser = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("5 Coins");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("                                      [3] 10 Stk Steinpilze = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("25 Coins");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                    --------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("                                      Antwort = ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                    //which item get in the inventory
                    switch (answer)
                    {
                        case 1:
                            money -= 7.5;
                            value  = new box(3, 30, 'E');
                            break;
                        case 2:
                            money -= 5;
                            value = new box(25, 20, 'T');
                            break;
                        case 3:
                            money -= 25;
                            value = new box(10, 10, 'P');
                            break;
                        default:
                            // if the input is wrong
                            Console.Clear();
                            PlaceHolder();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                      Falsche Eingabe");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                    input = true;
                }
                catch
                {// if the input is wrong
                    Console.Clear();
                    PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                      Falsche Eingabe");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (input == false);

        }

        /// <summary>
        /// checks if money not under 0
        /// </summary>
        /// <param name="money"> is the currency of the game</param>
        /// <returns></returns>
        public static bool MoneyOrNot(double money)
        {
            if(money < 0)
            {
                Console.Clear();
                UserInterface.PlaceHolder();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                    verloren");
                Console.WriteLine("                                    Leider haben Sie zu wenig Geld gehabt D:");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// shows the rules of the game
        /// </summary>
        private static void Rules()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("                                    -------------------------Regeln---------------------------");
         
            Console.WriteLine("                                    Regel 1. Jede Aktion kostet dich ein Runde.");
            Console.WriteLine();
            Console.WriteLine("                                    Regel 2. Wenn du jemande bedienst und du hast\n                                     KEINE Zutaten mehr, hast du verloren.");
            Console.WriteLine();
            Console.WriteLine("                                    Regel 3. Nach jeder Runde verlieren die Zutaten\n                                     in deinen Lager Haltbarkeit.\n                                    * Eier hatlen 30 Runden.\n                                    * Paradiser hatlen 20 Runden.\n                                    * Steinpilze hatlen 10 Runden.");
            Console.WriteLine();
            Console.WriteLine("                                    Regel 4. Wenn eine Zutat schlecht geworden ist,\n                                    müssen Sie entsorgt werden. Falls nicht und ein\n                                    Kunde bekommt ein schlechtes Produkt.Hast du verloren.");
            Console.WriteLine();
            Console.WriteLine("                                    Regel 5. Alle 4 Runden musst du eine Bestellung machen\n                                    sonst hast du verloren");
            Console.WriteLine();
            Console.WriteLine("                                    Regel 6. Sollte das Lager zu voll sein hast \n                                    du auch automatisch verloren");
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();
        }
    }
}

       


