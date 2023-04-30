using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    [Range(8, 16)] [SerializeField] private int size = 8;
    [SerializeField] private GameObject test;
    [SerializeField] private Material white;
    [SerializeField] private Material black;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            CreateBoard();
        }
    }


    private void CreateBoard()
    {
        Debug.Log("Creating board of" + size + "x" + size + "size.");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                CallInstantiation(i, j);
            }
        }
    }


    private void CallInstantiation(int i, int j)
    {
        switch (i % 2)
        {
            case 0:
                CreateCell(i, j, j % 2 == 0 ? white : black);

                break;
            case 1:
                CreateCell(i, j, j % 2 == 0 ? black : white);

                break;
        }
    }

    private void CreateCell(int i, int j, Material input)
    {
        GameObject cell = Instantiate(test, new Vector3(i, 0, j), Quaternion.identity);
        cell.GetComponent<Renderer>().material = input;
        cell.transform.parent = transform;
        cell.name = $"Cell {i} {j}";
    }
}