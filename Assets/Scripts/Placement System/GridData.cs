using System;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    Dictionary<Vector3Int,PlacementData> PlacedObjects = new();
    public void AddObjectAt(Vector3Int gridPosition,
                            Vector2Int objectSize,
                            int ID,
                            int placedObjectIndex)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionToOccupy, ID, placedObjectIndex);
        foreach(var pos in positionToOccupy){
            if(PlacedObjects.ContainsKey(pos)){
                throw new Exception($"dictionary already contains this cell position ,probably occupied{pos}");
            }
            PlacedObjects[pos] = data;
        }
    }    
    public bool CanPlaceObjectAt(Vector3Int gridPosition, Vector2Int objectSize){
        List<Vector3Int> positionToOccupy =  CalculatePositions(gridPosition, objectSize);
        foreach(var pos in positionToOccupy){
            if(PlacedObjects.ContainsKey(pos)){
                return false;
            }
        }
        return true;
    }

    internal int GetRepresentationIndex(Vector3Int gridPosition)
    {
        if(PlacedObjects.ContainsKey(gridPosition) == false){
            return -1;
        }
        return PlacedObjects[gridPosition].PlacedObjectIndex;
    }

    internal void RemoveObjectAt(Vector3Int gridPosition)
    {
        foreach( var pos in PlacedObjects[gridPosition].OccupiedPositions){
            PlacedObjects.Remove(pos);
        }
    }

    private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new();
        for(int y = 0; y < objectSize.y ; ++y){
            for(int x = 0; x < objectSize.x; ++x){
                returnVal.Add(gridPosition + new Vector3Int(x,0,y));
            }
        }
        return returnVal;
    }
}

public class PlacementData
{
    public List<Vector3Int> OccupiedPositions;

    public PlacementData(List<Vector3Int> occupiedPositions, int id, int placedObjectIndex)
    {
        OccupiedPositions = occupiedPositions;
        ID =   id;
        PlacedObjectIndex  =   placedObjectIndex;
    }

    public int ID{get; private set;}
    public int PlacedObjectIndex { get;private set;}
    
}