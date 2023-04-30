using UnityEngine;


public class BoardCreator : MonoBehaviour
{
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
        Quaternion rotationx = Quaternion.Euler(-90, 0, 0);
        Quaternion rotationy = Quaternion.Euler(-90, 180, 0);
        Vector3 offset = new Vector3(0, 1f, 0);
        // White
        for (int i = 0; i < size; i++)
        {
            Instantiate(pawn, new Vector3(i, 0, 1)+offset,rotationx);
        }
        Instantiate(rook, new Vector3(0, 0, 0)+offset, rotationx);
        Instantiate(knight, new Vector3(1, 0, 0)+offset, rotationx);
        Instantiate(bishop, new Vector3(2, 0, 0)+offset, rotationx);
        Instantiate(queen, new Vector3(3, 0, 0)+offset, rotationx);
        Instantiate(king, new Vector3(4, 0, 0)+offset, rotationx);
        Instantiate(bishop, new Vector3(5, 0, 0)+offset, rotationx);
        Instantiate(knight, new Vector3(6, 0, 0)+offset, rotationx);
        Instantiate(rook, new Vector3(7, 0, 0)+offset, rotationx);
        
        // Black
        for (int i = 0; i < size; i++)
        {
            Instantiate(pawn, new Vector3(i, 0, 6)+offset, rotationy);
        }
        Instantiate(rook, new Vector3(0, 0, 7)+offset, rotationy);
        Instantiate(knight, new Vector3(1, 0, 7)+offset, rotationy);
        Instantiate(bishop, new Vector3(2, 0, 7)+offset, rotationy);
        Instantiate(queen, new Vector3(3, 0, 7)+offset, rotationy);
        Instantiate(king, new Vector3(4, 0, 7)+offset, rotationy);
        Instantiate(bishop, new Vector3(5, 0, 7)+offset, rotationy);
        Instantiate(knight, new Vector3(6, 0, 7)+offset, rotationy);
        Instantiate(rook, new Vector3(7, 0, 7)+offset, rotationy);
        
        _board = new GameObject[size, size];
        
    }
    private void Start()
    {
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
        PiecesPosition();
    }
    
    private void PiecesPosition()
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
}