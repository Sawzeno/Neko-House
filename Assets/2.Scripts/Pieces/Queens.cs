using System;
using UnityEngine;

public class Queens :Piece
{
    public Queens(Configuration config ,Positions positions , int i ,  int j , int k ,String name , int l) : base(config.queen, config)
    {
        ChessPiece.name = name;
        ChessPiece.transform.position = new Vector3(i, j, k);
        positions.Pieces[i, k] = ChessPiece;
        if (l == 1)
        {
            ChessPiece.transform.rotation = RotationW;
            ChessPiece.GetComponent<Renderer>().material.color = Color1;
            positions.Life[i, k] = 1;
        }
        else if (l == 0)
        {
            ChessPiece.transform.rotation = RotationB;
            ChessPiece.GetComponent<Renderer>().material.color = Color2;
            positions.Life[i,k] = -1;
        }
    }
    public override void HighlightMoves()
    {

    }
    
    public override void Move()
    {
 
    }
    
}
