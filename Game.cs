using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Game
    {
        private int totalPlayers;
        private int totalComputers;
        private Random _randomPercent;
        private Random _randomScore;
        private List<Player> _playersList;


        private int arrow1;
        private int arrow2;
        private int arrow3;

        private int percent1;
        private int percent2;
        private int percent3;

        public Game()
        {
            _playersList = new List<Player>();
            _randomPercent = new Random();
            _randomScore = new Random();
        }
        public void GameStart()
        {

            AddPlayer();

            int totalScore = 0;
            int totalScoreComputer = 0;

            int scoreGoal = 301;

            Console.WriteLine("O jaki wynik chciałbyś zagrać?");
            scoreGoal = Convert.ToInt32(Console.ReadLine());


            do
            {

                foreach (var player in _playersList)
                {
                    percent1 = _randomPercent.Next(0, 100);
                    percent2 = _randomPercent.Next(0, 100);
                    percent3 = _randomPercent.Next(0, 100);
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Teraz jest {0} kolej na grę! Otrzymasz trzy strzały.", player);
                    arrow1 = PlayerThrow(percent1);
                    arrow2 = PlayerThrow(percent2);
                    arrow3 = PlayerThrow(percent3);

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Twoje punkty to: Pierwsza strzałka: {0} punktów. Druga strzałka: {1} punktów. Trzecia strzałka: {2} punktów.", arrow1, arrow2, arrow3);
                    Console.WriteLine("{0}s punktów w tej rundzie to: {1}", player, (arrow1 + arrow2 + arrow3));

                    player.AddTurn(arrow1, arrow2, arrow3);
                    totalScore = player.TotalScore();

                }

                foreach (var turn in _playersList)
                {
                    Console.WriteLine("Całkowity wynik dla {0} do tej pory wynosi {1}", turn, turn.TotalScore());

                    Console.WriteLine("-----------------------------------------");
                }
            } while ((totalScore <= scoreGoal));

            foreach (var player in _playersList)
            {
                Console.WriteLine("Całkowity wynik dla {0} to: {1}", player, player.TotalScore());
                player.PrintTotalScore();
            }

            Console.WriteLine("Dzięki za grę! Naciśnij dowolny klawisz aby zamknąć.");
            Console.ReadKey();
        }

        private int PlayerThrow(int percent)
        {
            Console.WriteLine("Środek daje najwięcej punktów");

            int switchSelection = Convert.ToInt32(Console.ReadLine());


            int score = 0;

            // Den här switchcase innehåller flertalet cases beroende på vad man väljer.
            switch (switchSelection)
            {
                case 1:

                    if (percent > 85)
                    {
                        score = 20;
                        Console.WriteLine("Masz {0} punktów!", score);
                    }
                    else
                    {
                        score = 0;
                        Console.WriteLine("Chybiłeś!");
                    }
                    break;
                case 2:

                    if (percent > 60)
                    {
                        score = _randomScore.Next(5, 15);
                        Console.WriteLine("Niezły rzut! Masz {0} punktów!!", score);
                    }
                    else
                    {
                        score = 0;
                        Console.WriteLine("Chybiłeś!");
                    }
                    break;
                case 3:
                    if (percent > 30)
                    {
                        score = _randomScore.Next(1, 10);
                        Console.WriteLine("Trafienie! Masz {0} punktów!", score);
                    }
                    else
                    {
                        score = 0;
                        Console.WriteLine("Chybiłeś!");
                    }
                    break;
                default:
                    Console.WriteLine("Wybierz liczbę od 1 do 3");
                    break;
            }
            return score;
        }

        public void AddPlayer()
        {

            Console.WriteLine("Ilu jest tam graczy?");
            totalPlayers = Convert.ToInt32(Console.ReadLine());


            for (int i = 0; i < totalPlayers; i++)
            {
                Console.WriteLine("Wpisz swoje imię i naciśnij enter.");
                _playersList.Add(new Player()
                {
                    PlayerName = Console.ReadLine(),

                });
                Console.WriteLine("------------------------------------------");

            }

        }
    }
}
