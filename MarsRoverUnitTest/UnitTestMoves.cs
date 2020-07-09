using System;
using System.Collections.Generic;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverUnitTest
{
    [TestClass]
    public class UnitTestMoves
    {
        [TestMethod]
        public void Scenario_12N_LMLMLMLMM()
        {
            List<int> boundaries = new List<int>() { 5, 5 };

            int startX = 1;
            int startY = 2;
            char startDirection = 'N';

            Rover rover = new Rover(1, startX, startY, startDirection);
            rover.MaxX = boundaries[0] + 1;
            rover.MaxY = boundaries[1] + 1;

            rover.Moves = "LMLMLMLMM";
            rover.Go();

            string result = "1 3 N";

            Assert.AreEqual(rover.ToString(), result);
        }

        [TestMethod]
        public void Scenario_33E_MMRMMRMRRM()
        {
            List<int> boundaries = new List<int>() { 5, 5 };

            int startX = 3;
            int startY = 3;
            char startDirection = 'E';

            Rover rover = new Rover(1, startX, startY, startDirection);
            rover.MaxX = boundaries[0] + 1;
            rover.MaxY = boundaries[1] + 1;

            rover.Moves = "MMRMMRMRRM";
            rover.Go();

            string result = "5 1 E";

            Assert.AreEqual(rover.ToString(), result);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfBoundsException))]
        public void Scenario_OutOfBoundsException()
        {
            List<int> boundaries = new List<int>() { 5, 5 };

            int startX = 3;
            int startY = 3;
            char startDirection = 'E';

            Rover rover = new Rover(1, startX, startY, startDirection);
            rover.MaxX = boundaries[0] + 1;
            rover.MaxY = boundaries[1] + 1;

            rover.Moves = "MMMMMMMMMMMMM";
            rover.Go();
        }
    }
}
