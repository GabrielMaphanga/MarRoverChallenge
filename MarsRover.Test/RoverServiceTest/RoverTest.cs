using MarsRover.Core;
using MarsRover.Core.Interface;
using MarsRover.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasRover.Test.RoverServiceTest
{

    [TestClass]
    public class RoverTest
    {
        private IRoverService _roverService;


        [TestInitializeAttribute]
        public void Initialize()
        {
            _roverService = new RoverService();
        }

        [TestMethod]
        public void Test_Input_For_Single_Rover_Directions()
        {
            Rover rover = new Rover
            {
                X_cordinate = 3,
                Y_cordinate = 3,
                Compass = Compass.East,
                Direction = "LMLMLMLMM"

            };
            
            var directions = _roverService.InputForSingleRoverDirections(rover);
            Assert.That.Equals(string.Equals(directions, "5 0 East"));

        }

        [TestMethod]
        public void Test_Input_For_Multi_Rovers_Directions()
        {
            //Test Rovers
            Rover rover = new Rover
            {
                X_cordinate = 3,
                Y_cordinate = 3,
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

            var resultedDirections = _roverService.InputForMultiRoversDirections(listOfRovers);

            List<string> expected = new List<string>();
            expected.Add("5 0 East");
            expected.Add("5 0 East");
            expected.Add("0 -4 South");
            expected.Add("-6 0 West");
            CollectionAssert.That.Equals(string.Equals(resultedDirections, expected));

        }

    }
}
