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
        PiecePosition = transform.position + new Vector3(0, 0, 7);
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
                    ChessPiece.AddComponent<Rook>();
                    break;
                case 'n':
                    ChessPiece   =   InstantiatePiece(BlackKnight, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'b':
                    ChessPiece   =   InstantiatePiece(BlackBishop, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'q':
                    ChessPiece   =   InstantiatePiece(BlackQueen, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'k':
                    ChessPiece   =   InstantiatePiece(BlackKing, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'p':
                    ChessPiece   =   InstantiatePiece(BlackPawn, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'R':
                    ChessPiece   =   InstantiatePiece(WhiteRook, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'N':
                    ChessPiece   =   InstantiatePiece(WhiteKnight, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'B':
                    ChessPiece   =   InstantiatePiece(WhiteBishop, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'Q':
                    ChessPiece   =   InstantiatePiece(WhiteQueen, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'K':
                    ChessPiece   =   InstantiatePiece(WhiteKing, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
                case 'P':
                    ChessPiece   =   InstantiatePiece(WhitePawn, ref PiecePosition);
                    ChessPiece.AddComponent<ChessPiece>();

                    break;
            }
        }
    }
        private GameObject InstantiatePiece(GameObject PieceType, ref Vector3 position)
    {
        GameObject Piece = Instantiate(PieceType, transform);
        Piece.transform.position = position;
        Piece.AddComponent<BoxCollider>();
        Piece.tag =   "ChessPiece";
        position.x += 1;
        return Piece;
    }
}
