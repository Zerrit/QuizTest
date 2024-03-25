using UnityEngine;

namespace QuizTest
{
    [CreateAssetMenu(fileName = "NewCardBundleData", menuName = "Card Bundle Data")]
    public class CardBundleData : ScriptableObject
    {
        [field: SerializeField] public CardData[] Cards { get; private set; }
    }
}