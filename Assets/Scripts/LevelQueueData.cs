using UnityEngine;

namespace QuizTest
{
    [CreateAssetMenu(fileName = "NewLevelQueueData", menuName = "Level Queue Data")]
    public class LevelQueueData : ScriptableObject
    {
        [field: SerializeField] public LevelData[] LevelsQueue { get; private set; }
    }
}