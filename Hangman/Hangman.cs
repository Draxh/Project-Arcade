using System;
using System.Text.RegularExpressions;

namespace Hangman
{
    public class Hangman
    {
        private static string _entryLetter;
        private static Letters letters;

        public static string EntryLetter
        {
            get => _entryLetter;
            set => _entryLetter = value;
        }

        public void Start()
        {
            letters = new Letters(); 
            
                Console.Write("Schreiben sie ein Buchstabe: ");
                _entryLetter = Console.ReadLine();
            
            
            letters.CheckEntryLetter();
            bool showTheStart = global::Hangman.Letters.ShowStart;
            Console.WriteLine(showTheStart);
            if (showTheStart)
            {
                Start();
            }
           
        }
    }
}