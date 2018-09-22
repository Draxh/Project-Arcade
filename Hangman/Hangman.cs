using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Project_Arcade;

namespace Hangman
{
    public class Hangman
    {
        private static string _entryLetter;
        private static Words _createWords;
        private static FileWord _fileWord;
        private static Letters letters;
        private static string WhateverPlayWord;
        private static bool showTheStart = Letters.ShowStart;

        public static bool ShowTheStart
        {
            get => showTheStart;
            set => showTheStart = value;
        }

        public static string EntryLetter
        {
            get => _entryLetter;
            set => _entryLetter = value;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine(
                "Would you like to create your own word or select a provided one? [1: Provided | 2: Create a word (2 Player-mode)]");
            string FirstEntry = Console.ReadLine();

            switch (FirstEntry)
            {
                case "1":
                    _createWords = new Words();
                    _createWords.SetLanguage();
                    //StartNormal();
                    break;
                case "2":
                    _fileWord = new FileWord();
                    _fileWord.InsertWord();
                    break;
                default:
                    Console.WriteLine("Wrong entry!");
                    break;
            }
        }

        public void StartNormal(string FirstPlayWord)
        {
            letters = new Letters();
            string DifferentPlayWords = FirstPlayWord;

            Console.Write("Type a letter ( Attention: All letters have to be in lower case! ): ");
            _entryLetter = Console.ReadLine();

            letters.CheckEntryLetter(DifferentPlayWords);

            //Console.WriteLine(DifferentPlayWords);
            // Console.WriteLine(showTheStart);
            End(DifferentPlayWords);
            if (showTheStart)
            {
                StartNormal(DifferentPlayWords);
            }
        }

        public void End(string CheckPlayWord)
        {
            bool IsEnd = false;
            WhateverPlayWord = CheckPlayWord;
            string[] CheckChars = Words.Replace;
            String FinishHangman = string.Join("", CheckChars);

            FinishHangman = FinishHangman.ToLower();
            WhateverPlayWord = WhateverPlayWord.ToLower();


            if (WhateverPlayWord == FinishHangman)
            {
                IsEnd = true;
                showTheStart = false;
            }
            else
            {
                IsEnd = false;
            }

            if (IsEnd)
            {
                Console.Clear();
                Console.WriteLine("WOW, you are too good!!");
                Console.WriteLine("The word was: " + WhateverPlayWord.ToUpper());

                AfterGame();
            }
        }

        public void lose()
        {
            Console.Clear();
            Console.WriteLine("Better luck next time!!");
            Console.WriteLine("The word was '" + WhateverPlayWord.ToUpper());

            AfterGame();
        }

        public void AfterGame()
        {
            Console.WriteLine("Play again [1]");
            Console.WriteLine("Exit game[2]");
            string AfterGameEntry = Console.ReadLine();

            switch (Convert.ToInt16(AfterGameEntry))
            {
                case 1:
                    Start();
                    break;
                case 2:
                    GameChooser.PlayMenuMusic();
                    GameChooser.Menu();
                    break;
                default:
                    Console.WriteLine("Wrong Entry");
                    break;
            }
        }
    }
}