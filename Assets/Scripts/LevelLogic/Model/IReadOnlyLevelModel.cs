using QuizTest.Cards;
using UnityEngine;

namespace QuizTest.LevelLogic.Model
{
    public interface IReadOnlyLevelModel
    {
        public string RightAnswerId { get; }
        public Vector2Int Size { get; }
        public CardData[] CardVariants { get; }
    }
}