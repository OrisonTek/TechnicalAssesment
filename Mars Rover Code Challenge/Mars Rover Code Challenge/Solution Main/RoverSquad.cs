using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover_Code_Challenge.Solution_Main
{
    class RoverSquad : List<IRover>
    {

    public RoverSquad(ILandingSurface landingSurface)
    {
        this.LandingSurface = landingSurface;
    }

    public ILandingSurface LandingSurface { get; private set; }

    public void DeployNewRover(string roverPosition, string roverCommands)
    {
        this.Add(new Rover(this, this.LandingSurface, roverPosition, roverCommands));
    }

}
}
