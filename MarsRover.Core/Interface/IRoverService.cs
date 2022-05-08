using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Interface
{
    public interface IRoverService
    {
        string InputForSingleRoverDirections(Rover rover);

        List<string> InputForMultiRoversDirections(List<Rover> rovers);
    }
}
