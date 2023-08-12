using System;
using UnityEngine;

public class MindZero : MonoBehaviour
{
    private Camera _cam;
    private Game _game;
    [SerializeField] private Configuration config;

    public void NewGame()
    {
        _game = new Game
        {
            Config = config,
            Positions = new Positions(config)
        };
        _game.NewGame();
        _cam = Camera.main;
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        SelectPieces();
    }

    private void SelectPieces()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                GameObject hitObject = hitInfo.transform.gameObject;

                switch (hitObject.name)
                {
                    //white pieces
                    case "White Pawn":
                        Debug.Log("White Pawn");
                        break;
                    case "White Rook":
                        Debug.Log("White Rook");
                        break;
                    case "White Knight":
                        Debug.Log("White Knight");
                        break;
                    case "White Bishop":
                        Debug.Log("White Bishop");
                        break;
                    case "White Queen":
                        Debug.Log("White Queen");
                        break;
                    case "White King":
                        Debug.Log("WhiteKing");
                        break;
                    
                    //black pieces
                    case "Black Pawn":
                        Debug.Log("Black Pawn");
                        break;
                    case "Black Rook":
                        Debug.Log("Black Rook");
                        break;
                    case "Black Knight":
                        Debug.Log("Black Knight");
                        break;
                    case "Black Bishop":
                        Debug.Log("Black Bishop");
                        break;
                    case "Black Queen":
                        Debug.Log("Black Queen");
                        break;
                    case "Black King":
                        Debug.Log("Black King");
                        break;
                }
            }
        }
    }
    

    public void EndGame()
    {
        DestroyImmediate(_game.Board.BoardObject);
        DestroyImmediate(_game.Pieces.PiecesObject);
        _game = null;
    }
}