using System;
using UnityEngine;

namespace QuizTest
{
    [Serializable]
    public class CardData
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public Sprite Icon { get; private set; }
    }
}