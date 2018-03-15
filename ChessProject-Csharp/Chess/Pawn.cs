using System;

namespace Gfi.Hiring
{
    ///Pawn inherits from Piece
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor): base(pieceColor){}

        //override the move method defined in the base Piece class.
        public override void Move(MovementType movementType, int newX, int newY)
        {
            if (IsLegalMove(newX, newY, movementType))
            {
                //Used a case statement here instead of an if as it may be worth adding additional movement types in the future, e.g FirstMove
                switch (movementType)
                {
                    case MovementType.Capture:
                        //In future add logic to remove the captured pawn from the board, not implemented yet as per specification.
                        throw new NotImplementedException("Capture movement not yet implemented.");
                    case MovementType.Move:
                        XCoordinate = newX;
                        YCoordinate = newY;
                        break;
                };
            }
            //In future may want to throw an exception here because If an illegal movement is attempted at this point there may be an issue with the UI e.g:
            //else
            //{
            //    throw new IllegalMovementException("Movement not allowed.");
            //}

        }

        //Checks for both Move and Capture types, if the type is just to move the pawn must move forward 1 space at a time
        //if the move is to capture the pawn can move left,right or straight ahead 1 space.
        public override bool IsLegalMove(int newXCoord, int newYCoord, MovementType movementType)
        {
            return ((Math.Abs(YCoordinate - newYCoord) == 1 //Moved forward 1 space
                && XCoordinate == newXCoord  //Not moved right or left.
                && movementType == MovementType.Move) // logic branch for moving.
                || (Math.Abs(YCoordinate - newYCoord) == 1 //Moved forward 1 space.
                && (Math.Abs(XCoordinate - newXCoord) == 1 || Math.Abs(XCoordinate - newXCoord) == 0) //Check if the pawn has moved left or right 1 space or continued straight ahead.
                && movementType == MovementType.Capture)); // logic branch for capturing.
        }

    }
}
