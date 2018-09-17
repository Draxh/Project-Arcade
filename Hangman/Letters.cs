using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class Letters
    {
        private static bool _showStart = true;
        private static int _life = 9;
        private static int IndexOfWord;

        public static int Life
        {
            get => _life;
            set => _life = value;
        }

        public static bool ShowStart
        {
            get => _showStart;
            set => _showStart = value;
        }

        public void CheckEntryLetter()
        {
            int n;
            bool IsNumeric;
            // string checkEntry = Hangman.EntryLetter;
            var chars = new char[] {Convert.ToChar(Hangman.EntryLetter)};
            if (IsNumeric = int.TryParse(Convert.ToString(chars), out n) || chars.Length >= 2 || chars.Length < 1)
            {
                Console.WriteLine("Falsche Eingabe");
                _showStart = false;
            }
            else
            {
                _showStart = true;    
                // Console.WriteLine(checkEntry);
                LetterInWord(chars);
                
            }
            
        }

        public bool LetterInWord(char[] buchstaben)
        {
            // List<string> LettersInList = new List<string>();
            string RightWord = Words.PlayWord;
            //string CheckEntry = Hangman.EntryLetter;
            // CheckEntry = CheckEntry.ToUpper();
            RightWord = RightWord.ToLower();
            
            var hasFoundAll = true;
            for (var i = 0; i < buchstaben.Length; i++)
            {
                var buchstabe = buchstaben[i];
                if (!RightWord.Contains(Convert.ToString(buchstabe)))
                {
                    hasFoundAll = false;
                    Console.WriteLine("Der Buchstebe '{0}' befindet sich nicht im Wort!", buchstaben[i]);
                    _life--;
                    DrawHangman();
                    
                }
                else
                {
                    ShowLetterInWord();
                }
            }

            var count = (new HashSet<char>(RightWord)).Count;
            if (count != buchstaben.Length)
            {
                hasFoundAll = false;
            }

            return hasFoundAll;
            
            
            /*if (RightWord.Contains(CheckEntry))
            {
                IndexOfWord = RightWord.IndexOf(CheckEntry);
                Console.WriteLine("Der Buchstabe '{0}' befindet sich an der {1} Stelle!", CheckEntry, IndexOfWord + 1);
                // Console.WriteLine(Words.WhereToWrite);
                ShowLetterInWord();

            }
            else
            {
                Console.WriteLine("Der Buchstebe '{0}' befindet sich nicht im Wort!", CheckEntry);
                _life--;
                DrawHangman();
            }*/
        }

        public void ShowLetterInWord()
        
        {
            Hangman hangman = new Hangman();
            var chars = new char[] {Convert.ToChar(Hangman.EntryLetter)};
            char[] SplitedWord = Words.PlayWord.ToCharArray();

            for (int i = 0; i < Words.WhereToWrite; i++)
            {
                if (Convert.ToString(SplitedWord[i]) == Hangman.EntryLetter)
                {
                    Words.Replace[i] = Hangman.EntryLetter;
                }
            }

            Console.Write("Wort: ");
            foreach (var element in Words.Replace)
            {
                Console.Write(element);
            }
            Console.WriteLine(" ");
            
            hangman.Start();
            hangman.End();
                
        }

        private void DrawHangman()
        {
            
            switch (_life)
            {
                    
                    case 8:
                        DrawHangman1();
                        break;
                    case 7:
                        DrawHangman2();
                        break;
                    case 6:
                        DrawHangman3();
                        break;
                    case 5:
                        DrawHangman4();
                        break;
                    case 4:
                        DrawHangman5();
                        break;
                    case 3:
                        DrawHangman6();
                        break;
                    case 2:
                        DrawHangman7();
                        break;                    
                    case 1:
                        DrawHangman8();
                        break;
                    case 0:
                        DrawHangman9();
                        break;
                   
            }
        }

        private static void DrawHangman9()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |  /     |");
            Console.WriteLine("   | /      |");
            Console.WriteLine("   |/      _|_");
            Console.WriteLine("   |      |___|");
            Console.WriteLine("   |      \\ | /");
            Console.WriteLine("   |       \\|/");
            Console.WriteLine("   |        |");
            Console.WriteLine(" __|__     / \\");
            Console.WriteLine("|     |   /   \\");
        }

        private static void DrawHangman8()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |  /     |");
            Console.WriteLine("   | /      |");
            Console.WriteLine("   |/      _|_");
            Console.WriteLine("   |      |___|");
            Console.WriteLine("   |      \\ | /");
            Console.WriteLine("   |       \\|/");
            Console.WriteLine("   |        |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman7()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |  /     |");
            Console.WriteLine("   | /      |");
            Console.WriteLine("   |/      _|_");
            Console.WriteLine("   |      |___|");
            Console.WriteLine("   |        |");
            Console.WriteLine("   |        |");
            Console.WriteLine("   |        |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman6()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |  /    |");
            Console.WriteLine("   | /     |");
            Console.WriteLine("   |/     _|_");
            Console.WriteLine("   |     |___|");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman5()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |  /    |");
            Console.WriteLine("   | /     |");
            Console.WriteLine("   |/      |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman4()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |  /");
            Console.WriteLine("   | /");
            Console.WriteLine("   |/");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman3()
        {
            Console.WriteLine("    _______");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman2()
        {
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine("   |");
            Console.WriteLine(" __|__ ");
            Console.WriteLine("|     |");
        }

        private static void DrawHangman1()
        {
            Console.WriteLine(" ____ ");
            Console.WriteLine("|    |");
        }
    }
}