using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            string EnglishWord, PigLatin;
            string[] Sentence;
            bool RunProgram = true;
            bool DoAgain;

            while (RunProgram == true)
            {
                Console.WriteLine("Hello! Welcome to Lab Number 6!");
                System.Threading.Thread.Sleep(500);

                //input & convert to lowercase
                Console.WriteLine("Please enter a word to be translated into Pig Latin:");

                EnglishWord = Console.ReadLine().ToLower();
                //EnglishWord = Console.ReadLine(); ...amend to accept and keep case from user input

                //validate that input is not empty
                while(Regex.Match(EnglishWord,@"^\s*$").Success)
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid input, please try again.");
                    EnglishWord = Console.ReadLine();
                }
                
                    if ("aeiouAEIOU".Contains(EnglishWord[0])) //if word begins with vowel
                    {
                        Console.WriteLine(VowelFirst(EnglishWord));
                    }
                    else //if word begins with consonant
                    {
                        Console.WriteLine(ConsFirst(EnglishWord));
                    }

                DoAgain = false;

                while (DoAgain == false)
                {
                    //input to run again
                    Console.WriteLine("Would you like to translate another word? (Y/N)");

                    string UserResponse = Console.ReadLine();

                    if (String.Compare(UserResponse, "y", true) == 0) //Y -- run again
                    {
                        Console.Clear();
                        Console.WriteLine("Great! Here we go...");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                        DoAgain = true;
                    }
                    else if (String.Compare(UserResponse, "n", true) == 0) //N -- quit program
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(500);
                        RunProgram = false;
                        DoAgain = true;
                    }
                    else //invalid response
                    {
                        Console.WriteLine("Not a valid input.");
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                    }
                }
            }
        }
        public static string VowelFirst(string Word)
        {
            return Word + "way";
        }
        public static string ConsFirst(string Word)
        {
            char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'A','E','I','O','U' };
            int VowelIndex = Word.IndexOfAny(Vowels); //finds index of first vowel
            string Prefix = Word.Substring(0,VowelIndex); //finds the letters up to the first vowel
            string NewWord = Word.Substring(VowelIndex); //gets the letters after the first vowel

            return NewWord+Prefix+"ay";
        }
        //public static string PigLatin(string Word)
        //{

        //}
    }
}
