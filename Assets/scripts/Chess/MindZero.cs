using System;
using UnityEngine;
public class MindZero : MonoBehaviour
{
    [SerializeField] private GameObject BoardManager, PiecesManager;
    [SerializeField] private Camera PlayCamera;
    private void Start()
    {
        Initialize();
    }
    private void Initialize(){
        BoardManager.GetComponent<BoardManager>().Setup();
        PiecesManager.GetComponent<PiecesManager>().Setup();
        transform.localScale *= 0.5f;
    }
}
