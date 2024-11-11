using System;

namespace Imbissbude.Class
{
    public class Customer
    {
        /// <summary>
        /// gives a random number bewtween 0 to 10
        /// </summary>
        /// <param name="order"></param>
        static public void RandomOrder(out int order)
        {

            Random rnd = new Random();
            order = rnd.Next(0, 10);


        }
        /// <summary>
        ///  The service is the order from the customer if the Omlett isnt right or good the user lose
        /// </summary>
        /// <param name="inv">invenory of the user</param>
        /// <param name="order">which radnom order the cosumer want</param>
        /// <param name="O"> Which Omlett</param>
        /// <param name="money">is the Currency of the game</param>
        static public void Service(inventar inv, int order, out Omlett O, ref double money)
        {

            O = new Omlett(0);
            int eggs = 0;
            int ingredient = 0;

            if (order == 1)
            {
                inv.GetIncredient(order, out eggs, out ingredient);
             
                O = new ShOmlett(ingredient, eggs);
                if (eggs > 0 && ingredient > 0)
                {
                    money += 10;
                    Console.Clear();
                    UserInterface.PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("                                    Den Kunden hat das Steinpilzomlett geschmeckt und gibt dir dafür 10 Coins");
                    Console.ReadLine();
                }

            }
            else if (order > 1 && order <= 5)
            {
                inv.GetIncredient(order, out eggs, out ingredient);
               
                O = new TOmlett(ingredient, eggs);
                if (eggs > 0 && ingredient > 0)
                {
                    money += 2.5;
                    Console.Clear();
                    UserInterface.PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("                                    Den Kunden hat das Paradiseromlett geschmeckt und gibt dir dafür 2.5 Coins");
                    Console.ReadLine();
                }

            }
            else if (order > 5 && order <= 10)
            {
                inv.GetIncredient(out eggs);
             
                O = new Omlett(eggs);
                if (eggs > 0)
                {
                    money += 1.5;
                    Console.Clear();
                    UserInterface.PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("                                    Den Kunden hat das Omlett geschmeckt und gibt dir dafür 1.5 Coins");
                    Console.ReadLine();
                }
                

            }
        }
        /// <summary>
        /// After four Round without service the game is over
        /// </summary>
        /// <param name="serviceTime">Rounds after a service</param>
        /// <returns></returns>
        static public bool ServiceTime(int serviceTime)
        {
            if (serviceTime > 3)
            {
                Console.Clear();
                UserInterface.PlaceHolder();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                      Sie haben leider zu spät den Kunden bedient D:");
                Console.ReadKey();
                return true;
            }
            else
            {
               return false;
            }
        }

    }
}
