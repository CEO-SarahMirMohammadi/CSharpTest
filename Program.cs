using System;

namespace NumberGuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Number Guess Game";
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private int maxNumber = 100;
        private int secretNumber;
        private int attempts;

        public void Start()
        {
            Console.WriteLine("Welcome to Number Guess Game!");
            Console.WriteLine($"Try to guess the number between 1 and {maxNumber}.");

            Random rand = new Random();
            secretNumber = rand.Next(1, maxNumber + 1);
            attempts = 0;

            bool guessed = false;

            while (!guessed)
            {
                Console.Write("Enter your guess: ");
                
                // Make input nullable-safe
                string? input = Console.ReadLine(); // string? allows null

                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Please enter a valid number!");
                    continue;
                }

                attempts++;

                if (guess < secretNumber)
                    Console.WriteLine("Too low!");
                else if (guess > secretNumber)
                    Console.WriteLine("Too high!");
                else
                    guessed = true;
            }

            Console.WriteLine($"Congratulations! You guessed the number {secretNumber} in {attempts} attempts.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
