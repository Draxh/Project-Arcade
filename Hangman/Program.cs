using System;
using System.Configuration;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using Project_Arcade;

namespace Hangman
{
    internal class Program
    {
        private static GameChooser _gameChooser;
        private static Hangman _hangman;

        public static Hangman Hangman
        {
            get => _hangman;
            set => _hangman = value;
        }
        


        public static void Main(string[] args)
        {
            
            _gameChooser = new GameChooser();
            GameChooser.HeadPhones();
            GameChooser.PlayMenuMusic();
            
            GameChooser.ShowText();
            GameChooser.PlayMenuMusic();
            GameChooser.Select();
        }
    }
}