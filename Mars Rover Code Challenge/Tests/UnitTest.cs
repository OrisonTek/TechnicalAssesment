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

       
}
    
