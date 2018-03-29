using System.Collections.Generic;
using theprophecy.Models;

namespace theprophecy
{
    public interface IGame
    {
        Room CurrentRoom { get; set; }

        void Setup();
        void Reset();

    }
}