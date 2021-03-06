using System.Collections.Generic;
using theprophecy.Models;

namespace theprophecy
{
    public interface IRoom
    {
        string Name { get; set; }
        string Description { get; set; }
        Dictionary<string, Item> Items { get; set; }

        void UseItem(Item item);

    }
}