using UnityEngine;
using Zenject;

namespace QuizTest
{
    public class CellsGrid : MonoBehaviour
    {
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private CellView[] cellViews;

        private float _cellSize = 6f; //TODO Добавить получения значения 6

        private ILevelSystem _levelSystem;
        
        
        [Inject]
        public void Construct(ILevelSystem levelSystem)
        {
            _levelSystem = levelSystem;

            _levelSystem.OnGridModelCreated += RedrowGrid;
        }

        private void RedrowGrid()
        {
            
        }
        

        private void UpdateGrid(Vector2Int size)
        {
            float totalWidth = (size.x - 1) * _cellSize; 
            float totalHeight = (size.y - 1) * _cellSize;  
          
            float startXPos = transform.position.x - (totalWidth / 2);
            float startYPos = transform.position.y + (totalWidth / 2);
            
            for (int i = 0; i < size.y; i++)
            {
                for (int j = 0; j < size.x; j++)
                {
                    Vector2 cellPosition = new Vector2(startXPos + _cellSize * j, startYPos - _cellSize * i);
                    Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                }
            }
        }
    }
}
