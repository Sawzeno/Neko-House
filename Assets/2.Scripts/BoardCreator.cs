using UnityEngine;


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

    private void InitializePieces()
    {
        Quaternion rotationW = Quaternion.Euler(-90, 180, 0);
        Quaternion rotationB = Quaternion.Euler(-90, 0, 0);
        // White
        for (int i = 0; i < size; i++)
        {
            CreatePiece(pawn, i, 0, 1, rotationW, "Pawn");
        }

        CreatePiece(rook, 0, 0, 0, rotationW, "Rook");
        CreatePiece(knight, 1, 0, 0, rotationW, "Knight");
        CreatePiece(bishop, 2, 0, 0, rotationW, "Bishop");
        CreatePiece(queen, 3, 0, 0, rotationW, "Queen");
        CreatePiece(king, 4, 0, 0, rotationW, "King");
        CreatePiece(bishop, 5, 0, 0, rotationW, "Bishop");
        CreatePiece(knight, 6, 0, 0, rotationW, "Knight");
        CreatePiece(rook, 7, 0, 0, rotationW, "Rook");


        // Black
        for (int i = 0; i < size; i++)
        {
            CreatePiece(pawn, i, 0, 6, rotationB, "Pawn");
            // Instantiate(pawn, new Vector3(i, 0, 6) , rotationB).AddComponent<BoxCollider>().tag = "Pawn";
        }

        CreatePiece(rook, 0, 0, 7, rotationB, "Rook");
        CreatePiece(knight, 1, 0, 7, rotationB, "Knight");
        CreatePiece(bishop, 2, 0, 7, rotationB, "Bishop");
        CreatePiece(queen, 3, 0, 7, rotationB, "Queen");
        CreatePiece(king, 4, 0, 7, rotationB, "King");
        CreatePiece(bishop, 5, 0, 7, rotationB, "Bishop");
        CreatePiece(knight, 6, 0, 7, rotationB, "Knight");
        CreatePiece(rook, 7, 0, 7, rotationB, "Rook");
    }


    private void Start()
    {
        _board = new GameObject[size, size];
        CreateBoard();
        InitializePieces();
    }


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

    private void Update()
    {
        SelectPiece();
        PossibleMoves();
    }

    private void SelectPiece()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(hit.transform.tag);
                // Debug.Log(hit.transform.name);
                // if (hit.transform.CompareTag("Pawn"))
                // {
                //     Debug.Log("selected");
                //     // hit.transform.gameObject.GetComponent<Renderer>().material =
                //     //     highlighter.GetComponent<Renderer>().material;
                // }
            }
        }
    }

    private void PossibleMoves()
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

    private void CreatePiece(GameObject piece, int i, int j, int k, Quaternion rotation, string type)
    {
        Vector3 offset = new Vector3(0, 1f, 0);
        Instantiate(piece, new Vector3(i, j, k) + offset, rotation).AddComponent<BoxCollider>().tag = type;
    }
}