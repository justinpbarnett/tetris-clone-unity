using TetrisClone.Runtime.Core;
using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;
#endif

namespace TetrisClone.Editor
{
#if UNITY_EDITOR
    [CustomEditor(typeof(Board))]
    public class BoardEditor : UnityEditor.Editor
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
#endif
}