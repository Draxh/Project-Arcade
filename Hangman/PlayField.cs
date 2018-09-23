using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Project_Arcade;
using Timer = System.Timers.Timer;
using System.Media;

namespace Hangman

{
    public class PlayField
    {
        private List<List<FieldContent>> Field = new List<List<FieldContent>>();
        private Snake Snake;


        private Food GeneratedFood;

        private Thread KeyCheck;


        private int Width = 55;
        private int Height = 20;
        private int Snakex = 5;
        private int Snakey = 5;
        private int CountScore = 0;
        private int HighScore = 0;
        private Timer foodTimer;


        private string Direction = "Right";


        private bool GameIsOn = true;

        public PlayField()
        {
            foodTimer = new System.Timers.Timer();
            foodTimer.Interval = 10000;

            foodTimer.Elapsed += GenerateFood;

            foodTimer.AutoReset = true;

            foodTimer.Enabled = true;
        }

        public void ResetField()
        {
            for (int i = 0; i < Height; i++)
            {
                List<FieldContent> row = new List<FieldContent>();
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1 || j == 0 || j == Width - 1)
                    {
                        row.Add(new FieldContent(FieldContent.FieldType.border));
                    }
                    else
                    {
                        row.Add(new FieldContent(FieldContent.FieldType.empty));
                    }
                }

                Field.Add(row);
            }
        }


        private void GenerateFood(Object source, System.Timers.ElapsedEventArgs e)
        {
            GeneratedFood = new Food();
        }

        public void Initialize()
        {
            this.Snake = new Snake(5, 5);
            KeyCheck = new Thread(CheckKey);
            KeyCheck.Start();
        }

        public void Render()
        {
            Console.Clear();
            var Board = "";
            for (var y = 0; y < Field.Count; y++)
            {
                var Line = "";
                for (var x = 0; x < Field[y].Count; x++)
                {
                    if (GeneratedFood != null && GeneratedFood.FoodY == y && GeneratedFood.FoodX == x)
                    {
                        Field[y][x] = new FieldContent(FieldContent.FieldType.apple);
                    }

                    Line += Field[y][x].Render();
                }

                Board += Line + Environment.NewLine;
            }

            Console.WriteLine(Board);
        }

        public void CreateSnake()
        {
            Field[Snakex][Snakey] = new FieldContent(FieldContent.FieldType.snake);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void StartGame()
        {
            while (GameIsOn)
            {
                Move();
                SetSnakeParts();
                Render();
                Thread.Sleep(125);
            }

            CheckHighScore();
            Console.WriteLine("\r\n");
            Console.WriteLine("You died, your score was " + CountScore);
            BackToMenu();
        }

        public bool CheckFieldContent()
        {
            if (GeneratedFood != null)
            {
                if (Snakex == GeneratedFood.FoodX && Snakey == GeneratedFood.FoodY)
                {
                    GeneratedFood = null;
                    CountScore++;
                    foodTimer.Stop();
                    GeneratedFood = new Food();
                    return true;
                }
            }


            if (Snakex <= 0 || Snakex >= Width - 1 || Snakey <= 0 || Snakey >= Height - 1)
            {
                GameIsOn = false;
                Console.WriteLine(CountScore);
            }

            SnakeHitSnake();
            return false;
        }


        private void Move()
        {
            switch (Direction)
            {
                case "Up":
                    Snakey--;
                    break;
                case "Down":
                    Snakey++;
                    break;
                case "Right":
                    Snakex++;
                    break;
                case "Left":
                    Snakex--;
                    break;
            }


            if (!CheckFieldContent())
            {
                Snakepart tail = Snake.PartList[0];
                Field[tail.y][tail.x] = new FieldContent(FieldContent.FieldType.empty);
                Snake.PartList.RemoveAt(0);
            }

            Snake.PartList.Add(new Snakepart(Snakex, Snakey));
        }

        private void CheckKey()
        {
            while (true)
            {
                var Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                        Direction = "Up";
                        break;
                    case ConsoleKey.DownArrow:
                        Direction = "Down";
                        break;
                    case ConsoleKey.RightArrow:
                        Direction = "Right";
                        break;
                    case ConsoleKey.LeftArrow:
                        Direction = "Left";
                        break;
                    default:
                        break;
                }
            }
        }

        public void SetSnakeParts()
        {
            for (int i = 0; i < Snake.PartList.Count; i++)
            {
                Snakepart snakepart = Snake.PartList[i];
                Field[snakepart.y][snakepart.x] = new FieldContent(FieldContent.FieldType.snake);
            }
        }

        public void SnakeHitSnake()
        {
            for (var i = 0; i < Snake.PartList.Count; i++)
                if (Snakex == Snake.PartList[i].x && Snakey == Snake.PartList[i].y)
                {
                    GameIsOn = false;
                }
        }

        public void BackToMenu()
        {
            KeyCheck.Abort();
            Console.WriteLine("Press [1] to play again");
            Console.WriteLine("Press [2] to go to the game menu");
            Console.Write("");
            var check = Console.ReadLine();

            switch (check)
            {
                case "1":
                    Console.Clear();
                    PlayField Field = new PlayField();
                    Field.ResetField();
                    Field.Initialize();
                    Field.CreateSnake();
                    Field.StartGame();

                    break;
                case "2":
                    GameChooser.PlayMenuMusic();
                    GameChooser.Menu();
                    break;
            }
        }

        private void CheckHighScore()
        {
            if (CountScore > HighScore)
            {
                HighScore = CountScore;
                System.IO.File.WriteAllText(@"..\..\..\HighScoreForSnake\HighScore.txt", Convert.ToString(HighScore));
                Console.WriteLine("Congratulations you beat the Highscore!");
            }

            string HighScoreFile = System.IO.File.ReadAllText(@"..\..\..\HighScoreForSnake\HighScore.txt");
            Console.WriteLine("The Highscore is " + HighScoreFile + "!");
        }
    }
}