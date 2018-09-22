using System;

namespace Hangman
{
    public class FileWord
    {
        static int i = 0;
        string[] UserWords = new string[i + 1];
        private static string OwnWordsInTextFile;
        private static Hangman hangman;
        private static Words words;
        private static char[] OwnChars = new char[1];


        public void InsertWord()
        {
            Console.Write("Write your own word: ");
            string SelfWord = Console.ReadLine();
            SelfWord = SelfWord + ";";
            //Console.WriteLine(SelfWord);
            for (i = 0; i < UserWords.Length; i++)
            {
                if (UserWords[i] == null)
                {
                    UserWords[i] = SelfWord;
                    System.IO.File.AppendAllText(@"..\..\..\TextForHangman\WordForHangmanSelf.txt", UserWords[i]);
                }
            }

            OwnWordsInTextFile = System.IO.File.ReadAllText(@"..\..\..\TextForHangman\WordForHangmanSelf.txt");
            SelectInsertedWord();
        }

        public void SelectInsertedWord()
        {
            Console.Clear();

            hangman = new Hangman();
            words = new Words();
            string[] MyOwnPlayWords = OwnWordsInTextFile.Split(';');
            foreach (var CoolWords in MyOwnPlayWords)
            {
                Console.Write(CoolWords + " ");
            }

            Console.WriteLine(" ");
            Console.Write(
                "Choose the word you want to guess (1 --> 1. Word, 2 --> 2. Word etc. '{0}' for the chosen one): ",
                MyOwnPlayWords.Length - 1);
            var SelectWord = Console.ReadLine();
            string OwnRightWord = MyOwnPlayWords[Convert.ToInt16(SelectWord) - 1];
            words.OnlyLengthWord(OwnRightWord);
        }
    }
}