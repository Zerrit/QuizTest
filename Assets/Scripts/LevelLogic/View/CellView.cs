using System;
using DG.Tweening;
using QuizTest.Cards;
using UnityEngine;

namespace QuizTest.LevelLogic.View
{
    /// <summary>
    /// Отображение ячейки и её содержимого.
    /// </summary>
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private SpriteRenderer cardSprite;

        public string VariantId => _cardData.Id;
        public float CellSize => background.transform.localScale.x;
        
        private CardData _cardData;
        private Tween _cellTween;
        
        
        /// <summary>
        /// Устанавливает в ячейку карточку.
        /// </summary>
        /// <param name="cardData"> Данные установленной карточки.</param>
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

        /// <summary>
        /// Запускает анимацию появления ячейки.
        /// </summary>
        /// <returns> Возвращает данные о твине. </returns>
        public Tween SpawnAnimation()
        {
            _cellTween?.Kill();
            transform.localScale = Vector3.one;
            _cellTween = transform.DOPunchScale(new Vector3(.2f, .2f, 1f), .6f, 3)
                .SetEase(Ease.InBounce);

            return _cellTween;
        }
        
        /// <summary>
        /// Запускает анимацию неправильного выбора.
        /// </summary>
        public void ShowFailAnimation()
        {
            _cellTween?.Kill();
            cardSprite.transform.localPosition = Vector3.zero;
            _cellTween = cardSprite.transform.DOPunchPosition(Vector3.right, .7f).SetEase(Ease.InBounce);
        }

        /// <summary>
        /// Запускает анимацию верного выбора.
        /// </summary>
        /// <param name="endAnimationCallback"> Колбэк онончания анимации</param>
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