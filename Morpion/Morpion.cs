using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Morpion
    {
        private char[,] maps = new char[3, 3];
        private char player1 = 'X';
        private char player2 = 'O';
        private char currentPlayer;
        private bool statGame = false;
        private bool isWinner = false;
        private string deplacement = null;
        private string pc;

        public Morpion()
        {
            currentPlayer = player2;

            //Initialisaton de la map
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    maps[i, j] = '.';
                }
            }
        }

        private void displayMap()
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(maps[i, j] + "\t");
                }
                Console.WriteLine('\n');
            }
        }

        private object play(string position, char player)
        {
            if (position.Length == 3)
            {
                int l = int.Parse(position.Split(',')[0]);
                int c = int.Parse(position.Split(',')[1]);
                if (maps[l - 1, c - 1].Equals('.'))
                {
                    maps[l - 1, c - 1] = player;
                    return true;
                }
                else return "Deplacement invalide: Case ciblé occupé";
                    
            }
                else return "Deplacement invalide: Syntaxe de déplacement incorrect";
        }

        private bool checkWinner(char player)
        {
            if (maps[0, 0].Equals(player) && maps[0, 1].Equals(player) && maps[0, 2].Equals(player))
            {
                return true;
            }
            if (maps[1, 0].Equals(player) && maps[1, 1].Equals(player) && maps[1, 2].Equals(player))
            {
                return true;
            }
            if (maps[2, 0].Equals(player) && maps[2, 1].Equals(player) && maps[2, 2].Equals(player))
            {
                return true;
            }
            if (maps[0, 0].Equals(player) && maps[1, 0].Equals(player) && maps[2, 0].Equals(player))
            {
                return true;
            }
            if (maps[0, 1].Equals(player) && maps[1, 1].Equals(player) && maps[2, 1].Equals(player))
            {
                return true;
            }
            if (maps[0, 2].Equals(player) && maps[1, 2].Equals(player) && maps[2, 2].Equals(player))
            {
                return true;
            }
            if (maps[0, 0].Equals(player) && maps[1, 1].Equals(player) && maps[2, 2].Equals(player))
            {
                return true;
            }
            if (maps[0, 2].Equals(player) && maps[1, 1].Equals(player) && maps[2, 0].Equals(player))
            {
                return true;
            }
            return false;
        }

        private bool gameIsNull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (maps[i, j].Equals('.'))
                        return false;
                }
            }
            if (checkWinner(player1) || checkWinner(player2))
                return false;
            return true;
        }

        private void reinitialMap()
        {
            //Initialisaton de la map
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    maps[i, j] = '.';
                }
            }
        }

        public void startGame()
        {
            Console.WriteLine("Bienvenu dans morpion\nPlayer 1 : X \nPlayer 2 : O");
            displayMap();
            do
            {
                currentPlayer = (currentPlayer == player2) ? player1 : player2;
                Object positionIsValide;
                do
                {
                    Console.Write("Player " + ((currentPlayer == 'X') ? '1' : '2') + ": ");
                    positionIsValide = play(Console.ReadLine(), currentPlayer);
                    if(!positionIsValide.Equals(true))
                        Console.WriteLine(positionIsValide);

                } while (!positionIsValide.Equals(true));

                displayMap();
            } while (!checkWinner(currentPlayer) && !gameIsNull());
            if (!gameIsNull())
            {
                Console.WriteLine("Winner: Player"+ ((currentPlayer == 'X') ? '1' : '2') + "(" + currentPlayer + ")");
            } else
            {
                Console.WriteLine("Game null");
            }
        }
    }
}
