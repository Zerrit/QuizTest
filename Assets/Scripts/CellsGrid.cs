using UnityEngine;

namespace QuizTest
{
    public class CellsGrid : MonoBehaviour
    {
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private CellView[] cellViews;

        private float _cellSize = 6f;
        
        private void Start()
        {
            UpdateGrid(new Vector2Int(4,1));
        }

        private void UpdateGrid(Vector2Int size)
        {
            float totalWidth = (size.x - 1) * 6;
            float startXPos = transform.position.x - (totalWidth / 2);
            
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    Instantiate(cellPrefab, new Vector2(startXPos + _cellSize * j, 0), Quaternion.identity);
                }
            }
        }
    }
}
