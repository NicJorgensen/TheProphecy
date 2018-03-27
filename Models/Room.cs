using System.Collections.Generic;

namespace theprophecy.Models
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Directions { get; set; }
        public Dictionary<string, Item> Items { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Directions = new Dictionary<string, Room>();
            Items = new Dictionary<string, Item>();
        }

        public void UseItem(Item item)
        {

        }
    }
}