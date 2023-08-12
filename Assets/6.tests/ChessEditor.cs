using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MindZero))]
[CanEditMultipleObjects]
public class ChessEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MindZero debug = target as MindZero;
        if (GUILayout.Button("Create Board"))
        {
            if (debug != null) debug.NewGame();
        }
        if(GUILayout.Button("End Game"))
        {
            if (debug != null) debug.EndGame();
        }
    }
}