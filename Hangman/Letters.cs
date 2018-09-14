using System;

namespace Hangman
{
    public class Letters
    {
        private static bool _showStart = true;

        public static bool ShowStart
        {
            get => _showStart;
            set => _showStart = value;
        }

        public void CheckEntryLetter()
        {
            int n;
            bool IsNumeric;
            string checkEntry = Hangman.EntryLetter;
            if (IsNumeric = int.TryParse(checkEntry, out n) || checkEntry.Length >= 2 || checkEntry.Length < 1)
            {
                Console.WriteLine("Falsche Eingabe");
                _showStart = false;
            }
            else
            {
                _showStart = true;
                Console.WriteLine(checkEntry);
                LetterinWord();
                
            }
            
        }

        public void LetterinWord()
        {
            string RightWord = Words.PlayWord;
            string CheckEntry = Hangman.EntryLetter;
            CheckEntry = CheckEntry.ToUpper();

            if (RightWord.ToUpper().Contains(CheckEntry))
            {
                Console.WriteLine("Yeaaah");
            }
        }
    }
}