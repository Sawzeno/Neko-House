using UnityEngine;

public class Pieces
{
    public readonly GameObject PiecesObject;
    public Vector3 PiecesPosition;
    private Vector3 _offset;


    public Pieces(Configuration config, Positions positions)
    {
        PiecesObject = new GameObject("Pieces");
        PiecesObject.transform.position = PiecesPosition;

        //White

        //Pawns
        for (int i = 0; i < config.size; i++)
        {
            Pawns pawn = new Pawns(config, positions, i, 1, 1, "Pawn", 1);
        }

        //Rooks
        Rooks rookW1 = new Rooks(config, positions, 0, 1, 0, "Rook", 1);
        Rooks rookW2 = new Rooks(config, positions, 7, 1, 0, "Rook", 1);

        //Knights
        Knights knightW1 = new Knights(config, positions, 1, 1, 0, "Knight", 1);
        Knights knightW2 = new Knights(config, positions, 6, 1, 0, "Knight", 1);

        //Bishops
        Bishops bishopW1 = new Bishops(config, positions, 2, 1, 0, "Bishop", 1);
        Bishops bishopW2 = new Bishops(config, positions, 5, 1, 0, "Bishop", 1);

        //Queen
        Queens queenW = new Queens(config, positions, 3, 1, 0, "Queen", 1);

        //King
        Kings kingW = new Kings(config, positions, 4, 1, 0, "King", 1);

        //Black

        //Pawns
        for (int i = 0; i < config.size; i++)
        {
            Pawns pawn = new Pawns(config, positions, i, 1, 6, "Pawn", 0);
        }

        //Rooks
        Rooks rookB1 = new Rooks(config, positions, 0, 1, 7, "Rook", 0);
        Rooks rookB2 = new Rooks(config, positions, 7, 1, 7, "Rook", 0);

        //Knights
        Knights knightB1 = new Knights(config, positions, 1, 1, 7, "Knight", 0);
        Knights knightB2 = new Knights(config, positions, 6, 1, 7, "Knight", 0);

        //Bishops
        Bishops bishopB1 = new Bishops(config, positions, 2, 1, 7, "Bishop", 0);
        Bishops bishopB2 = new Bishops(config, positions, 5, 1, 7, "Bishop", 0);

        //Queen
        Queens queenB = new Queens(config, positions, 3, 1, 7, "Queen", 0);

        //King
        Kings kingB = new Kings(config, positions, 4, 1, 7, "King", 0);
    }
}