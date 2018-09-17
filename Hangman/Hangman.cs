using System;
using System.ComponentModel;
using System.Security.Cryptography;
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
            var chars = new[]{_entryLetter};
            int countEntry = 0;
            
                Console.Write("Schreiben sie ein Buchstabe ( Achtung: Alle buchstaben in klein eingeben!! ): ");
                _entryLetter = Console.ReadLine();

            chars[countEntry] = _entryLetter;
            countEntry++;
            
            
            letters.CheckEntryLetter();
            bool showTheStart = global::Hangman.Letters.ShowStart;
            // Console.WriteLine(showTheStart);
            if (showTheStart)
            {
                Start();

            }
           
        }

        public void End()
        {

            bool IsEnd = false;
            

            for (int i = 0; i < Words.WhereToWrite; i++)
            {
                
                if (Words.Replace[i] != "_ ")
                {
                    IsEnd = true;
                }
                else
                {
                    IsEnd = false;
                }
            }

            if (IsEnd)
            {
                Console.WriteLine("Richtig!!");
            }
        }
    }
}