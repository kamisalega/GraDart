using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Turns
    {
        private readonly int _arrow1;
        private readonly int _arrow2;
        private readonly int _arrow3;

        public Turns(int arrow1, int arrow2, int arrow3)
        {
            _arrow1 = arrow1;
            _arrow2 = arrow2;
            _arrow3 = arrow3;
        }



        public int CurrentScore()
        {
            int totalScore;
            totalScore = _arrow1 + _arrow2 + _arrow3;
            return totalScore;
        }



        public override string ToString()
        {
            return string.Format("Arrow 1: {0} points, Arrow 2: {1} points and Arrow 3: {2} points", _arrow1, _arrow2, _arrow3);
        }


    }
}
