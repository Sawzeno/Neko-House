using UnityEngine;

public abstract class Piece
{
    protected readonly Color Color1;
    protected readonly Color Color2;
    protected readonly Color Highlight;
    protected readonly Color Danger;
    protected readonly GameObject ChessPiece;
    protected readonly Quaternion RotationW = Quaternion.Euler(-90, 180, 0);
    protected readonly Quaternion RotationB = Quaternion.Euler(-90, 0, 0);

    protected Piece(GameObject prefab,Configuration config)
    {
        Color1 = config.color1;
        Color2 = config.color2;
        Highlight = config.highlight;
        Danger = config.danger;
        ChessPiece = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        ChessPiece.AddComponent<Rigidbody>();
        ChessPiece.AddComponent<BoxCollider>();
        ChessPiece.GetComponent<BoxCollider>().size = new Vector3(1, 1f, 1);
        ChessPiece.GetComponent<BoxCollider>().center = new Vector3(0, 0f, 0);
    }

    public abstract void HighlightMoves();

    public abstract void Move();
}