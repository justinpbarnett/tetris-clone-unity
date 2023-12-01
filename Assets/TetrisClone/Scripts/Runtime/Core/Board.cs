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
        [SerializeField] private int boardHeaderHeight = 4;
        [SerializeField] private int boardHeight = 20;
        [SerializeField] private int boardWidth = 10;

        private Transform[,] _cells;

        private void OnValidate()
        {
            if (IsBoardDrawn) return;
            DrawBoard();
        }
        
        public void DrawBoard()
        {
            if (cellPrefab == null)
            {
                Debug.LogError("Cell prefab is null!");
                return;
            }
            
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
                foreach (Transform cell in _cells) { DestroyImmediate(cell.gameObject); }
            }
        }
        
        private void CreateNewCells()
        {
            _cells = new Transform[boardHeight+boardHeaderHeight,boardWidth];

            for (int i = 0; i < boardHeight; i++)
            {
                for (int j = 0; j < boardWidth; j++)
                {
                    Transform cell = Instantiate(cellPrefab, transform).transform;
                    _cells[i,j] = cell.transform;
                    cell.localPosition = new Vector3(j, i, 0);
                }
            }
        }
        
        private void RepositionCamera()
        {
            transform.position = new Vector3(-boardWidth / 2f + 0.5f, -boardHeight / 2f + 0.5f, 0);
        }
    }
}
