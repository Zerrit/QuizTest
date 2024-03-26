using QuizTest.Cards;
using UnityEngine;

namespace QuizTest.LevelLogic.Model
{
    /// <summary>
    /// Создержит данные модели уровня для их отрисовки.
    /// </summary>
    public interface IReadOnlyLevelModel
    {
        /// <summary>
        /// Id правильной карточки.
        /// </summary>
        public string RightAnswerId { get; }
        
        /// <summary>
        /// Размер уровня.
        /// </summary>
        public Vector2Int Size { get; }
        
        /// <summary>
        /// Массив карточек для отрисовки.
        /// </summary>
        public CardData[] CardVariants { get; }
    }
}