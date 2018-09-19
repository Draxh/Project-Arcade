using System;
using System.Runtime.InteropServices;
using Hangman;

namespace Project_Arcade
{
    public class GameChooser
    {
        private static Hangman.Hangman hangman;


        private static string[] Arcade =
        {
            "▄▄▄       ██▀███   ▄████▄   ▄▄▄      ▓█████▄ ▓█████    ",
            "▒████▄    ▓██ ▒ ██▒▒██▀ ▀█  ▒████▄    ▒██▀ ██▌▓█   ▀    ",
            "▒██  ▀█▄  ▓██ ░▄█ ▒▒▓█    ▄ ▒██  ▀█▄  ░██   █▌▒███      ",
            "░██▄▄▄▄██ ▒██▀▀█▄  ▒▓▓▄ ▄██▒░██▄▄▄▄██ ░▓█▄   ▌▒▓█  ▄   ",
            " ▓█   ▓██▒░██▓ ▒██▒▒ ▓███▀ ░ ▓█   ▓██▒░▒████▓ ░▒████▒   ",
            " ▒▒   ▓▒█░░ ▒▓ ░▒▓░░ ░▒ ▒  ░ ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░   ",
            "  ▒   ▒▒ ░  ░▒ ░ ▒░  ░  ▒     ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░   ",
            "  ░   ▒     ░░   ░ ░          ░   ▒    ░ ░  ░    ░      ",
            "      ░  ░   ░     ░ ░            ░  ░   ░       ░  ░ "
        };


        public static void ShowText()
        {
            Console.WriteLine(" ");
            foreach (string line in Arcade)
            {
                Console.WriteLine(line);
            }
        }

        void Select()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ShowText();
            Console.ResetColor();
            Console.WriteLine("\r\n");
            Console.WriteLine("Press [1] to Play");
            var check = Console.ReadLine();

            switch (check)
            {
                case "1":
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                    Console.ResetColor();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Falsche Eingabe");
                    break;
            }
        }

        public static void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ShowText();
            Console.ResetColor();
            Console.WriteLine("Select a Game");
            Console.WriteLine("Press [1] to play Snake");
            Console.WriteLine("Press [2] to play Hangman");


            var check = Console.ReadLine();

            switch (check)
            {
                case "1":
                    Console.WriteLine("Snake");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Hangman");
                    hangman = new Hangman.Hangman();
                    hangman.Start();
                    break;
                default:
                    Console.WriteLine("Falsche Eingabe");
                    break;
            }
        }
    }
}