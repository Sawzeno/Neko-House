using System;
using UnityEngine;
using UnityEngine.EventSystems;




public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera PlayCamera;
    [SerializeField] private LayerMask PlacementMask;
    private Vector3 lastPosition;

    public event Action OnClicked, OnExit;

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            OnClicked?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            OnExit?.Invoke();
        }
    }

    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        // so that we cannot render objects that are not selected by the camera
        mousePos.z = PlayCamera.nearClipPlane;
        Ray ray = PlayCamera.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, PlacementMask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
