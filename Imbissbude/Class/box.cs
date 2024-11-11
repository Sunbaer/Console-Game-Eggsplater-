using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Imbissbude.Class
{
    public class box
    {
        protected int size;
        protected int timeStamp;
        protected char ingredient; 
        public box(int size, int timeStamp,char ingredient)
        {
            this.Size = size;
            this.TimeStamp = timeStamp;
            this.Ingredient = ingredient; 
        }

        public char Ingredient
        {
            get
            {
                return ingredient;
            }

            set
            {
                ingredient = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public int TimeStamp
        {
            get 
            {
                return timeStamp;
            }
            set
            {
                timeStamp = value;
            }
        }
        /// <summary>
        /// Get the infromation from the Inventory
        /// </summary>
        public void GetInfo()
        {
            Console.Write(timeStamp);
            Console.Write(size);
            Console.Write(ingredient);
            Console.ReadLine();
        }
    }
}
