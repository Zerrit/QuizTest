using QuizTest.LevelLogic.Model;
using QuizTest.LevelLogic.System;
using QuizTest.ObjectPool;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace QuizTest.LevelLogic.View
{
    public class CellsGridView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CellView cellPrefab;
        [SerializeField] private ParticleSystem successFX;

        private float _cellSize = 6f; //TODO Добавить получения значения 6

        private CellView _choosenCell;
        private ObjectPooler<CellView> _cellViewPool;
        private IReadOnlyLevelModel _currentLevelModel;
        private ILevelSystem _levelSystem;


        [Inject]
        public void Construct(ILevelSystem levelSystem)
        {
            _levelSystem = levelSystem;
            _cellViewPool = new ObjectPooler<CellView>(cellPrefab, transform, 9);
            _levelSystem.OnLevelModelChanged += UpdateLevelModel;
        }

        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (TryGetCellView(eventData, out _choosenCell))
            {
                if (_choosenCell.VariantId == _currentLevelModel.RightAnswerId)
                {
                    successFX.transform.position = _choosenCell.transform.position;
                    successFX.Play();
                    _choosenCell.ShowSuссessAnimation(_levelSystem.CompleteLevel);
                }
                else
                    _choosenCell.ShowFailAnimation();
            }
        }
        

        private void UpdateLevelModel(IReadOnlyLevelModel newLevelModel)
        {
            _currentLevelModel = newLevelModel;
            RedrowGrid();
        }

        private void RedrowGrid()
        {
            _cellViewPool.ReleaseAllElements();
            
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
                    
                    CellView cellView = _cellViewPool.GetFreeElement();
                    cellView.transform.SetPositionAndRotation(cellPosition, Quaternion.identity);
                    cellView.SetCard(_currentLevelModel.CardVariants[cardIndex]);
                    cellView.SpawnAnimation();
                }
            }
        }

        private bool TryGetCellView(PointerEventData eventData, out CellView targetCell)
        {
            targetCell = eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<CellView>();

            return (targetCell != null);
        }
    }
}
