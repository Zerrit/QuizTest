using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuizTest
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer cardSprite;

        public string VariantId => _cardData.Id;
        
        private CardData _cardData;

        public void SetCard(CardData cardData)
        {
            _cardData = cardData;
            cardSprite.sprite = _cardData.Icon;
        }
    }
}