using UnityEngine;

public class Positions 
{
    public GameObject[,] Cells;
    public GameObject[,] Pieces;
    public int[,] Life;
    
    public Positions(Configuration config)
    {
        Cells = new GameObject[config.size, config.size];
        Pieces = new GameObject[config.size, config.size];
        
        Life = new int[config.size, config.size];
    }
    
    
}