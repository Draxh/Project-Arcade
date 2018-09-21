using System;
 using System.Collections.Generic;
 using System.Linq.Expressions;
 
 namespace Hangman
 {
     public class Words
     {
         private string WordsInTextFile;
         private static string _playWord;
         private static int _whereToWrite;
         private static string myPlayWords;
         private static string[] _replace;
         private static Hangman hangman;

         public static string[] Replace
         {
             get => _replace;
             set => _replace = value;
         }

         public static int WhereToWrite
         {
             get => _whereToWrite;
             set => _whereToWrite = value;
         }

         public static string PlayWord
         {
             get => _playWord;
             set => _playWord = value;
         }
 
         private void GetWords(string Language)
         {
             WordsInTextFile = System.IO.File.ReadAllText(@"..\..\..\TextForHangman\WordForHangman" + Language + ".txt");
             splitWords();
         }

         public void SetLanguage()
         {
             Console.WriteLine("Möchten Sie Englische oder Deutsche Wörter? [E|D]");
             string SetLanguage = Console.ReadLine();
             SetLanguage = SetLanguage.ToUpper();
             switch (SetLanguage)
             {
                 case "D":
                     SetLanguage = "German";
                     Console.Clear();
                     break;
                 case "E":
                     SetLanguage = "English";
                     Console.Clear();
                     break;
                 default:
                     Console.WriteLine("Falsche Eingabe");
                     break;
             }
             
             GetWords(SetLanguage);
         }
         
         public void splitWords()
         {
             
                 
             string[] myPlayWords = WordsInTextFile.Split(';');
             
             Random rnd = new Random();
             int rndIndex = rnd.Next(0, myPlayWords.Length - 1);
             // Console.WriteLine(myPlayWords[rndIndex]);
             _playWord = myPlayWords[rndIndex];
             // Console.WriteLine(_playWord);
            
             OnlyLengthWord(_playWord);
         }

         public void OnlyLengthWord(string LenghtPlayWord)
         {
             
             Console.Clear();
             hangman = new Hangman();
             
             Console.Write("Wort: ");
             string FancyPlayWord = LenghtPlayWord;
             _replace = new string[FancyPlayWord.Length];
             for (int i = 0; i < FancyPlayWord.Length; i++)
             {
                 _replace[i] = "_ ";
             }

             foreach (var element in _replace)
             {
                 Console.Write(element);
             }

             Console.WriteLine(" ");
             
             _whereToWrite = FancyPlayWord.Length;
             hangman.StartNormal(FancyPlayWord);
         }
     }
 }