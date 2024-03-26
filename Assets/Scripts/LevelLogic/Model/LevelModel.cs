using System.Collections.Generic;
using System.Linq;
using QuizTest.Cards;
using UnityEngine;

namespace QuizTest.LevelLogic.Model
{
    public class LevelModel : IReadOnlyLevelModel
    {
        public string RightAnswerId { get; private set; }
        public Vector2Int Size { get; private set; }
        public CardData[] CardVariants { get; private set; }
        
        
        public LevelModel(Vector2Int size, CardBundleData cardBundle)
        {
            Size = size;
            int gridSize = size.x * size.y;
            int bundleSize = cardBundle.Cards.Length;

            CardVariants = new CardData[gridSize];
            List<CardData> tempCards = cardBundle.Cards.ToList();

            for (int i = 0; i < gridSize; i++)
            {
                int randomIndex = Random.Range(0, bundleSize - (1 + i));

                CardVariants[i] = tempCards[randomIndex];
                tempCards.RemoveAt(randomIndex);
            }

            RightAnswerId = CardVariants[Random.Range(0, gridSize - 1)].Id;
        } 
    }
}