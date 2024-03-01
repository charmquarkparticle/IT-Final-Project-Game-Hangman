using System;
using System.Linq;

class Hangman
{
    static void Main(string[] args)
    {
        string[] words = { "electricity", "garbage", "grass", "matter", "newspaper", "orange", "pencil", "Appearance", "bathroom", "department", "homework", "language", "midnight", "obligation" };
        string guessTheWord = words[new Random().Next(words.Length)];   

        char[] guessTheLetters = new char[guessTheWord.Length];
        int chance = 12;

        Console.WriteLine("guess the word:");

        for (int i = 0; i < guessTheWord.Length; i++)
        {
            guessTheLetters[i] = '*';                   
            Console.Write("* ");
        }
        Console.WriteLine();

        while (chance > 0)
        {
            Console.WriteLine($"You have {chance} attempts left");
            Console.Write("Guess the letter: ");
            char enteredLetter = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (!char.IsLetter(enteredLetter))   
            {
                Console.WriteLine("Enter only one letter ! ");
                continue;
            }

            if (guessTheWord.Contains(enteredLetter))    
            {
                for (int i = 0; i < guessTheWord.Length; i++)
                {
                    if (guessTheWord[i] == enteredLetter)
                    {
                        guessTheLetters[i] = enteredLetter;
                    }
                }
            }
            else
            {
                Console.WriteLine("You could not guess the correct letter");
                chance--;
            }

            Console.WriteLine(string.Join(" ", guessTheLetters));

            if (!guessTheLetters.Contains('*'))   
            {
                Console.WriteLine("You guessed the word correctly");
                return;
            }
        }

        Console.WriteLine("Unfortunately, you could not guess the word, the chances of recognizing the letters are over. The guess word was: ყ" + guessTheWord);
    }
}