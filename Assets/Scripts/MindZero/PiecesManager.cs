using System;
using UnityEngine;

public class PiecesManager : MonoBehaviour
{
    [SerializeField]
    GameObject
   WhiteKing,
   WhiteQueen,
   WhiteRook,
   WhiteBishop,
   WhiteKnight,
   WhitePawn,
   BlackKing,
   BlackQueen,
   BlackRook,
   BlackBishop,
   BlackKnight,
   BlackPawn;
    private Vector3 PiecePosition;
    public void Setup()
    {
        PiecePosition = transform.position;
        string defaultPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

        GameObject ChessPiece;
        for (int i = 0; i < defaultPosition.Length; ++i)
        {
            char c = defaultPosition[i];
            if (c > '0' && c < '9')
            {
                int offset = c - '0';
                PiecePosition.x += offset;
            }
            if (c == '/')
            {
                PiecePosition.z -= 1;
                PiecePosition.x -= 8;
            }
            switch (c)
            {
                case 'r':
                    ChessPiece   =   InstantiatePiece(BlackRook, ref PiecePosition);

                    break;
                case 'n':
                    ChessPiece   =   InstantiatePiece(BlackKnight, ref PiecePosition);


                    break;
                case 'b':
                    ChessPiece   =   InstantiatePiece(BlackBishop, ref PiecePosition);


                    break;
                case 'q':
                    ChessPiece   =   InstantiatePiece(BlackQueen, ref PiecePosition);


                    break;
                case 'k':
                    ChessPiece   =   InstantiatePiece(BlackKing, ref PiecePosition);


                    break;
                case 'p':
                    ChessPiece   =   InstantiatePiece(BlackPawn, ref PiecePosition);


                    break;
                case 'R':
                    ChessPiece   =   InstantiatePiece(WhiteRook, ref PiecePosition);


                    break;
                case 'N':
                    ChessPiece   =   InstantiatePiece(WhiteKnight, ref PiecePosition);


                    break;
                case 'B':
                    ChessPiece   =   InstantiatePiece(WhiteBishop, ref PiecePosition);


                    break;
                case 'Q':
                    ChessPiece   =   InstantiatePiece(WhiteQueen, ref PiecePosition);


                    break;
                case 'K':
                    ChessPiece   =   InstantiatePiece(WhiteKing, ref PiecePosition);


                    break;
                case 'P':
                    ChessPiece   =   InstantiatePiece(WhitePawn, ref PiecePosition);


                    break;
            }
        }
    }
        private GameObject InstantiatePiece(GameObject PieceType, ref Vector3 position)
    {
        GameObject Piece = Instantiate(PieceType, transform);
        Piece.transform.position = position;
        Piece.tag =   "ChessPiece";
        position.x += 1;
        return Piece;
    }
}
