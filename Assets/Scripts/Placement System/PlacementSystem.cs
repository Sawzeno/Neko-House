using System;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    #region SERIALIZED 
    [SerializeField] private Grid Grid;
    [SerializeField] private GameObject GridPlane;
    [SerializeField] private ObjectDatabaseSO Database;
    [SerializeField] private InputManager InputManager;
    [SerializeField] private PreviewSystem PreviewSystem;
    [SerializeField] private ObjectPlacer ObjectPlacer;
    #endregion
    private GridData FloorData, FurnitureData;
    private IBuildingState BuildingState;
    private Vector3Int LastDetectedPosition = Vector3Int.zero;
    private void Start()
    {
        StopPlacement();
        FloorData = new GridData();
        FurnitureData = new GridData();
    }

    public void StartPlacement(int id)
    {
        StopPlacement();
        GridPlane.SetActive(true);
        BuildingState = new PlacementState(id,
                                               Grid,
                                               PreviewSystem,
                                               Database,
                                               FloorData,
                                               FurnitureData,
                                               ObjectPlacer);
        InputManager.OnClicked += PlaceStructure;
        InputManager.OnExit += StopPlacement;
    }
    public void StartRemoving(){
        StopPlacement();
        GridPlane.SetActive(true);
        BuildingState = new RemovingState(Grid, PreviewSystem, FloorData, FurnitureData, ObjectPlacer);
        InputManager.OnClicked += PlaceStructure;
        InputManager.OnExit += StopPlacement;
    }
    private void PlaceStructure()
    {
        if (InputManager.IsPointerOverUI())
        {
            return;
        }
        Vector3 mousePosition = InputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = Grid.WorldToCell(mousePosition);
        BuildingState.OnAction(gridPosition);
    }
    private void StopPlacement()
    {
        GridPlane.SetActive(false);
        if(BuildingState == null) return;
        BuildingState.EndState();
        BuildingState = null;
        InputManager.OnClicked -= PlaceStructure;
        InputManager.OnExit -= StopPlacement;
        LastDetectedPosition = Vector3Int.zero;
    }
    private void Update()
    {
        if (BuildingState == null) return;
        //calculate position
        Vector3 mousePosition = InputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = Grid.WorldToCell(mousePosition);

        if (LastDetectedPosition == gridPosition) return;
        //placement state
        BuildingState.UpdateState(gridPosition);
        LastDetectedPosition = gridPosition;
    }
}
