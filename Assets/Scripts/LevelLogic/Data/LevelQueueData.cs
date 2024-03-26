using UnityEngine;

namespace QuizTest.LevelLogic.Data
{
    [CreateAssetMenu(fileName = "NewLevelQueueData", menuName = "Level Queue Data")]
    public class LevelQueueData : ScriptableObject
    {
        /// <summary>
        /// Очередь из уровней.
        /// </summary>
        [field: SerializeField] public LevelData[] LevelsQueue { get; private set; }
    }
}