using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace Hangman
{
    public class Snake
    {
        public List<Snakepart> PartList = new List<Snakepart>();

        public Snake(int x, int y)
        {
            PartList.Add(new Snakepart(x, y));
        }
    }
}