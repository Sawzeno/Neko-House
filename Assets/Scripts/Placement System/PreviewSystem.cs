using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    [SerializeField] private float PreviewYOffset = 0.06f;
    [SerializeField] private GameObject CellIndicator;
    private GameObject previewObject;
    [SerializeField] private Material PreviewMaterialPrefab;
    private Renderer CellIndicatorRenderer;
    private Material PreviewMaterialInstance;

    private void Start()
    {
        PreviewMaterialInstance = new Material(PreviewMaterialPrefab);
        CellIndicator.SetActive(false);
        CellIndicatorRenderer = CellIndicator.GetComponentInChildren<Renderer>();
    }
    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        previewObject = Instantiate(prefab);
        PreparePreview(previewObject);
        PrepareCellIndicator(size);
        CellIndicator.SetActive(true);
    }
    public void StartShowingRemovePreview()
    {
        CellIndicator.SetActive(true);
        PrepareCellIndicator(Vector2Int.one);
        ApplyFeedabackToCellIndicator(false);
    }
    public void StopShowingPreview()
    {
        CellIndicator.SetActive(false);
        if(previewObject == null) return;
        Destroy(previewObject);
    }
    private void PrepareCellIndicator(Vector2Int size)
    {
        CellIndicator.transform.localScale = new Vector3(size.x, 1, size.y);
        CellIndicatorRenderer.material.mainTextureScale = size;
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = PreviewMaterialInstance;
            }
            renderer.materials = materials;
        }
    }
    public void UpdatePosition(Vector3 position, bool validity)
    {
        MoveCellIndicator(position);
        ApplyFeedabackToCellIndicator(validity);

        if (previewObject == null) return;

        MovePreview(position);
        ApplyFeedabackToPreview(validity);

    }

    private void ApplyFeedabackToPreview(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;
        PreviewMaterialInstance.color = c;
    }
    private void ApplyFeedabackToCellIndicator(bool validity)
    {
        Color c = validity ? Color.white : Color.red;
        c.a = 0.5f;
        CellIndicatorRenderer.material.color = c;
    }
    private void MoveCellIndicator(Vector3 position)
    {
        CellIndicator.transform.position = position;
    }
    private void MovePreview(Vector3 position)
    {
        previewObject.transform.position = new Vector3(position.x, position.y + PreviewYOffset, position.z);
    }
}
