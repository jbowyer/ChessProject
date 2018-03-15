using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gfi.Hiring
{
    //Created abstract class for Pieces, this will add common methods/properties which are inherited when writing code for the next pieces e.g Knight, Castle etc
    public abstract class Piece
    {
        public Piece(PieceColor pieceColor)
        {
            _pieceColor = pieceColor;
        }

        private ChessBoard _chessBoard;
        private int _xCoordinate;
        private int _yCoordinate;
        private PieceColor _pieceColor;

        public ChessBoard ChessBoard
        {
            get { return _chessBoard; }
            set { _chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public PieceColor Color
        {
            get { return _pieceColor; }
            private set { _pieceColor = value; }
        }

        //Every piece will need the move method but will implement it differently hence the absraction (same goes for IsLegalMove)
        public abstract void Move(MovementType movementType, int newX, int newY);

        public abstract bool IsLegalMove(int newXCoord, int newYCoord, MovementType movementType);

        //Moved out of the Pawn class so other pieces inheriting from Piece can use this method.
        protected virtual string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, Color);
        }
        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        //User defined exception not used in this example but may be useful in the future.
        public class IllegalMovementException : Exception
        {
            public IllegalMovementException() { }
            public IllegalMovementException(string message) : base(message) { }
            public IllegalMovementException(string message, Exception inner) : base(message, inner) { }
        }

    }
}
