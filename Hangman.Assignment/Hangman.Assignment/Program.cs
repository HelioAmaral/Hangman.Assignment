using System.Collections.Generic;
using static System.Random;
using System.Text;

internal class Program
{
    private static void hangmanPrint(int wrongAnswer)
    {
        if(wrongAnswer == 0)
        {
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
        }
        else if (wrongAnswer == 1)
        {

            Console.WriteLine("\n----");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");

        }
        else if (wrongAnswer == 2)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
        }
        else if (wrongAnswer == 3)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine("     |");
            Console.WriteLine("     |");
            Console.WriteLine("     |");
            Console.WriteLine("      ");

        }
        else if (wrongAnswer == 4)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine("     |");
            Console.WriteLine("     |");
            Console.WriteLine("     |");
            Console.WriteLine("    ===");
        }
        else if (wrongAnswer == 5)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine(" o   |");
            Console.WriteLine("     |");
            Console.WriteLine("     |");
            Console.WriteLine("    ===");
        }
        else if (wrongAnswer == 6)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine(" o   |");
            Console.WriteLine(" |   |");
            Console.WriteLine("     |");
            Console.WriteLine("    ===");
        }
        else if (wrongAnswer == 7)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine(" o   |");
            Console.WriteLine("/|   |");
            Console.WriteLine("     |");
            Console.WriteLine("    ===");
        }
        else if (wrongAnswer == 8)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine(" o    |");
            Console.WriteLine("/|\\   |");
            Console.WriteLine("      |");
            Console.WriteLine("     ===");
        }
        else if (wrongAnswer == 9)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine(" o    |");
            Console.WriteLine("/|\\   |");
            Console.WriteLine("/     |");
            Console.WriteLine("     ===");
        }
        else if (wrongAnswer == 10)
        {
            Console.WriteLine("\n+----+");
            Console.WriteLine(" o    |");
            Console.WriteLine("/|\\   |");
            Console.WriteLine("/ \\   |");
            Console.WriteLine("     ===");
        }
    }

    private static int wordPrint(List<char>lettersUserGuessed, String randomWord)
    {
        int wordCounter = 0;
        int correctLetters = 0;
        Console.Write("\r\n");
        foreach (char c in randomWord)
        {
            if(lettersUserGuessed.Contains(c))
            {
                Console.Write(c + " ");
                correctLetters++;
            }
            else
            {
                Console.Write(" ");
            }
            wordCounter++;
        }
        return correctLetters;
    }

    private static void linesPrint(String randomWord)
    {
        Console.Write("\r");
        foreach (char c in randomWord)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("\u0305");
        }
    }



    private static void Main(string[] args)
    {
        Console.WriteLine("---------HANGMAN---------");

        Random random = new Random();
        List<string> wordList = new List<string> { "coding", "learning", "vacations", "polymorphism", "inheritance", "software" };
        int index = random.Next(wordList.Count);
        String randomWord = wordList[index];

        foreach (char item in randomWord)
        {
            Console.Write("_ ");
        }

        int lengthOfWord = randomWord.Length;
        int numberTimesWrong = 0;
        List<char> lettersGuessed = new List<char>();
        int lettersGuessedRight = 0;

        while(numberTimesWrong != 10 && lettersGuessedRight != lengthOfWord)
        {
            Console.Write("\nLetters guessed: ");
            foreach (char letter in lettersGuessed) 
            {
                Console.Write(letter + " ");
            }
            Console.Write("\nGuess a letter: ");
            char letterUserGuessed = Console.ReadLine()[0];

            if (lettersGuessed.Contains(letterUserGuessed))
            {
                Console.Write("\r\nYou have already guessed this letter.");
                hangmanPrint(numberTimesWrong);
                lettersGuessedRight = wordPrint(lettersGuessed, randomWord);
                linesPrint(randomWord);
            }
            else
            {
                bool right = false;
                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (letterUserGuessed == randomWord[i])
                    {
                        right = true;
                    }
                }

                if (right)
                {
                    hangmanPrint(numberTimesWrong);
                    lettersGuessed.Add(letterUserGuessed);
                    lettersGuessedRight = wordPrint(lettersGuessed, randomWord);
                    linesPrint(randomWord);
                }
                else
                {
                    numberTimesWrong++;
                    lettersGuessed.Add(letterUserGuessed);
                    hangmanPrint(numberTimesWrong);
                    lettersGuessedRight = wordPrint(lettersGuessed, randomWord);
                    Console.Write("\r\n");
                    linesPrint(randomWord);

                }
            }

        }

        Console.WriteLine("\r\nGame is over!");
    }
}