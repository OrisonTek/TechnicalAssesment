using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {

        [TestMethod] 
        public void DeployRoversTest()
        {
            ILandingSurface landingSurface = new Plateau("5 5");
            RoverSquad roverSquad = new RoverSquad(landingSurface);

            roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");

            int noRovers = 2;
            int roverOneIdx = 0;
            int roverTwoIdx = 1;

            Assert.IsTrue(roverSquad.Count() == noRovers);

            IRover roverOne = roverSquad[roverOneIdx];
            IRover roverTwo = roverSquad[roverTwoIdx];

            Assert.IsNotNull(roverOne);
            Assert.IsNotNull(roverTwo);
        }

    [TestMethod]
    public void DeployRoversAndTestCoordinates()
    {
        ILandingSurface landingSurface = new Plateau("5 5");
        RoverSquad roverSquad = new RoverSquad(landingSurface);

        roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
        roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");

        int roverOneIdx = 0;
        int roverTwoIdx = 1;

        IRover roverOne = roverSquad[roverOneIdx];
        IRover roverTwo = roverSquad[roverTwoIdx];

        Assert.IsTrue(roverOne.XCoordinate == 1, "RoverOne: X != 1");
        Assert.IsTrue(roverOne.YCoordinate == 3, "RoverOne: Y != 3");
        Assert.IsTrue(roverOne.DirectionFacing == "N", "RoverOne: Direction != North");

        Assert.IsTrue(roverTwo.XCoordinate == 5, "RoverTwo: X != 5");
        Assert.IsTrue(roverTwo.YCoordinate == 1, "RoverTwo: Y != 1");
        Assert.IsTrue(roverTwo.DirectionFacing == "E", "RoverTwo: Direction != East");
    }


}
    
