using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover_Code_Challenge.Solution_Main
{
    class Rover : IRover
    {

    public Rover(List<IRover> squad, ILandingSurface landingSurface, string roverPosition, string roverCommands)
    {
        this.Squad = squad;

        this.TranslateRoverPosition(roverPosition);

        if (!RoverIsWithinLandingCoordinates(landingSurface))
            return;

        this.TranslateRoverCommands(roverCommands);
    }

    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }
    public string DirectionFacing { get; set; }
    public List<IRover> Squad { get; set; }

    private static readonly char MessageSeperator = ' ';

    private void TranslateRoverPosition(string roverPosition)
    {
        string[] roverPositionMsgSplit = roverPosition.Split(Rover.MessageSeperator);

        int xCoordinateIdx = 0;
        int yCoordinateIdx = 1;
        int facingDirectionIdx = 2;

        this.XCoordinate = Convert.ToInt32(roverPositionMsgSplit[xCoordinateIdx]);
        this.YCoordinate = Convert.ToInt32(roverPositionMsgSplit[yCoordinateIdx]);
        this.DirectionFacing = roverPositionMsgSplit[facingDirectionIdx];
    }

    public static class Commands
    {
        public const string MoveForward = "M";
        public const string RotateLeft = "L";
        public const string RotateRight = "R";
    }

    private void TranslateRoverCommands(string roverCommands)
    {
        char[] commands = roverCommands.ToCharArray();

        foreach (char command in commands)
        {
            switch (command.ToString())
            {
                case Commands.MoveForward:
                    this.MoveRoverForward();
                    break;

                default:
                    this.RotateRover(command.ToString());
                    break;
            }
        }
    }

    private bool RoverIsWithinLandingCoordinates(ILandingSurface landingSurface)
    {
        return (this.XCoordinate >= 0) && (this.XCoordinate < landingSurface.Width) &&
            (this.YCoordinate >= 0) && (this.YCoordinate < landingSurface.Height);
    }

    public void MoveRoverForward()
    {
        switch (this.DirectionFacing)
        {
            case Facing.North:
                this.YCoordinate += 1;
                break;

            case Facing.East:
                this.XCoordinate += 1;
                break;

            case Facing.South:
                this.YCoordinate -= 1;
                break;

            case Facing.West:
                this.XCoordinate -= 1;
                break;
        }
    }

    public void RotateRover(string directionCommand)
    {
        switch (directionCommand.ToUpper())
        {
            case Commands.RotateLeft:
                this.TurnRoverLeft();
                break;

            case Commands.RotateRight:
                this.TurnRoverRight();
                break;

            default:
                throw new ArgumentException();
        }
    }

    public static class Facing
    {
        public const string North = "N";
        public const string East = "E";
        public const string South = "S";
        public const string West = "W";
    }

    private void TurnRoverLeft()
    {
        switch (this.DirectionFacing)
        {
            case Facing.North:
                this.DirectionFacing = Facing.West;
                break;

            case Facing.West:
                this.DirectionFacing = Facing.South;
                break;

            case Facing.South:
                this.DirectionFacing = Facing.East;
                break;

            case Facing.East:
                this.DirectionFacing = Facing.North;
                break;
        }
    }

    private void TurnRoverRight()
    {
        switch (this.DirectionFacing)
        {
            case Facing.North:
                this.DirectionFacing = Facing.East;
                break;

            case Facing.East:
                this.DirectionFacing = Facing.South;
                break;

            case Facing.South:
                this.DirectionFacing = Facing.West;
                break;

            case Facing.West:
                this.DirectionFacing = Facing.North;
                break;
        }
    }

}
}
