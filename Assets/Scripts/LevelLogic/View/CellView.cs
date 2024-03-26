using System;
using DG.Tweening;
using QuizTest.Cards;
using UnityEngine;

namespace QuizTest.LevelLogic.View
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer cardSprite;

        public string VariantId => _cardData.Id;
        
        private CardData _cardData;
        private Tween _cellTween;

        public void SetCard(CardData cardData)
        {
            _cardData = cardData;
            cardSprite.sprite = _cardData.Icon;
            if (_cardData.IsNeedAlign)
            {
                cardSprite.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                cardSprite.transform.rotation = Quaternion.identity;
            }
        }

        
        
        public void SpawnAnimation()
        {
            _cellTween?.Kill();
            transform.localScale = Vector3.one;
            _cellTween = transform.DOPunchScale(new Vector3(.2f,.2f,1f), .7f, 3).SetEase(Ease.InBounce);
        }
        
        public void ShowFailAnimation()
        {
            _cellTween?.Kill();
            cardSprite.transform.localPosition = Vector3.zero;
            _cellTween = cardSprite.transform.DOPunchPosition(Vector3.right, .7f).SetEase(Ease.InBounce);
        }

        public void ShowSuссessAnimation(Action endAnimationCallback)
        {
            _cellTween?.Kill();
            cardSprite.transform.localScale = Vector3.one;
            
            _cellTween = cardSprite.transform
                .DOPunchScale(new Vector3(.3f,.3f,1f), 1f, 3)
                .SetEase(Ease.InBounce)
                .OnComplete(() => endAnimationCallback?.Invoke());
        }
    }
}