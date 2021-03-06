using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hangman
{
    public class Letters
    {
        private static bool _showStart = true;
        private static int _life = 9;
        private static int IndexOfWord;
        private static char[] _chars;
        private static Hangman hangman;
        static List<string> WringUsedletters = new List<string>();

        public static char[] Chars
        {
            get => _chars;
            set => _chars = value;
        }


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

        public void CheckEntryLetter(string DifferentPlayWords)
        {
            int n;
            bool IsNumeric;
            _chars = new char[] {Convert.ToChar(Hangman.EntryLetter)};
            string RightWord = DifferentPlayWords;
            if (IsNumeric = int.TryParse(Convert.ToString(_chars), out n) || _chars.Length >= 2 || _chars.Length < 1)
            {
                Console.WriteLine("Wrong entry");
                _showStart = false;
            }
            else
            {
                _showStart = true;

                LetterInWord(_chars, RightWord);
            }
        }

        public bool LetterInWord(char[] buchstaben, string RightWord)
        {
            RightWord = RightWord.ToLower();

            var hasFoundAll = true;
            for (var i = 0; i < buchstaben.Length; i++)
            {
                var buchstabe = buchstaben[i];

                if (!RightWord.Contains(Convert.ToString(buchstabe)))
                {
                    hasFoundAll = false;

                    Console.Clear();
                    Console.WriteLine("The letter '{0}' doesn't exist in the word!", buchstaben[i]);
                    _life--;
                    DrawHangman();

                    WringUsedletters.Add(Convert.ToString(buchstaben[i]));

                    Console.Write("Letters that don't exist in the word: ");

                    foreach (var WrongElements in WringUsedletters)
                    {
                        Console.Write(WrongElements + " ");
                    }

                    Console.WriteLine(" ");

                    Console.Write("Wort: ");
                    foreach (var element in Words.Replace)
                    {
                        Console.Write(element);
                    }

                    Console.WriteLine(" ");
                }
                else
                {
                    ShowLetterInWord(RightWord);
                }
            }

            var count = (new HashSet<char>(RightWord)).Count;
            if (count != buchstaben.Length)
            {
                hasFoundAll = false;
            }

            return hasFoundAll;
        }

        public void ShowLetterInWord(string ShowRightWord)

        {
            Hangman hangman = new Hangman();

            char[] SplitedWord = ShowRightWord.ToLower().ToCharArray();


            for (int i = 0; i < ShowRightWord.Length; i++)
            {
                if (Convert.ToString(SplitedWord[i]) == Hangman.EntryLetter)
                {
                    Words.Replace[i] = Hangman.EntryLetter;
                }
            }


            Words.Replace[0] = Words.Replace[0].ToUpper();

            Console.Clear();
            Console.Write("Wort: ");
            foreach (var element in Words.Replace)
            {
                Console.Write(element);
            }

            Console.WriteLine(" ");


            hangman.End(ShowRightWord);
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
                    hangman = new Hangman();
                    DrawHangman9();
                    Hangman.ShowTheStart = false;
                    Thread.Sleep(3000);
                    hangman.lose();
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