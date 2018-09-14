using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Hangman
{
    public class Words
    {
        private string WordsInTextFile;
        private static string _playWord;

        public static string PlayWord
        {
            get => _playWord;
            set => _playWord = value;
        }

        private void GetWords()
        {
            WordsInTextFile = System.IO.File.ReadAllText(@"..\..\..\TextForHangman\WordForHangman.txt");
        }

        public void splitWords()
        {
            GetWords();
            String[] myPlayWords = WordsInTextFile.Split(';');
            
            Random rnd = new Random();
            int rndIndex = rnd.Next(0, myPlayWords.Length - 1);
            // Console.WriteLine(myPlayWords[rndIndex]);
            _playWord = myPlayWords[rndIndex];
            Console.WriteLine(_playWord);

        }
        
        
        
    }
}