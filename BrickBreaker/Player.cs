using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Player
    {
        public int Lives { get; set; }
        public int Score { get; set; }
        public Player(int lives, int score)
        {
            Lives = lives;
            Score = score;
        }
    }
}
