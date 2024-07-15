using UnityEngine;

public class BoardManager : MonoBehaviour
{    
    [SerializeField] GameObject ChessBoard;
    public void Setup(){
        GameObject board    =   Instantiate(ChessBoard, transform);
        board.AddComponent<BoxCollider>();
        board.AddComponent<ChessBoard>();
    }
}
