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
        
        public static void Music()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"..\..\..\ArcadeMusic.wav";
            player.Play();
        }
            
        public static void Main(string[] args)
        {
            _gameChooser = new GameChooser();
            
            GameChooser.ShowText();
            Music();
            GameChooser.Select();

        }
        
    }
}