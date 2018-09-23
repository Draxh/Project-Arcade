using System;
using System.Runtime.InteropServices;
using System.Media;
using System.Threading;
using Hangman;

namespace Project_Arcade
{
    public class GameChooser
    {
        private static Hangman.Hangman hangman;
        public static SoundPlayer player = new SoundPlayer();

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

        public static void HeadPhones()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ShowText();
            Console.ResetColor();
            Console.WriteLine("\r\n");
            Console.WriteLine("Please make sure to use headphones while playing in the insane Arcade!");
            Console.WriteLine("Press Enter to get into the Arcade!");
            Console.WriteLine("Have fun!");
            Console.ReadLine();
        }

        public static void Select()
        {
            Console.Clear();
            ShowColorArcade();
            Console.WriteLine("\r\n");
            Console.WriteLine("Press [1] to play");

            var check = Console.ReadLine();
            switch (check)
            {
                case "1":
                    Console.Clear();
                    Menu();
                    break;
                default:
                    Console.WriteLine("Wrong entry");
                    break;
            }
        }

        public static void Menu()
        {
            Console.Clear();
            ShowColorArcade();
            Console.WriteLine("\r\n");
            Console.WriteLine("Select a game:");
            Console.WriteLine("Press [1] to play Snake");
            Console.WriteLine("Press [2] to play Hangman");
            Console.WriteLine("Press [3] to leave the Arcade");

            int check = Convert.ToInt32(Console.ReadLine());
            switch (check)
            {
                case 1:
                    StopMusic();
                    PlaySnakeMusic();
                    PlayField Field = new PlayField();
                    Field.ResetField();
                    Field.Initialize();
                    Field.CreateSnake();
                    Field.StartGame();
                    break;
                case 2:
                    StopMusic();
                    PlayHangmanMusic();
                    Console.Clear();
                    Console.WriteLine("Hangman");
                    hangman = new Hangman.Hangman();
                    hangman.Start();
                    break;
                case 3:
                    Console.Clear();
                    ShowColorArcade();
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Thank you for playing in the Arcade");
                    Console.WriteLine("See you next time");
                    Thread.Sleep(3000);
                    break;
                default:
                    Console.WriteLine("Wrong entry");
                    break;
            }
        }

        public static void PlayMenuMusic()
        {
            player.SoundLocation = @"..\..\..\ArcadeMusic.wav";
            player.PlayLooping();
        }

        public static void PlaySnakeMusic()
        {
            player.SoundLocation = @"..\..\..\Nintendo Wii - Mii Channel Theme.wav";
            player.PlayLooping();
        }

        public static void PlayHangmanMusic()
        {
            player.SoundLocation = @"..\..\..\Nintendo Wii - Mii Channel Theme.wav";
            player.PlayLooping();
        }

        public static void StopMusic()
        {
            player.SoundLocation = @"..\..\..\ArcadeMusic.wav";
            player.SoundLocation = @"..\..\..\Nintendo Wii - Mii Channel Theme.wav";
            player.Stop();
        }

        public static void ShowColorArcade()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ShowText();
            Console.ResetColor();
        }
    }
}