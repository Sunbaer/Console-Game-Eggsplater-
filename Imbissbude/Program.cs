using Imbissbude.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imbissbude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            inventar inv;
            int slots = 0;
            int answer = 0;
            double money = 0;
            int order = 0;
            int serviceTime = 0;
            int punkte = 0;
            int runde = 1;

            UserInterface.GameSettings(ref money, out inv);
            do
            {
                UserInterface.Selection(out answer, money, runde, punkte, serviceTime);
                switch (answer)
                {
                    case 1:
                        //if the user want buy incredients
                        UserInterface.Shop(ref money, out box value);
                        inv.AddToInvetory(value, out slots);
                        serviceTime++;

                        break;
                    case 2:
                        // if the user want to make a service to collect points
                        Omlett o = new Omlett(0);
                        Customer.RandomOrder(out order);
                        Customer.Service(inv, order, out o, ref money);
                        if (inv.NotAvailable() == false)
                        {
                            inv.Sortboxes();
                        }
                        serviceTime = 0;
                        punkte += 250;
                        break;
                    // if the user want to make a look in his storage
                    case 3:
                        inv.showInventory();
                        serviceTime++;
                        break;
                    case 4:
                        // if the user want delete Garbadge
                        inv.Deleteboxes();
                        inv.Sortboxes();
                        serviceTime++;
                        break;
                    default:
                        //Wrong input
                        Console.Clear();
                        UserInterface.PlaceHolder();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                      Falsche Eingabe");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                // checks after round the conditions for losing the game
                answer = 0;
                UserInterface.MoneyOrNot(money);
                Customer.ServiceTime(serviceTime);
                inv.DeletetimeStep();
                runde++;

            } while (inv.FullInventar() == false && inv.NotAvailable() == false && Customer.ServiceTime(serviceTime) == false && UserInterface.MoneyOrNot(money) == false);

            // Shows after lose your End Score
            Console.ReadLine();
            Console.WriteLine("verloren");
            Console.Clear();
            UserInterface.PlaceHolder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                      Sie haben einen end Punktestand von {0} gut gemacht ;D",punkte);
            Console.ReadKey();

        }
    }
}
