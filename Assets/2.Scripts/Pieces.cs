using UnityEngine;

public class Pieces
{
    private Vector3 _piecePosition;
    private GameObject _pieces;
    private Vector3 _offset;

    public void CreatePieces(Game game)
    {
        Quaternion rotationW = Quaternion.Euler(-90, 180, 0);
        Quaternion rotationB = Quaternion.Euler(-90, 0, 0);
        _pieces = new GameObject("Pieces");
        _pieces.transform.position = game.Positions.Cells[0, 0].transform.position;
        
        //white
        
        //pawn
        for (int i = 0; i < game.Config.size; i++)
        {
            CreatePiece(game, game.Config.pawn, i, 0, 1, game.Config.color1, rotationW);
        }
        
        //rook
        CreatePiece(game, game.Config.rook, 0, 0, 0, game.Config.color1, rotationW);
        CreatePiece(game, game.Config.rook, 7, 0, 0, game.Config.color1, rotationW);
        
        //knight
        CreatePiece(game, game.Config.knight, 1, 0, 0, game.Config.color1, rotationW);
        CreatePiece(game, game.Config.knight, 6, 0, 0, game.Config.color1, rotationW);
        
        //bishop
        CreatePiece(game, game.Config.bishop, 2, 0, 0, game.Config.color1, rotationW);
        CreatePiece(game, game.Config.bishop, 5, 0, 0, game.Config.color1, rotationW);
        
        //queen
        CreatePiece(game, game.Config.queen, 3, 0, 0, game.Config.color1, rotationW);
        
        //king
        CreatePiece(game, game.Config.king, 4, 0, 0, game.Config.color1, rotationW);
        
        //black
        
        //pawn
        for (int i = 0; i < game.Config.size; i++)
        {
            CreatePiece(game, game.Config.pawn, i, 0, 6, game.Config.color2, rotationB);
        }
        
        //rook
        CreatePiece(game, game.Config.rook, 0, 0, 7, game.Config.color2, rotationB);
        CreatePiece(game, game.Config.rook, 7, 0, 7, game.Config.color2, rotationB);
        
        //knight
        CreatePiece(game, game.Config.knight, 1, 0, 7, game.Config.color2, rotationB);
        CreatePiece(game, game.Config.knight, 6, 0, 7, game.Config.color2, rotationB);
        
        //bishop
        CreatePiece(game, game.Config.bishop, 2, 0, 7, game.Config.color2, rotationB);
        CreatePiece(game, game.Config.bishop, 5, 0, 7, game.Config.color2, rotationB);
        
        //queen
        CreatePiece(game, game.Config.queen, 3, 0, 7, game.Config.color2, rotationB);
        
        //king
        CreatePiece(game, game.Config.king, 4, 0, 7, game.Config.color2, rotationB);
        
        
    }

    private void CreatePiece(Game game, GameObject piece, int i  , int j , int k  , Color color, Quaternion rotation)
    {
        _offset = new Vector3(0, 3f, 0);
        GameObject newPiece = Object.Instantiate(piece, new Vector3(i,j,k) + _offset, rotation);
        newPiece.GetComponent<Renderer>().material.color = color;
        Rigidbody collider = newPiece.AddComponent<Rigidbody>();
        collider.mass = 0.01f;
        
        newPiece.AddComponent<BoxCollider>();
        newPiece.name = $"{i} {k}";
        newPiece.transform.parent = _pieces.transform;
        game.Positions.Pieces[i, k] = newPiece;
        if (color == game.Config.color1)
        {
            game.Positions.Life[i,k] = 1;
        }
        else if (color == game.Config.color2)
        {
            game.Positions.Life[i,k] = -1;
        }
    }
}