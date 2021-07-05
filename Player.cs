using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp4
{
    public class Player
    {

        private List<Turns> _playersTurns;
        public string PlayerName { get; set; }

        public Player()
        {
            _playersTurns = new List<Turns>();
        }

        public int TotalScore()
        {
            int total = 0;
            foreach (var turn in _playersTurns)
            {
                total = total + turn.CurrentScore();
            }
            return total;
        }

        public void AddTurn(int arrow1, int arrow2, int arrow3)
        {
            _playersTurns.Add(new Turns(arrow1, arrow2, arrow3));
        }

        public void PrintTotalScore()
        {
            foreach (var turns in _playersTurns)
            {
                Console.WriteLine("Twój wynik to: {0}", turns);
            }
        }
    }
}
