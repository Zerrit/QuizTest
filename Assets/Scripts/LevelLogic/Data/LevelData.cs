using System;
using UnityEngine;

namespace QuizTest.LevelLogic.Data
{
    [Serializable]
    public class LevelData
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public Vector2Int Size { get; private set; }
    }
}