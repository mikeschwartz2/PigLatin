using System;
using System.Collections;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            string rerun = "";
            string english;

            do
            {
                Console.Write("Please enter a sentance to translate to pig latin: ");
                english = Console.ReadLine().ToLower();

                Translate(english);

                rerun = Rerun(rerun);
            }
            while (rerun == "y");
        }

            static string Rerun(string rerun)
            {
                Console.WriteLine("Would you like to translate another sentance? y/n");
                rerun = Console.ReadLine();
                rerun = rerun.ToLower();

                while (rerun != "y" && rerun != "n")
                {
                    Console.WriteLine("This is not a valid input. Would you like to continue: y/n");
                    rerun = Console.ReadLine();
                    rerun = rerun.ToLower();
                }
                return rerun;
            }

            static string Translate (string translate)
            {
                string[] words = translate.Split(' ');
                Queue<char> wordStack = new Queue<char>();
                int wordCount = 0;
                string pigLatin = "";
                int letterCount = 0;

                while (wordCount < words.Length)
                {
                    
                    if ("aeiouAEIOU".Contains(words[wordCount][0]))
                    {
                        words[wordCount] = words[wordCount] + "way ";
                    }
                    else
                    {
                        letterCount = 0;
                        while( letterCount < words[wordCount].Length )
                        {

                            if("aeiouAEIOU".Contains(words[wordCount][letterCount]))
                            {
                                words[wordCount] = words[wordCount].Substring(letterCount);
                                int i = 0;
                                while (i <= wordStack.Count)
                                {
                                    words[wordCount] = words[wordCount] + wordStack.Dequeue();

                                    i++;
                                }
                                break;
                            }
                            else
                            {
                                wordStack.Enqueue(words[wordCount][letterCount]);
                            }

                            letterCount++;
                        }
                        words[wordCount] = words[wordCount] + "ay ";
                    }

                    pigLatin = pigLatin + words[wordCount];
                    wordCount++;
                }
                Console.WriteLine("\n============================================");
                Console.WriteLine($"Translated sentance = {pigLatin}");

                return translate;

            }

        
    }
}
