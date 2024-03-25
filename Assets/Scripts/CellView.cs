using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuizTest
{
    public class CellView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer cardSprite;

        private CardData _cardData;

        public void SetCard(CardData cardData)
        {
            _cardData = cardData;
            cardSprite.sprite = _cardData.Icon;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.LogWarning("Клик по ячейке");
        }
    }
}