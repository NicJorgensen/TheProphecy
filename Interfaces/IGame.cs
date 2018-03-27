using System.Collections.Generic;
using theprophecy.Models;

namespace theprophecy
{
    public interface IGame
    {
        Room CurrentRoom { get; set; }

        void Setup();
        void Reset();

        //No need to Pass a room since Items can only be used in the CurrentRoom
        void UseItem(string itemName);
    }
}