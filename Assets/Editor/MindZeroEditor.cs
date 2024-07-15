// using UnityEditor;
// using UnityEditor.Rendering;

// [CustomEditor(typeof(MindZero))]
// public class MindZeroEditor : Editor
// {
//     #region SerailziedProperties
//     SerializedProperty
//      Board,
//      WhiteKing, WhiteQueen, WhiteRook, WhiteBishop,WhiteKnight,WhitePawn,
//      BlackKing,BlackQueen,BlackRook,BlackBishop,BlackKnight,BlackPawn;
//      SerializedProperty PlayCamera;
//     bool CameraUIGroup,BoardUIGroup, PiecesUIGroup = false;
//     #endregion

//     private void OnEnable()
//     {
//         PlayCamera = serializedObject.FindProperty("PlayCamera");
//         Board = serializedObject.FindProperty("Board");
//         WhiteKing = serializedObject.FindProperty("WhiteKing");
//         WhiteQueen = serializedObject.FindProperty("WhiteQueen");
//         WhiteRook = serializedObject.FindProperty("WhiteRook");
//         WhiteBishop = serializedObject.FindProperty("WhiteBishop");
//         WhiteKnight = serializedObject.FindProperty("WhiteKnight");
//         WhitePawn = serializedObject.FindProperty("WhitePawn");
//         BlackKing = serializedObject.FindProperty("BlackKing");
//         BlackQueen = serializedObject.FindProperty("BlackQueen");
//         BlackRook = serializedObject.FindProperty("BlackRook");
//         BlackBishop = serializedObject.FindProperty("BlackBishop");
//         BlackKnight = serializedObject.FindProperty("BlackKnight");
//         BlackPawn = serializedObject.FindProperty("BlackPawn");
//     }
//     public override void OnInspectorGUI()
//     {
//         serializedObject.Update();
//         CameraUIGroup = EditorGUILayout.BeginFoldoutHeaderGroup(CameraUIGroup, "Cameras");
//         if(CameraUIGroup){
//         EditorGUILayout.PropertyField(PlayCamera);
//         }
//         EditorGUILayout.EndFoldoutHeaderGroup();

//         BoardUIGroup = EditorGUILayout.BeginFoldoutHeaderGroup(BoardUIGroup, "Board");
//         if (BoardUIGroup)
//         {
//             EditorGUILayout.PropertyField(Board);
//         }
//         EditorGUILayout.EndFoldoutHeaderGroup();

//         PiecesUIGroup = EditorGUILayout.BeginFoldoutHeaderGroup(PiecesUIGroup, "Pieces");
//         if (PiecesUIGroup)
//         {
//             EditorGUILayout.PropertyField(WhiteKing);
//             EditorGUILayout.PropertyField(WhiteQueen);
//             EditorGUILayout.PropertyField(WhiteRook);
//             EditorGUILayout.PropertyField(WhiteBishop);
//             EditorGUILayout.PropertyField(WhiteKnight);
//             EditorGUILayout.PropertyField(WhitePawn);
//             EditorGUILayout.PropertyField(BlackKing);
//             EditorGUILayout.PropertyField(BlackQueen);
//             EditorGUILayout.PropertyField(BlackRook);
//             EditorGUILayout.PropertyField(BlackBishop);
//             EditorGUILayout.PropertyField(BlackKnight);
//             EditorGUILayout.PropertyField(BlackPawn);
//         }
//         EditorGUILayout.EndFoldoutHeaderGroup();

//         serializedObject.ApplyModifiedProperties();
//     }
// }
