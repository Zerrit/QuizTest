using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace QuizTest
{
    public class CellsGrid : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private CellView[] cellViews;

        private float _cellSize = 6f; //TODO Добавить получения значения 6

        private CellView _choosenCell;
        private IReadOnlyLevelModel _currentLevelModel;
        
        private ILevelSystem _levelSystem;


        [Inject]
        public void Construct(ILevelSystem levelSystem)
        {
            _levelSystem = levelSystem;
            _levelSystem.OnLevelModelChanged += UpdateLevelModel;
            Debug.LogWarning("Подписка оформлена");
        }

        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (TryGetCellView(eventData, out _choosenCell))
            {
                _levelSystem.TryAnswer(_choosenCell.VariantId);
            }
        }

        private void UpdateLevelModel(IReadOnlyLevelModel newLevelModel)
        {
            Debug.LogWarning("Обновлена сетка");
            _currentLevelModel = newLevelModel;
            RedrowGrid();
        }



        private void RedrowGrid()
        {
            Vector2Int gridSize = _currentLevelModel.Size;
            Debug.LogWarning(gridSize);
            float totalWidth = (gridSize.x - 1) * _cellSize; 
            float totalHeight = (gridSize.y - 1) * _cellSize;  
          
            float startXPos = transform.position.x - (totalWidth / 2);
            float startYPos = transform.position.y + (totalHeight / 2);
            
            for (int i = 0; i < gridSize.y; i++)
            {
                for (int j = 0; j < gridSize.x; j++)
                {
                    int cardIndex = j + gridSize.x * i;
                    Vector2 cellPosition = new Vector2(startXPos + _cellSize * j, startYPos - _cellSize * i);
                    CellView cellView = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
                    cellView.SetCard(_currentLevelModel.CardVariants[cardIndex]);
                }
            }
        }

        private bool TryGetCellView(PointerEventData eventData, out CellView targetCell)
        {
            targetCell = eventData.pointerCurrentRaycast.gameObject.GetComponent<CellView>();
			
            return (targetCell != null);
        }
    }
}
