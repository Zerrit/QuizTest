using System;
using UnityEngine;

namespace QuizTest.LevelLogic.Data
{
    [Serializable]
    public class LevelData
    {
        /// <summary>
        /// Идентификатор уровня.
        /// </summary>
        [field:SerializeField] public string Id { get; private set; }
        /// <summary>
        /// Размер поля на уровне.
        /// </summary>
        [field:SerializeField] public Vector2Int Size { get; private set; }
    }
}