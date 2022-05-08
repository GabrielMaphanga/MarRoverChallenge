using MarsRover.Core;
using MarsRover.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Service.Service
{
    public class RoverService : IRoverService
    {
        public List<string> InputForMultiRoversDirections(List<Rover> rovers)
        {
            List<string> roversLocations = new List<string>();

            foreach(var rover in rovers)
            {
                var locatoins = this.InputForSingleRoverDirections(rover);
                roversLocations.Add(locatoins);
            }
            return roversLocations;
        }

        public string InputForSingleRoverDirections(Rover rover)
        {
            //We assume the rover lends facing north
            int x_origin = 0;
            int y_origin = 0;
            string final_directions;

            //If no string direction was given and direction
            if (string.IsNullOrWhiteSpace(rover.Direction) && rover.Compass == Compass.Undefined)
            {
                x_origin += rover.X_cordinate;
                y_origin += rover.Y_cordinate;

                //We assume the Rover is facing norith 
                final_directions = $"{x_origin} {y_origin} N";
                return final_directions;
            }
            else
            {
                //To count Left or Right repeations in the intruction string
                int LCount = 0;
                int RCount = 0;

                //rover.Direction.ToCharArray().Count(c => c == 'M');
                int DirectionLength = rover.Direction.Length;
                var tempDirectionString = rover.Direction.ToUpper();
                char[] instructions = tempDirectionString.ToCharArray();
                Compass compass = rover.Compass;
                

                for (int i = 0; i < DirectionLength; i++)
                {
                    if (!Char.IsWhiteSpace(instructions[i]))
                    {
                        if (Char.IsLetter(instructions[i]))
                        {
                            if (instructions[i].Equals('L') && (LCount == 0) && rover.Compass == Compass.North)
                            {
                                compass = Compass.West;
                                LCount++;
                            }
                            if (instructions[i].Equals('L') && (LCount == 1) && rover.Compass == Compass.East)
                            {

                                compass = Compass.South;
                                LCount++;
                            }
                            if (instructions[i].Equals('L') && (LCount == 2) && rover.Compass == Compass.South)
                            {
                                compass = Compass.East;
                                LCount++;
                            }
                            if (instructions[i].Equals('L') && (LCount == 3) && rover.Compass == Compass.West)
                            {
                                compass = Compass.North;
                                LCount = 0;
                            }

                            if (instructions[i].Equals('R') && (RCount == 0) && rover.Compass == Compass.North)
                            {
                                compass = Compass.East;
                                RCount++;
                            }
                            if (instructions[i].Equals('R') && (RCount == 1)   && rover.Compass == Compass.East)
                            {
                                compass = Compass.South;
                                RCount++;
                            }
                            if (instructions[i].Equals('R') && (RCount == 2) && rover.Compass == Compass.South)
                            {
                                compass = Compass.West;
                                RCount++;
                            }
                            if (instructions[i].Equals('R') && (RCount == 3) && rover.Compass == Compass.West)
                            {
                                compass = Compass.North;
                                RCount = 0;
                            }

                            if (instructions[i].Equals('M'))
                            {

                                if(compass == Compass.North)
                                {
                                    y_origin++;
                                 
                                }
                                if (compass == Compass.South)
                                {
                                    y_origin--;
                                    
                                }
                                if (compass == Compass.East)
                                {
                                    x_origin++;
                                    
                                }
                                else if (compass == Compass.West)
                                {
                                    x_origin--;
                                
                                }
                            }

                            
                        }


                    }

                }
                final_directions = $"{x_origin} {y_origin} {compass}";


            }

            return final_directions;

        }
    }
}
