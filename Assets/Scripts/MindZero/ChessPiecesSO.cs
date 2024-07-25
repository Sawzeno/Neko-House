using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChessPiecesSO : ScriptableObject
{
    public List<ChessPieces> Pieces;
}

[Serializable]
public class ChessPieces
{
    [field: SerializeField] public string Name{get; private set;}
    [field: SerializeField] public uint ID{get; private set;}
    [field: SerializeField] public Vector2Int Size{get; private set;} = Vector2Int.one;
    [field: SerializeField] public GameObject Prefab{get; private set;}
}
