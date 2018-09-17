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
 
         private void GetWords()
         {
             WordsInTextFile = System.IO.File.ReadAllText(@"..\..\..\TextForHangman\WordForHangman.txt");
         }
 
         public void splitWords()
         {
             GetWords();
             string[] myPlayWords = WordsInTextFile.Split(';');
             
             Random rnd = new Random();
             int rndIndex = rnd.Next(0, myPlayWords.Length - 1);
             // Console.WriteLine(myPlayWords[rndIndex]);
             _playWord = myPlayWords[rndIndex];
             Console.WriteLine(_playWord);

            
             Console.Write("Wort: ");
             _replace = new string[_playWord.Length];
             for (int i = 0; i < _playWord.Length; i++)
             {
                 _replace[i] = "_ ";
             }

             foreach (var element in _replace)
             {
                 Console.Write(element);
             }

             Console.WriteLine(" ");
             _whereToWrite = _playWord.Length;
 
         }
         
         
         
     }
 }