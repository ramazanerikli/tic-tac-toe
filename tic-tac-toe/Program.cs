using System;

using System.Threading;

namespace tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {

            // Game state
            bool playing = true;
            bool isBoardFull = false;
            bool isMainMenu = true;
            int currentPlayer = 0;
            int mark = 0;
            int option = 0;
            string sureOption = "";
            char[] gameTexture = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

            while (isMainMenu)
            {
                Console.Clear();
                playing = false;
                Intro();

                // Main menu options
                option = int.Parse(Console.ReadLine());

                // New game
                if (option == 1)
                {
                    Console.Clear();
                    isMainMenu = false;
                    playing = true;
                    gameTexture[0] = ' ';
                    gameTexture[1] = ' ';
                    gameTexture[2] = ' ';
                    gameTexture[3] = ' ';
                    gameTexture[4] = ' ';
                    gameTexture[5] = ' ';
                    gameTexture[6] = ' ';
                    gameTexture[7] = ' ';
                    gameTexture[8] = ' ';
                }

                // About the author
                if (option == 2)
                {
                    Console.Clear();
                    playing = false;
                    Console.WriteLine("Created by Ramazan Erikli.");
                    // Get the ascii code that user have entered
                    int userSelectAscii = Console.Read();
                    // Convert the ascii code to string
                    string userSelect = Char.ConvertFromUtf32(userSelectAscii);
                    // If user press enter, return the main menu
                    if (userSelectAscii == 10)
                    {
                        Console.Clear();
                        Intro();
                        isMainMenu = true;
                    }

                }

                // Exit 
                if (option == 3)
                {
                    Console.Clear();
                    playing = false;
                    Console.WriteLine("Are you sure you want to quit? [y/n]");
                    Console.Write("> ");
                    sureOption = Console.ReadLine();
                    if (sureOption == "y")
                    {
                        Environment.Exit(0);
                    }
                    if (sureOption == "n")
                    {
                        Console.Clear();
                        Intro();
                        isMainMenu = true;
                    }
                }
            }

            while (playing)
            {
                Console.Clear();
                GameBoard(gameTexture);
                AskInput(currentPlayer, gameTexture, mark, playing);

                // Switch players to 1 & 0
                currentPlayer = currentPlayer == 1 ? 0 : 1;

                // Winning conditions (rows, columns, diagonals)
                if (
                  (gameTexture[0] == gameTexture[1] && gameTexture[1] == gameTexture[2] && gameTexture[2] != ' ') ||
                  (gameTexture[3] == gameTexture[4] && gameTexture[4] == gameTexture[5] && gameTexture[5] != ' ') ||
                  (gameTexture[6] == gameTexture[7] && gameTexture[7] == gameTexture[8] && gameTexture[8] != ' ') ||
                  (gameTexture[0] == gameTexture[3] && gameTexture[3] == gameTexture[6] && gameTexture[6] != ' ') ||
                  (gameTexture[1] == gameTexture[4] && gameTexture[4] == gameTexture[7] && gameTexture[7] != ' ') ||
                  (gameTexture[2] == gameTexture[5] && gameTexture[5] == gameTexture[8] && gameTexture[8] != ' ') ||
                  (gameTexture[0] == gameTexture[4] && gameTexture[4] == gameTexture[8] && gameTexture[8] != ' ') ||
                  (gameTexture[2] == gameTexture[4] && gameTexture[4] == gameTexture[6] && gameTexture[6] != ' ')
                )
                {
                    {
                        playing = false;
                        isBoardFull = true;
                    }
                }

            }

            while (!playing)
            {
                // All marks have done
                if (isBoardFull)
                {
                    Console.Clear();
                    GameBoard(gameTexture);

                    // Show the winner 
                    if (currentPlayer == 0)
                    {
                        Console.WriteLine("0 won!");
                    }
                    else
                    {
                        Console.WriteLine("X won!");
                    }

                    // Back to the main menu
                    Console.WriteLine("[Press enter to return to main menu...]");
                }

                // Get the ascii code that user have entered
                int userSelectAscii = Console.Read();
                // Convert the ascii code to string
                string userSelect = Char.ConvertFromUtf32(userSelectAscii);

                // If user press enter, return the main menu
                if (userSelectAscii == 10)
                {
                    Console.Clear();
                    Intro();
                    isBoardFull = false;
                    isMainMenu = true;
                }

            }

            Console.Clear();
            Intro();
            GameBoard(gameTexture);
            AskInput(currentPlayer, gameTexture, mark, playing);

            // Ask user for the move
            static void AskInput(int currentPlayer, char[] gameTexture, int mark, bool playing)
            {

                // If current player equals to 0, turns X, otherwise turns O
                if (currentPlayer == 0)
                {
                    Console.Write("X's move > ");
                }
                else
                {
                    Console.Write("O's move > ");
                }

                // Store the number that user entered
                mark = int.Parse(Console.ReadLine());

                // If current player equals to 0, fill with X the relevant place on the game board
                if (currentPlayer == 0)
                {
                    gameTexture[mark - 1] = 'X';
                }

                // If current player equals to 1, fill with O the relevant place on the game board
                else
                {
                    gameTexture[mark - 1] = 'O';
                }
            }

            // Draw game board 
            static void GameBoard(char[] gameTexture)
            {
                Console.WriteLine($" {gameTexture[0]} | {gameTexture[1]} | {gameTexture[2]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {gameTexture[3]} | {gameTexture[4]} | {gameTexture[5]} ");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {gameTexture[6]} | {gameTexture[7]} | {gameTexture[8]} ");
            }

            // Game intro
            static void Intro()
            {
                Console.WriteLine("1. New game");
                Console.WriteLine("2. About the author");
                Console.WriteLine("3. Exit");
                Console.Write("> ");
            }

        }
    }
}