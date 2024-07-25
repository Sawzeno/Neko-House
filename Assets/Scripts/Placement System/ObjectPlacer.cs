using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects  =   new();
    internal int PlaceObject(GameObject prefab, Vector3 pos)
    {
        GameObject newobject = Instantiate(prefab);
        newobject.transform.position = pos;
        placedGameObjects.Add(newobject);
        return placedGameObjects.Count -1;
    }
    internal void RemoveObject(int gameObjectIndex)
    {
        if(placedGameObjects.Count <= gameObjectIndex || placedGameObjects[gameObjectIndex] == null){
            return;
        }
        Destroy(placedGameObjects[gameObjectIndex]);
        placedGameObjects[gameObjectIndex] = null;
    }
}
