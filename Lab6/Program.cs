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
            string Sentence;
            bool RunProgram = true;
            bool DoAgain;

            while (RunProgram == true)
            {
                Console.WriteLine("Hello! Welcome to Lab Number 6!");
                System.Threading.Thread.Sleep(500);

                //input & convert to lowercase
                Console.WriteLine("Please enter a sentence to be translated into Pig Latin:");

                Sentence = Console.ReadLine().ToLower();

                //validate that input is not empty
                while (Regex.Match(Sentence, @"^\s*$").Success)
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid input, please try again.");
                    Sentence = Console.ReadLine();
                }

                //if validation passed, print result
                Console.WriteLine(TranslatePigLatin(Sentence));

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
        public static string TranslatePigLatin(string sentence)
        {
            List<string> PigLatin = new List<string>();

            foreach (string word in sentence.Split(' '))
            {
                if ("aeiouAEIOU".Contains(word[0])) //if word begins with vowel
                {
                    PigLatin.Add(word + "way");
                }
                else if (Regex.Match(word, @"[^A-Za-z\.\,\'\!\?]").Success) //if word contains special characters or numbers
                {
                    PigLatin.Add(word);
                }
                else //if word begins with consonant
                {
                    char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
                    int VowelIndex = word.IndexOfAny(Vowels); //finds index of first vowel
                    string Prefix = word.Substring(0, VowelIndex); //finds the letters up to the first vowel
                    string NewWord = word.Substring(VowelIndex); //gets the letters after the first vowel

                    PigLatin.Add(NewWord + Prefix + "ay");
                }
            }
            return string.Join(" ", PigLatin);
        }
    }
}
