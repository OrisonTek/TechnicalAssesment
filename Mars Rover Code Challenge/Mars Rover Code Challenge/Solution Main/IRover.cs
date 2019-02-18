using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mars_Rover_Code_Challenge.Solution_Main
{
    interface IRover{
   
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        string DirectionFacing { get; set; }
        List<IRover> Squad { get; set; }

}
}
