using System.Collections.Generic;

namespace Project.Game.Model
{
    public class GameModel
    {
        public List<string> BaseWords { get; set; }
        public List<string> AvailableWords { get; set; }
        public int BaseLives { get; set; }
        public int AvailableLives { get; set; }
        public string AvailableLetters { get; set; }

    }
}