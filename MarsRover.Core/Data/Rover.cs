using System;

namespace MarsRover.Core
{
    public class Rover
    {
        public int X_cordinate { get; set; }
        public int Y_cordinate { get; set; }
        public Compass Compass { get; set; }
        public string Direction { get; set; }
    }
}
