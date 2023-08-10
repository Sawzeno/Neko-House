using UnityEngine;

public class Configuration : MonoBehaviour
{
    
    //Size
    [SerializeField] public int size = 8;
    
    //Colors
    [SerializeField] public Color color1;
    [SerializeField] public Color color2;
    [SerializeField] public Color highlight;
    [SerializeField] public Color danger;
    
    //pieces
    [SerializeField] public GameObject cell;
    [SerializeField] public GameObject pawn;
    [SerializeField] public GameObject rook;
    [SerializeField] public GameObject knight;
    [SerializeField] public GameObject bishop;
    [SerializeField] public GameObject queen;
    [SerializeField] public GameObject king;
    
    

}
