using System;
using System.Collections.Generic;
using System.Linq;

namespace Gfi.Hiring
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;

        //Changed to a list rather than an array, imo a list of pieces is easier to work with in this scenario.
        private List<Piece> pieces;

        public ChessBoard ()
        {
            pieces = new List<Piece>();
        }

        public void Add(Piece piece, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            //if the pawn position is not valid set the coords to -1 and do not add it to the list of pieces.
            if (!IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                piece.XCoordinate = -1;
                piece.YCoordinate = -1;
            }
            else
            {
                //Set the properties of the pawn, no need to set the color as it must be set when the pawn is instantiated.
                piece.XCoordinate = xCoordinate;
                piece.YCoordinate = yCoordinate;
                //Add pawn to the boards list of pieces.
                pieces.Add(piece);
            }        
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (xCoordinate >= 0 
                && xCoordinate <= MaxBoardWidth 
                && yCoordinate >= 0 
                && yCoordinate <= MaxBoardHeight //Check x & y coordinates are within the limits of the board (0,0) / (7,7)
                && !pieces.Any(p => p.XCoordinate == xCoordinate && p.YCoordinate == yCoordinate) //Check the board for a pieces already in the same position.
                && pieces.Select(p => p.GetType() == typeof(Pawn)).Count() < MaxBoardWidth); //Check number if pawns for each color is less than width of the board.
                //In future we will need addtional logic for different types of pieces for example for example number of Knights = 4
        }

    }
}
