using UnityEngine;

[CreateAssetMenu(fileName = "Pieces/Piece", menuName ="Piece")]
public class PieceScriptable : ScriptableObject
{
 public GameObject PieceType;

public void OnMouseDown(){
    Debug.Log(PieceType.transform.position);
    PieceType.transform.position += new Vector3(0,1,0);
 }
}
