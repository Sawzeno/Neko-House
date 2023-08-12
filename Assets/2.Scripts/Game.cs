using UnityEngine;

public class Game
{
    public Configuration Config;
    public Positions Positions;
    public Board Board;
    public Pieces Pieces;

    public void NewGame()
    {
        
        Board = new Board(Config, Positions);

        Pieces = new Pieces(Config , Positions)
        {
            PiecesPosition = Board.BoardObject.transform.position
        };
    }
}