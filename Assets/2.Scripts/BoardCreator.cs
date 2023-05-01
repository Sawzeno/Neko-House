using UnityEngine;
using static System.Math;

public class BoardCreator : MonoBehaviour
{
    //camera
    [SerializeField] private Camera cam;

    // GameObjects
    private readonly int size = 8;
    [SerializeField] private GameObject cell;
    [SerializeField] private GameObject pawn;
    [SerializeField] private GameObject rook;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject bishop;
    [SerializeField] private GameObject queen;
    [SerializeField] private GameObject king;

    [SerializeField] private GameObject highlighter;

    // materials
    [SerializeField] private Material white;
    [SerializeField] private Material black;

    //Game Object List
    private GameObject[,] _board;

    private void CreateBoard()
    {
        Debug.Log("Creating board of" + size + "x" + size + "size.");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                CallInstantiation(i, j);
            }
        }
    }

    private void InitializePieces()
    {
        Quaternion rotationW = Quaternion.Euler(-90, 180, 0);
        Quaternion rotationB = Quaternion.Euler(-90, 0, 0);
        // White
        for (int i = 0; i < size; i++)
        {
            CreatePiece(pawn, i, 0, 1, rotationW, "White Pawn", white);
        }

        CreatePiece(rook, 0, 0, 0, rotationW, "White Rook", white);
        CreatePiece(knight, 1, 0, 0, rotationW, "White Knight", white);
        CreatePiece(bishop, 2, 0, 0, rotationW, "White Bishop", white);
        CreatePiece(queen, 3, 0, 0, rotationW, "White Queen", white);
        CreatePiece(king, 4, 0, 0, rotationW, "White King", white);
        CreatePiece(bishop, 5, 0, 0, rotationW, "White Bishop", white);
        CreatePiece(knight, 6, 0, 0, rotationW, "White Knight", white);
        CreatePiece(rook, 7, 0, 0, rotationW, "White Rook", white);


        // Black
        for (int i = 0; i < size; i++)
        {
            CreatePiece(pawn, i, 0, 6, rotationB, "Black Pawn", black);
        }

        CreatePiece(rook, 0, 0, 7, rotationB, "Black Rook", black);
        CreatePiece(knight, 1, 0, 7, rotationB, "Black Knight", black);
        CreatePiece(bishop, 2, 0, 7, rotationB, "Black Bishop", black);
        CreatePiece(queen, 3, 0, 7, rotationB, "Black Queen", black);
        CreatePiece(king, 4, 0, 7, rotationB, "Black King", black);
        CreatePiece(bishop, 5, 0, 7, rotationB, "Black Bishop", black);
        CreatePiece(knight, 6, 0, 7, rotationB, "Black Knight", black);
        CreatePiece(rook, 7, 0, 7, rotationB, "Black Rook", black);
    }


    private void Start()
    {
        _board = new GameObject[size, size];
        CreateBoard();
        InitializePieces();
    }

    private void Update()
    {
        SelectPiece();
        MovePieces();
    }


    private void SelectPiece()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("_______" + hit.transform.tag);

                switch (hit.transform.tag)
                {
                    case "White Pawn":
                        PawnMoves(hit, "White Pawn");
                        break;
                    case "White Rook":
                        RookMoves(hit, "White Rook");
                        break;
                    case "White Knight":
                        KnightMoves(hit, "White Knight");
                        break;
                    case "White Bishop":
                        BishopMoves(hit, "White Bishop");
                        break;
                    case "White Queen":
                        QueenMoves(hit, "White Queen");
                        break;
                    case "White King":
                        KingMoves(hit, "White King");
                        break;
                    case "Black Pawn":
                        PawnMoves(hit, "Black Pawn");
                        break;
                    case "Black Rook":
                        RookMoves(hit, "Black Rook");
                        break;
                    case "Black Knight":
                        KnightMoves(hit, "Black Knight");
                        break;
                    case "Black Bishop":
                        BishopMoves(hit, "Black Bishop");
                        break;
                    case "Black Queen":
                        QueenMoves(hit, "Black Queen");
                        break;
                    case "Black King":
                        KingMoves(hit, "Black King");
                        break;
                }
            }
        }
    }

    private void PawnMoves(RaycastHit obj, string type)
    {
        Vector3 transformPosition = obj.transform.position;
        switch (type)
        {
            //possible moves for White pawn
            case "White Pawn" when transformPosition.z == 1:

                Instantiate(highlighter, transformPosition + new Vector3(0, 0, 1), Quaternion.identity);
                Instantiate(highlighter, transformPosition + new Vector3(0, 0, 2), Quaternion.identity);
                break;
            case "White Pawn":
                Instantiate(highlighter, transformPosition + new Vector3(0, 0, 1), Quaternion.identity);
                break;
            case "Black Pawn" when transformPosition.z == 6:
                Instantiate(highlighter, transformPosition - new Vector3(0, 0, 1), Quaternion.identity);
                Instantiate(highlighter, transformPosition - new Vector3(0, 0, 2), Quaternion.identity);

                break;
            case "Black Pawn":
                Instantiate(highlighter, transformPosition - new Vector3(0, 0, 1), Quaternion.identity);
                break;
        }
    }

    private void RookMoves(RaycastHit obj, string type)
    {
        //possible moves for rook
        switch (type)
        {
            case "White Rook":
                
        }
        
    }

    private void KnightMoves(RaycastHit obj, string type)
    {
        //possible moves for knight
    }

    private void BishopMoves(RaycastHit obj, string type)
    {
        //possible moves for bishop
    }

    private void QueenMoves(RaycastHit obj, string type)
    {
        //possible moves for queen
    }

    private void KingMoves(RaycastHit obj, string type)
    {
        //possible moves for king
    }

    private void MovePieces()
    {
    }


    private void CallInstantiation(int i, int j)
    {
        switch (i % 2)
        {
            case 0:
                CreateCell(i, j, j % 2 == 0 ? white : black);

                break;
            case 1:
                CreateCell(i, j, j % 2 == 0 ? black : white);

                break;
        }
    }

    private void CreateCell(int i, int j, Material input)
    {
        GameObject temp = Instantiate(cell, new Vector3(i, 0, j), Quaternion.identity);
        temp.GetComponent<Renderer>().material = input;
        temp.transform.parent = transform;
        temp.name = $"Cell {i} {j}";
        _board[i, j] = temp;
    }

    private void CreatePiece(GameObject piece, int i, int j, int k, Quaternion rotation, string type, Material material)
    {
        Vector3 offset = new Vector3(0, 1, 0);
        GameObject newPiece = Instantiate(piece, new Vector3(i, j, k) + offset, rotation);
        newPiece.AddComponent<BoxCollider>();
        newPiece.tag = type;
        newPiece.GetComponent<Renderer>().material = material;
    }
}