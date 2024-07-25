using System;
using UnityEngine;

public class RemovingState : IBuildingState
{
    private int GameObjectIndex = -1;
    private readonly Grid Grid;
    private readonly PreviewSystem PreviewSystem;
    private readonly GridData FloorData, FurnitureData;
    private readonly ObjectPlacer ObjectPlacer;

    public RemovingState(Grid grid,
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer)
    {
        Grid = grid;
        PreviewSystem = previewSystem;
        FloorData = floorData;
        FurnitureData = furnitureData;
        ObjectPlacer = objectPlacer;
        
        PreviewSystem.StartShowingRemovePreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        if(FurnitureData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false){
            selectedData = FurnitureData;
        }else if(FloorData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false){
            selectedData = FloorData;
        }
        if(selectedData == null){
            // do something
        }else{
            GameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if(GameObjectIndex == -1){
                return;
            }
            selectedData.RemoveObjectAt(gridPosition);
            ObjectPlacer.RemoveObject(GameObjectIndex);
        }
        Vector3 cellPosition = Grid.CellToWorld(gridPosition);
        PreviewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));

    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        return !(FurnitureData.CanPlaceObjectAt(gridPosition, Vector2Int.one)
            || FloorData.CanPlaceObjectAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity   =   CheckIfSelectionIsValid(gridPosition);
        PreviewSystem.UpdatePosition(Grid.CellToWorld(gridPosition), validity);
    }

    public void EndState()
    {
        PreviewSystem.StopShowingPreview();
    }
}
