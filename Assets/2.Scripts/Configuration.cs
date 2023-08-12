using UnityEngine;

public class Configuration : MonoBehaviour
{
    public int size = 8;
    [SerializeField] public Color color1 = Color.white;
    [SerializeField] public Color color2 = Color.black;
    [SerializeField] public Color highlight = Color.green;
    [SerializeField] public Color danger = Color.red;

    [SerializeField] public GameObject cell;
    [SerializeField] public GameObject pawn;
    [SerializeField] public GameObject rook;
    [SerializeField] public GameObject knight;
    [SerializeField] public GameObject bishop;
    [SerializeField] public GameObject queen;
    [SerializeField] public GameObject king;
    
}