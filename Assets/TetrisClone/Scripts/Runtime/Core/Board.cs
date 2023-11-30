using System;
using UnityEngine;

namespace TetrisClone.Runtime.Core
{
    public class Board : MonoBehaviour
    {
        public Action OnBoardDrawn;
        public bool IsBoardDrawn { get; private set; }
    
        [Header("References")]
        [SerializeField] private GameObject cellPrefab;
    
        [Header("Settings")]
        [SerializeField] private int boardHeight = 20;
        [SerializeField] private int boardWidth = 10;

        private GameObject[] _cells;

        private void OnValidate()
        {
            if (IsBoardDrawn || cellPrefab == null) return;
            DrawBoard();
        }
        
        public void DrawBoard()
        {
            RemoveExistingCells();
            CreateNewCells();
            RepositionCamera();
        
            IsBoardDrawn = true;
            OnBoardDrawn?.Invoke();
        }
        
        private void RemoveExistingCells()
        {
            if (_cells?.Length > 0)
            {
                foreach (GameObject cell in _cells) { DestroyImmediate(cell); }
            }
        }
        
        private void CreateNewCells()
        {
            _cells = new GameObject[boardHeight * boardWidth];

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    GameObject cell = Instantiate(cellPrefab, transform);
                    _cells[(i * boardWidth) + j] = cell;
                    cell.transform.localPosition = new Vector3(j, i, 0);
                }
            }
        }
        
        private void RepositionCamera()
        {
            transform.position = new Vector3(-boardWidth / 2f + 0.5f, -boardHeight / 2f + 0.5f, 0);
        }
    }
}
