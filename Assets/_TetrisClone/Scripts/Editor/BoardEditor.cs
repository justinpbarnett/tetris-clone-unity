using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Board board = (Board)target;
        if(GUILayout.Button("Redraw Board"))
        {
            board.DrawBoard();
        }
        
        DrawDefaultInspector();
    }
}