using System.Collections.Generic;

namespace theprophecy.Models
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }

        public Player()
        {
            Score = 0;
            Inventory = new List<Item>();
        }
    }
}