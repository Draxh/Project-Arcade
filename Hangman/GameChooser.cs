using System;
using System.Runtime.InteropServices;
using System.Media;
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
            Console.WriteLine("Please make sure to use Headphoens while playing in the insane Arcade!");
            Console.WriteLine("Press Enter to get into the Arcade!");
            Console.WriteLine("Have Fun!");
            Console.ReadLine();
        }

        public static void Select()
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
            Console.WriteLine("\r\n");
            Console.WriteLine("Select a Game");
            Console.WriteLine("Press [1] to play Snake");
            Console.WriteLine("Press [2] to play Hangman");

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
                default:
                    Console.WriteLine("Falsche Eingabe");
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
            player.SoundLocation = @"..\..\..\StarCraft II - Wings of Liberty Main Theme.wav";
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
            player.SoundLocation = @"..\..\..\StarCraft II - Wings of Liberty Main Theme.wav";
            player.SoundLocation = @"..\..\..\Nintendo Wii - Mii Channel Theme.wav";
            player.Stop();
        }
    }
}