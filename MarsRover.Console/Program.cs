using MarsRover.Core;
using MarsRover.Core.Interface;
using MarsRover.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsRoverChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Depency Injection
            var serviceProvider = new ServiceCollection()
    
           .AddTransient<IRoverService, RoverService>()
       
           .BuildServiceProvider();

            //Test Rovers
            Rover rover = new Rover
            {X_cordinate =3,
            Y_cordinate =3,
             Compass = Compass.East,
            Direction = "LMLMLMLMM"

            };
            Rover rover2 = new Rover
            {
                X_cordinate = 4,
                Y_cordinate = 3,
                Compass = Compass.South,
                Direction = "LLMLMLMM"

            };
            Rover rover3 = new Rover
            {
                X_cordinate = 3,
                Y_cordinate = 3,
                Compass = Compass.West,
                Direction = "MMRMMRMRRM"

            };
            List<Rover> listOfRovers = new List<Rover>();

            listOfRovers.Add(rover);
            listOfRovers.Add(rover2);
            listOfRovers.Add(rover3);

            var roverDirections = serviceProvider.GetService<IRoverService>();
            var data = roverDirections.InputForSingleRoverDirections(rover);
            var listOfRoversDirections = roverDirections.InputForMultiRoversDirections(listOfRovers);

            Console.WriteLine("***********Single Rover Test***********");

            Console.WriteLine(data);


            Console.WriteLine("***********Multi Rovers Test***********");
            foreach (var tempRover in listOfRoversDirections)
            {
                Console.WriteLine(tempRover);
            }


            Console.ReadLine();
        }

        
    }
}
