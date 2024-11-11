using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Imbissbude.Class
{
    public class inventar
    {

        protected int avaibleSlots = 60;
        protected List<box> Eggs = new List<box>();
        protected List<box> Tomato = new List<box>();
        protected List<box> Shrooms = new List<box>();
        protected List<box> boxes = new List<box>();
        protected bool isntAvailable = false;
        protected bool full = false;
        public inventar()
        {

        }

        /// <summary>
        /// the buyed box get stored in the inventory.
        /// the inventory is splittet in three lists.
        /// Eggs = eggboxes
        /// tomato = tomatoboxes
        /// shrooms = shroomboxes
        /// the avaible slot will calculatet 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="avaibleSlots"></param>
        public void AddToInvetory(box b, out int avaibleSlots)
        {
            //add a new item to the storage and minimized the available slots
            avaibleSlots = this.avaibleSlots - b.Size;
            this.avaibleSlots = avaibleSlots;
            boxes.Add(b);

            if (b.Ingredient == 'E')
            {
                Eggs.Add(b);
            }
            if (b.Ingredient == 'T')
            {
                Tomato.Add(b);
            }
            if (b.Ingredient == 'P')
            {
                Shrooms.Add(b);
            }
        }
        /// <summary>
        /// if the avaible slots 0 zero, the game will be over.
        /// </summary>
        /// <returns></returns>
        public bool FullInventar()
        {
            //checks if the inventory is full
            if (avaibleSlots < 0)
            {
                Console.Clear();
                UserInterface.PlaceHolder();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("                                    verloren");
                Console.WriteLine("                                    Sie haben leider kein Platz mehr im Inventar D:");
                return full = true;
            }
            else
            {
                return full = false;
            }

        }

        /// <summary>
        /// every round the items loss one timestamp
        /// </summary>
        public void DeletetimeStep()

        {
            for (int i = 0; i < boxes.Count; i++)
            {
                boxes[i].TimeStamp--;
            }

        }
        /// <summary>
        /// Delete the incredients under a certain timestamp
        /// </summary>
        public void Deleteboxes()
        {
            int e = 0;
            int t = 0;
            int p = 0;

            // Delete boxes with low TimeStamp before running up
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].TimeStamp > 2)
                {
                    if (boxes[i].Ingredient == 'E')
                    {
                        Eggs[e] = boxes[i];
                        e++;
                    }
                    if (boxes[i].Ingredient == 'T')
                    {
                        Tomato[t] = boxes[i];
                        t++;
                    }
                    if (boxes[i].Ingredient == 'P')
                    {
                        Shrooms[p] = boxes[i];
                        p++;
                    }
                }
                else
                {
                    

                    if (boxes[i].Ingredient == 'E')
                    {
                       
                        Eggs.RemoveAt(e);
                   
                    }
                    if (boxes[i].Ingredient == 'T')
                    {
                        Tomato.RemoveAt(t);
                        
                    }
                    if (boxes[i].Ingredient == 'P')
                    {
                        Shrooms.RemoveAt(p);
                        
                    }
                    boxes.RemoveAt(i);
                    i--;
                }

            }
            Console.Clear();

            UserInterface.PlaceHolder();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                    Alle die eine schlechte Halbarkeit haben sind entsorgt");
            Console.ReadLine();
        }
        /// <summary>
        /// After a service the box get new sortet int the 3 boxes to refresh the new properties
        /// </summary>
        public void Sortboxes()
        {
            int e = 0;
            int t = 0;
            int p = 0;
            // every change of ingrdience have to changed in the lits
            for (int i = 0; i < boxes.Count; i++)
            {
                //save the box to the right incredient if Size bigger 0
                if (boxes[i].Size > 0)
                {
                    if (boxes[i].Ingredient == 'E')
                    {
                        Eggs[e] = boxes[i];
                        e++;
                    }
                    if (boxes[i].Ingredient == 'T')
                    {
                        Tomato[t] = boxes[i];
                        t++;
                    }
                    if (boxes[i].Ingredient == 'P')
                    {
                        Shrooms[p] = boxes[i];
                        p++;
                    }
                }
                //boxes and the ingredient get deleted 
                else
                {
                    if (boxes[i].Ingredient == 'E')
                    {
                        Eggs.RemoveAt(e);
                       
                    }
                    if (boxes[i].Ingredient == 'T')
                    {
                        Tomato.RemoveAt(t);
                       
                    }
                    if (boxes[i].Ingredient == 'P')
                    {
                        Shrooms.RemoveAt(p);
                        
                    }
                }

                boxes.RemoveAt(i);
                i--;


            }

        }
        /// <summary>
        /// Checks if egg boxes available for a service if not game over.
        /// if the egg box is avaible but not enough eggs for the omlett the game is also over
        /// </summary>
        /// <param name="eggs"></param>
        public void GetIncredient(out int eggs)
        {
            Random rnd = new Random();
            eggs = 0;


            for (int i = 0; i < 3; i++)
            {
                int randomIngredient = rnd.Next(0, Eggs.Count);
                try
                {
                    if (Eggs[randomIngredient].Size > 0)
                    {
                        Eggs[randomIngredient].Size -= 1;
                        if (Eggs[randomIngredient].TimeStamp > 0)
                        {
                            eggs++;
                            for (int j = 0; j < boxes.Count; j++)
                            {
                                if (boxes[j].Ingredient == 'E')
                                {
                                    boxes[j].Size = Eggs[randomIngredient].Size;
                                    avaibleSlots++;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            UserInterface.PlaceHolder();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                    verloren");
                            Console.WriteLine("                                    Leider war ein Schlectes Ei dabei D:");
                            isntAvailable = true;

                        }

                    }
                    else
                    {
                        Console.Clear();
                        UserInterface.PlaceHolder();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                    verloren");
                        Console.WriteLine("                                    Sie haben leider keine Eier mehr um das Omlett fertig zu machen D:");
                        isntAvailable = true;
                        Console.ReadLine();
                    }

                }
                catch
                {
                    Console.Clear();
                    UserInterface.PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                    verloren");
                    Console.WriteLine("                                    Sie haben leider keine Eier mehr D:");
                    Console.ReadLine();
                    isntAvailable = true;
                }
            }



        }
        /// <summary>
        ///    /// Checks if egg boxes available for a service if not game over.
        /// if the egg box is avaible but not enough eggs for the omlett the game is also over
        /// the order decide witch Omlett will get made. 
        /// it cheks if the other ingredients for the servic is available if not game is over
        /// </summary>
        /// <param name="order">ist die Bestellung die der Kunde bkommt</param>
        /// <param name="eggs">ist die anzahl der Eier </param>
        /// <param name="ingredient"> ist die Anzahl der anderen Zutaten</param>
        public void GetIncredient(int order, out int eggs, out int ingredient)
        {
            Random rnd = new Random();
            eggs = 0;
            ingredient = 0;

            for (int i = 0; i < 3; i++)
            {
                int randomIngredient = rnd.Next(0, Eggs.Count);
                try
                { //Ask if the Eggs have a Size > 0
                    if (Eggs[randomIngredient].Size > 0)
                    {
                         //Ask if the Eggs have a Size > 0
                        Eggs[randomIngredient].Size -= 1;
                        //Ask if the Egg timeStamp > 0

                        if (Eggs[randomIngredient].TimeStamp > 0)
                        {
                            //egg can be addet to the Omlett
                            eggs++;
                            // egg slot get deleted in the storage
                            for (int j = 0; j < boxes.Count; j++)
                            {
                                if (boxes[j].Ingredient == 'E')
                                {
                                    boxes[j].Size = Eggs[randomIngredient].Size;
                                    avaibleSlots++;
                                }

                            }
                        }
                        else
                        {
                            //if timestamp was under 0 
                            Console.Clear();
                            UserInterface.PlaceHolder();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                    verloren");
                            Console.WriteLine("                                    Leider war ein schlectes Ei dabei D:");
                            isntAvailable = true;

                        }



                    }
                    else
                    {
                        //if you ingredince but not enough for the omlett
                        Console.Clear();
                        UserInterface.PlaceHolder();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("                                    verloren");
                        Console.WriteLine("                                    Sie haben leider keine Eier mehr um das Omlett fertig zu machen D:");
                        isntAvailable = true;

                    }

                }
                catch
                {
                    // if you already have no incrediens for the Omlett
                    Console.Clear();
                    UserInterface.PlaceHolder();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("                                    verloren");
                    Console.WriteLine("                                    Sie haben leider keine Eier mehr D:");
                    isntAvailable = true;
                }
            }

            if (!isntAvailable == true)
            {

                if (order == 1)
                {
                    Random nrnd = new Random();

                    for (int i = 0; i < 1; i++)
                    {
                        int randomIngredient = nrnd.Next(0, Shrooms.Count);

                        try
                        {
                            if (Shrooms[randomIngredient].Size > 0)
                            {
                                Shrooms[randomIngredient].Size -= 1;
                                if (Shrooms[randomIngredient].TimeStamp > 0)
                                {
                                    ingredient++;

                                    for (int j = 0; j < boxes.Count; j++)
                                    {
                                        if (boxes[j].Ingredient == 'P')
                                        {
                                            boxes[j].Size = Shrooms[randomIngredient].Size;
                                            avaibleSlots++;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    UserInterface.PlaceHolder();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("                                    verloren");
                                    Console.WriteLine("                                    Leider war ein schlecter Steinpilz dabei D:");
                                    isntAvailable = true;

                                }

                            }
                            else
                            {
                                Console.Clear();
                                UserInterface.PlaceHolder();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("                                    verloren");
                                Console.WriteLine("                                    Sie haben leider keine Steinpilze mehr um das Omlett fertig zu machen D:");
                                isntAvailable = true;

                            }
                        }

                        catch
                        {
                            Console.Clear();
                            UserInterface.PlaceHolder();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                    verloren");
                            Console.WriteLine("                                    Sie haben leider keine Steinpilze mehr D:");
                            isntAvailable = true;

                        }


                    }
                }

            }

            if (!isntAvailable == true)
            {
                if (order > 1 && order <= 5)
                {
                    Random nrnd = new Random();


                    for (int i = 0; i < 1; i++)
                    {
                        int randomIngredient = nrnd.Next(0, Tomato.Count);
                        try
                        {
                            if (Tomato[randomIngredient].Size > 0)
                            {
                                Tomato[randomIngredient].Size -= 1;
                                if (Tomato[randomIngredient].TimeStamp > 0)
                                {
                                    ingredient++;

                                    for (int j = 0; j < boxes.Count; j++)
                                    {
                                        if (boxes[j].Ingredient == 'T')
                                        {
                                            boxes[j].Size = Tomato[randomIngredient].Size;
                                            avaibleSlots++;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    UserInterface.PlaceHolder();
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("                                    verloren");
                                    Console.WriteLine("                                    Leider war ein schlechter Paradiser dabei D:");
                                    isntAvailable = true;

                                }


                            }
                            else
                            {
                                Console.Clear();
                                UserInterface.PlaceHolder();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("                                    verloren");
                                Console.WriteLine("                                    Sie haben leider keine Paradiser mehr um das Omlett fertig zu machen D:");
                                isntAvailable = true;

                            }

                        }
                        catch
                        {
                            Console.Clear();
                            UserInterface.PlaceHolder();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("                                    verloren");
                            Console.WriteLine("                                    Sie haben leider keine Paradiser mehr mehr D:");
                            isntAvailable = true;

                        }


                    }
                }
            }

        }

        /// <summary>
        /// Shows the inventory
        /// </summary>
        public void showInventory()
        {
            int allTomatos = 0;
            int allEggs = 0;
            int allShrooms = 0;
            Console.Clear();
            UserInterface.PlaceHolder();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                    -------------------------Eier---------------------------");
            if (Eggs.Count != 0)
            {
                
               // Shows the avaibable eggs in the storage
                for (int i = 0; i < Eggs.Count; i++)
                {
                    Console.WriteLine("                                    Eierbox " + (i+1));
                    Console.WriteLine("                                    Es sind noch {0} Eier in der Box", Eggs[i].Size);
                    Console.WriteLine("                                    Die in dieser Box laufen die Eier in {0} Runden ab", Eggs[i].TimeStamp);
                    Console.WriteLine();
                    allEggs += Eggs[i].Size;
                }
                Console.WriteLine("                                    Es sind noch insgesamt {0} Eier in dem Lager", allEggs);
                Console.WriteLine();
            }
            else
            {
                //if you dont have eggs in the storage
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                    Keine Eier im Inventar");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

                Console.WriteLine("                                    -------------------------Steinpilze----------------------");
            if (Shrooms.Count != 0)
            {
                // Shows the avaibable shrooms in the storage
                for (int i = 0; i < Shrooms.Count; i++)
                {
                    Console.WriteLine("                                    Steinpilzbox " + (i+1));
                    Console.WriteLine("                                    Es sind noch {0} Steinpilze in der Box", Shrooms[i].Size);
                    Console.WriteLine("                                    Die in dieser Box laufen die Steinpilze in {0} Runden ab", Shrooms[i].TimeStamp);
                    Console.WriteLine();
                    allShrooms += Shrooms[i].Size;
                }
                Console.WriteLine("                                    Es sind noch insgesamt {0} Steinpilze in dem Lager", allShrooms);
                Console.WriteLine();
            }
            else
            {
                //if you dont have Shrooms in the storage
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                    Keine Steinpilze im Inventar");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

            Console.WriteLine("                                    -------------------------Paradiser-----------------------");
            if (Tomato.Count != 0)
            {
                // Shows the avaibable Tomatos in the storage
                for (int i = 0; i < Tomato.Count; i++)
                {
                    Console.WriteLine("                                    ParadiserBox " + (i + 1));
                    Console.WriteLine("                                    Es sind noch {0} Paradiser in der Box", Tomato[i].Size);
                    Console.WriteLine("                                    Die in dieser Box laufen die Paradiser in {0} Runden ab", Tomato[i].TimeStamp);
                    Console.WriteLine();
                    allTomatos += Tomato[i].Size;
                }
                Console.WriteLine("                                    Es sind noch insgesamt {0} Paradiser in dem Lager", allTomatos);
                Console.WriteLine();
            }
            else
            {
                //if you dont have Tomatos in the storage
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("                                    Keine Paradiser im Inventar");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

            Console.WriteLine("                                    Dein Lager hat noch {0} Plätze frei", (60 -(allTomatos+allEggs+allShrooms)));
            Console.ReadLine();
        }

        /// <summary>
        /// if an incredient is not available than the game will lose
        /// </summary>
        /// <returns></returns>
        public bool NotAvailable()
        {
            if (isntAvailable)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
