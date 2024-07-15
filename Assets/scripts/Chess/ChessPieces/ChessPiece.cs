using UnityEngine;
interface IChessPiece
{
    public void Setup(Vector3 Position);
    public void Move(Vector3 Destination);
    public void Test();
}
public class ChessPiece : MonoBehaviour, IChessPiece
{
    protected string algebraicPosition;
    protected string PieceType;
    public void Move(Vector3 Destination)
    {
        Debug.Log("Move");
    }

    public void Setup(Vector3 Position)
    {
        Debug.Log("Piece Setup called");

    }

    public void Test()
    {
        Debug.Log("Test");
    }

    void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }
}
