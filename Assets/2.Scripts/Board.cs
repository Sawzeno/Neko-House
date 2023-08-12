using UnityEngine;
using Object = UnityEngine.Object;

public class Board
{
    public readonly GameObject BoardObject;

    public Board(Configuration config , Positions positions)
    {
        BoardObject = new GameObject("Board");
        BoardObject.transform.position = new Vector3(0, 0, 0);
        BoardObject.AddComponent<Rigidbody>();
        for (int i = 0; i < config.size; i++)
        {
            for (int k = 0; k < config.size; k++)
            {
                GameObject cell = Object.Instantiate(config.cell, new Vector3(i, 0, k), Quaternion.identity);
                BoxCollider collider = cell.GetComponent<BoxCollider>();
                collider.size = new Vector3(1, 1f, 1);
                collider.center = new Vector3(0, 0f, 0);
                cell.transform.parent = BoardObject.transform;
                if ((i + k) % 2 == 1)
                {
                    cell.GetComponent<Renderer>().material.color = config.color1;
                    cell.name = $"{i} {k}";
                    positions.Cells[i, k] = cell;
                }
                else if ((i + k) % 2 == 0)
                {
                    cell.GetComponent<Renderer>().material.color = config.color2;
                    cell.name = $"{i} {k}";
                    positions.Cells[i, k] = cell;
                }
            }
        }
    }
    
}