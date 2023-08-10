using UnityEngine;
using Object = UnityEngine.Object;

public class Board
{
    public void CreateBoard(Game game)
    {
        GameObject board = new GameObject("Board");
        board.transform.position = new Vector3(0, 0, 0);
        board.AddComponent<Rigidbody>();
        // board.AddComponent<BoxCollider>();
        for (int i = 0; i < game.Config.size; i++)
        {
            for (int k = 0; k < game.Config.size; k++)
            {
                GameObject cell = Object.Instantiate(game.Config.cell, new Vector3(i, 0, k), Quaternion.identity);
                BoxCollider collider = cell.GetComponent<BoxCollider>();
                collider.size = new Vector3(1, 1f, 1);
                collider.center = new Vector3(0, 0f, 0);
                cell.transform.parent = board.transform;
                if ((i + k) % 2 == 1)
                {
                    cell.GetComponent<Renderer>().material.color = game.Config.color1;
                    cell.name = $"{i} {k}";
                    game.Positions.Cells[i, k] = cell;
                    game.Positions.Life[i, k] = 0;
                }
                else if ((i + k) % 2 == 0)
                {
                    cell.GetComponent<Renderer>().material.color = game.Config.color2;
                    cell.name = $"{i} {k}";
                    game.Positions.Cells[i, k] = cell;
                    game.Positions.Life[i, k] = 0;
                }
            }
        }
    }
    
    public void DebugBoard(Configuration config)
    {
        Debug.Log(config.size);
        Debug.Log(config.color1);
        Debug.Log(config.color2);
        Debug.Log(config.highlight);
        Debug.Log(config.danger);
    }

}