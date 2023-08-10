using UnityEngine;

public class MindZero : MonoBehaviour
{
    [SerializeField] public Configuration config;
    
    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        Game game = new Game
        {
            Config = config,
            Positions = new Positions()   
        };
        game.Positions.CreatePositions(game.Config);
        SetBoard(game);
        SetPieces(game);
    }

    private void SetBoard(Game game)
    {
        Board board = new Board();
        board.CreateBoard(game);
    }

    private void SetPieces(Game game)
    {
        Pieces pieces = new Pieces();
        pieces.CreatePieces(game);
    }
}