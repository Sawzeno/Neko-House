using System;
using UnityEngine;

public class Chess : MonoBehaviour
{
    [SerializeField] private GameObject Board;
    [SerializeField] private Camera      PlayCamera;
    #region PIECE
    [SerializeField]
    private PieceScriptable
    WhiteKing,
    WhiteQueen,
    WhiteBishop,
    WhiteKnight,
    WhiteRook,
    WhitePawn,
    BlackKing,
    BlackQueen,
    BlackBishop,
    BlackKnight,
    BlackRook,
    BlackPawn;
    #endregion
    private GameObject  BoardInstance;
    private GameObject  PiecesInstance;
    private Ray         ray;
    private Vector3     MousePos;
    private void Start()
    {
        ray =   new Ray();
        MousePos    =   PlayCamera.ScreenToWorldPoint(MousePos);
        SetupBoard();
        SetupPieces();
        transform.localScale *= 0.5f;
    }
    private void Update()
    {
        ray =   PlayCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray , out RaycastHit hit)){
            if(hit.collider.gameObject.tag == "Piece"){
                PieceScriptable type = hit.collider.gameObject.GetComponent<PieceScriptable>();
                type.OnMouseDown();
            }
        }    
    }
    private void SetupPieces()
    {
        PiecesInstance = new GameObject();
        PiecesInstance.transform.parent = transform;
        PiecesInstance.transform.position = transform.position + new Vector3(0, 0.5f, 7);
        PiecesInstance.transform.name = "Pieces";
        Vector3 piecePosition = PiecesInstance.transform.position;
        String defaultPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
        // String defaultPosition      =   "r1bk3r/p2pBpNp/n4n2/1p1NP2P/6P1/3P4/P1P1K3/q5b1";
        for (int i = 0; i < defaultPosition.Length; ++i)
        {
            char c = defaultPosition[i];
            if (c > '0' && c < '9')
            {
                int offset = c - '0';
                piecePosition.x += offset;
            }
            if (c == '/')
            {
                piecePosition.z -= 1;
                piecePosition.x -= 8;
            }
            switch (c)
            {
                case 'r':
                    InstantiatePiece(BlackRook, ref piecePosition);
                    break;
                case 'n':
                    InstantiatePiece(BlackKnight, ref piecePosition);
                    break;
                case 'b':
                    InstantiatePiece(BlackBishop, ref piecePosition);
                    break;
                case 'q':
                    InstantiatePiece(BlackQueen, ref piecePosition);
                    break;
                case 'k':
                    InstantiatePiece(BlackKing, ref piecePosition);
                    break;
                case 'p':
                    InstantiatePiece(BlackPawn, ref piecePosition);
                    break;
                case 'R':
                    InstantiatePiece(WhiteRook, ref piecePosition);
                    break;
                case 'N':
                    InstantiatePiece(WhiteKnight, ref piecePosition);
                    break;
                case 'B':
                    InstantiatePiece(WhiteBishop, ref piecePosition);
                    break;
                case 'Q':
                    InstantiatePiece(WhiteQueen, ref piecePosition);
                    break;
                case 'K':
                    InstantiatePiece(WhiteKing, ref piecePosition);
                    break;
                case 'P':
                    InstantiatePiece(WhitePawn, ref piecePosition);
                    break;
            }
        }
    }
    private void SetupBoard()
    {
        BoardInstance = Instantiate(Board);
        BoardInstance.transform.position = transform.position;
        BoardInstance.transform.localScale = transform.localScale;
        BoardInstance.transform.parent = transform;
    }
    private void InstantiatePiece(in PieceScriptable piece, ref Vector3 position)
    {
        GameObject temp = Instantiate(piece.PieceType, PiecesInstance.transform);
        temp.transform.position = position;
        temp.AddComponent<BoxCollider>();
        temp.tag =   "Piece";
        position.x += 1;
    }
}
