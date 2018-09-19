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
          
            Console.Write("Schreibe das Wort welches du haben möchtest: ");
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
            Console.Write("Wähle dein Wort aus mit welchem du Spielen möchtest (1 --> 1. Wort, 2 --> 2. Wort etc. '{0}' für das eingegebene): ", MyOwnPlayWords.Length - 1);
            var SelectWord = Console.ReadLine();
            string OwnRightWord = MyOwnPlayWords[Convert.ToInt16(SelectWord) - 1];
            words.OnlyLengthWord(OwnRightWord);
        }
    }
}