using System.Collections.Generic;
using theprophecy.Models;

namespace theprophecy
{
    public interface IPlayer
    {
        int Score { get; set; }
        List<Item> Inventory { get; set; }

    }
}