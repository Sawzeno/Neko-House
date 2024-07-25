using UnityEngine;

public class PlacementState : IBuildingState
{
    private int SelectedObjectIndex = -1;
    private readonly int ID;
    private readonly Grid Grid;
    private readonly PreviewSystem PreviewSystem;
    private readonly ObjectDatabaseSO Database;
    private readonly GridData FloorData, FurnitureData;
    private readonly ObjectPlacer ObjectPlacer;
    public PlacementState(int id,
                          Grid grid,
                          PreviewSystem previewSystem,
                          ObjectDatabaseSO database,
                          GridData floorData,
                          GridData furnitureData,
                          ObjectPlacer objectPlacer)
    {
        ID = id;
        Grid = grid;
        PreviewSystem = previewSystem;
        Database = database;
        FloorData = floorData;
        FurnitureData = furnitureData;
        ObjectPlacer = objectPlacer;

        SelectedObjectIndex = Database.objectsData.FindIndex(data => data.ID == id);
        if (SelectedObjectIndex < 0)
        {
            throw new System.Exception($"No Object with ID {id}");
        }
        previewSystem.StartShowingPlacementPreview(Database.objectsData[SelectedObjectIndex].Prefab,
                                                   Database.objectsData[SelectedObjectIndex].Size);
    }
    public void OnAction(Vector3Int gridPosition)
    {
        bool placementValidity = CheckPlacementValidity(gridPosition, SelectedObjectIndex);
        if (placementValidity == false)
        {
            return;
        }

        int index = ObjectPlacer.PlaceObject(Database.objectsData[SelectedObjectIndex].Prefab, Grid.CellToWorld(gridPosition));

        GridData selectedObjectData = Database.objectsData[SelectedObjectIndex].ID == 0 ? FloorData : FurnitureData;
        // only updates the occupied positions in Database 
        selectedObjectData.AddObjectAt(gridPosition,
                                       Database.objectsData[SelectedObjectIndex].Size,
                                       Database.objectsData[SelectedObjectIndex].ID,
                                       index);

        PreviewSystem.UpdatePosition(Grid.CellToWorld(gridPosition), false);
    }
    public void UpdateState(Vector3Int gridPosition)
    {
        bool placementValidity = CheckPlacementValidity(gridPosition, SelectedObjectIndex);
        PreviewSystem.UpdatePosition(Grid.CellToWorld(gridPosition), placementValidity);
    }
    public void EndState()
    {
        PreviewSystem.StopShowingPreview();
        SelectedObjectIndex = -1;
    }
    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedObjectData = Database.objectsData[SelectedObjectIndex].ID == 0 ? FloorData : FurnitureData;

        return selectedObjectData.CanPlaceObjectAt(gridPosition, Database.objectsData[selectedObjectIndex].Size);
    }
}