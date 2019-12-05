using System;
using System.Collections.Generic;

namespace Point
{
    class Score
    {
        int score;
        public int GetScore()
        {
            return score;
        }
        public void AddPoint()
        {
            score++;
        }
        public void ResetScore()
        {
            score = 0;
        }
    }
}
