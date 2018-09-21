using System;
using System.Collections.Generic;

namespace Hangman
{
    public class Food
    {
        private Random rnd = new Random();

        public  int FoodX { get; set; }
        public  int FoodY { get; set; }

        public Food()
        {
            FoodX = rnd.Next(1, 54);
            FoodY = rnd.Next(1, 19);
        }

         
    }
}