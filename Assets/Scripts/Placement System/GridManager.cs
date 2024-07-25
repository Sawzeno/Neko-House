using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] List<GameObject> Grids;
    
    private void Start(){
        SetGridScale();
    }
    private void SetGridScale(){
        Vector2 ParentScale = new(transform.localScale.x, transform.localScale.z);
        foreach(GameObject Grid in Grids){
            Renderer renderer = Grid.GetComponent<Renderer>();
            Material mat = renderer.material;
            mat.SetVector("_DefaultScale", ParentScale * Grid.transform.localScale);
        }
    }
}
